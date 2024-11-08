using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class PlaylistWithTracksViewModel : PlaylistBaseViewModel
    {
        public PlaylistWithTracksViewModel()
        {
            Tracks = new List<TrackBaseViewModel>();
        }

        // List of selected track IDs from the form
        [Display(Name = "Tracks on the playlist")]
        public IEnumerable<TrackBaseViewModel> Tracks { get; set; }
    }
}