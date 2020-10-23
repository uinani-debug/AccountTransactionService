using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AccountLibrary.API.Entities
{
    public class AccountTransaction
    {
        public string Transaction_Date { get; set; }
        public decimal Transaction_Amount { get; set; }
        public string Transaction_Type { get; set; }
        public string transaction_towards { get; set; }
        public decimal Available_balance { get; set; }
    }
}
