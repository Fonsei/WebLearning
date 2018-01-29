using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLearning.logic
{
    public class UserVerwaltung
    {

        public static bool Register(string nickname, string email, string password, string password2,string Username,DateTime birthday)
        {
            Debug.WriteLine("UserVerwaltung - RegisterUser");
            Debug.Indent();
            bool erfolgreich = false;
            if (nickname == "Fonsei")
                erfolgreich = true;
            Debug.Unindent();
            return erfolgreich;
        }

        public static bool Login(string nickname, string email, string password, string password2, string Username, DateTime birthday)
        {
            Debug.WriteLine("UserVerwaltung - RegisterUser");
            Debug.Indent();
            bool erfolgreich = false;
            if (nickname == "Fonsei")
                erfolgreich = true;
            Debug.Unindent();
            return erfolgreich;
        }
    }
}
