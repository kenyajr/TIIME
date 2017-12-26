//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class TransactionLog
    {
        public int logsId { get; set; }
        [DisplayName ("Log Name")]
        public int logId { get; set; }
        [DisplayName("Transaction Date")]
        public System.DateTime transactionDate { get; set; }
        [DisplayName("Category Name")]
        public int categoryID { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual DateDimension DateDimension { get; set; }
        public virtual Log Log { get; set; }
    }
}
