using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Interface
{
	public interface IProducts
	{
		public int Add(Products entity);
		public List<Products> GetAll();
		public Products GetById(int id);
		public int Update(Products entity);
		public int Delete(Products entity);
		public List<ProductDetailsView> GetProductDetails();

    }
}

