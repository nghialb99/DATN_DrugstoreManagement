using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.Common
{
    public class PagingRequestBase
    {
        public int pgaeIndex { get; set; }
        public int pageSize { get; set; }
    }
}
