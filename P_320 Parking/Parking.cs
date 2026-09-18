using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_320_Parking
{
    internal class Parking
    {

        public int placeTot;
        public int placeOcc;
        public string matricule {  get; private set; }
        int checkLenght;
        string matriculeNbrTest;
        int matriculeLettreTest;
        int choixPlace;
        bool lettreOk = false;
        bool chiffreOk = false;
        bool plaqueOk = false;
        bool placeOk = false;
        public Voiture[] places { get; set; }

        private string _choix;
        public string Choix
        { 
            get;
            set; 
        }

        public Parking(int place_tot)
        {
           this.placeTot = place_tot;
           places = new Voiture[placeTot];
        }








        public void Menu()
        {

            Console.Write("--- MENU PRINCIPAL ---\n1. Entree d'un vehicule\n2. Sortie d'un véhicule \n3. Afficher l'etat du parking\n4. Rechercher un vehicule\n5. Statistiques du jour\n6. Historique des transactions\n0. Quitter\nVotre choix : ");

            Choix = Console.ReadLine();

            Console.Clear();

            switch (Choix)
            {
                case "1":
                    EntreeVoiture();
                    break;

                case "2":
                    SortieVoiture();
                    break;

                case "3":
                    ShowStatus();
                    break;

                case "4":
                    Search();
                    break;

                case "5":
                    DayStats();
                    break;

                case "6":
                    Historique();
                    break;

                case "0":
                    Exit();
                    break;

                default:
                    Console.WriteLine("Choix invalide");
                    break;

            }
        }

        public void EntreeVoiture()
        {

            plaqueOk = false ;
            lettreOk = false ;
            chiffreOk = false ;
            placeOk = false;

            while (!plaqueOk)
            {


                while (!lettreOk)
                {
                    Console.Write("\n\nVeuillez entrer votre matricule (Canton, ex: VD): ");

                    //Test la partie des lettres de la plaque
                    matricule = Console.ReadLine();

                    matricule = matricule.ToUpper();

                    matriculeLettreTest = matricule.Length;

                    if (matriculeLettreTest != 2)
                    {
                        Console.WriteLine("Plaque invalide, le canton ne fait pas la bonne longueure (ex: VD)");

                    }
                    else
                    {
                        lettreOk = true;
                    }
                }


                matricule += "-";


                while (!chiffreOk)
                {

                    Console.Write("Veillez entrer votre matricule (chiffre) : ");
                    matriculeNbrTest = Console.ReadLine();


                    //Test pour la partie chiffre de la plaque
                    bool isAllNbr = int.TryParse(matriculeNbrTest, out int nombre);

                    if (matriculeNbrTest == "")
                    {
                        Console.WriteLine("Plaque invalide");

                    }
                    else if (isAllNbr)
                    {
                        matricule += matriculeNbrTest;
                        chiffreOk = true;
                    }
                    else if (!isAllNbr)
                    {
                        Console.Write("Plaque invalide, la 2e partie doit uniquement contenir des chiffres.");

                    }

                }



                //Check de la longueure de la plaque
                checkLenght = matricule.Length;

                if (checkLenght > 9 || checkLenght <= 3)
                {
                    Console.WriteLine("Plaque invalide");
                    chiffreOk = false;
                    lettreOk = false;
                }
                else
                {

                    Console.WriteLine($"\nVotre matricule est {matricule}.\n\n");
                    plaqueOk = true;
                }
            }

            while (!placeOk)
            {


                Console.Write("Veillez choisir la place: ");
                choixPlace = int.Parse(Console.ReadLine());

                if (places[choixPlace] == null)
                {
                    places[choixPlace] = new Voiture(matricule, choixPlace);

                    placeOcc++;
                    placeOk = true;
                }
                else
                {
                    Console.Write("La place est deja occupee, veuillez en choisir une autre.\n\n");
                } 
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
