using JEUX_HASARD;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace JEUX_HASARD
{
    public class Ticket
    {



        private int id;
        private string numero;
        private int _idCompte;

        public Ticket(int id, string numero, int _idCompte)
        {
            this.id = id;
            this.numero = numero;
            this._idCompte = _idCompte;
        }

        public Ticket()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Numero { get => numero; set => numero = value; }
        public int IdCompte { get => _idCompte; set => _idCompte = value; }

        public void SetId(int value) => id = value;
        public void SetIDCompte(int value) => _idCompte = value;
        public void SetNumero(string value) => numero = value;




        public int AddTicket(string path, Ticket T)
        {
            throw new NotImplementedException();
        }

        // supprimer un ticket est appeler la fonction qui modifie les IDs apres la suppression.

        public int DeleteTicket(string path, Ticket T)
        {
            throw new NotImplementedException();
        }

        // cette fonction retourn la position du ticket dans la liste 

        public int SearchTicket(List<Ticket> Tickets, Ticket T)
        {

            throw new NotImplementedException();

        }

        //cette fonction permet de valider la forme d'un ticket

        public static Boolean ValidTicket(Ticket T)
        {

            throw new NotImplementedException();

        }

        // cette fonction retourn le statut qui correspond au nombre des tickets  d'un compte

        public string ChoixStatut(List<Ticket> Tickets, Ticket T)
        {
            throw new NotImplementedException();
        }

        public void ModifierStatut(Ticket T, string statut)
        {
            throw new NotImplementedException();

        }

        // cette fonction permet de retourner le dernier ID.ticket dans le fichier Json 

        public int lastID(string path)
        {
            throw new NotImplementedException();

        }

        // Modifier les IDs des tickets apres une suppression 

        public List<Ticket> modifierID(List<Ticket> Tickets)
        {

            throw new NotImplementedException();

        }

        public static List<Ticket> ListeTicket()
        {
            throw new NotImplementedException();
        }




    }


}