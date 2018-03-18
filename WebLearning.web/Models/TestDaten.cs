using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLearning.logic;
using WebLearning.web.Models.Tasks;
using WebLearning.web.Models.User;

namespace WebLearning.web.Models
{
    public class TestDaten
    {
        public static DashboardModel LadeDaten(DashboardModel model ,string email)
        {
            //model.Fach = new List<Subject>();
            //model.Fach.Add(Subject.NewSubject("Mathematik", new List<string>() { "Modul 1", "Modul 2" }));

            UserVerwaltung.CurrentUser(email);



            return model;
        }
    }
}