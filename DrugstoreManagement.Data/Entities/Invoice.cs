namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Invoices")]
    public partial class Invoice
    {
        public int id { get; set; }

        [Column(TypeName = "xml")]
        public string invoiceInfo { get; set; }

        [StringLength(200)]
        public string reasonDelete { get; set; }

        public bool? status { get; set; }
    }
}
