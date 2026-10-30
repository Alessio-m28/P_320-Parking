using Microsoft.VisualStudio.TestTools.UnitTesting;
using P_320_Parking;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;

namespace P_320_Parking.Tests
{
    [TestClass]
    public class Tests
    {


        [TestMethod]
        public void Ticket_SansSortie_PrixEstZero()
        {
            // Arrange
            Ticket ticket = new Ticket("VD-123456", 5);

            // Act
            decimal prix = ticket.CalculerPrix();

            // Assert
            Assert.AreEqual(0m, prix);
        }


        [TestMethod]
        public void Ticket_ApresSortie_DureeEstPositive()
        {
            // Arrange
            Ticket ticket = new Ticket("GE-987654", 10);

            // Act
            System.Threading.Thread.Sleep(100);
            ticket.EnregistrerSortie();

            // Assert
            Assert.IsTrue(ticket.GetDuree() > TimeSpan.Zero);
            Assert.IsNotNull(ticket._sortie);
        }




        [TestMethod]
        public void Ticket_EnregistrerSortie_DateSortieApresArrivee()
        {
            // Arrange
            Ticket ticket = new Ticket("VD-123456", 5);

            // Act
            ticket.EnregistrerSortie();

            // Assert
            Assert.IsNotNull(ticket._sortie);
            Assert.IsTrue(ticket._sortie.Value >= ticket._arrivee);
        }

    }
}