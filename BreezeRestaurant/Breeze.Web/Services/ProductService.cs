using Breeze.Web.Models;
using Breeze.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Breeze.Web.Services
{
    public class ProductService : BaseService, IProductServices
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) :base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProdcutAsync<T>(ProductDto productDto)
        {
           return await this.SendAsync<T>(new ApiRequest() { 
                ApiType = StaticDetails.ApiType.POST,
                Data = productDto,
                Url = StaticDetails.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.ProductAPIBase + "/api/products" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/products" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProdcutAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = productDto,
                Url = StaticDetails.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }
    }
}
