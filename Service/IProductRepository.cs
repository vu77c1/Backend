using System;
using MSQL.Data;
using MSQL.Models;

namespace MSQL.Service
{
	public interface IProductRepository
	{
		 List<ProductModel> GetAll();
		ProductModel Add(ProductModel p);

    }
}

