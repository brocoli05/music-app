using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class AlbumBaseViewModel
    {
        [Key]
        [Required]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Album title")]
        public string Title { get; set; }

        [Display(Name = "Artist Id")]
        public int ArtistId { get; set; }
    }
}