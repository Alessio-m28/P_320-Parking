using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_320_Parking
{
    internal class Voiture
    {
        int noPlace;
        string plaque;

        public Voiture(string plaque, int noPlace)
        {
            this.plaque = plaque;
            this.noPlace = noPlace;
        }
    }
}
