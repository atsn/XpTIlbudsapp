using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpTIlbudsapp
{
    class VareMedKampanie
    {
        public int Pris { get; set; }
        public string Varenavn { get; set; }
        public string Navn { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime SlutDate { get; set; }

        public VareMedKampanie(int pris, string varenavn, string navn, DateTime startdate, DateTime slutDate)
        {
            Pris = pris;
            Varenavn = varenavn;
            Navn = navn;
            Startdate = startdate;
            SlutDate = slutDate;
        }
    }
}
