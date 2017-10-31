using ninja.model.Entity;
using ninja.model.Manager;
using ninja.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using System.Linq;

namespace ninja.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceManager invoiceManager;

        public InvoiceController()
        {
            invoiceManager = new InvoiceManager();
        }

        public ActionResult Index()
        {
            IList<Invoice> invoices = invoiceManager.GetAll();
            IList<InvoiceModel> invoicesModel = MapInvoiceList(invoices);
            return View(invoicesModel);
        }

        public ActionResult Detail(long id)
        {
            Invoice invoice = this.invoiceManager.GetById(id);

            InvoiceModel model = this.MapInvoice(invoice);

            return View(model);
        }

        public ActionResult New()
        {
            var model = new InvoiceCrearModel();

            model.Types = new List<SelectListItem> {
                new SelectListItem{
                    Text = Invoice.Types.A.ToString(),
                    Value = Invoice.Types.A.ToString(),
                },
                new SelectListItem{
                    Text = Invoice.Types.B.ToString(),
                    Value = Invoice.Types.B.ToString(),
                },
                new SelectListItem{
                    Text = Invoice.Types.C.ToString(),
                    Value = Invoice.Types.C.ToString(),
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult New(InvoiceCrearModel model)
        {
            Invoice nuevoInvoice = this.MapModelNew(model);
            this.invoiceManager.Insert(nuevoInvoice);
            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            Invoice invoice = this.invoiceManager.GetById(id);
            InvoiceCrearModel model = new InvoiceCrearModel
            {
                Type = invoice.Type,
                Id = invoice.Id,
                Details = new List<InvoiceDetailCrearModel>()
            };

            return View(model);
        }

        public ActionResult AddDetail()
        {
            return PartialView("PartialUpdate", new InvoiceDetailCrearModel());
        }

        [HttpPost]
        public ActionResult Update(InvoiceCrearModel model)
        {
            if (ModelState.IsValid) { 
                IList<InvoiceDetail> details = MapModelDetails(model.Id, model.Details);
                this.invoiceManager.UpdateDetail(model.Id, details);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        private IList<InvoiceDetail> MapModelDetails(long invoiceId, IList<InvoiceDetailCrearModel> details)
        {
            var invoiceDetails = new List<InvoiceDetail>();

            foreach (InvoiceDetailCrearModel detailCrearModel in details)
            {
                invoiceDetails.Add(new InvoiceDetail
                {
                    Amount = detailCrearModel.Amount,
                    Description = detailCrearModel.Description,
                    InvoiceId = invoiceId,
                    UnitPrice = detailCrearModel.UnitPrice
                });
            }

            return invoiceDetails;
        }

        public ActionResult Delete(long id)
        {
            this.invoiceManager.Delete(id);

            return View();
        }

        private IList<InvoiceModel> MapInvoiceList(IList<Invoice> invoices)
        {
            var invoicesModel = new List<InvoiceModel>();

            foreach (Invoice invoice in invoices)
            {
                invoicesModel.Add(
                    MapInvoice(invoice)
                );
            }

            return invoicesModel;
        }


        private InvoiceModel MapInvoice(Invoice invoice)
        {
            var model = new InvoiceModel
            {
                Id = invoice.Id,
                Type = invoice.Type,
                PriceWithTaxes = invoice.CalculateInvoiceTotalPriceWithTaxes(),
                Details = MapInvoiceDetailList(invoice.GetDetail())
            };
            
            return model;
        }

        private IList<InvoiceDetailModel> MapInvoiceDetailList(IList<InvoiceDetail> details)
        {
            var detailsModel = new List<InvoiceDetailModel>();

            foreach (InvoiceDetail invoiceDetail in details)
            {
                detailsModel.Add(new InvoiceDetailModel
                {
                    Id = invoiceDetail.Id,
                    Amount = invoiceDetail.Amount,
                    Description = invoiceDetail.Description,
                    UnitPrice = invoiceDetail.UnitPrice,
                    InvoiceId = invoiceDetail.InvoiceId,
                    TotalPrice = invoiceDetail.TotalPrice,
                    TotalPriceWithTaxes = invoiceDetail.TotalPriceWithTaxes
                });
            }

            return detailsModel;
        }

        private Invoice MapModelNew(InvoiceCrearModel model) {
            var invoice = new Invoice();

            invoice.Type = model.Type;
            invoice.Id = this.invoiceManager.GetAll()
                .OrderByDescending(x => x.Id)
                .Select(x => x.Id).FirstOrDefault() + 1;

            return invoice;
        }
    }
}