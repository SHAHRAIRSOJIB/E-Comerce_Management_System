using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Repository
{
	public class InventoryLevelRepository: IInventoryLevels,IDisposable
	{
		public readonly ECMSContext _dbContext;
		public InventoryLevelRepository(ECMSContext context)
		{
				_dbContext = context;
		}
		public int Add(InventoryLevels entity)
		{
			_dbContext.InventoryLevels.Add(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public List<InventoryLevels> GetAll()
		{
			var invenntoryLevelList = _dbContext.InventoryLevels.ToList();
			return invenntoryLevelList;
		}
		public InventoryLevels GetById(int id)
		{
			InventoryLevels invenntoryLevel = _dbContext.InventoryLevels.Where(x => x.Id == id).First();
			return invenntoryLevel;
		}
		public int Update(InventoryLevels entity)
		{
			_dbContext.InventoryLevels.Update(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public int Delete(InventoryLevels entity)
		{
			_dbContext.InventoryLevels.Remove(entity);
			_dbContext.SaveChanges();
			return entity.Id;
		}
		public List<InventoryLevels> GetInventoryListForDropdown()
		{
			try
			{
                List<InventoryLevels> list = _dbContext.InventoryLevels.ToList();
                return list;
            }
			catch
			{
				throw;
			}
			
		}
		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
