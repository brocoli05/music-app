using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class InvoiceBaseViewModel
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "City")]
        public string BillingCity { get; set; }

        [StringLength(40)]
        [Display(Name = "State")]
        public string BillingState { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Country")]
        public string BillingCountry { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal/Zip")]
        public string BillingPostalCode { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Total { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
    }
}