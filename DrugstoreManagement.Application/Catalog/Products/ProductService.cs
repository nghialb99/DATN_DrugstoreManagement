using DrugstoreManagement.ViewModels.Catalog.Products;
using DrugstoreManagement.ViewModels.Common;
using DrugstoreManagement.Data.EF;
using DrugstoreManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using DrugstoreManagement.Application.Common;

namespace DrugstoreManagement.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly DrugstoreDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public ProductService(DrugstoreDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public Task<int> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            Product product = new Product()
            {
                name = request.name,
                idCategory = request.idCategory,

            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException(); 
        }
        public async Task<List<ProductViewModel>> GetAll()
        {
            //1. Select join
            var query = from p in _context.Products
                        join c in _context.ProductCategories on p.idCategory equals c.id
                        select new { p, c};
            var data = await query.OrderByDescending(x => x.p.id).Select(
                x=> new ProductViewModel()
                {
                    id = x.p.id,
                    name = x.p.name,
                    code = x.p.code,
                    idCategory = x.c.name,
                }
                ).ToListAsync();
            return data;
        }
        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            throw new NotImplementedException();
        }
        //private async Task<string> SaveFile(IFormFile file)
        //{
        //    var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
        //    await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
        //    return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        //}

        public Task<int> AddImage(int productId, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
