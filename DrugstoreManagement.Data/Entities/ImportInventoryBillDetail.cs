namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ImportInventoryBillDetails")]
    public partial class ImportInventoryBillDetail
    {
        [Column(Order = 0)]
        public int ImportInventoryBillId { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productId { get; set; }

        [Required]
        [StringLength(50)]
        public string unitInput { get; set; }

        public int exchangeValue { get; set; }

        public int quantityInput { get; set; }

        public decimal priceInput { get; set; }

        public virtual ImportInventoryBill ImportInventoryBill { get; set; }

        public virtual Product Product { get; set; }
    }
}
