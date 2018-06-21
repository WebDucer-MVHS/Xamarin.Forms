using System;
using System.Collections.Generic;
using System.Text;

namespace RezepteApp.Services
{
    public interface IPathService
    {
        string GetDbPath(string dbName);
    }
}
