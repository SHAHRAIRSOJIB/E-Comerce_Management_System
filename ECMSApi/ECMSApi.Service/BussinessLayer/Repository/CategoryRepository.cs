using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Repository
{
	public class CategoryRepository:ICategories,IDisposable
	{
        private readonly ECMSContext _dbContext;
        public CategoryRepository(ECMSContext context)
        {
			_dbContext = context;

		}
		public int Add(Categories entity)
		{
			_dbContext.Categories.Add(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public List<Categories> GetAll()
		{
			var categoryList = _dbContext.Categories.ToList();
			return categoryList;
		}
		public Categories GetById(int id)
		{
			Categories category = _dbContext.Categories.Where(x => x.Id == id).First();
			return category;
		}
		public int Update(Categories entity)
		{
			_dbContext.Categories.Update(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public int Delete(Categories entity)
		{
			_dbContext.Categories.Remove(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}

		public List<Categories> GetCategoryListForDropDown()
		{
			var list = _dbContext.Categories.ToList();
			return list;
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
