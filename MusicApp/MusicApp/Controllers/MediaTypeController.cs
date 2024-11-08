using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class MediaTypeController : Controller
    {
        // Reference to a manager object
        private Manager m = new Manager();

        // GET: MediaType
        public ActionResult Index()
        {
            var mediaTypes = m.MediaTypeGetAll().OrderBy(m => m.Name);
            return View(mediaTypes);
        }
    }
}
