using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.BussinessLayer.Service;
using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Repository
{
	public class OrderRepository: IOrder,IDisposable
	{
        private readonly ECMSContext _Context;
        private readonly DapperService _dapperService;
        public OrderRepository(ECMSContext context, DapperService dapper)
        {
                _Context = context;
               _dapperService = dapper; 
        }
		public int Post(Order entity)
        {
            _Context.Orders.Add(entity);
            _Context.SaveChanges();
            foreach (var unitProduct in entity.OrderDetails)
            {
                var product = _Context.Products.Where(x => x.Id == unitProduct.ProductId).FirstOrDefault();
                if (product != null)
                {
                    product.Qty = product.Qty - unitProduct.UnitQty;
                }
                _Context.Products.Update(product);
                _Context.SaveChanges();
            }
           
            return entity.Id;

		}

        public List<OrderDetailsView> GetAllOrderDetailsList(){
            string query = "select * from OrderDetailsView";
            var list = _dapperService.GetAllByQuery<OrderDetailsView>(query).ToList();  
            return list;    
        }
		public void Dispose()
		{
			_Context?.Dispose();	
		}
	}
}
