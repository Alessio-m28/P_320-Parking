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
        public void CreationTicket_VerifieInformations()
        {
            // Arrange
            string plaque = "VD-123456";
            int numeroPlace = 5;

            // Act
            Ticket ticket = new Ticket(plaque, numeroPlace);

            // Assert
            Assert.AreEqual(plaque, ticket.GetPlaque());
            Assert.AreEqual(numeroPlace, ticket.GetNumeroPlace());
            Assert.IsNotNull(ticket.GetArrivee());
            Assert.IsNull(ticket.GetSortie());
        }

        [TestMethod]
        public void Ticket_EnregistrerSortie_VerifieSortie()
        {
            // Arrange
            Ticket ticket = new Ticket("VD-123456", 5);

            // Act
            ticket.EnregistrerSortie();

            // Assert
            Assert.IsNotNull(ticket.GetSortie());
        }

        [TestMethod]
        public void SortieVoiture_AvecNumeroPlace_LibereLaPlace()
        {
            // Arrange
            Parking parking = new Parking(20);

            Voiture voiture = new Voiture("VD-123456", 5);
            parking.places[5] = voiture;
            parking.placeOcc = 1;

            StringReader input = new StringReader("1\n5\n");
            Console.SetIn(input);

            // Act
            parking.SortieVoiture();

            // Assert
            Assert.IsNull(parking.places[5]);
            Assert.AreEqual(0, parking.placeOcc);
        }
    }
}