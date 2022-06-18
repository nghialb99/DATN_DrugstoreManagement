using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.Catalog.Enterprises
{
    public class EnterpriseInfoUpdateRequest
    {
        public string? taxCode { get; set; }

        public string? metaTitle { get; set; }

        public string? enterpriseName { get; set; }

        public string? address { get; set; }

        public string? phonenumber { get; set; }

        public string? website { get; set; }

        public string? email { get; set; }

        public string? bankAccount { get; set; }

        public string? bankName { get; set; }
    }
}
