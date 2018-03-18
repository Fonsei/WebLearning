using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebLearning.web.Models.Tasks;

namespace WebLearning.web.Models.Interface
{
    public class CreateSubjectModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Fach")]
        public string Fach { get; set; }

        [Required]
        [Display(Name = "Modul")]
        public string Modul { get; set; }
    }
}