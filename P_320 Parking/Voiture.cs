using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_320_Parking
{
    internal class Voiture
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
