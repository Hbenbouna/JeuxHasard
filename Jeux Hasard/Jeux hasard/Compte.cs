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
            throw new NotImplementedException();
        }


        // supprimer un compte est appeler la fonction qui modifie les IDs apres la suppression.
        public static int DeleteCompte(string path, Compte C)
        {
            throw new NotImplementedException();
        }
        public static int ModifierCompte(string path, Compte C)
        {
            throw new NotImplementedException();
        }


        //Rechecher si le compte exist deja dans le fichier Json
        public static int SearchCompte(List<Compte> Comptes, Compte C)
        {

            throw new NotImplementedException();

        }

        // cette fonction renvoi la liste des comptes que j'appel par la suite dans dans la fonction ajouter "ticket" pour modifier le statut du compte. 
        public static List<Compte> ListeComptes()
        {

            throw new NotImplementedException();
        }

        // cette fonction permet de retourner le dernier ID.compte dans le fichier Json 

        public int lastID(string path)
        {
            throw new NotImplementedException();

        }

        // cette fonction modifie les IDs apres les la suppression d'un compte
        public static List<Compte>  modifierID(List<Compte> Comptes)
        {

            throw new NotImplementedException();

        }

    }
}