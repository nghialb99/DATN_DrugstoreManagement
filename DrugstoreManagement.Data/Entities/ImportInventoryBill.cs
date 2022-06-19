namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ImportInventoryBills")]
    public partial class ImportInventoryBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImportInventoryBill()
        {
            ImportInventoryBillDetails = new HashSet<ImportInventoryBillDetail>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreated { get; set; }

        [Required]
        [StringLength(50)]
        public string creator { get; set; }

        public decimal? totalAmountWithVat { get; set; }

        public int? status { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportInventoryBillDetail> ImportInventoryBillDetails { get; set; }
    }
}
