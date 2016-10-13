using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace XpTIlbudsapp
{
    class Handler
    {

        public static IEnumerable<VareMedTilbud> søgetilbud(string søgeord)

        {


            try
            {
                var tildbud = facade.GetListAsync(new Tilbud()).Result;
                var kæde = facade.GetListAsync(new Kaede()).Result;
                var Vare = facade.GetListAsync(new Vare()).Result;




                if (søgeord == null)
                {
                    søgeord = "";
                }



                var søgtevare = from v in Vare where (v.Navn.ToLower().Contains(søgeord)) select v;



                var tilbudsliste = from s in søgtevare
                    join t in tildbud on s.Vare_ID equals t.Fk_Vare_ID
                    select
                    new {s.Vare_ID, varenavn = s.Navn, t.Fk_Vare_ID, t.Fk_Kaede_ID, t.Pris, t.Slut_Dato, t.Start_Dato};

                // Console.WriteLine(tilbudsliste.First());
                var tilbudslistemedkæde = from t in tilbudsliste
                    join k in kæde on t.Fk_Kaede_ID equals k.Kaede_ID
                    where t.Start_Dato < DateTime.Now && t.Slut_Dato > DateTime.Now
                    select new VareMedTilbud(t.Pris, t.varenavn, k.Navn, t.Start_Dato, t.Slut_Dato);

                return tilbudslistemedkæde;





            }
            catch (Exception e)
            {
                MessageDialog errorbox = new MessageDialog(e + e.Message);
                errorbox.ShowAsync();
                return null;
            }

        }
        public static IEnumerable<VareMedTilbud> søgeKælde(string søgeord)

        {


            try
            {
                var tildbud = facade.GetListAsync(new Tilbud()).Result;
                var kæde = facade.GetListAsync(new Kaede()).Result;
                var Vare = facade.GetListAsync(new Vare()).Result;




                if (søgeord == null)
                {
                    søgeord = "";
                }



                var SøgteKæde = from v in kæde where (v.Navn.ToLower().Contains(søgeord)) select v;



                var tilbudsliste = from s in SøgteKæde
                                   join t in tildbud on s.Kaede_ID equals t.Fk_Kaede_ID
                                   select new { kædenavn = s.Navn, t.Fk_Vare_ID, t.Fk_Kaede_ID, t.Pris, t.Slut_Dato, t.Start_Dato };

                var tilbudliste2 = from s in tilbudsliste
                    join v in Vare on s.Fk_Vare_ID equals v.Vare_ID
                    select new VareMedTilbud(s.Pris, v.Navn, s.kædenavn, s.Start_Dato, s.Slut_Dato);

               

                return tilbudliste2;





            }
            catch (Exception e)
            {
                MessageDialog errorbox = new MessageDialog(e + e.Message);
                errorbox.ShowAsync();
                return null;
            }

        }
        public static IEnumerable<KampagneMedAltInfo> søgekampagne(string søgeord)
        {
            var tildbud = facade.GetListAsync(new Tilbud()).Result;
            var kæde = facade.GetListAsync(new Kaede()).Result;
            var Vare = facade.GetListAsync(new Vare()).Result;
            var Tilbudkampagne = facade.GetListAsync(new TilbudKampagne()).Result;
            var kampagne = facade.GetListAsync(new Kampagne()).Result;





            if (søgeord == null)
            {
                søgeord = "";
            }

            var søgtevare = from k in kampagne where (k.Navn.ToLower().Contains(søgeord)) select k;

            var kampanieliste1 = from k in søgtevare
                join t in kæde on k.Fk_kaede_ID equals t.Kaede_ID
                select new {k, t};
            //Console.WriteLine("1" + kampanieliste1);
            var kampanieliste2 = from k in kampanieliste1
                join J in Tilbudkampagne on k.k.Kampagne_ID equals J.Fk_Kampagne_ID
                select new {k, J};
            //Console.WriteLine("2" + kampanieliste2);
            var kampanieliste3 = from k in kampanieliste2
                join i in tildbud on k.J.Fk_Tilbud_ID equals i.Tilbud_ID
                select new {k, i};
            //  Console.WriteLine("3" + kampanieliste3);
            var kampanieliste4 = from k in kampanieliste3
                join v in Vare on k.i.Fk_Vare_ID equals v.Vare_ID
                where k.i.Start_Dato < DateTime.Now && k.i.Slut_Dato > DateTime.Now
                select
                new KampagneMedAltInfo(

                    v.Navn,
                    k.i.Pris,
                    k.k.k.t.Navn,
                    k.k.k.k.Navn,
                    k.i.Start_Dato,
                    k.i.Slut_Dato);
                

          
                return kampanieliste4;
               
        }

      
    }
}

