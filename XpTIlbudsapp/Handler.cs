//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace XpTIlbudsapp
//{
//    class Handler
//    {

//        public static void søgetilbud()

//        {


//            try
//            {
//                var tildbud = facade.GetListAsync(new Tilbud()).Result;
//                var kæde = facade.GetListAsync(new Kaede()).Result;
//                var Vare = facade.GetListAsync(new Vare()).Result;



//                Console.WriteLine("Skriv hele eller dele af varenavnet");
//                string søgeord = Console.ReadLine();

//                if (søgeord == null)
//                {
//                    søgeord = "";
//                }



//                var søgtevare = from v in Vare where (v.Navn.ToLower().Contains(søgeord)) select v;



//                var tilbudsliste = from s in søgtevare
//                                   join t in tildbud on s.Vare_ID equals t.Fk_Vare_ID
//                                   select new { s.Vare_ID, varenavn = s.Navn, t.Fk_Vare_ID, t.Fk_Kaede_ID, t.Pris, t.Slut_Dato, t.Start_Dato };

//                // Console.WriteLine(tilbudsliste.First());
//                var tilbudslistemedkæde = from t in tilbudsliste
//                                          join k in kæde on t.Fk_Kaede_ID equals k.Kaede_ID
//                                          where t.Start_Dato < DateTime.Now && t.Slut_Dato > DateTime.Now
//                                          select new { t.Pris, t.varenavn, k.Navn, t.Slut_Dato, t.Start_Dato };

//                foreach (var tilbud in tilbudslistemedkæde)
//                {
//                    Console.WriteLine("Varenavn: " + tilbud.varenavn + "\n" + "Pris: " + tilbud.Pris + "\n" + "Butik: " + tilbud.Navn + "\n" + "Fra og Med: " + tilbud.Start_Dato + "\n" + "Til og med: " + tilbud.Slut_Dato + "\n");
//                }





//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e + e.Message);
//            }

//        }

//        public static void søgekampagne()
//        {
//            var tildbud = facade.GetListAsync(new Tilbud()).Result;
//            var kæde = facade.GetListAsync(new Kaede()).Result;
//            var Vare = facade.GetListAsync(new Vare()).Result;
//            var Tilbudkampagne = facade.GetListAsync(new TilbudKampagne()).Result;
//            var kampagne = facade.GetListAsync(new Kampagne()).Result;


//            Console.WriteLine("Skriv hele eller dele af KampanieNavnet");
//            string søgeord = Console.ReadLine();


//            if (søgeord == null)
//            {
//                søgeord = "";
//            }

//            var søgtevare = from k in kampagne where (k.Navn.ToLower().Contains(søgeord)) select k;

//            var kampanieliste1 = from k in søgtevare
//                                 join t in kæde on k.Fk_kaede_ID equals t.Kaede_ID
//                                 select new { k, t };
//            //Console.WriteLine("1" + kampanieliste1);
//            var kampanieliste2 = from k in kampanieliste1
//                                 join J in Tilbudkampagne on k.k.Kampagne_ID equals J.Fk_Kampagne_ID
//                                 select new { k, J };
//            //Console.WriteLine("2" + kampanieliste2);
//            var kampanieliste3 = from k in kampanieliste2
//                                 join i in tildbud on k.J.Fk_Tilbud_ID equals i.Tilbud_ID
//                                 select new { k, i };
//            //  Console.WriteLine("3" + kampanieliste3);
//            var kampanieliste4 = from k in kampanieliste3
//                                 join v in Vare on k.i.Fk_Vare_ID equals v.Vare_ID
//                                 where k.i.Start_Dato < DateTime.Now && k.i.Slut_Dato > DateTime.Now
//                                 select
//                new
//                {
//                    VareNavn = v.Navn,
//                    Kædenavn = k.k.k.t.Navn,
//                    Kampagnenavn = k.k.k.k.Navn,
//                    k.i.Pris,
//                    Stardato = k.i.Start_Dato,
//                    Slutdato = k.i.Slut_Dato
//                };
//            Console.Clear();
//            List<string> kampanienavne = new List<string>();

//            foreach (var tilbud in kampanieliste4)
//            {
//                if (!kampanienavne.Contains(tilbud.Kædenavn))
//                {
//                    kampanienavne.Add(tilbud.Kædenavn);
//                }
//                Console.WriteLine("KampanieNavn: " + tilbud.Kampagnenavn + "\n" + "Varenavn: " + tilbud.VareNavn + "\n" + "Pris: " + tilbud.Pris + "\n" + "Butik: " + tilbud.Kædenavn + "\n" + "Fra og Med: " + tilbud.Stardato + "\n" + "Til og med: " + tilbud.Slutdato + "\n");
//            }












//        }
//    }
//}

