using AutoCar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.Domain.Entities.User
{
    public class UDbModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email cannot ...")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password!")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9]{8,15})$", ErrorMessage = "Password must contain: " +
            "Minimum 8 characters atleast 1 UpperCase Alphabet, " +
            "1 LowerCase      Alphabet and 1 Number")]
        public string Password { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string UserName { get; set; }
        public string RegisterIP { get; set; }

        [Required]
        public bool Terms { get; set; }

        [DataType(DataType.Date)]
        public DateTime LoginDateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisterDateTime { get; set; }
        
        [Required]
        public URole AccessLevel { get; set; }

    }
}
