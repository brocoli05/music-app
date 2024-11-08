using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class MediaTypeBaseViewModel
    {
        [Key]
        [Required]
        public int MediaTypeId { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Media type")]
        public string Name { get; set; }
    }
}