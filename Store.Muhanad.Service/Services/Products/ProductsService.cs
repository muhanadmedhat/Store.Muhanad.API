using AutoMapper;
using Store.Muhanad.Core;
using Store.Muhanad.Core.Dtos.Product;
using Store.Muhanad.Core.Entities;
using Store.Muhanad.Core.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Muhanad.Service.Services.Products
{
    public class ProductsService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {

            return _mapper.Map<IEnumerable<ProductDto>>(await _unitOfWork.Repository<Product, int>().GetAllAsync());
             
        }

        public async Task<ProductDto> GetProductById(int id)
        {
           var product =await _unitOfWork.Repository<Product,int>().GetAsync(id);
            var mappedproduct = _mapper.Map<ProductDto>(product);
            return mappedproduct;
        }

        public async Task<IEnumerable<BrandTypeDto>> GetAllBrandsAsync()
        {
            var brands =await _unitOfWork.Repository<ProductBrand,int>().GetAllAsync();
            var mappedbrands = _mapper.Map<IEnumerable<BrandTypeDto>>(brands);
            return mappedbrands;
        }

        public async Task<IEnumerable<BrandTypeDto>> GetAllTypesAsync()
        {
           var types =await _unitOfWork.Repository<ProductType,int>().GetAllAsync();
            var mappedtypes = _mapper.Map<IEnumerable<BrandTypeDto>>(types);
            return mappedtypes;
        }

        
    }
}
