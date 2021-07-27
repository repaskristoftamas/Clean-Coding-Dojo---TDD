using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Coding_Dojo
{
    public class KiskereskedoBevasarlas
    {
        private int ketchupAr = 100;
        private int mustarAr = 200;
        private int majonezAr = 250;

        public int FizetendoOsszeg(int ketchupDB, int mustarDB, int majonezDB)
        {
            if (ketchupDB >= 50 || mustarDB >= 50 || majonezDB >= 50)
                return (int)((ketchupDB * ketchupAr + mustarDB * mustarAr + majonezDB * majonezAr) * 0.75);
            else if (ketchupDB >= 25 || mustarDB >= 25 || majonezDB >= 25)
                return (int)((ketchupDB * ketchupAr + mustarDB * mustarAr + majonezDB * majonezAr) * 0.9);
            else
                return ketchupDB * ketchupAr + mustarDB * mustarAr + majonezDB * majonezAr;
        }

        public string Purchase(int ketchupDB, int mustarDB, int majonezDB)
        {
            int vegosszeg;

            if (ketchupDB <= 0 || mustarDB <= 0 || majonezDB <= 0)
                throw new Exception("Mindegyikből vásárolni kell legalább 10 darabot!");
            else if (ketchupDB > 100 || mustarDB > 100 || majonezDB > 100)
                throw new Exception("Nem lehet semmiből 100-nál többet venni");
            else
            {
                vegosszeg = FizetendoOsszeg(ketchupDB, mustarDB, majonezDB);
                Console.WriteLine(vegosszeg);
                return $"A:{ketchupDB}B:{mustarDB}C:{majonezDB}";
            }
        }
    }
}
