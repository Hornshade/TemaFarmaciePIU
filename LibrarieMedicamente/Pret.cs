using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieMedicamente
{
    public static class  Pret
    {
        public const int PRET_MINIM = 1;
        public const int PRET_MAXIM = 10000;

        public static bool ValideazaPret(int pret)
        {
            if (pret >= PRET_MINIM && pret <= PRET_MAXIM)
                return true;
            return false;
        }
    }
}
