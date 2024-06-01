using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Interface
{
	public interface ICategories
	{
		public int Add(Categories entity);
		public List<Categories> GetAll();
		public Categories GetById(int id);
		public int Update(Categories entity);
		public int Delete(Categories entity);
		public List<Categories> GetCategoryListForDropDown();

    }
}
