using Prism.Commands;
using Prism.Mvvm;
using RezepteApp.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace RezepteApp.ViewModels
{
    public class ReceiptListViewModel : BindableBase
    {
        public ReceiptListViewModel()
        {
            SearchCommand = new DelegateCommand(Search);
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

        private DelegateCommand _searchCommand;
        public DelegateCommand SearchCommand
        {
            get => _searchCommand;
            set => SetProperty(ref _searchCommand, value);
        }

        private void Search()
        {
            // Prüfen, dass die Suche durchgeführt werden darf
            if ((SearchTerm?.Length ?? 0) < 3)
            {
                return;
            }

            Debug.WriteLine("Ich suche");
        }

        private List<Receipt> _receiptList;
        public List<Receipt> ReceiptList
        {
            get => _receiptList;
            set => SetProperty(ref _receiptList, value);
        }
    }
}
