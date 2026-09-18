using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P_320_Parking;

namespace P_320_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;  
            Parking parking = new Parking(20);

            while (loop)
            {
                parking.Menu();
            }
            
            Console.ReadLine();
        }

        
    }
}
