﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ninja.model.Entity;
using ninja.model.Manager;

namespace ninja.test {

    [TestClass]
    public class TestInvoice {

        [TestMethod]
        public void InsertNewInvoice() {

            InvoiceManager manager = new InvoiceManager();
            long id = 1006;
            Invoice invoice = new Invoice() {
                Id = id,
                Type = Invoice.Types.A.ToString()
            };

            manager.Insert(invoice);
            Invoice result = manager.GetById(id);

            Assert.AreEqual(invoice, result);

        }

        [TestMethod]
        public void InsertNewDetailInvoice() {

            InvoiceManager manager = new InvoiceManager();
            long id = 1006;
            Invoice invoice = new Invoice() {
                Id = id,
                Type = Invoice.Types.A.ToString()
            };

            invoice.AddDetail(new InvoiceDetail() {
                Id = id,
                InvoiceId = id,
                Description = "Venta insumos varios",
                Amount = 14,
                UnitPrice = 4.33
            });

            invoice.AddDetail(new InvoiceDetail() {
                Id = id,
                InvoiceId = 6,
                Description = "Venta insumos tóner",
                Amount = 5,
                UnitPrice = 87
            });

            manager.Insert(invoice);
            Invoice result = manager.GetById(id);

            Assert.AreEqual(invoice.Id, result.Id);

        }

        [TestMethod]
        public void DeleteInvoice() {

            /*
              1- Eliminar la factura con id=4
              2- Comprobar de que la factura con id=4 ya no exista
              3- La prueba tiene que mostrarse que se ejecuto correctamente
            */

            #region Escribir el código dentro de este bloque
            InvoiceManager manager = new InvoiceManager();

            manager.Delete(4);

            Invoice result = manager.GetById(4);

            Assert.IsNull(result);
            #endregion Escribir el código dentro de este bloque

        }

        [TestMethod]
        public void UpdateInvoiceDetail() {

            long id = 1003;
            InvoiceManager manager = new InvoiceManager();
            IList<InvoiceDetail> detail = new List<InvoiceDetail>();

            detail.Add(new InvoiceDetail() {
                Id = 1,
                InvoiceId = id,
                Description = "Venta insumos varios",
                Amount = 14,
                UnitPrice = 4.33
            });

            detail.Add(new InvoiceDetail() {
                Id = 2,
                InvoiceId = id,
                Description = "Venta insumos tóner",
                Amount = 5,
                UnitPrice = 87
            });

            manager.UpdateDetail(id, detail);
            Invoice result = manager.GetById(id);

            Assert.AreEqual(2, result.GetDetail().Count());

        }

        [TestMethod]
        public void CalculateInvoiceTotalPriceWithTaxes() {

            long id = 1005;
            InvoiceManager manager = new InvoiceManager();
            Invoice invoice = manager.GetById(id);

            double sum = 0;
            foreach(InvoiceDetail item in invoice.GetDetail()) 
                sum += item.TotalPrice * item.Taxes;

            Assert.AreEqual(sum, invoice.CalculateInvoiceTotalPriceWithTaxes());

        }

    }

}