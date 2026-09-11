using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_320_Parking
{
    internal class Parking
    {

        public int placeTot;
        public int placeOcc;
        public string matricule;
        int checkLenght;

        private int _choix;
        public int Choix
        { 
            get;
            set; 
        }

        public Parking(int place_tot)
        {
            this.placeTot = place_tot;
        }

        public void Menu()
        {

            Console.Write("--- MENU PRINCIPAL ---\n1. Entree d'un vehicule\n2. Sortie d'un véhicule\r\n3. Afficher l'etat du parking\n4. Rechercher un vehicule\n5. Statistiques du jour\n6. Historique des transactions\n0. Quitter\nVotre choix : ");

            Choix = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (Choix)
            {
                case 1:
                    EntreeVoiture();
                    break;

                case 2:
                    SortieVoiture();
                    break;

                case 3:
                    ShowStatus();
                    break;

                case 4:
                    Search();
                    break;

                case 5:
                    DayStats();
                    break;

                case 6:
                    Historique();
                    break;

                case 0:
                    Exit();
                    break;

                default:
                    Console.WriteLine("Choix invalide");
                    break;

            }
        }

        public void EntreeVoiture()
        {
            Console.Write("\n\nVeuillez entrer votre matricule (Canton, ex: VD): ");
            matricule = Console.ReadLine();
            matricule += "-";
            Console.Write("Veillez entrer votre matricule (chiffre) : ");
            matricule += Console.ReadLine();

            checkLenght = matricule.Length;

            if (checkLenght > 9|| checkLenght <= 3)
            {
                Console.WriteLine("Plaque invalide");
                EntreeVoiture();
            }
            else
            {

                Console.WriteLine($"\nVotre matricule est {matricule}.\n\n");
            }
        }

        public void SortieVoiture()
        {

        }

        public void ShowStatus()
        {
            Console.Write($"--- ÉTAT DU PARKING --- \nPlaces Totales: {placeTot} \nPlaces occupée: {placeOcc} \nPlace libres: {placeTot - placeOcc} \nTaux d'occupation: {100 * placeOcc / placeTot}% \n\n");
        }

        public void Search()
        {

        }

        public void DayStats()
        {

        }

        public  void Historique()
        {

        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }

   
}
