using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebLearning.web.Models.Tasks
{
    public class Modul
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }


        public static List<Modul> NewModul(List<string> name)
        {
            Debug.WriteLine("Modul - NewModul");
            Debug.Indent();

            List<Modul> modullist = new List<Modul>();
            foreach (var modulname in name)
            {
                Modul modul = new Modul();
                modul.Name = modulname;
                modullist.Add(modul);
            }
            Debug.Unindent();
            return modullist;
        }
    }
}