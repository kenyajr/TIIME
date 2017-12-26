using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class DisplayLog
    {
        [DisplayName("TransactionDate")]
        public DateTime transactionDate { get; set; }
        [DisplayName("Log Name")]
        public String logName { get; set; }
        [DisplayName("Category Name")]
        public String categoryName { get; set; }
        [DisplayName("Description")]
        public String description { get; set; }
        public int logsId { get; set; }



}
}