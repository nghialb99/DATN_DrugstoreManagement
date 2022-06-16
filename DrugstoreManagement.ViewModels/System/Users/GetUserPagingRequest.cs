using DrugstoreManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public DateTime dateCreated { get; set; }
        public int employeeId { get; set; }
        public bool lockoutEnabled { get; set; }
    }
}
