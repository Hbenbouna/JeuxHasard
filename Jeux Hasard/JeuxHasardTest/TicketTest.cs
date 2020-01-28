using JEUX_HASARD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;


namespace JeuxHasardTest
{
    [TestClass]
    class TicketTest
    {

        [TestMethod]
        [Description("")]
        public void searchTicketTest()
        {

            Ticket ticketForSearch = new Ticket();

            List<Ticket> listTicket = new List<Ticket>();
            Ticket ticket1 = new Ticket(1, "245345345345345345345", 1);
            Ticket ticket2 = new Ticket(2,"245345345345345345345", 2);
            Ticket ticket3 = new Ticket(3, "245345345345345345347", 3);

            listTicket.Add(ticket1);
            listTicket.Add(ticket2);

            Assert.AreEqual(ticketForSearch.SearchTicket(listTicket, ticket1),0);
            Assert.AreEqual(ticketForSearch.SearchTicket(listTicket, ticket1), 1);
            Assert.AreEqual(ticketForSearch.SearchTicket(listTicket, ticket3), -1);
        }

        [TestMethod]
        [Description("")]
        public void validTicketTest()
        {
           
            Ticket ticket = new Ticket(1, "245345345345345345345", 1);
            Ticket ticket2 = new Ticket(2, "false ticket", 2);

            Assert.IsTrue(Ticket.ValidTicket(ticket));
            Assert.IsFalse(Ticket.ValidTicket(ticket2));
        }


        [TestMethod]
        [Description("")]
        public void addTicketTest()
        {


        }

        [TestMethod]
        [Description("")]
        public void deleteTicket()
        {

        }
    }

}
