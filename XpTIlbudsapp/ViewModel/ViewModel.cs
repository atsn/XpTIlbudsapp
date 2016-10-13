using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
using Windows.UI.Popups;
using XpTIlbudsapp.Annotations;

namespace XpTIlbudsapp.ViewModel 
{
    class ViewModel : INotifyPropertyChanged
    {
        private bool _isrunning;
        private ObservableCollection<VareMedTilbud> _tilbudsvarer;
        private ObservableCollection<KampagneMedAltInfo> _kampagneVare;
        private VareMedTilbud _selectvare;
        private KampagneMedAltInfo _selectetKampagne;
        private RelayCommand _søgKædeCommand;
        private RelayCommand _søgKampagneCommand;
        private RelayCommand _søgTilbudCommand;
        private string _søgeord;
        private double _totalIndkøbsliste;
        private RelayCommand _addtilbudtoinkøbslisteCommand;
        private RelayCommand _beregnTotalCommand;
        private static ObservableCollection<VareMedTilbud> _inkøbsliste = new ObservableCollection<VareMedTilbud>();

        public bool isrunning
        {
            get { return _isrunning; }
            set { _isrunning = value; OnPropertyChanged();}
        }

        public ObservableCollection<VareMedTilbud> Tilbudsvarer
        {
            get { return _tilbudsvarer; }
            set { _tilbudsvarer = value; OnPropertyChanged(); }
        }

        public ObservableCollection<KampagneMedAltInfo> KampagneVare
        {
            get { return _kampagneVare; }
            set { _kampagneVare = value; OnPropertyChanged(); }
        }

        public static ObservableCollection<VareMedTilbud> Inkøbsliste
        {
            get { return _inkøbsliste; }
            set { _inkøbsliste = value; }
        }

        public VareMedTilbud selectvare
        {
            get { return _selectvare; }
            set { _selectvare = value; OnPropertyChanged(); }
        }

        public KampagneMedAltInfo SelectetKampagne
        {
            get { return _selectetKampagne; }
            set { _selectetKampagne = value; OnPropertyChanged(); }
        }

        public RelayCommand SøgKædeCommand
        {
            get { return _søgKædeCommand; }
            set { _søgKædeCommand = value; OnPropertyChanged(); }
        }

        public RelayCommand SøgKampagneCommand
        {
            get { return _søgKampagneCommand; }
            set { _søgKampagneCommand = value; OnPropertyChanged(); }
        }

        public RelayCommand SøgTilbudCommand
        {
            get { return _søgTilbudCommand; }
            set { _søgTilbudCommand = value; OnPropertyChanged(); }
        }

        public string Søgeord
        {
            get { return _søgeord; }
            set { _søgeord = value; OnPropertyChanged(); }
        }

        public double TotalIndkøbsliste
        {
            get { return _totalIndkøbsliste; }
            set { _totalIndkøbsliste = value; OnPropertyChanged(); }
        }

        public RelayCommand AddtilbudtoinkøbslisteCommand
        {
            get { return _addtilbudtoinkøbslisteCommand; }
            set { _addtilbudtoinkøbslisteCommand = value; OnPropertyChanged(); }
        }

        public RelayCommand BeregnTotalCommand
        {
            get { return _beregnTotalCommand; }
            set { _beregnTotalCommand = value; OnPropertyChanged(); }
        }

        public ViewModel()
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}







