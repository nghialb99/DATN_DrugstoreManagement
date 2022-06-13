using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Data.Entities
{
    [Table("AppConfigs")]
    public class AppConfig
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
