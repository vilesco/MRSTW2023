using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Models
{
    public class PostData
    {
        public const string errMsg = "Too long input.";
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter car model.")]
        [StringLength(50, ErrorMessage = errMsg)]
        public string Model { get; set; }
        [Required(ErrorMessage = "Please enter car type.")]
        [StringLength(50, ErrorMessage = errMsg)]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please enter car make.")]
        [StringLength(50, ErrorMessage = errMsg)]
        public string Make { get; set; }
        [Required(ErrorMessage = "Please enter car year.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter car transmission.")]
        [StringLength(50, ErrorMessage = errMsg)]
        public string Transmission { get; set; }
        [Required(ErrorMessage = "Please enter car color.")]
        [StringLength(50, ErrorMessage = errMsg)]
        public string Color { get; set; }
        [Required(ErrorMessage = "Please enter car engine capacity (cc).")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid engine capacity.")]
        public int EngineCapacity { get; set; }
        [Required(ErrorMessage = "Please enter car millage.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid Millage.")]
        public int Millage { get; set; }
        [Required(ErrorMessage = "Please enter car fuel type.")]
        [StringLength(50, ErrorMessage = errMsg)]
        public string Fuel { get; set; }
        public bool ABS { get; set; }
        public bool AC { get; set; }
        public bool CruiseControl { get; set; }
        public bool KeylessEntry { get; set; }
        public bool AirBags { get; set; }
        public bool PowerWindows { get; set; }
        [Required(ErrorMessage = "Please enter car price.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid price.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please enter car location.")]
        [StringLength(50, ErrorMessage = errMsg)]
        public string Location { get; set; }
        public string Comment { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateAdded { get; set; }
        public string Author { get; set; }
        public string AuthorPhoneNumber { get; set; }
    }
}