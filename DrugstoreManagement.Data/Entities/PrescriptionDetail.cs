namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PrescriptionDetails")]
    public partial class PrescriptionDetail
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int prescriptionId { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productId { get; set; }

        public int? unitNameId { get; set; }

        public int? quantity { get; set; }

        public virtual Prescription Prescription { get; set; }

        public virtual Product Product { get; set; }

        public virtual UnitName UnitName { get; set; }
    }
}
