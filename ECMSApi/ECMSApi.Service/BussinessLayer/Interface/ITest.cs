using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Interface
{
	public interface ITest
	{
		public int Add(tblTest entity);
		public List<tblTest> GetAll();
	}
}
