
using DrugstoreManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.Catalog.Products
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string keyWord { get; set; }
        public List<int> categoryIds { get; set; }
    }
}
