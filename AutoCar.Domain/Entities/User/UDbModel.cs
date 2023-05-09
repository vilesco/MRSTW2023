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

        [Required(ErrorMessage ="Please enter your full name.")]
        [StringLength(50, ErrorMessage ="Full name too long.")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Please enter an email.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email too long.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage ="Password too long.")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please enter a username.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage ="Username too long.")]
        public string UserName { get; set; }
        public string RegisterIP { get; set; }

        [Required(ErrorMessage ="Please agree to all terms and conditions.")]
        public bool Terms { get; set; }

        [DataType(DataType.Date)]
        public DateTime LoginDateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisterDateTime { get; set; }
        
        [Required]
        public URole AccessLevel { get; set; }
        public string PhoneNumber { get; set; }
    }
}
