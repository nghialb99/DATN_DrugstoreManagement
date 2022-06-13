using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public string code { get; set; }

        public string name { get; set; }

        public int? idCategory { get; set; }

        public string metaTitle { get; set; }

        public string Description { get; set; }

        public string registrationNumber { get; set; }

        public string batchNo { get; set; }

        public string component { get; set; }

        public string dosage { get; set; }

        public string origin { get; set; }

        public string packagingSpecifications { get; set; }

        public int? exchangeValue { get; set; }

        public string baseUnits { get; set; }

        public DateTime manDate { get; set; }

        public DateTime expDate { get; set; }

        public int? inventoryNumber { get; set; }

        public string? images { get; set; }

        public string? moreImage { get; set; }

        public string? qrCode { get; set; }

        public string? note { get; set; }
        public IFormFile? ThumbnailImage { get; set; }
    }
}
