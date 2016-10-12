using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpTIlbudsapp
{
    class Kampagne : IWebUri
    {


        public int Kampagne_ID { get; set; }
        public int Fk_kaede_ID { get; set; }
        public string Navn { get; set; }


        public Kampagne(int fkKaedeId, string navn) : this()
        {
            
            Fk_kaede_ID = fkKaedeId;
            Navn = navn;
        }


        public Kampagne()
        {
            ResourceUri = "Kampagnes";
            VerboseName = "Kampagne";

        }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}
