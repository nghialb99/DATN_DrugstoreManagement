
using DrugstoreManagement.ViewModels.Catalog.Products;
using DrugstoreManagement.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int id);
        Task<List<ProductViewModel>> GetAll();

        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
        Task<int> AddImage(int productId, IFormFile file);
    }
}
