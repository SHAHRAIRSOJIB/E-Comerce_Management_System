using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.BussinessLayer.Service;
using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Repository
{
	public class ProductRepository : IProducts, IDisposable
	{
		private readonly ECMSContext _dbContext;
		private readonly DapperService _dapperService;
		public ProductRepository(ECMSContext dbContext, DapperService dapperService)
		{
			_dbContext = dbContext;
			_dapperService = dapperService;

		}
		public int Add(Products entity)
		{
			_dbContext.Products.Add(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public List<Products> GetAll()
		{
			var productList = _dbContext.Products.Where(x => x.Qty != 0).OrderByDescending(a => a.Id).ToList();
			return productList;
		}
		public Products GetById(int id)
		{
			Products product = _dbContext.Products.Where(x => x.Id == id).First();
			return product;
		}
		public int Update(Products entity)
		{
			_dbContext.Products.Update(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public List<ProductDetailsView> GetProductDetails()
		{
			string query = "select * from ProductDetailsView";
			var productDetailsView = _dapperService.GetAllByQuery<ProductDetailsView>(query).ToList();
			return productDetailsView;
		}
		public int Delete(Products entity)
		{
			_dbContext.Products.Remove(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
