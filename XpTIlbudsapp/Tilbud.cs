using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpTIlbudsapp
{
    class Tilbud :IWebUri
    {
        public int Fk_Vare_ID { get; set; }
        public int Fk_Kaede_ID { get; set; }
        public int Pris { get; set; }
        public DateTime Start_Dato { get; set; }
        public DateTime Slut_Dato { get; set; }
        public int Tilbud_ID { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public Tilbud()
        {
            ResourceUri = "Tilbuds";
            VerboseName = "Tilbud";

        }
        public Tilbud(int fkVareId, int fkKaedeId, int pris, DateTime startDato, DateTime slutDato) : this()
        {
            Fk_Vare_ID = fkVareId;
            Fk_Kaede_ID = fkKaedeId;
            Pris = pris;
            Start_Dato = startDato;
            Slut_Dato = slutDato;
            
        }

        
    }
}
