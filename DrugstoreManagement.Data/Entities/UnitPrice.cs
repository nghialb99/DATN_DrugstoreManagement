using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Data.Entities
{
    public class UnitPrice
    {
        public int id { get; set; }

        public int? productId { get; set; }

        public int? UnitNameId { get; set; }

        public int? exchangeValue { get; set; }

        public decimal? price { get; set; }
    }
}
