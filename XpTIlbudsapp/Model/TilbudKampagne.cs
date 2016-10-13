using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XpTIlbudsapp
{
    class TilbudKampagne : IWebUri
    {

        public int Fk_Kampagne_ID { get; set; }

        public int Fk_Tilbud_ID { get; set; }

        public int TK_ID { get; set; }


        public TilbudKampagne(int fkKampagneId, int fkTilbud) : this()
        {
            Fk_Kampagne_ID = fkKampagneId;
            Fk_Tilbud_ID = fkTilbud;
        }

    
        public TilbudKampagne()
        {
            ResourceUri = "TilbudKampagnes";
            VerboseName = "TilbudKampagne";

        }

        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}



