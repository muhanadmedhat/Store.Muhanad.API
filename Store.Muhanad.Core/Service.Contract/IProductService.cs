using Store.Muhanad.Core.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Muhanad.Core.Service.Contract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<IEnumerable<BrandTypeDto>> GetAllTypesAsync();
        Task<IEnumerable<BrandTypeDto>> GetAllBrandsAsync();
        Task<ProductDto> GetProductById(int id);
    }
}
