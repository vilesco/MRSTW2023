using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.Domain.Entities.User
{
    public class UChangePasswordData
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the new password.")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password too short.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Please confirm the new password.")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password too short.")]
        public string ConfirmedPassword { get; set; }
    }
}
