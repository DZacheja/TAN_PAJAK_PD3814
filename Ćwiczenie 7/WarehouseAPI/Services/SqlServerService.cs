using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Models;

namespace WarehouseAPI.Services
{
    public interface IDatabaseService
    {
        public Task<int> RegisterNewProduct(Models.NewProduct product);
        public Task<Product> GetProductById(int id);
        public Task<int> GetProductFromWarehouse(int orderId, int productId);
    }
    public class SqlServerService : IDatabaseService

    {
        private readonly string CONNECTION_STRING;
        public SqlServerService(IConfiguration configuration)
        {
            CONNECTION_STRING = configuration.GetConnectionString("WarehousPAJAK");
        }

        public async Task<Product> GetProductById(int id)
        {
            Product result = null;
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM Product WHERE IdProduct = @ProductID;";
                cmd.Parameters.AddWithValue("@ProductID", id);

                using (var dataReader = await cmd.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        result = new Product()
                        {
                            IdProduct = Convert.ToInt16(dataReader["IdProduct"].ToString()),
                            Name = dataReader["Name"].ToString(),
                            Description = dataReader["Description"].ToString(),
                            Price = Convert.ToDecimal(dataReader["Price"].ToString())
                        };
                    }
                }

            }
            return result;
        }

        public async Task<int> GetProductFromWarehouse(int orderId, int productId)
        {
            int result = 0;
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT IdProductWarehouse FROM Product_Warehouse WHERE IdOrder = @OrderId AND IdProduct = @ProductId;";
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                using (var dataReader = await cmd.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt16(dataReader["IdProductWarehouse"].ToString());
                    }
                }

            }
            return result;
        }

        public async Task<int> RegisterNewProduct(NewProduct newProduct)
        {
            int createdID = 0;
            using (var con = new SqlConnection(CONNECTION_STRING))
            {
                int itemExist;
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                Product product = await GetProductById(newProduct.IdProduct);

                if (product == null)
                {
                    cmd.Dispose();
                    throw new NotFoundException("Produkt o podanym ID nie istnieje w bazie!");
                }

                DbTransaction tran = con.BeginTransaction();
                cmd.Transaction = (SqlTransaction)tran;

                cmd.Parameters.AddWithValue("@ProductId", newProduct.IdProduct);
                cmd.Parameters.AddWithValue("@WarehouseID", newProduct.IdWarehouse);
                cmd.Parameters.AddWithValue("@AmountCount", newProduct.Amount);
                cmd.Parameters.AddWithValue("@regDate", newProduct.CreatedAt);
                cmd.Parameters.AddWithValue("@now", DateTime.Now);

                cmd.CommandText = "SELECT COUNT(*) FROM Warehouse WHERE IdWarehouse=@WarehouseID";
                itemExist = (int)await cmd.ExecuteScalarAsync();
                if (itemExist != 1)
                {
                    await tran.RollbackAsync();
                    cmd.Dispose();
                    throw new NotFoundException("Magazyn o podanym ID nie istnieje w bazie!");
                }
                
                cmd.CommandText = "SELECT COUNT(*) FROM [Order] WHERE IdProduct=@ProductId AND Amount=@AmountCount AND CreatedAt<@regDate;";


                itemExist = (int)await cmd.ExecuteScalarAsync();
                if (itemExist != 1)
                {
                    await tran.RollbackAsync();
                    cmd.Dispose();
                    throw new NotFoundException("Nie istnieje zlecenia na ten typ produktu i taką ilość");
                }

                cmd.CommandText = "SELECT * FROM [Order] WHERE IdProduct=@ProductId AND Amount=@AmountCount AND CreatedAt<@regDate;";
                Order order = null;
                using (var dataReader = await cmd.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        order = new Order()
                        {
                            IdOrder = Convert.ToInt16(dataReader["IdOrder"].ToString()),
                            IdProduct = Convert.ToInt16(dataReader["IdProduct"].ToString()),
                            Amount = Convert.ToInt16(dataReader["Amount"].ToString()),
                            CreatedAt = DateTime.Parse(dataReader["CreatedAt"].ToString()),
                        };
                    }
                }

                cmd.CommandText = "SELECT COUNT(*) FROM Product_Warehouse WHERE IdOrder=@OrderID";
                cmd.Parameters.AddWithValue("@OrderID", order.IdOrder);

                itemExist = (int)await cmd.ExecuteScalarAsync();
                if (itemExist != 0)
                {
                    await tran.RollbackAsync();
                    cmd.Dispose();
                    throw new Exception("Zamówienie zostało już zrealizowane!");
                }

                cmd.CommandText = "UPDATE [Order] SET FulfilledAt=@now";
                string erMessage = "";
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                } catch (Exception)
                {
                    await tran.RollbackAsync();
                    erMessage = "Błąd podczas aktualizacji czasu realizacji zamówienia w tabeli Order.";
                }

                if (!string.IsNullOrEmpty(erMessage))
                {
                    throw new Exception(erMessage);
                }

                cmd.CommandText = "INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
                                    "VALUES(@WarehouseID, @ProductId, @OrderID, @AmountCount, @Price, @now)";
                Decimal price = newProduct.Amount * product.Price;
                cmd.Parameters.AddWithValue("@Price", price);

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                } catch (Exception)
                {
                    await tran.RollbackAsync();
                    erMessage = "Błąd podczas dodawnia produktu do magazynu";
                }

                if (!string.IsNullOrEmpty(erMessage))
                {
                    throw new Exception(erMessage);
                }
                await tran.CommitAsync();


                createdID = await GetProductFromWarehouse(order.IdOrder, product.IdProduct);

                return createdID;
            }

        }
    }
}
