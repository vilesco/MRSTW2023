using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using AutoCar.Domain.Entities.User;

namespace AutoCar.Domain.Entities.Post
{
    public class PDbModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter car model.")]
        [StringLength(50, ErrorMessage = "Model too long.")]
        public string Model { get; set; }
        public bool Type { get; set; }

        [Required(ErrorMessage = "Please enter car make.")]
        [StringLength(50)]
        public string Make { get; set; }

        [Required(ErrorMessage = "Please enter car year.")]
        public int Year { get; set; }
        public string Color { get; set; }

        [Required(ErrorMessage = "Please enter engine capacity.")]
        public int EngineCapacity { get; set; }

        [Required(ErrorMessage = "Please enter millage.")]
        public int Millage { get; set; }

        [Required(ErrorMessage = "Please select fuel type.")]
        public bool Fuel { get; set; }
        public bool ABS { get; set; }
        public bool AC { get; set; }
        public bool CruiseControl { get; set; }
        public bool KeylessEntry { get; set; } 
        public bool AirBags { get; set; } 
        public bool PowerWindows { get; set; }

        [Required(ErrorMessage = "Please enter the price.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please enter location.")]
        public string Location { get; set; } 
        public string Comment { get; set; } 
        public byte[] Image { get; set; } 
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
