using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MusicApp.Models
{
    public class TrackBaseViewModel
    {
        [Key]
        [Required]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Length(ms)")]
        public int Milliseconds { get; set; }

        [Range(0.0, 1000.0)]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        // Composed read-only property to display full name
        public string NameFull
        {
            get
            {
                var ms = Math.Round((((double)Milliseconds / 1000) / 60), 1);
                var composer = string.IsNullOrEmpty(Composer) ? "" : ", composer " + Composer; 
                var trackLength = (ms > 0) ? ", " + ms.ToString() + " minutes" : ""; 
                var unitPrice = (UnitPrice > 0) ? ", $ " + UnitPrice.ToString() : "";
                return string.Format("{0}{1}{2}{3}", Name, composer, trackLength, unitPrice);
            }
        }
        // Composed read-only property to display short name
        public string NameShort
        {
            get 
            {
                var ms = Math.Round((((double)Milliseconds / 1000) / 60), 1); 
                var trackLength = (ms > 0) ? ms.ToString() + " minutes" : ""; 
                var unitPrice = (UnitPrice > 0) ? " $ " + UnitPrice.ToString() : "";
                return string.Format("{0} - {1} - {2}", Name, trackLength, unitPrice);
            }
        }
    }
}