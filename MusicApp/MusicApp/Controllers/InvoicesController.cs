using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class InvoicesController : Controller
    {
        private Manager m = new Manager();

        // GET: Invoices
        public ActionResult Index()
        {
            // Get all invoices
            var invoices = m.InvoiceGetAll();
            return View(invoices);
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int id)
        {
            // Get the invoice by id with details
            var invoice = m.InvoiceGetByIdWithDetail(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }
    }
}
