using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class TrackAddViewModel : TrackBaseViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please select an album.")]
        public int AlbumId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a media type.")]
        public int MediaTypeId { get; set; }
    }
}