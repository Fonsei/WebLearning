using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLearning.web.Models.Tasks;

namespace WebLearning.web.Models.User
{
    public class DashboardModel
    {

        public int IDUser { get; set; }

        public string Nickname { get; set; }

        public int Aktuelles { get; set; }

        public int Community { get; set; }

        public int Message { get; set; }

        public List<Subject> Fach { get; set; }





    }

}