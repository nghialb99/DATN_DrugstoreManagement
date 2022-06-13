namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EnterpriseInformations")]
    public partial class EnterpriseInformation
    {
        public int id { get; set; }

        [StringLength(14)]
        public string taxCode { get; set; }

        [StringLength(250)]
        public string metaTitle { get; set; }

        [Required]
        [StringLength(400)]
        public string enterpriseName { get; set; }

        [Required]
        [StringLength(500)]
        public string address { get; set; }

        [StringLength(100)]
        public string phonenumber { get; set; }

        [StringLength(100)]
        public string website { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(300)]
        public string bankAccount { get; set; }

        [StringLength(300)]
        public string bankName { get; set; }
    }
}
