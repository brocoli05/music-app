using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class InvoiceLineWithDetailViewModel : InvoiceLineBaseViewModel
    {
        [Display(Name = "Name")]
        public string TrackName { get; set; }

        [Display(Name = "Composer(s)")]
        public string TrackComposer { get; set; }

        // Album details
        [Display(Name = "Album Title")]
        public string AlbumTitle { get; set; }

        // Artist details
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        // Genre details
        [Display(Name = "Genre")]
        public string GenreName { get; set; }

        // MediaType details
        [Display(Name = "Media Type")]
        public string MediaTypeName { get; set; }
    }
}