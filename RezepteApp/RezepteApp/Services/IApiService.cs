using RezepteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RezepteApp.Services
{
    public interface IApiService
    {
        Task<IEnumerable<ApiReceipt>> SearchReceiptsAsync(string searchTerm);
    }
}
