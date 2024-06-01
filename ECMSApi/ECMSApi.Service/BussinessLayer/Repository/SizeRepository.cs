using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Repository
{
	public  class SizeRepository : ISizes, IDisposable
	{
        private readonly ECMSContext _dbContext;
        public SizeRepository(ECMSContext context)
        {
			_dbContext =  context;

		}
		public int Add(Sizes entity)
		{
			_dbContext.Sizes.Add(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public List<Sizes> GetAll()
		{
			var sizeList = _dbContext.Sizes.ToList();
			return sizeList;
		}
		public Sizes GetById(int id)
		{
			Sizes size = _dbContext.Sizes.Where(x => x.Id == id).First();
			return size;
		}
		public int Update(Sizes entity)
		{
			_dbContext.Sizes.Update(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public int Delete(Sizes entity)
		{
			_dbContext.Sizes.Remove(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public List<Sizes> GetSizeListForDropDown()
		{
			var list = _dbContext.Sizes.ToList();
			return list;
		}

		public string GetSizeNameById(int id)
		{
			string sizeName = _dbContext.Sizes.Where(x=>x.Id == id).First().Name;
			return sizeName;
		}
		public void Dispose()
		{
			_dbContext.Dispose();	
		}
	}
}
