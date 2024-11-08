using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class InvoiceLineBaseViewModel
    {
        [Key]
        [Display(Name = "Line ID")]
        public int InvoiceLineId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Line Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal LinePrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
}