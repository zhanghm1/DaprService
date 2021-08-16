using DaprTest.Domain;
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
                    Id=1,
                    Name="iPhone X",
                    Models=new List<ProductModel>(){
                        new ProductModel(){
                            ProductId=1,
                            Model="64G",
                            Number=100
                        },
                        new ProductModel(){
                            ProductId=1,
                            Model="128G",
                            Number=100
                        },
                    }
                },
                new Product(){
                    Id=2,
                    Name="iPhone XR",
                    Models=new List<ProductModel>(){
                        new ProductModel(){
                            ProductId=2,
                            Model="64G",
                            Number=100
                        },
                        new ProductModel(){
                            ProductId=2,
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
