using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class PlaylistController : Controller
    {
        // Reference to a manager object
        private Manager m = new Manager();

        // GET: Playlist
        public ActionResult Index()
        {
            var playlists = m.PlaylistGetAll().OrderBy(p => p.Name);
            return View(playlists);
        }

        // GET: Playlist/Details/5
        public ActionResult Details(int? id)
        {
            var playlist = m.PlaylistGetById(id.GetValueOrDefault());
            if (playlist == null)
            {
                return HttpNotFound();
            }
            else
            {
                var tracks = playlist.Tracks.OrderBy(t => t.Name);
                playlist.Tracks = tracks;

                return View(playlist);
            }            
        }

        // GET: Playlist/Edit/5
        public ActionResult EditPlaylist(int? id)
        {
            var o = m.PlaylistGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Create a form, based on the fetched matching object
                var form = m.mapper.Map<PlaylistWithTracksViewModel, PlaylistEditTracksFormViewModel >(o);

                // For the multi select list, configure the "selected" items
                // Notice the use of the Select() method, 
                // which allows us to select/return/use only some properties from the source
                var selectedValues = o.Tracks.Select(t => t.TrackId);
                form.Tracks = o.Tracks.OrderBy(t => t.Name);
                // For clarity, use the named parameter feature of C#
                form.TrackList = new MultiSelectList
                    (items: m.TrackGetAllWithDetail(),
                    dataValueField: "TrackId",
                    dataTextField: "NameFull",
                    selectedValues: selectedValues);

                return View(form);
            }         
        }

        // POST: Playlist/EditPlaylist/5
        [HttpPost]
        public ActionResult EditPlaylist(int? id, PlaylistEditTracksViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = newItem.PlaylistId });
            }

            if (id.GetValueOrDefault() != newItem.PlaylistId)
            {
                return RedirectToAction("Index");
            }

            //Attempt to do the update
            try
            {
                var editedItem = m.PlaylistEditTracks(newItem);
                return RedirectToAction("Details", new { id = newItem.PlaylistId });
            }
            catch
            {
                return RedirectToAction("Edit", new { id = newItem.PlaylistId });

            }
        }
    }
}
