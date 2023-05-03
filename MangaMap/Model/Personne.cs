using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    public class Personne
    {
        public string MotDePasse { get;  set; }
        public string Email { get;  set; }
        public string Pseudo { get;  set; }

        public bool MofifierMotDePasse(string MotDePasse)
        {
            string test = "";
            test = Console.ReadLine();

            if (test == this.MotDePasse)
            {
                this.MotDePasse = MotDePasse.Trim();
                return true;
            }

            return false;
        }

        public bool MofifierEmail(string Email)
        {
            string test = "";
            test = Console.ReadLine();

            if (test == this.MotDePasse)
            {
                this.Email = Email.Trim();
                return true;
            }

            return false;
        }

        public bool MofifierPseudo(string Pseudo)
        {
            string test = "";
            test = Console.ReadLine();

            if (test == this.MotDePasse)
            {
                this.Pseudo = Pseudo.Trim();
                return true;
            }

            return false;
        }
    }
}
