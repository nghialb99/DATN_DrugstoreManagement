using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Data.Entities
{
    public class Product
    {
        public int id { get; set; }

        [StringLength(50)]
        public string code { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        public int idCategory { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string batchNo { get; set; }

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
    }
}
