using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpTIlbudsapp
{
    class Notification_Handler
    {
        /// </summary>
        #region 

        private static Notification_Handler _instance;

        private IEnumerable<Vare> varelistevirkerikkesomønskeliste;

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
          
        }


        public async void notification()
        {
            varelistevirkerikkesomønskeliste = await Persistency.PersistencyService2.LoadNotesFromJsonAsync();
        }
        

    }
}
