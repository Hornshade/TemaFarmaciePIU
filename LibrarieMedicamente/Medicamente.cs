using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieMedicamente
{
    public class Medicamente
    {
        private const bool SUCCES = true;
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        private const int ID = 0;
        private const int NUME = 1;
        private const int PRET = 2;

        public int[] Price;
        //public int nrMedicamente { get; set; }
        public static int IdUltimMedicament { get; set; } = 0;
        public int IdMedicament { get; set; }    
        public string Name { get; set; }
        
        #region Constructori

        //implicit
        public Medicamente()
        {
            Name = string.Empty;
            IdUltimMedicament++;
            IdMedicament = IdUltimMedicament;      
        }

        //cu 1 param
        //public Medicamente(string _Name)
        //{
        //    Name = _Name;
        //    IdUltimMedicament++;
        //    IdMedicament = IdUltimMedicament;      
        //}

        // cu 2 param
        public Medicamente(string _Name, int[] _Price)
        {
            Name = _Name;
            Price = new int[_Price.Length];
            _Price.CopyTo(Price, 0);
            IdUltimMedicament++;
            IdMedicament = IdUltimMedicament;
        }

        // cu 1 param tip string pt linie din fisier text
        public Medicamente(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            IdMedicament = Convert.ToInt32(dateFisier[ID]);
            Name = dateFisier[NUME];
            SetPrice(dateFisier[PRET]);
            IdUltimMedicament = IdMedicament;
        }


        //Tema3_1
        public Medicamente(string nume,int s)
        {
            string[] strg = new string[2];
            strg = nume.Split(',');
            Name = strg[0];
            SetPrice(strg[1]);
        }

        #endregion

        public void SetPrice(string PriceString)
        {
            string[] vectorSplit = PriceString.Split(' ');
            Price = new int[vectorSplit.Length];
            int nrPrice = 0;
            foreach (var price in vectorSplit)
            {
                bool rezultatConversie = Int32.TryParse(price, out Price[nrPrice]);
                if (rezultatConversie == SUCCES && Pret.ValideazaPret(Price[nrPrice]) == SUCCES)
                {
                    nrPrice++;
                }
            }
            Array.Resize(ref Price, nrPrice);
        }

        public void SetPrice(int[] _Price)
        {
            Price = new int[_Price.Length];
            _Price.CopyTo(Price, 0);
        }

        public int[] GetPrice()
        {
            return (int[])Price.Clone();
        }

        public string ConvertString()
        {
            string sPrice = "Nu exista( nu ati apelat SetPrice ).";
            if (Price != null)
            {
                sPrice = string.Join(",", Price);
            }
            string m = string.Format("Medicamentul  {0}  are pretul :   {1}", (Name ?? " NECUNOSCUT "), sPrice);
            return m;
        }

        public string ConversieLaSir_PentruFisier()
        {
            string sPrice = string.Empty;
            if(Price!=null)
            {
                sPrice = string.Join(SEPARATOR_AFISARE, Price);
            }
            string m = string.Format("{1}{0}{2}{0}{3}",
                SEPARATOR_PRINCIPAL_FISIER, IdMedicament.ToString(), (Name ?? " NECUNOSCUT "), sPrice);

            return m;
        }
    }
}
