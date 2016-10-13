using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
using Windows.UI.Popups;

namespace XpTIlbudsapp.ViewModel
{
    class ViewModel_OpretTilbud
    {

        public ObservableCollection<VareMedTilbud> Tilbudsvarer { get; set; }
        public ObservableCollection<KampagneMedAltInfo> KampagneVare { get; set; }
        public static ObservableCollection<VareMedTilbud> Inkøbsliste { get; set; } = new ObservableCollection<VareMedTilbud>();

        public VareMedTilbud selectvare { get; set; }
        public KampagneMedAltInfo SelectetKampagne { get; set; }
        public RelayCommand SøgKædeCommand { get; set; }
        public RelayCommand SøgKampagneCommand { get; set; }
        public RelayCommand SøgTilbudCommand { get; set; }
        public string Søgeord { get; set; }
        public int TotalIndkøbsliste { get; set; }
        public RelayCommand AddtilbudtoinkøbslisteCommand { get; set; }
        public RelayCommand BeregnTotalCommand { get; set; }
        public ViewModel_OpretTilbud()
        {
            Tilbudsvarer = new ObservableCollection<VareMedTilbud>();
            KampagneVare = new ObservableCollection<KampagneMedAltInfo>();
            SøgKædeCommand = new RelayCommand(callsøgekæde);
            SøgKampagneCommand = new RelayCommand(callsøgekampagne);
            SøgTilbudCommand = new RelayCommand(callsøgetilbud);
            AddtilbudtoinkøbslisteCommand = new RelayCommand(addtilbudtoinkøbsliste);
            BeregnTotalCommand = new RelayCommand(beregntotal);
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

        public void addtilbudtoinkøbsliste()
        {
            if (selectvare != null)
            {
                Inkøbsliste.Add(selectvare);
            }

            else if (SelectetKampagne != null)
            {
                Inkøbsliste.Add(new VareMedTilbud(SelectetKampagne.Pris, SelectetKampagne.Varenavn,
                    SelectetKampagne.kædenavn, SelectetKampagne.Startdate, SelectetKampagne.SlutDate));


            }
            else
            {
                MessageDialog message = new MessageDialog("Vælg venligst vare");
                message.ShowAsync();
            }
        }

        public void beregntotal()
        {
            foreach (var Varer in Inkøbsliste)
            {
                TotalIndkøbsliste = TotalIndkøbsliste + Varer.Pris;

            }
        }
    }
}






