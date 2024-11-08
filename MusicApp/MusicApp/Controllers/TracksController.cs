using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class TracksController : Controller
    {
        // Reference to a manager object
        private Manager m = new Manager();

        // GET: Tracks (Get All)
        public ActionResult Index()
        {
            var tracks = m.TrackGetAllWithDetail().OrderBy(t => t.Name);
            return View(tracks);
        }

        // GET: Track/Details/5
        public ActionResult Details(int id)
        {
            var track = m.TrackGetById(id);
            if (track == null) return HttpNotFound();
            return View(track);
        }

        // GET: Track/Add
        public ActionResult Add()
        {
            var form = new TrackAddFormViewModel
            {
                AlbumList = new SelectList(m.AlbumGetAll(), "AlbumId", "Title"),
                MediaTypeList = new SelectList(m.MediaTypeGetAll(), "MediaTypeId", "Name")
            };
            return View(form);
        }

        // POST: Track/Add
        [HttpPost]
        public ActionResult Add(TrackAddViewModel newTrack)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newTrack);
            }

            // Process the input if valid
            var addedTrack = m.TrackAdd(newTrack);
            if (addedTrack == null)
            {
                return View(newTrack);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedTrack.TrackId });
            }
        }
    }
}
