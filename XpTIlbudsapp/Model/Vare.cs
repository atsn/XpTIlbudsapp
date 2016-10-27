using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XpTIlbudsapp
{
    class Vare : IWebUri
    {
        public bool HasBeenNotified { get; set; }
        public int Vare_ID { get; set; }
        public string Navn { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public Vare(string navn) : this()
        {

            Navn = navn;

        }

        public Vare()
        {
            ResourceUri = "Vares";
            VerboseName = "Vare";
        }

        public Vare(int vareId, string navn )
        {

            Vare_ID = vareId;
            Navn = navn;
        }

        public override string ToString()
        {
            return $"Navn: {Navn}";
        }
    }
}
