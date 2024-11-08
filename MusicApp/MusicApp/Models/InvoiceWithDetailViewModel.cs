using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class InvoiceWithDetailViewModel : InvoiceBaseViewModel
    {
        // Customer details
        [Display(Name = "Customer First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Customer Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Customer State")]
        public string CustomerState { get; set; }

        [Display(Name = "Customer Country")]
        public string CustomerCountry { get; set; }

        // Employee (Sales Rep) details
        [Display(Name = "Sales Rep First Name")]
        public string CustomerEmployeeFirstName { get; set; }

        [Display(Name = "Sales Rep Last Name")]
        public string CustomerEmployeeLastName { get; set; }

        // Collection for Invoice Lines
        public IEnumerable<InvoiceLineWithDetailViewModel> InvoiceLines { get; set; }
    }
}