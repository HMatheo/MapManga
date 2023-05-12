using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    [DataContract]
    public class Personne
    {
        [DataMember]
        public string MotDePasse { get;  set; }
        [DataMember]
        public string Email { get;  set; }
        [DataMember]
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
