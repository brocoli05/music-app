using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Models
{
    public class PlaylistEditTracksFormViewModel : PlaylistEditTracksViewModel
    {
        public PlaylistEditTracksFormViewModel()
        {
            Tracks = new List<TrackBaseViewModel>();
        }

        public int TracksCount { get; set; }

        // SelectList for all tracks (to render as checkboxes)
        [Display(Name = "Tracks")]
        public MultiSelectList TrackList { get; set; }

        // List of tracks already in the playlist
        public IEnumerable<TrackBaseViewModel> Tracks;
    }
}