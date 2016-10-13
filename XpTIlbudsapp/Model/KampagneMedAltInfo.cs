using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpTIlbudsapp
{
    class KampagneMedAltInfo
    {
        public string Varenavn { get; set; }
        public int Pris { get; set; }
        public string kædenavn { get; set; }
        public string Kampagnenavn { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime SlutDate { get; set; }

        public KampagneMedAltInfo(string varenavn, int pris, string kædenavn, string kampagnenavn, DateTime startdate, DateTime slutDate)
        {
            Varenavn = varenavn;
            Pris = pris;
            this.kædenavn = kædenavn;
            Kampagnenavn = kampagnenavn;
            Startdate = startdate;
            SlutDate = slutDate;
        }

        public override string ToString()
        {
            return $"{nameof(Varenavn)}: {Varenavn}, {nameof(Pris)}: {Pris}, {nameof(kædenavn)}: {kædenavn}, {nameof(Kampagnenavn)}: {Kampagnenavn}, {nameof(Startdate)}: {Startdate}, {nameof(SlutDate)}: {SlutDate}";
        }
    }
}
