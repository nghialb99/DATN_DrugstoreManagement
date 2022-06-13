namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Prescriptions")]
    public partial class Prescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prescription()
        {
            PrescriptionDetails = new HashSet<PrescriptionDetail>();
        }

        public int id { get; set; }

        [StringLength(20)]
        public string code { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreated { get; set; }

        [StringLength(50)]
        public string physician { get; set; }

        [StringLength(200)]
        public string medicalFacility { get; set; }

        public int? patientId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
    }
}
