using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Interface
{
	public interface ISizes
	{
		public int Add(Sizes entity);
		public List<Sizes> GetAll();
		public Sizes GetById(int id);
		public int Update(Sizes entity);
		public int Delete(Sizes entity);
		public List<Sizes> GetSizeListForDropDown();
		public string GetSizeNameById(int id);


	}
}
