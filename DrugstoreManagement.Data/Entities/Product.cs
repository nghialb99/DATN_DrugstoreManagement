namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Products")]
    public class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ImportBillDetails = new HashSet<ImportBillDetail>();
            ImportInventoryBillDetails = new HashSet<ImportInventoryBillDetail>();
            PrescriptionDetails = new HashSet<PrescriptionDetail>();
            UnitPrices = new HashSet<UnitPrice>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string code { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        public int? idCategory { get; set; }

        [StringLength(250)]
        public string metaTitle { get; set; }

        public string Description { get; set; }

        [StringLength(30)]
        public string registrationNumber { get; set; }

        [StringLength(100)]
        public string batchNo { get; set; }

        [StringLength(100)]
        public string component { get; set; }

        [StringLength(100)]
        public string dosage { get; set; }

        [StringLength(100)]
        public string origin { get; set; }

        [StringLength(100)]
        public string packagingSpecifications { get; set; }

        public int? exchangeValue { get; set; }

        [StringLength(50)]
        public string baseUnits { get; set; }

        public DateTime? manDate { get; set; }

        public DateTime? expDate { get; set; }

        public int? inventoryNumber { get; set; }

        public string images { get; set; }

        [Column(TypeName = "xml")]
        public string moreImage { get; set; }

        [StringLength(250)]
        public string qrCode { get; set; }

        [StringLength(250)]
        public string note { get; set; }

        public int? status { get; set; }

        public bool? statusDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportBillDetail> ImportBillDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportInventoryBillDetail> ImportInventoryBillDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnitPrice> UnitPrices { get; set; }
    }
}
