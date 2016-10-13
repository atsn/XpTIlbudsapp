using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpTIlbudsapp
{
    class Kaede : IWebUri
    {

        public int Kaede_ID { get; set; }
        public string Navn { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public Kaede()
        {
            ResourceUri = "Kaedes";
            VerboseName = "Kaede";
        }

        public Kaede(string navn) : this()
        {
            
            Navn = navn;

        }

       
    }
}
