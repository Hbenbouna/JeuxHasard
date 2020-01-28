using JEUX_HASARD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.IO;


// <>
namespace JeuxHasardTest
{
    [TestClass]
    public class CompteTest
    {
        [TestMethod]
        [Description("Teste la presence d'un compte dans un liste de compte" +
            "Retourne -1 si le compte n'appartient pas à la liste sinon l'index du compte dans la liste")]
        public void searchCompteTest()
        {
            //Arrange
            List<Compte> myCompteList = new List<Compte>();
            List<Compte> myEmptyCompteList = new List<Compte>();

            Compte compte1 = new Compte("Hamza", "hamza@oceane.fr", 1234, "Ben", "Hamza", 25,"Soldat");
            Compte compte2 = new Compte("Omar", "omar@oceane.fr", 1235, "Kabore", "Omar", 25, "Soldat");
            Compte compte3 = new Compte("Asma", "Asma@oceane.fr", 1236, "Ould", "Asma", 26, "Soldat");

            myCompteList.Add(compte1);
            myCompteList.Add(compte2);

            Console.WriteLine(Compte.SearchCompte(myCompteList, compte1));
            if (Compte.SearchCompte(myCompteList, compte1) != 0)
                Assert.Fail();

            if (Compte.SearchCompte(myCompteList, compte2) != 1)
                Assert.Fail();

            if (Compte.SearchCompte(myEmptyCompteList, compte3) != -1)
                Assert.Fail();

            Assert.AreEqual(Compte.SearchCompte(myCompteList, compte1), 0, "Le compte est présent dans le compte");

        }

        [TestMethod]
        [Description("Cette methode test que le fichier json est bien chargé")]
        public void checkFileReadingJsonTest()
        {
            List<Compte> listCompteFromJsonFile = new List<Compte>();
            listCompteFromJsonFile = Compte.ListeComptes();    
            Assert.AreNotEqual(listCompteFromJsonFile.Count, 0, "La taille de la liste ne doit pas être 0 ou reverifier le chemin du comptes.json");

            
        }

        [TestMethod]
        [Description("")]
        public void SupprimerCompteCheck()
        {
            //Existe dans le fichier json
            Compte compteToDelete = new Compte("Hbenbouna", "benbouna.hamza@gmail.com", 1, "BENBOUNA", "Hamza", 24, "Soldat");

            //N'existe pas dans le fichier json
            Compte compteToDelete2 = new Compte("Hamza", "hamza@oceane.fr", 1234, "Ben", "Hamza", 25, "Soldat");

            string con = Directory.GetCurrentDirectory();
            string t = "bin";
            string dossCompte = "Compte.json";
            string cheminCompte = con.Substring(0, con.IndexOf(t)) + dossCompte;
            int resultDelete = Compte.DeleteCompte(cheminCompte, compteToDelete);

            Assert.AreEqual(Compte.DeleteCompte(cheminCompte, compteToDelete2), 0);

            if (resultDelete != 1)
                Assert.Fail();
        }

    }
}
