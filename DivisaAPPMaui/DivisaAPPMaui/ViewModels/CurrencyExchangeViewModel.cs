using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DivisaAPPMaui.ViewModels
{
    class CurrencyExchangeViewModel : INotifyPropertyChanged  
    {
        private string _USDvalue;
        private string _EUROValue;

        public string USDValue
        {
            get => _USDvalue;
            set
            {
                if (USDValue != value)
                {
                    _USDvalue = value;
                    OnPropertyChanged();
                    ConvertUSDtoEURO(); 
                }
            }
        }

        public string EUROValue
        {
            get => _EUROValue;
            set
            {
                if (EUROValue != value)
                {
                    _EUROValue = value;
                    OnPropertyChanged();
                    
                }
            }
        }

        public ICommand ShowResultsCommand { get; set; }

        public CurrencyExchangeViewModel()
        {
            ShowResultsCommand = new Command(async() => await ShowResults());
        }

        public async Task ShowResults()
        {
            USDValue = "0";
            EUROValue = "0";
        }





        public void ConvertUSDtoEURO()
        { 
            var EuroValue = Double.Parse(_USDvalue) * 0.85;
            EUROValue = EuroValue.ToString();
        }

        

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
