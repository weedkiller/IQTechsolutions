using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grouping.Base.Models;
using Iqt.Base.Interfaces;
using Iqt.Web;
using Iqt.Web.Helpers;

namespace Products.Base.Api.Services
{
    public class ProductCategoriesApiService
    {
        private readonly IApplicationConfiguration _configuration;

        public ProductCategoriesApiService(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<WebRequestResult<IEnumerable<CategoryModel>>> GetAllCategoriesAsync(string parentId = null)
        {
            try
            {
                var serverResponse = await WebRequests.GetAsync<IEnumerable<CategoryModel>>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "productcategories/" + parentId));
                return serverResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<WebRequestResult<CategoryModel>> GetCategoryAsync(string id)
        {
            try
            {
                var serverResponse = await WebRequests.GetAsync<CategoryModel>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, id));
                return serverResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
