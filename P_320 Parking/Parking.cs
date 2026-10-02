using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
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
        bool isPlaceNbr;
        int choixPlaceSortie;
        string choixPlaque;
        bool isOut = false;
        string noPlaceLibre;
        bool existe = false;
        string answerSearch;
        string searchPlaque;
        string searchChoixPlace;
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

            Console.Write("--- Entree d'un vehicule ---");

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

                    bool isAllLettre = int.TryParse(matricule, out int lettre);

                    matriculeLettreTest = matricule.Length;

                    if (matriculeLettreTest != 2 && isAllLettre)
                    {
                        Console.WriteLine("Plaque invalide");

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

                        if (matriculeNbrTest.Length <= 6)
                        {
                            matricule += matriculeNbrTest;
                            chiffreOk = true;
                        }
                        else
                        {
                            Console.Write("Plaque invalide, la partie des chiffres est trop longue\n\n");
                        }

                    }
                    else if (!isAllNbr)
                    {
                        Console.Write("Plaque invalide, la 2e partie doit uniquement contenir des chiffres.");

                    }

                }

                Console.WriteLine($"\nVotre matricule est {matricule}.\n\n");
                plaqueOk = true;
                
            }

                for (int i = 0; i < places.Length; i++)
                {
                    if (places[i] == null)
                    {
                        noPlaceLibre += $"{i}  ";
                    }
                }

            while (!placeOk)
            {

                Console.WriteLine($"Les places libres sont les suivantes : {noPlaceLibre}");

                Console.Write("Veillez choisir la place (de 0 a 19): ");
                isPlaceNbr = int.TryParse(Console.ReadLine(), out choixPlace);

                if (!isPlaceNbr)
                {
                    Console.Write("Veuillez entrer un NOMBRE entre 0 a 19\n\n");
                }
                else if (choixPlace > 19)
                {
                    Console.Write("Veuillez entrer un nombre ENTRE 0 a 19\n\n");

                }
                else
                {
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

        }

        public void SortieVoiture()
        {
            isOut = false;
            Console.Write("--- Sortie d'un vehicule ---\n\n");
            Console.Write("Veuillez choisir une methode de sortie:\n\n1: sortie avec le numero de la place\n2: sortie avec la plaque\nVotre choix: ");

            string methodeDeSortie = Console.ReadLine();
            if (methodeDeSortie == "1")
            {

                Console.Write("Veullez choisir une place pour faire sortir votre vehicule: ");
                choixPlaceSortie = int.Parse(Console.ReadLine());

                places[choixPlaceSortie] = null;

                placeOcc--;

            }
            else if(methodeDeSortie == "2")
            {
                Console.Write("Veullez choisir une plaque de vehicule a sortir (format: LL-CCCCCC, ecrire en majuscule): ");
                choixPlaque = Console.ReadLine();
                

                foreach ( Voiture matricule in places)
                {
                    if(matricule != null && choixPlaque == matricule.plaque)
                    {
                        places[choixPlace] = null;
                        placeOcc--;
                        isOut = true;
                        Console.Write($"La voiture avec le plaque {choixPlaque} est sortie avec succes \n\n");
                    }
                   
                }

                if (!isOut)
                {
                    Console.Write($"Aucune voiture n'a ete trouvee avec la plaque {choixPlaque} \n\n");
                }
            }
            else
            {
                Console.Write("Veuillez choisir soit 1, soit 2 et pas autre chose\n\n");
            }
        }

        public void ShowStatus()
        {
            Console.Write($"--- ÉTAT DU PARKING --- \nPlaces Totales: {placeTot} \nPlaces occupée: {placeOcc} \nPlace libres: {placeTot - placeOcc} \nTaux d'occupation: {100 * placeOcc / placeTot}% \n\n");

            int i = 0;
            string status;
            foreach( Voiture voiture in places)
            {

                if (places[i] == null)
                {
                    status = " ";
                }
                else
                {
                    status = "X";
                }


                if(i == 0)
                {
                    Console.Write($"|| 0{i}: {status} |");
                }
                else if(i == 19)
                {
                    Console.Write($"| {i}: {status} ||\n\n");
                }
                else if(i < 10)
                {
                    Console.Write($"| 0{i}: {status} |");
                }
                else
                {
                    Console.Write($"| {i}: {status} |");
                }
                    i++;

                if(i%4 == 0 && i != 0 && i != 20)
                {
                    Console.Write("|\n|");
                }

            }

        }

        public void Search()
        {
            Console.Write("Veuillez entrer 1 pour chercher avec le N° de la place et 2 pour rechercher avec la plaque: ");
            answerSearch = Console.ReadLine();

            if (answerSearch == "1")
            {
                Console.Write("Veuillez entrer la place que vous voulez rechercher: ");
                int searchPlace = int.Parse(Console.ReadLine());

                if (places[searchPlace] == null)
                {
                    Console.Write($"Aucune voiture n'a ete trouvee, cette place est vide \n\n");
                }
                else
                {
                    Console.Write($"Place N° {searchPlace}\n");

                    searchChoixPlace = places[searchPlace].plaque;
                    Console.Write($"Plaque: {searchChoixPlace}\n\n");
                }
            }
            else if (answerSearch == "2")
            {
                Console.Write("Veuillez entrer la plaque pour la voiture que vous voulez rechercher (format: LL-CCCCCC, écrire en majuscule): ");
                searchPlaque = Console.ReadLine();

                foreach (Voiture matricule in places)
                {
                    if (matricule != null && searchPlaque == matricule.plaque)
                    {
                        Console.Write($"Place N° {matricule.noPlace}\n");
                        Console.Write($"Plaque: {searchPlaque}\n\n");
                        existe = true;
                    }

                }

                if (!existe)
                {
                    Console.Write($"Aucune voiture n'a ete trouvee avec la plaque {searchPlaque} \n\n");
                }
            }
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
