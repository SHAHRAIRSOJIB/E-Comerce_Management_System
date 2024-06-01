using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Interface
{
	public interface IInventoryLevels
	{
		public int Add(InventoryLevels entity);
		public List<InventoryLevels> GetAll();
		public InventoryLevels GetById(int id);
		public int Update(InventoryLevels entity);
		public int Delete(InventoryLevels entity);
		public List<InventoryLevels> GetInventoryListForDropdown();

    }
}
