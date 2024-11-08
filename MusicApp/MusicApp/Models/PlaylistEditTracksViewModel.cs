using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class PlaylistEditTracksViewModel
    {
        public PlaylistEditTracksViewModel()
        {
            TrackIds = new List<int>();
        }

        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        // List of selected track IDs from the form
        public IEnumerable<int> TrackIds { get; set; }
    }
}