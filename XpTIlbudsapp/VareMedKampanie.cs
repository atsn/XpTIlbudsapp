using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpTIlbudsapp
{
    class VareMedTilbud
    {
        public int Pris { get; set; }
        public string Varenavn { get; set; }
        public string KædeNavn { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime SlutDate { get; set; }
        
        public VareMedTilbud(int pris, string varenavn, string kædeNavn, DateTime startdate, DateTime slutDate)
        {
            Pris = pris;
            Varenavn = varenavn;
            KædeNavn = kædeNavn;
            Startdate = startdate;
            SlutDate = slutDate;
        }
    }
}
