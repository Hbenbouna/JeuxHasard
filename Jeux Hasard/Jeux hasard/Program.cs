
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


            string[] listStatut = new string[] { "General", "Colonel", "Capitaine", "Lieutenant", "Soldat" };

            String chemin = "";

            /*********Connection ou inscription********/



            /*********Connection ou inscription********/




            Ticket T = new Ticket();


            T.SetNumero("245343445345345316341");
            T.SetIDCompte(1);
            //var successT = T.AddTicket(@"C:\Users\Hamza BENBOUNA\Desktop\intech\Jeux hasard\ticket.json", T);
            //var successT = T.DeleteTicket(@"C:\Users\Hamza BENBOUNA\Desktop\intech\Jeux hasard\ticket.json", T);
            /*switch (successT)
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
            }*/

            Compte C = new Compte();

            C.SetPseudo("Hbenbouna");
            C.SetEmail("benbouna.hamzp@gmail.com");
            C.SetNom("BENBOUNA");
            C.SetPrenom("Hamza");
            C.SetAge(24);
            C.SetStatut("");


            /*int successC = C.AddCompte(@"C:\Users\Hamza BENBOUNA\Desktop\intech\Jeux hasard\Compte.json", C);
            
            switch (successC)
            {
                case -1:
                    Console.WriteLine("Ce compte existe Deja");
                    break;
                case 1:
                    Console.WriteLine("Le compte est bien ajouter");
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }*/
            //C.DeleteCompte(@"C:\Users\Hamza BENBOUNA\Desktop\intech\Jeux hasard\Compte.json", C);
            //Console.Write(retourr);




        }



    }
}
