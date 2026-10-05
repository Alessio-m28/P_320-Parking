using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_320_Parking
{
    public class Ticket
    {

        public string _plaque;
        public int _place;
        public DateTime _arrivee;
        public DateTime? _sortie;
        public const decimal TARIF_HORAIRE = 30;

        public Ticket(string plaque, int numeroPlace)
        {
            _plaque = plaque;
            _place = numeroPlace;
            _arrivee = DateTime.Now;
            _sortie = null;
        }

        public void EnregistrerSortie()
        {

            _sortie = DateTime.Now;

        }

        public TimeSpan GetDuree()
        {

            if (_sortie == null)
            {

                return DateTime.Now - _arrivee;

            }

            return _sortie.Value - _arrivee;
        }

        public decimal CalculerPrix()
        {
            if (_sortie == null)
            {

                return 0;

            }

            TimeSpan duree = _sortie.Value - _arrivee;

            return (decimal)duree.TotalHours * TARIF_HORAIRE;
        }

        public void Afficher()
        {

            Console.WriteLine("\n--- TICKET DE PARKING ---");

            Console.WriteLine($"Plaque  : {_plaque} \nPlace   : {_place} \nArrivée : {_arrivee:dd/MM/yyyy HH:mm:ss}");

            if (_sortie == null)
            {

                Console.WriteLine("Sortie  : En cours de stationnement");

                Console.WriteLine("Prix    : Non disponible");

            }
            else
            {

                TimeSpan duree = _sortie.Value - _arrivee;

                decimal prix = CalculerPrix();

                Console.Write($"\nSortie  : {_sortie.Value:dd/MM/yyyy HH:mm:ss} \nDurée   : {(int)duree.TotalHours}h {duree.Minutes}min \nTarif   : {TARIF_HORAIRE:F2} CHF/heure \nÀ payer : {prix:F2} CHF");
            }
        }
    }
}



