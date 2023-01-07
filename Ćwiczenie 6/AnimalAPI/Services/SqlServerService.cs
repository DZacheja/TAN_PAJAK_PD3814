using AnimalAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalAPI.Services
{
    public interface IDbService
    {
        public Task<IEnumerable<Animal>> GetAnimals();
        public Task<Animal> GetAnimal(int id);
        public Task<Animal> CreateAnimal(Animal animal);
        public Task<Animal> UpdateAnimal(Animal animal, int id);
        public Task<int> DeleteAnimal(int id);
    }
    public class SqlServerService : IDbService
    {
        private readonly string _connectionString;
        public SqlServerService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AnimalsPAJAK");
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            var res = new List<Animal>();
            using (var con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Animal;";
                con.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (dr.Read())
                {
                    res.Add(new Animal
                    {
                        IdAnimal = Convert.ToInt16(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    });
                }
                cmd.Dispose();
            }
            return res;
        }

        public async Task<Animal> GetAnimal(int id)
        {
            Animal res = null;
            using (var con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Animal WHERE IdAnimal=@AnimalID;";
                cmd.Parameters.AddWithValue("@AnimalID", id);
                con.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (dr.Read())
                {
                    res = new Animal()
                    {
                        IdAnimal = Convert.ToInt16(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    };
                }
                cmd.Dispose();
            }
            return res;
        }

        public async Task<Animal> CreateAnimal(Animal animal)
        {
            Animal res = null;
            using (var con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"INSERT INTO Animal(Name, Description, Category, Area) " +
                    @"Values(@Name, @Description, @Category, @Area);";

                cmd.Parameters.AddWithValue("@Name", animal.Name);
                cmd.Parameters.AddWithValue("@Description", animal.Description);
                cmd.Parameters.AddWithValue("@Category", animal.Category);
                cmd.Parameters.AddWithValue("@Area", animal.Area);
                con.Open();
                var cntInserted = await cmd.ExecuteNonQueryAsync();
                if (cntInserted == 1)
                {
                    cmd.CommandText = "SELECT * FROM Animal WHERE Name=@Name AND Description=@Description AND Category=@Category AND Area=@Area";
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        res = new Animal()
                        {
                            IdAnimal = Convert.ToInt16(dr["IdAnimal"].ToString()),
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            Category = dr["Category"].ToString(),
                            Area = dr["Area"].ToString()
                        };
                    }
                }
                cmd.Dispose();
            }
            return res;
        }

        public async Task<Animal> UpdateAnimal(Animal animal, int id)
        {
            Animal res = null;
            using (var con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"UPDATE Animal " + 
                    @"SET Name=@Name, Description=@Description, Category=@Category, Area=@Area " +
                    @"WHERE IdAnimal=@AnimalID";

                cmd.Parameters.AddWithValue("@Name", animal.Name);
                cmd.Parameters.AddWithValue("@Description", animal.Description);
                cmd.Parameters.AddWithValue("@Category", animal.Category);
                cmd.Parameters.AddWithValue("@Area", animal.Area);
                cmd.Parameters.AddWithValue("@AnimalID", id);

                con.Open();
                var cntInserted = await cmd.ExecuteNonQueryAsync();
                if (cntInserted == 1)
                {
                    res = await GetAnimal(id);
                }
                cmd.Dispose();
            }
            return res;
        }

        public async Task<int> DeleteAnimal(int id)
        {
            int res = 0;
            using (var con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal=@AnimalID;";
                cmd.Parameters.AddWithValue("@AnimalID", id);
                con.Open();
                res = await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
            }
            return res;
        }
    }
}
