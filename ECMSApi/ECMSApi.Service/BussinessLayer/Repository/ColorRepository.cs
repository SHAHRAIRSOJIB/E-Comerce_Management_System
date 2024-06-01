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
	
	public class ColorRepository:IColor
	{
		
		private readonly ECMSContext _dbContext;
		public ColorRepository(ECMSContext context)
		{
			_dbContext = context;

		}
		public List<Color> GetAll()
		{
			var categoryList = _dbContext.Colors.ToList();
			return categoryList;
		}
		public string GetById(int id)
		{ 
			string color = _dbContext.Colors.Where(x=>x.Id == id).First().ColorName;
			return color;
		}

	}
}
