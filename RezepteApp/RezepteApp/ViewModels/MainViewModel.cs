using Prism.Mvvm;
using Prism.Navigation;
using RezepteApp.Commands;
using RezepteApp.Models;
using RezepteApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RezepteApp.ViewModels
{
    public class MainViewModel : BindableBase, INavigatedAware
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
        private readonly IReceiptRepo _repo;

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

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("ID"))
            {
                var id = parameters.GetValue<int>("ID");

                LoadData(id);
            }
        }

        private async Task LoadData(int id)
        {
            try
            {
                Receipt receipt = await _repo.GetReceiptByIdAsync(id);

                Zutat = receipt.Ingredient;
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public MainViewModel(IReceiptRepo repo)
        {
            AddCommand = new DelegateCommand(Add, CanAdd);
            _repo = repo;
        }
    }
}
