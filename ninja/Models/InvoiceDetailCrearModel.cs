using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ninja.Models
{
    public class InvoiceDetailCrearModel
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public double UnitPrice { get; set; }
    }
}