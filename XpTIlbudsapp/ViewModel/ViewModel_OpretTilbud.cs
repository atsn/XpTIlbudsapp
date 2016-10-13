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
        public bool isrunning { get; set; }
        public ObservableCollection<VareMedTilbud> Tilbudsvarer { get; set; }
        public ObservableCollection<KampagneMedAltInfo> KampagneVare { get; set; }

        public static ObservableCollection<VareMedTilbud> Inkøbsliste { get; set; } =
            new ObservableCollection<VareMedTilbud>();

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

        public async void callsøgetilbud()
        {
            isrunning = true;
            try
            {
                IEnumerable<VareMedTilbud> Tilbudsvarerlist = await Handler.søgetilbud(Søgeord);
                foreach (var vareMedTilbud in Tilbudsvarerlist)
                {
                    Tilbudsvarer.Add(vareMedTilbud);
                }
                isrunning = false;
            }
            catch (Exception e)
            {
                MessageDialog message = new MessageDialog(e + e.Message);
                await message.ShowAsync();
                isrunning = false;
            }



        }

        public async void callsøgekæde()
        {
            try
            {
                isrunning = true;
                IEnumerable<VareMedTilbud> Tilbudsvarerlist = await Handler.søgeKæde(Søgeord);

                foreach (var vareMedTilbud in Tilbudsvarerlist)
                {
                    Tilbudsvarer.Add(vareMedTilbud);
                }
            }
            catch (Exception e)
            {

                MessageDialog message = new MessageDialog(e + e.Message);
                await message.ShowAsync();
                isrunning = false;
            }

        }

        public async void callsøgekampagne()
        {
            try
            {
                isrunning = true;
                IEnumerable<KampagneMedAltInfo> Tilbudsvarerlist = await Handler.søgekampagne(Søgeord);

                foreach (var vareMedTilbud in Tilbudsvarerlist)
                {
                    KampagneVare.Add(vareMedTilbud);
                }
            }
            catch (Exception e)
            {

                MessageDialog message = new MessageDialog(e + e.Message);
                await message.ShowAsync();
                isrunning = false;
            }

        }

        public async void addtilbudtoinkøbsliste()
        {
            try
            {
                isrunning = true;
                if (selectvare != null)
                {
                    Inkøbsliste.Add(selectvare);
                    await Persistency.PersistencyService.SaveNotesAsJsonAsync(Inkøbsliste);
                }

                else if (SelectetKampagne != null)
                {
                    Inkøbsliste.Add(new VareMedTilbud(SelectetKampagne.Pris, SelectetKampagne.Varenavn,
                        SelectetKampagne.kædenavn, SelectetKampagne.Startdate, SelectetKampagne.SlutDate));
                    await Persistency.PersistencyService.SaveNotesAsJsonAsync(Inkøbsliste);

                }
                else
                {
                    MessageDialog message = new MessageDialog("Vælg venligst vare");
                    await message.ShowAsync();
                }
                isrunning = false;
            }
            catch (Exception e)
            {
                MessageDialog message = new MessageDialog(e + e.Message);
                await message.ShowAsync();
                isrunning = false;
            }
        }

        public async void beregntotal()
        {
            isrunning = true;
            try
            {
                foreach (var Varer in Inkøbsliste)
                {
                    TotalIndkøbsliste = TotalIndkøbsliste + Varer.Pris;
                }
                isrunning = false;
            }
            
            catch (Exception e)
            {
                MessageDialog message = new MessageDialog(e + e.Message);
                await message.ShowAsync();
                isrunning = false;
            }

        }

    }
}
}






