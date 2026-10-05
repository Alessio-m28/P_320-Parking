namespace P_320_Parking
{
    public class Voiture
    {
        public int noPlace;
        public string plaque;

        public Voiture(string plaque, int noPlace)
        {
            this.plaque = plaque;
            this.noPlace = noPlace;
        }
    }
}