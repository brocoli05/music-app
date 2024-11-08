using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class AlbumController : Controller
    {
        // Reference to a manager object
        private Manager m = new Manager();

        // GET: Album
        public ActionResult Index()
        {
            var albums = m.AlbumGetAll().OrderBy(a => a.Title);
            return View(albums);
        }
    }
}
