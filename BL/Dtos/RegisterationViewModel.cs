using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
   public class RegisterViewodel
    {

        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string ? PhoneNumber { get; set; }
        [MinLength(3)]
        public string ? Country { get; set; }
        public string ? RoleName { get; set; }
        public string? Image { get; set; }

    }
}
