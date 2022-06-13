using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public string code { get; set; }

        public string name { get; set; }

        public string metaTitle { get; set; }

        public string Description { get; set; }

        public int? inventoryNumber { get; set; }

        public string images { get; set; }

        public string moreImage { get; set; }

        public string qrCode { get; set; }

        public IFormFile? ThumbnailImage { get; set; }
    }
}
