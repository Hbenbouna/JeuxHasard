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
            try
            {
                if (ValidTicket(T))
                {
                    List<Ticket> Tickets = new List<Ticket>();
                    if (new FileInfo(path).Length > 0)
                    {
                        string json;
                        using (StreamReader r = new StreamReader(path))
                        {
                            json = r.ReadToEnd();
                            Tickets = JsonConvert.DeserializeObject<List<Ticket>>(json);
                        }
                        int indexDe = SearchTicket(Tickets, T);
                        if (indexDe < 0)
                        {

                            T.id = lastID(path);
                            Tickets.Add(T);
                            System.IO.File.WriteAllText(path, string.Empty);

                        }
                        else
                        {
                            return -2;
                        }
                    }
                    else
                    {
                        T.id = 1;
                        Tickets.Add(T);
                    }

                    ModifierStatut(T, ChoixStatut(Tickets, T));

                    String JSONresultC = JsonConvert.SerializeObject(Tickets);

                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine(JSONresultC.ToString());
                        tw.Close();
                    }
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : " + e);
                return 0;
            }
        }

        // supprimer un ticket est appeler la fonction qui modifie les IDs apres la suppression.

        public int DeleteTicket(string path, Ticket T)
        {
            List<Ticket> Tickets = new List<Ticket>();
            if (new FileInfo(path).Length > 0)
            {
                string json;
                using (StreamReader r = new StreamReader(path))
                {
                    json = r.ReadToEnd();
                    Tickets = JsonConvert.DeserializeObject<List<Ticket>>(json);
                }

                int indexDe = SearchTicket(Tickets, T);
                Console.WriteLine(indexDe);
                if (indexDe >= 0)
                {
                    Tickets.RemoveAt(indexDe);
                    Tickets = modifierID(Tickets);
                    System.IO.File.WriteAllText(path, string.Empty);
                    String JSONresultC = JsonConvert.SerializeObject(Tickets);

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

        // cette fonction retourn la position du ticket dans la liste 

        public int SearchTicket(List<Ticket> Tickets, Ticket T)
        {

            int i = -1;
            foreach (Ticket Ts in Tickets)
            {
                i++;
                if (Ts.numero == T.numero && Ts._idCompte == T._idCompte)
                {
                    return i;
                }
            }
            return -1;

        }

        //cette fonction permet de valider la forme d'un ticket

        public static Boolean ValidTicket(Ticket T)
        {

            Regex rx = new Regex(@"\b[0-9]{10}(4)[0-9]{10}\b",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(T.numero);
            if (matches.Count == 1)
            {
                return true;
            }
            return false;

        }

        // cette fonction retourn le statut qui correspond au nombre des tickets  d'un compte

        public string ChoixStatut(List<Ticket> Tickets, Ticket T)
        {
            int i = 1;
            foreach (Ticket Ts in Tickets)
            {
                if (Ts._idCompte == T._idCompte)
                {
                    i++;
                }
            }
            if (i <= 5) { return "Soldat"; } else if (i > 5 && i <= 10) { return "Lieutenant"; } else if (i > 10 && i <= 15) { return "Capitaine"; } else if (i > 15 && i <= 20) { return "Colonel"; } else { return "General"; }

        }

        public void ModifierStatut(Ticket T, string statut)
        {
            try
            {
                var path = @"C:\Users\Hamza BENBOUNA\Desktop\intech\Jeux hasard\compte.json";
                Compte C = new Compte();
                List<Compte> Comptes = new List<Compte>();
                Comptes = Compte.ListeComptes();
                foreach (Compte Cs in Comptes)
                {
                    if (Cs.Id == T._idCompte)
                    {
                        Cs.SetStatut(statut);
                    }
                }
                System.IO.File.WriteAllText(path, string.Empty);
                String JSONresultC = JsonConvert.SerializeObject(Comptes);

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(JSONresultC.ToString());
                    tw.Close();
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : " + e);
            }

        }

        // cette fonction permet de retourner le dernier ID.ticket dans le fichier Json 

        public int lastID(string path)
        {
            try
            {
                List<Ticket> Tickets = new List<Ticket>();
                string json;
                using (StreamReader r = new StreamReader(path))
                {
                    json = r.ReadToEnd();
                    Tickets = JsonConvert.DeserializeObject<List<Ticket>>(json);
                }
                Ticket Last = new Ticket();
                Last = Tickets[Tickets.Count - 1];

                return Last.id + 1;


            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : " + e);
                return -1;
            }

        }

        // Modifier les IDs des tickets apres une suppression 

        public List<Ticket> modifierID(List<Ticket> Tickets)
        {

            int i = 0;

            foreach (Ticket Ts in Tickets)
            {
                i++;
                Ts.id = i;
            }
            return Tickets;

        }




    }


}