using System;
using System.Collections.Generic;
using System.Text;

namespace RezepteApp.Models
{
    public class ApiReceipt
    {
        public int RezeptID { get; set; }

        public string RezeptName { get; set; }

        public string RezeptBild { get; set; }
    }

    public class ReceiptResult
    {
        public ApiReceipt[] result { get; set; }
    }
}
