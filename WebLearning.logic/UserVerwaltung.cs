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

        public static bool Register(string nickname, string email, string password, string password2,string username,DateTime birthday)
        {
            Debug.WriteLine("UserVerwaltung - Register");
            Debug.Indent();
            bool erfolgreich = false;

            try
            {
                if (password != password2)
                    return erfolgreich;

                password = PasswordHash(password);

                using (var context = new WebLearningEntities())
                {
                    List<Benutzer> AlleBenutzer = context.AlleBenutzer.Where(x => x.Email == email).ToList();

                    if(AlleBenutzer.Count == 0)
                    {
                        Benutzer newUser = new Benutzer()
                        {
                            Nickname = nickname,
                            Email = email,
                            Passwort = password,
                            Username = username,
                            Geburtstag = birthday

                        };

                        context.AlleBenutzer.Add(newUser);
                        int zeilen = context.SaveChanges();
                        erfolgreich = zeilen > 0;
                        Debug.WriteLine(zeilen + " Benutzer erfolgreich Gespeichert");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in Register");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }
            

            Debug.Unindent();
            return erfolgreich;
        }

        public static bool Login(string nickname, string email, string password)
        {
            Debug.WriteLine("UserVerwaltung - RegisterUser");
            Debug.Indent();
            bool erfolgreich = false;

            if (password == "" || password == null)
                return erfolgreich;

            try
            {
                password = PasswordHash(password);
                using (var context = new WebLearningEntities())
                {
                    Benutzer AktBenutzer = context.AlleBenutzer.Where(x => x.Email == email).FirstOrDefault();

                    if(AktBenutzer != null)
                    {
                        Debug.WriteLine("Benutzer Gefunden");
                        if(AktBenutzer.Passwort == password)
                        {
                            AktBenutzer.LastLogin = DateTime.Now;
                            int anzahl = context.SaveChanges();
                            erfolgreich = anzahl > 0;
                            return erfolgreich;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in Login");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return erfolgreich;
        }

        public static Benutzer AktUser(string email)
        {
            Debug.WriteLine("UserVerwaltung - RegisterUser");
            Debug.Indent();
            Benutzer user = new Benutzer();
            if (email == "fonsei1988@msn.com")
            {
                user = new Benutzer();
                user.Nickname = "Fonsei";
                user.Email = email;
                user.ID = 1;

            }
            Debug.Unindent();
            return user;
        }

        public static string PasswordHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
