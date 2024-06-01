using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.BussinessLayer.Service;
using ECMSApi.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Repository
{
	public class TestRepository : ITest,IDisposable
	{
		readonly ECMSContext _dbContext;
		private readonly IDapperService _IDapperService;
		public TestRepository(ECMSContext dbContext, DapperService dapperService)
		{
			_dbContext = dbContext;
			_IDapperService = dapperService;
		}
		public int Add(tblTest entity)
		{
			try
			{
				_dbContext.Add<tblTest>(entity);
				_dbContext.SaveChanges();
				return entity.id;
			}
			catch
			{
				throw;
			}
		}
		public List<tblTest> GetAll()
		{
			var list = _dbContext.Tests.ToList();
			return list;
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
