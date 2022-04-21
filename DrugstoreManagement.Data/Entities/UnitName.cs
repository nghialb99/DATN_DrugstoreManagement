using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Data.Entities
{
    public class UnitName
    {
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(250)]
        public string note { get; set; }
    }
}
