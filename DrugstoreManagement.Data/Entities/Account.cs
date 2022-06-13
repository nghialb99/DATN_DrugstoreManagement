namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Accounts")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            ImportBills = new HashSet<ImportBill>();
            ImportInventoryBills = new HashSet<ImportInventoryBill>();
        }

        [Key]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public int? employeeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreated { get; set; }

        public int? userRoleid { get; set; }

        public int? veriCode { get; set; }

        public int? numberOfLogin { get; set; }

        [StringLength(50)]
        public string currentLoginDevice { get; set; }

        [Column(TypeName = "xml")]
        public string historyLogin { get; set; }

        [StringLength(200)]
        public string note { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual UserRole UserRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportBill> ImportBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportInventoryBill> ImportInventoryBills { get; set; }
    }
}
