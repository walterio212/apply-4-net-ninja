using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ninja.Models
{
    public class InvoiceCrearModel
    {
        public string Type { get; set; }
        
        public IList<SelectListItem> Types { get; set; }

        public long Id { get; set; }

        public IList<InvoiceDetailCrearModel> Details { get; set; }
    }
}