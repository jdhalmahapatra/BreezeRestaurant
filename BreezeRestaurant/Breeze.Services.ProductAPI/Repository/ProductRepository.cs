using AutoMapper;
using Breeze.Services.ProductAPI.DbContexts;
using Breeze.Services.ProductAPI.Models;
using Breeze.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breeze.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product prodcut = _mapper.Map<ProductDto, Product>(productDto);
            if (prodcut.ProductId > 0)
            {
                _db.Products.Update(prodcut);
            }
            else
            {
                _db.Products.Add(prodcut);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(prodcut);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if(product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            List<Product> prodcutList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(prodcutList);
        }

        public async Task<ProductDto> GetProdcutById(int productId)
        {
            Product prodcut = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(prodcut);
        }
    }
}
