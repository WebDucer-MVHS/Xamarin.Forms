using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RezepteApp.Models;
using RezepteApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RezepteApp.ViewModels
{
    public class ReceiptListViewModel : BindableBase, INavigatedAware
    {
        private readonly IReceiptRepo _repo;
        private readonly INavigationService _navService;

        public ReceiptListViewModel(IReceiptRepo repo, INavigationService navigationService)
        {
            if (repo == null)
            {
                throw new ArgumentNullException(nameof(repo));
            }

            // Initialisierung des Repositories
            _repo = repo;
            _navService = navigationService;

            SearchCommand = new DelegateCommand(async () => await Search());
            SearchCommand.ObservesProperty(() => SearchTerm);

            AddNewCommand = new DelegateCommand(async () => await AddNew());

            EditCommand = new DelegateCommand<Receipt>(async receipt => await Edit(receipt));
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private DelegateCommand _searchCommand;
        public DelegateCommand SearchCommand
        {
            get => _searchCommand;
            set => SetProperty(ref _searchCommand, value);
        }

        private async Task Search()
        {
            if (IsLoading)
            {
                return;
            }

            IsLoading = true;
            // Prüfen, dass die Suche durchgeführt werden darf
            if ((SearchTerm?.Length ?? 0) < 3)
            {
                return;
            }

            var receipts = await _repo.FindReceiptsAsync(SearchTerm);

            ReceiptList = receipts.ToList();

            IsLoading = false;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // Not needed
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // Laden der Daten
            LoadData();
        }

        private async Task LoadData()
        {
            IsLoading = true;

            try
            {
                var favorites = await _repo.GetFavoritesAsync();
                ReceiptList = favorites.ToList();
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            IsLoading = false;
        }

        private List<Receipt> _receiptList;
        public List<Receipt> ReceiptList
        {
            get => _receiptList;
            set => SetProperty(ref _receiptList, value);
        }

        public DelegateCommand AddNewCommand { get; }

        private async Task AddNew()
        {
            // Navigierenzu Details
            await _navService.NavigateAsync(nameof(MainPage));
        }

        public DelegateCommand<Receipt> EditCommand { get; }

        private async Task Edit(Receipt receipt)
        {
            // Navigeieren zu details
            NavigationParameters parameter = new NavigationParameters();
            parameter.Add("ID", receipt.Id);
            await _navService.NavigateAsync(nameof(MainPage), parameter);
        }

        public Receipt Receipt
        {
            get => null;
            set
            {
                Edit(value);
            }
        }
    }
}
