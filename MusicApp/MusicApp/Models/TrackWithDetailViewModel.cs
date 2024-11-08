using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        [Display(Name = "Album title")]
        public string AlbumTitle { get; set; }

        [Display(Name = "Artist name")]
        public string AlbumArtistName { get; set; }

        [Display(Name = "Media type")]
        public MediaTypeBaseViewModel MediaType { get; set; }

        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }
    }
}