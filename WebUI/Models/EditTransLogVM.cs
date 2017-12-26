using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class EditTransLogVM
    {
        [DisplayName("Log Name")]
        public String selectedLog { get; set; }
        [DisplayName("Category Name")]
        public String selectedCategory { get; set; }
        public TransactionLog TransLog { get; set; }

    }
}