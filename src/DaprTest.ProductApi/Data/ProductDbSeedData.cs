using DaprTest.Domain;
using DaprTest.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.ProductApi.Data
{
    public class ProductDbSeedData
    {
        private readonly ProductDbContext _productDbContext;
        public ProductDbSeedData(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public async Task Init()
        {
           var Products = new List<Product>() {
                new Product(){
                    TenantCode=TenantInfoData.DefaultTenantCode,
                    Name="iPhone X",
                    Models=new List<ProductModel>(){
                        new ProductModel(){
                            Model="64G",
                            Number=100
                        },
                        new ProductModel(){
                            Model="128G",
                            Number=100
                        },
                    }
                },
                new Product(){
                    TenantCode=TenantInfoData.DefaultTenantCode,
                    Name="iPhone XR",
                    Models=new List<ProductModel>(){
                        new ProductModel(){
                            TenantCode=TenantInfoData.DefaultTenantCode,
                            Model="64G",
                            Number=100
                        },
                        new ProductModel(){
                            TenantCode=TenantInfoData.DefaultTenantCode,
                            Model="128G",
                            Number=100
                        },
                    }
                },
            };
            foreach (var item in Products)
            {
                if (!await _productDbContext.Products.AnyAsync(a => a.Id == item.Id))
                {
                    _productDbContext.Products.Add(item);
                }
            }
            await _productDbContext.SaveChangesAsync();
        }
    }
}
