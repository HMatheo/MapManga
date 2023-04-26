using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    class Personne
    {
        public string MotDePasse { get; private set; }
        public string Email { get; private set; }
        public string Pseudo { get; private set; }

        /*public Liste[] Listes { get; private set; }*/

        public Personne(string mdp, string email, string pseudo)
        {
            Email = email;
            Pseudo = pseudo;
            MotDePasse = mdp;
        }

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
