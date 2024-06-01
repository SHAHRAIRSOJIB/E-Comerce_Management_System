using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Service
{
	public class SQLConnectionString
	{
		public string GetConnectionString(string ProjectCsKey)
		{
			string CS = "";
			if (ProjectCsKey == "default")
			{
				CS = "Data Source=DESKTOP-HVOVS1K\\SQLEXPRESS;Initial Catalog=ECMSDb;Trusted_Connection=True";
			}
			return CS;
		}
	}
}
