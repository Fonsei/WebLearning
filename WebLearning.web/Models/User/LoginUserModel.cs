using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLearning.web.Models.User
{
    public class LoginUserModel
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Nickname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }
    }
}