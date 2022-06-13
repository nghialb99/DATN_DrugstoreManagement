namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ImportBillDetails")]
    public partial class ImportBillDetail
    {
        [Column(Order = 0)]
        public int importBillId { get; set; }

        [Column(Order = 1)]
        public int productId { get; set; }

        [Required]
        [StringLength(50)]
        public string unitInput { get; set; }

        public int exchangeValue { get; set; }

        public int quantityInput { get; set; }

        public decimal priceInput { get; set; }

        public virtual ImportBill ImportBill { get; set; }

        public virtual Product Product { get; set; }
    }
}
