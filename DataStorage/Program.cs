using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public class AdministrareConturi_FisierText
    {
        private const int ID_PRIMUL_CONT = 1;
        private const int INCREMENT = 1;

        private const int NR_MAX_CONTURI = 150;
        private string numeFisier;

        public AdministrareConturi_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddCont(Cont cont)
        {
            cont.IdCont = GetId();

            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(cont.ConversieLaSir_PentruFisier());
            }
        }

        public Cont[] GetConturi(out int nrConturi)
        {
            Cont[] conturi = new Cont[NR_MAX_CONTURI];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrConturi = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    conturi[nrConturi++] = new Cont(linieFisier);
                }
            }

            Array.Resize(ref conturi, nrConturi);

            return conturi;
        }
        private int GetId()
        {
            int IdCont = ID_PRIMUL_CONT;

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Cont cont = new Cont(linieFisier);
                    IdCont = cont.IdCont + INCREMENT;
                }
            }

            return IdCont;
        }
    }
}
