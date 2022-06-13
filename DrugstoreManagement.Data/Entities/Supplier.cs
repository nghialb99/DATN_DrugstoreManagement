namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Suppliers")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            ImportBills = new HashSet<ImportBill>();
        }

        [Key]
        [StringLength(14)]
        public string taxcode { get; set; }

        [Required]
        [StringLength(300)]
        public string name { get; set; }

        public int SupplierRoleId { get; set; }

        [StringLength(100)]
        public string phoneNumber { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string website { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        public int status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportBill> ImportBills { get; set; }

        public virtual SupplierRole SupplierRole { get; set; }
    }
}
