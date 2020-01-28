using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEUX_HASARD
{
    public class Compte
    {

        private string _pseudo;
        private string email;
        private int id;
        private string nom;
        private string prenom;
        private int age;
        private string statut;


        public Compte(string Pseudo, string Email, int Id, string Nom, string Prenom, int Age, string Statut)
        {
            this._pseudo = Pseudo;
            this.email = Email;
            this.id = Id;
            this.nom = Nom;
            this.prenom = Prenom;
            this.age = Age;
            this.statut = Statut;
        }


        public Compte()
        {

        }

        public string Pseudo { get => _pseudo; set => _pseudo = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int Age { get => age; set => age = value; }
        public string Statut { get => statut; set => statut = value; }

        public void SetPseudo(string value) => Pseudo = value;
        public void SetEmail(string value) => Email = value;
        public void SetID(int value) => Id = value;
        public void SetNom(string value) => Nom = value;
        public void SetPrenom(string value) => Prenom = value;
        public void SetAge(int value) => Age = value;
        public void SetStatut(string value) => Statut = value;





        // ajouter un compte
        public int AddCompte(string path, Compte C)
        {

            try
            {

                List<Compte> Comptes = new List<Compte>();
                if (new FileInfo(path).Length > 0)
                {
                    string json;
                    using (StreamReader r = new StreamReader(path))
                    {
                        json = r.ReadToEnd();
                        Comptes = JsonConvert.DeserializeObject<List<Compte>>(json);
                    }
                    int indexDe = Compte.SearchCompte(Comptes, C);
                    if (indexDe < 0)
                    {
                        C.id = lastID(path);
                        Comptes.Add(C);
                        System.IO.File.WriteAllText(path, string.Empty);
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    Comptes.Add(C);
                }

                String JSONresultC = JsonConvert.SerializeObject(Comptes);

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(JSONresultC.ToString());
                    tw.Close();
                }
                return 1;
            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : " + e);
                return 0;
            }
        }


        // supprimer un compte est appeler la fonction qui modifie les IDs apres la suppression.
        public static int DeleteCompte(string path, Compte C)
        {
            List<Compte> Comptes = new List<Compte>();
            if (new FileInfo(path).Length > 0)
            {
                string json;
                using (StreamReader r = new StreamReader(path))
                {
                    json = r.ReadToEnd();
                    Comptes = JsonConvert.DeserializeObject<List<Compte>>(json);
                }

                int indexDe = Compte.SearchCompte(Comptes, C);
                Console.WriteLine(indexDe);
                if (indexDe >= 0)
                {
                    Comptes.RemoveAt(indexDe);
                    Comptes = Compte.modifierID(Comptes);
                    System.IO.File.WriteAllText(path, string.Empty);
                    String JSONresultC = JsonConvert.SerializeObject(Comptes);

                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine(JSONresultC.ToString());
                        tw.Close();
                    }
                    return 1;
                }
                else { return 0; }

            }
            else
            {
                return 0;
            }

        }
        public static int ModifierCompte(string path, Compte C)
        {

            try
            {

                List<Compte> Comptes = new List<Compte>();
                if (new FileInfo(path).Length > 0)
                {
                    string json;
                    using (StreamReader r = new StreamReader(path))
                    {
                        json = r.ReadToEnd();
                        Comptes = JsonConvert.DeserializeObject<List<Compte>>(json);
                    }
                    int indexDe = Compte.SearchCompte(Comptes, C);
                    if (indexDe < 0)
                    {
                        Comptes.Add(C);
                        Comptes[indexDe].id = C.id;
                        Comptes[indexDe]._pseudo.Equals(C._pseudo);
                        Comptes[indexDe].nom = C.nom;
                        Comptes[indexDe].email = C.email;
                        System.IO.File.WriteAllText(path, string.Empty);
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    Comptes.Add(C);
                }

                String JSONresultC = JsonConvert.SerializeObject(Comptes);

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(JSONresultC.ToString());
                    tw.Close();
                }
                return 1;
            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : " + e);
                return 0;
            }
        }


        //Rechecher si le compte exist deja dans le fichier Json
        public static int SearchCompte(List<Compte> Comptes, Compte C)
        {

            Comptes.IndexOf(C);
            int i = -1;
            foreach (Compte CS in Comptes)
            {
                i++;
                if (CS.nom.Equals(C.nom) && CS.email.Equals(C.email) && CS.prenom.Equals(C.prenom))
                {
                    return i;
                }
            }
            return -1;

        }

        // cette fonction renvoi la liste des comptes que j'appel par la suite dans dans la fonction ajouter "ticket" pour modifier le statut du compte. 
        public static List<Compte> ListeComptes()
        {

            List<Compte> Comptes = new List<Compte>();
            string json;
            using (StreamReader r = new StreamReader(@"C:\Users\USER\Desktop\HamzaBen\compte.json"))
            {
                json = r.ReadToEnd();
                Comptes = JsonConvert.DeserializeObject<List<Compte>>(json);
            }
            return Comptes;
        }

        // cette fonction permet de retourner le dernier ID.compte dans le fichier Json 

        public int lastID(string path)
        {
            try
            {
                List<Compte> Comptes = new List<Compte>();
                Comptes = Compte.ListeComptes();
                Compte Last = new Compte();
                Last = Comptes[Comptes.Count - 1];

                return Last.id + 1;

            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : " + e);
                return -1;
            }

        }

        // cette fonction modifie les IDs apres les la suppression d'un compte
        public static List<Compte>  modifierID(List<Compte> Comptes)
        {

            int i = 0;

            foreach (Compte Cs in Comptes)
            {
                i++;
                Cs.id = i;
            }
            return Comptes;

        }

    }
}