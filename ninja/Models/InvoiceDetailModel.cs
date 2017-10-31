using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ninja.Models
{
    public class InvoiceDetailModel
    {
        public long InvoiceId { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public double TotalPriceWithTaxes { get; set; }
    }
}