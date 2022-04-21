using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DrugstoreManagement.Data.Entities
{
    public class ProductCategory
    {
        public int id { get; set; }

        [StringLength(50)]
        public string code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        public DateTime? dateCreated { get; set; }

        [StringLength(250)]
        public string note { get; set; }

        public bool? status { get; set; }
    }
}
