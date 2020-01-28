
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JEUX_HASARD
{
    class Program
    {
        static void Main(string[] args)
        {


            string con = Directory.GetCurrentDirectory();
            string t = "bin";
            string dossTicket = "ticket.json";
            string dossCompte = "Compte.json";
            string cheminTicket = con.Substring(0, con.IndexOf(t)) + dossTicket;
            string cheminCompte = con.Substring(0, con.IndexOf(t)) + dossCompte;
            int repeter = 1;
            while (repeter == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("1 : Ce connecter");
                Console.WriteLine("2 : S'inscrire");
                Console.WriteLine("3 : Quitter");
                int menu = int.Parse(Console.ReadLine());

                Compte C = new Compte();
                switch (menu)
                {

                    case 1:
                        List<Compte> Comptes = Compte.ListeComptes();

                        Console.WriteLine("");
                        Console.WriteLine("Entrer votre email : ");
                        String email = Console.ReadLine();
                        Console.WriteLine("Entrer votre Nom : ");
                        String nomRecherche = Console.ReadLine();
                        Console.WriteLine("Entrer votre Prenom : ");
                        String prenomRecherche = Console.ReadLine();


                        C.SetNom(nomRecherche);
                        C.SetPrenom(prenomRecherche);
                        C.SetEmail(email);
                        int indCompte = Compte.SearchCompte(Comptes, C);
                        
                        if(indCompte != -1)
                        {
                            MenuTicket(indCompte);
                        }

                        

                        break;
                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Entrer votre email : ");
                        string emailInscri = Console.ReadLine();
                        Console.WriteLine("Entrer votre Pseudo : ");
                        string pseudo = Console.ReadLine();
                        Console.WriteLine("Entrer votre Nom : ");
                        string nom = Console.ReadLine();
                        Console.WriteLine("Entrer votre Prenom : ");
                        string prenom = Console.ReadLine();
                        Console.WriteLine("Entrer votre Age : ");
                        int age = int.Parse(Console.ReadLine());

                        if (age > 21)
                        {

                            C.SetPseudo(pseudo);
                            C.SetEmail(emailInscri);
                            C.SetNom(nom);
                            C.SetPrenom(prenom);
                            C.SetAge(age);
                            C.SetStatut("");
                            int successC = C.AddCompte(cheminCompte, C);

                            switch (successC)
                            {
                                case -1:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ce compte existe Deja");
                                    break;
                                case 1:
                                    Console.WriteLine("");
                                    Console.WriteLine("Le compte est bien ajouter");
                                    break;
                                default:
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("vous n'êtes pas majeur");
                            break;
                        }
                        break;
                    default:
                        repeter = 0;
                        break;
                }
                Console.Clear();
            }

            void MenuTicket(int id)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("1 : Ajouter un ticket");
                Console.WriteLine("2 : Supprimer un ticket");
                int ticketInscri = int.Parse(Console.ReadLine());
                switch (ticketInscri)
                {
                    case 1:
                        Console.WriteLine("Entrer votre ticket");
                        string numeroTicket = Console.ReadLine();
                        Ticket T = new Ticket();
                        T.SetNumero(numeroTicket);
                        T.SetIDCompte(id);
                        var successT = T.AddTicket(cheminTicket, T);
                        switch (successT)
                        {

                            case -1:
                                Console.WriteLine("Le ticket n'est pas valide");
                                break;
                            case -2:
                                Console.WriteLine("Le ticket existe Deja");
                                break;
                            case 1:
                                Console.WriteLine("Le ticket est bien ajouter");
                                break;
                            default:
                                Console.WriteLine("");
                                break;
                        }
                        break;
                    case 2:
                        List<Ticket> ListeTicket = Ticket.ListeTicket();
                        int i = 0;
                        foreach (Ticket Ts in ListeTicket)
                        {

                            if (Ts.IdCompte == id)
                            {
                                Console.WriteLine(Ts.Id + " : " + Ts.Numero);
                                i++;
                            }
                            string nTicket = Console.ReadLine();
                        }
                        Console.WriteLine("Choisi votre ticket");
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
            }




        }



    }
}
