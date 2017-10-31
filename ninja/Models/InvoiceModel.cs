using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ninja.Models
{
    public class InvoiceModel
    {
        public long Id { get; set; }

        public string Type { get; set; }

        public double PriceWithTaxes { get; set; }

        public IList<InvoiceDetailModel> Details { get; set; }
    }
}