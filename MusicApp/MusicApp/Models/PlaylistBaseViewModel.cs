using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MusicApp.Models
{
    public class PlaylistBaseViewModel
    {
        [Key]
        [Required]
        public int PlaylistId { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Playlist Name")]
        public string Name { get; set; }

        // New property for counting the number of tracks
        [Display(Name = "Playlist Track Count")]
        public int TracksCount { get; set; }
    }
}