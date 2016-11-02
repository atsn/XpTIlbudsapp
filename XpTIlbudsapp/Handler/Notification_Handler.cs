using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.System.Threading;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace XpTIlbudsapp
{
    class Notification_Handler
    {
        
        TimeSpan period = TimeSpan.FromHours(1);


        private IEnumerable<Vare> Ønskeliste;
        #region 

        private static Notification_Handler _instance;

       

        public static Notification_Handler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Notification_Handler();
                }
                return _instance;
            }
        }

        #endregion

     

        

        public Notification_Handler()
        {
         
             notification();
             
        }


        public async void notification()
        {
            while (true)
            {
                Ønskeliste = await Persistency.PersistencyService2.LoadNotesFromJsonAsync();

                if (Ønskeliste != null)
                {

                    var tilbud = await facade.GetListAsync(new Tilbud());

                    var kaede = await facade.GetListAsync(new Kaede());

                    var tilbudmedkaede = from s in kaede
                                         join t in tilbud on s.Kaede_ID equals t.Fk_Kaede_ID
                                         select
                                         new { s.Navn, t.Fk_Vare_ID, t.Fk_Kaede_ID, t.Pris, t.Slut_Dato, t.Start_Dato };


                    foreach (var vare in Ønskeliste)
                    {

                        foreach (var vare1 in tilbudmedkaede)
                        {


                            if (vare1.Fk_Vare_ID.Equals(vare.Vare_ID) && vare.HasBeenNotified.Equals(false))
                            {



                                MessageDialog message = new MessageDialog("Vare er nu på tilbud: " + vare.Navn + vare1.Pris + vare1.Navn);
                                await message.ShowAsync();

                                vare.HasBeenNotified = true;

                               await Persistency.PersistencyService2.SaveNotesAsJsonAsync(Ønskeliste as ObservableCollection<Vare>);
                            }

                            

                        }


                    }
                }



            //   await Task.Delay(300000);
                await Task.Delay(30000);
            }
           

        }
        

    }
}
