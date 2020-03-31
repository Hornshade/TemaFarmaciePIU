using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibrarieMedicamente;

namespace StocareData
{
    public class AdministrareMedicamente_FisierText : IStocareData
    {
        private const int NR_ALOCARE = 50;
        
        string NumeFisier { get; set; }

        public AdministrareMedicamente_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }

        public void AddMedicament(Medicamente m)
        {
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(m.ConversieLaSir_PentruFisier());
                }
            }
            catch(IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch(Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        //public void EditMedicament(Medicamente m)
        //{
        //    try
        //    {
        //        using (StreamWriter swFisierText = new StreamWriter(NumeFisier, false))
        //        {
        //            swFisierText.WriteLine(m.ConversieLaSir_PentruFisier());
        //        }
        //    }
        //    catch (IOException eIO)
        //    {
        //        throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
        //    }
        //    catch (Exception eGen)
        //    {
        //        throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
        //    }

        //}
        public void EditMedicament(Medicamente[] m, int ind)
        {
            int i = ind;
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, false))
                {
                    swFisierText.WriteLine(m[i].ConversieLaSir_PentruFisier());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public Medicamente[] GetMedicamente(out int nrMedicamente)
        {
            Medicamente[] medicament = new Medicamente[NR_ALOCARE];

            try
            {
                using(StreamReader sr= new StreamReader(NumeFisier))
                {
                    string line;
                    nrMedicamente = 0;

                    while((line=sr.ReadLine())!=null)
                    {
                        medicament[nrMedicamente++] = new Medicamente(line);
                        if(nrMedicamente== NR_ALOCARE)
                        {
                            Array.Resize(ref medicament, nrMedicamente + NR_ALOCARE);
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return medicament;
        }
    }
}
