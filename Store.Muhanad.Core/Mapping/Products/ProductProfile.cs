﻿using AutoMapper;
using Store.Muhanad.Core.Dtos.Product;
using Store.Muhanad.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Muhanad.Core.Mapping.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                    .ForMember(d => d.BrandName, options => options.MapFrom(s => s.Brand.Name))
                    .ForMember(d => d.TypeName, options => options.MapFrom(s => s.Type.Name));

            CreateMap<ProductBrand, BrandTypeDto>();
            CreateMap<ProductType, BrandTypeDto>();
        }
    }
}
