using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace XpTIlbudsapp.ViewModel
{
    class ViewModel_OpretTilbud
    {

        public ObservableCollection<VareMedTilbud> Tilbudsvarer  { get; set; }
        public ObservableCollection<KampagneMedAltInfo> KampagneVare { get; set; }
        public RelayCommand SøgKædeCommand { get; set; }
        public RelayCommand SøgKampagneCommand { get; set; }
        public RelayCommand SøgTilbudCommand { get; set; }
        public string Søgeord { get; set; }

        public ViewModel_OpretTilbud()
        {
            Tilbudsvarer = new ObservableCollection<VareMedTilbud>();
            KampagneVare = new ObservableCollection<KampagneMedAltInfo>();
            SøgKædeCommand = new RelayCommand(callsøgekæde);
            SøgKampagneCommand = new RelayCommand(callsøgekampagne);
            SøgTilbudCommand = new RelayCommand(callsøgetilbud);
        }

        public void callsøgetilbud()
        {
            IEnumerable<VareMedTilbud> Tilbudsvarerlist = Handler.søgetilbud(Søgeord);

            foreach (var vareMedTilbud in Tilbudsvarerlist)
            {
                Tilbudsvarer.Add(vareMedTilbud);
            }
        }

        public void callsøgekæde()
        {
            IEnumerable<VareMedTilbud> Tilbudsvarerlist = Handler.søgeKæde(Søgeord);

            foreach (var vareMedTilbud in Tilbudsvarerlist)
            {
                Tilbudsvarer.Add(vareMedTilbud);
            }
        }

        public void callsøgekampagne()
        {
            IEnumerable<KampagneMedAltInfo> Tilbudsvarerlist = Handler.søgekampagne(Søgeord);

            foreach (var vareMedTilbud in Tilbudsvarerlist)
            {
                KampagneVare.Add(vareMedTilbud);
            }
        }
    }




    }
}
