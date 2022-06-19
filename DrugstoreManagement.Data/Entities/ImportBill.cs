namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ImportBills")]
    public partial class ImportBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImportBill()
        {
            ImportBillDetails = new HashSet<ImportBillDetail>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreated { get; set; }

        [Required]
        [StringLength(50)]
        public string creator { get; set; }

        [StringLength(14)]
        public string supplierId { get; set; }

        public int? VAT { get; set; }

        public decimal? totalAmount { get; set; }

        public int? status { get; set; }

        [StringLength(100)]
        public string note { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportBillDetail> ImportBillDetails { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
