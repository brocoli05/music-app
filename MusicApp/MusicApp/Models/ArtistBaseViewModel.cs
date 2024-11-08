using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class ArtistBaseViewModel
    {
        [Key]
        [Required]
        public int ArtistId { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Artist name")]
        public string Name { get; set; }
    }
}