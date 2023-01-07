using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Models
{
    public class NewProduct
    {
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Wartość nie może być pusta.")]
        public int IdProduct { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Wartość nie może być pusta.")]
        public int IdWarehouse { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Liczba musi być większa od 0")]
        public int Amount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
