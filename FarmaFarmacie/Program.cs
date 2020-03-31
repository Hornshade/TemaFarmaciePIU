using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieMedicamente;
using StocareData;



namespace FarmaFarmacie
{
    class Program
    {
        static void Main(string[] args)
        { 
            Medicamente[] med;
            IStocareData adminMedicamente = StocareFactory.GetAdministratorStocare();
            int nrMedicamente;
            med = adminMedicamente.GetMedicamente(out nrMedicamente);
            Medicamente.IdUltimMedicament = nrMedicamente;

            bool validare = true;
            while (validare)
            {
                Console.Clear();
                Console.WriteLine("1.Adaugare medicament.");
                Console.WriteLine("2.Stergere medicament.");
                Console.WriteLine("3.Editare medicament.");
                Console.WriteLine("4.Afisare lista medicamente.");
                Console.WriteLine("5.Cautare medicament.");
                Console.WriteLine("X.Iesire.");
                Console.WriteLine("\nSelectati o optiune : ");


                switch (Console.ReadLine())
                {
                    case "1":
                        Medicamente m = CitireMedicament();
                        med[nrMedicamente] = m;
                        
                        adminMedicamente.AddMedicament(m);              //adauga medicamentul in fisierul text
                        #region OLD_CODE_ADD  
                        //med[nrMedicamente - 1] = new Medicamente();
                        //Console.WriteLine("Introduceti numele medicamentului pe care doriti sa-l adaugati: ");
                        //med[nrMedicamente - 1].Name = Console.ReadLine();
                        //Console.WriteLine("Introduceti pretului produsului {0}", med[nrMedicamente - 1].Name);
                        //med[nrMedicamente - 1].SetPrice(Convert.ToInt32(Console.ReadLine()));
                        //Console.WriteLine("Ati adaugat medicamentul {0} la pretul de {1} lei", med[nrMedicamente - 1].Name, med[nrMedicamente - 1].Price);
                        nrMedicamente++;
                        //Console.ReadKey();
                        #endregion
                        break;
                    case "2":
                        AfisareMedicamente(med, nrMedicamente);
                        Console.WriteLine("Alegeti numarul medicamentului din lista pe care doriti sa-l stergeti : ");
                        int indice = Convert.ToInt32(Console.ReadLine());                                                              
                        med[indice - 1].Name = string.Empty;
                        med[indice - 1].SetPrice(string.Empty);
                        //med[indice - 1].Price = null;
                        Console.ReadKey();
                        break;
                    case "3":
                        AfisareMedicamente(med, nrMedicamente);
                        Console.WriteLine("Alegeti numarul medicamentului din lista pe care doriti sa-l editati : ");
                        int ind = Convert.ToInt32(Console.ReadLine());
                        Medicamente medit = CitireMedicament();
                        med[ind - 1] = medit;
                        adminMedicamente.EditMedicament(med, ind);
                        #region cod vechi
                        //Medicamente m1 = EditareMedicament();
                        //med[ind - 1] = m1;
                        //adminMedicamente.AddMedicament(m1);
                        //Console.WriteLine("Ati ales sa editati medicamentul {0} .", med[ind - 1].Name);
                        //Console.WriteLine("Alegeti un nume : ");
                        //med[ind - 1].Name = Console.ReadLine();
                        //Console.WriteLine("Alegeti un pret : ");
                        //med[ind - 1].SetPrice(Console.ReadLine());
                        //Console.WriteLine("Nou : {0}",med[ind-1].ConvertString());
                        //Medicamente editare = new Medicamente();
                        //med[ind - 1] = editare;
                        //adminMedicamente.AddMedicament(editare);
                        #endregion
                        Console.ReadKey();
                        break;
                    case "4":
                        AfisareMedicamente(med, nrMedicamente);
                        #region OLD_CODE_Afisare
                        //for (int i=0;i<nrMedicamente-1;i++)
                        //{
                        //    Console.WriteLine("{0} . {1} pret: {2} lei", i + 1, m1[i].Name, m1[i].Price);
                        //}
                        #endregion
                        Console.ReadKey();
                        break;
                    case "5":
                        CautareMedicament(med, nrMedicamente);
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.WriteLine("Introduceti numele si pretul pe aceeasi linie cu , intre ele");
                        string tema3_1 = Console.ReadLine();
                        Medicamente tema3 = new Medicamente(tema3_1,3);
                        Console.WriteLine(tema3.ConvertString());
                        Console.ReadKey();
                        break;
                    case "X":
                        validare = false;
                        break;
                    default:
                        
                        break;
                }
            }
            
        }

        public static void AfisareMedicamente(Medicamente[] med,int nrMedicamente)
        {
           
                Console.WriteLine("Medicamentele sunt:");
                for (int i = 0; i < nrMedicamente; i++)
                {
                    if(med[i].Name!=string.Empty)
                        Console.WriteLine(med[i].ConvertString());
                }
            
        }
       
        public static Medicamente CitireMedicament()
        {
            Console.WriteLine("Introduceti numele medicamentului: ");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti pretul medicamentului: ");
            string pret = Console.ReadLine();

            Medicamente m = new Medicamente();
            m.SetPrice(pret);
            m.Name = nume;

            return m;
        }

        public static void CautareMedicament(Medicamente[] med,int nrMedicamente)
        {
            Console.WriteLine("Introduceti numele medicamentului cautat : ");
            string nume = Console.ReadLine();
            int VerificaOK = -1;
            int ok = VerificaOK;
            for (int i=0;i<nrMedicamente;i++)
            {
                if (nume == med[i].Name)
                {
                    ok = i;
                } 
            }
            if (ok != VerificaOK)
            {
                Console.WriteLine("{0} lei ", med[ok].ConvertString());
            }
            else
                Console.WriteLine("Medicamentul nu a fost gasit.");

        }

        public static Medicamente EditareMedicament()
        {
            Console.WriteLine("Introduceti numele medicamentului: ");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti pretul medicamentului: ");
            string pret = Console.ReadLine();

            Medicamente m = new Medicamente();
            m.SetPrice(pret);
            m.Name = nume;

            return m;

        }

        public static void EditMed(Medicamente[] med,int ind)
        {
            Console.WriteLine("Introduceti noul nume al medicamentului: ");
            med[ind - 1].Name = Console.ReadLine();
            Console.WriteLine("Introduceti noul pret al medicamentului: ");
            med[ind - 1].SetPrice(Console.ReadLine());
        }

    }
}
