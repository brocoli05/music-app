using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class ArtistController : Controller
    {
        // Reference to a manager object
        private Manager m = new Manager();

        // GET: Artist
        public ActionResult Index()
        {
            var artists = m.ArtistGetAll().OrderBy(a => a.Name);
            return View(artists);
        }
    }
}
