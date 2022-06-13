namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SupplierRoles")]
    public partial class SupplierRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplierRole()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string supplierRoleCode { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreated { get; set; }

        [StringLength(150)]
        public string note { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
