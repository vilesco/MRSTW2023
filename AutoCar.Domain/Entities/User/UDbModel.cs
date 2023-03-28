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
        public string Email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string UserName { get; set; }
        public string RegisterIP { get; set; }
        [Required]
        public bool Terms { get; set; }
        public DateTime LoginDateTime { get; set; }
        public DateTime RegisterDateTime { get; set; }
        [Required]
        public URole AccessLevel { get; set; }

    }
}
