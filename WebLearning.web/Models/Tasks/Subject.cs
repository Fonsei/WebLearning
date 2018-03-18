using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebLearning.web.Models.Tasks
{
    public class Subject
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Modul> ModulName { get; set; }

        public Subject()
        {

        }

        public static Subject NewSubject(string SubjectName, List<string> ModulName)
        {
            Debug.WriteLine("Subject - NewSubject");
            Debug.Indent();

            List<Modul> modul = Modul.NewModul(ModulName);
            Subject fach = new Subject();
            fach.Name = SubjectName;
            fach.ModulName = modul;

            Debug.Unindent();
            return fach;
        }
    }
}