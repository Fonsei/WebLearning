using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLearning.web.Models.User
{
    public class RegisterUserModel
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

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort Wiederholen")]
        public string PasswordRepeat { get; set; }

        [Display(Name = "Name")]
        public string Username { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Geburtstag")]
        public DateTime Birthday { get; set; }
    }
}