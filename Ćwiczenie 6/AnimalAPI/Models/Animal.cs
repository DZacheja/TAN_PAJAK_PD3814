using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalAPI.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Category { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Area { get; set; }
    }
}
