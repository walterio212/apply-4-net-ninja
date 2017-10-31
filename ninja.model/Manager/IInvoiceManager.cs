using System.Collections.Generic;
using ninja.model.Entity;

namespace ninja.model.Manager
{
    public interface IInvoiceManager
    {
        void Delete(long id);
        bool Exists(long id);
        IList<Invoice> GetAll();
        Invoice GetById(long id);
        void Insert(Invoice item);
        void UpdateDetail(long id, IList<InvoiceDetail> detail);
    }
}