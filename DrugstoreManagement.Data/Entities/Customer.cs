namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customers")]
    public partial class Customer
    {
        public int id { get; set; }

        [StringLength(50)]
        public string customerCode { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(14)]
        public string taxCode { get; set; }

        public string address { get; set; }

        [StringLength(100)]
        public string phoneNumber { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public bool? status { get; set; }
    }
}
