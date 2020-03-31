using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieMedicamente;

namespace StocareData
{
    public class AdministrareMedicamente_FisierBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareMedicamente_FisierBinar(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddMedicament(Medicamente m)
        {
            throw new Exception("Optiunea AddMedicament nu este implementata");
        }

        public void EditMedicament(Medicamente[] m,int ind)
        {
            throw new Exception("Optiunea EditMedicament nu este implementata");
        }

        public Medicamente[] GetMedicamente(out int nrMedicamente)
        {
            throw new Exception("Optiunea GetMedicamente nu este implementata");
        }

    }
}
