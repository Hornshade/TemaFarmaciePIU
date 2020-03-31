using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieMedicamente;

namespace StocareData
{
    public interface IStocareData
    {
        void AddMedicament(Medicamente m);
        void EditMedicament(Medicamente[] m,int ind);
        Medicamente[] GetMedicamente(out int nrMedicamente);

    }
}
