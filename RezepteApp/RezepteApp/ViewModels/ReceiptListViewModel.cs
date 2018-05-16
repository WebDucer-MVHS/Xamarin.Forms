using Prism.Commands;
using Prism.Mvvm;
using RezepteApp.Models;
using RezepteApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RezepteApp.ViewModels
{
    public class ReceiptListViewModel : BindableBase
    {
        private readonly IReceiptRepo _repo;

        public ReceiptListViewModel(IReceiptRepo repo)
        {
            // Initialisierung des Repositories
            _repo = repo;

            SearchCommand = new DelegateCommand(async () => await Search());
            SearchCommand.ObservesProperty(() => SearchTerm);

            ReceiptList = new List<Receipt>
            {
                new Receipt
                {
                    Title = "Rezept 1",
                    IsFavorit = false
                },
                new Receipt
                {
                    Title = "Rezept 2",
                    IsFavorit = false
                },
                new Receipt
                {
                    Title = "Rezept 3",
                    IsFavorit = true
                },
                new Receipt
                {
                    Title = "Rezept 4",
                    IsFavorit = false
                }
            };
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

        //private Task Search()
        //{
        //    // Prüfen, dass die Suche durchgeführt werden darf
        //    if ((SearchTerm?.Length ?? 0) < 3)
        //    {
        //        return Task.CompletedTask;
        //    }

        //    return _repo.FindReceiptsAsync(SearchTerm)
        //        .ContinueWith(t =>
        //        {
        //            ReceiptList = t.Result.ToList();
        //        }, TaskScheduler.FromCurrentSynchronizationContext);
        //}

        //private void Search()
        //{
        //    // Prüfen, dass die Suche durchgeführt werden darf
        //    if ((SearchTerm?.Length ?? 0) < 3)
        //    {
        //        return;
        //    }

        //    // Möglicher Deadlock
        //    //var receipts = _repo.FindReceiptsAsync(SearchTerm).Result;

        //    // Teuere Lösung
        //    var receipts = Task.Run(async () => await _repo.FindReceiptsAsync(SearchTerm)).Result;

        //    ReceiptList = receipts.ToList();
        //}

        private List<Receipt> _receiptList;
        public List<Receipt> ReceiptList
        {
            get => _receiptList;
            set => SetProperty(ref _receiptList, value);
        }
    }
}
