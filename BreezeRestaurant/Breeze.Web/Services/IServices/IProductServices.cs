using Breeze.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breeze.Web.Services.IServices
{
    public interface IProductServices : IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProdcutAsync<T>(ProductDto productDto);
        Task<T> UpdateProdcutAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
