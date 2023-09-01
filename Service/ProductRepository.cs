using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSQL.Data;
using MSQL.Models;

namespace MSQL.Service
{
	public class ProductRepository:IProductRepository
	{
        private readonly MsqlContext _context;

        public ProductRepository(MsqlContext context)
        {
            _context = context;
        }

        public ProductModel Add(ProductModel p)
        {

            var _p = new Product()
            {
                ProductName=p.ProductName,
                Description=p.Description,
                Price=p.Price,
                ProductImage=p.ProductImage,
                     
                
            };
            _context.Add(_p);
            _context.SaveChanges();
            return new ProductModel()
            {
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                ProductImage = p.ProductImage
            };
        }

        public List<ProductModel> GetAll()
        {

            var rs = _context.Products.Select(p=>new ProductModel()
            {
                ProductName=p.ProductName,
                Description=p.Description,
                Price=p.Price,
                ProductImage=p.ProductImage
                
            });
            return rs.ToList();
        }
    }
}

