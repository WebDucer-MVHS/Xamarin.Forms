using Prism.Mvvm;
using RezepteApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace RezepteApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _zutat;
        public string Zutat
        {
            get => _zutat;
            set
            {
                if(SetProperty(ref _zutat, value))
                {
                    AddCommand.RaisCanExecuteChanged();
                }
            }
        }

        private double _menge;
        public double Menge
        {
            get => _menge;
            set => SetProperty(ref _menge, value);
        }

        private string _arbeitsSchritte;
        public string ArbeitsSchritte
        {
            get => _arbeitsSchritte;
            set => SetProperty(ref _arbeitsSchritte, value);
        }

        public DelegateCommand AddCommand { get; set; }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(Zutat);
        }

        private void Add()
        {
            Menge = Menge + 1;
        }

        public MainViewModel()
        {
            AddCommand = new DelegateCommand(Add, CanAdd);
        }
    }
}
