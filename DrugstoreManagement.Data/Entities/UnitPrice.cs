namespace DrugstoreManagement.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UnitPrices")]
    public partial class UnitPrice
    {
        public int id { get; set; }

        public int? productId { get; set; }

        public int? unitNameId { get; set; }

        public int? exchangeValue { get; set; }

        public decimal? price { get; set; }

        public virtual Product Product { get; set; }

        public virtual UnitName UnitName { get; set; }
    }
}
