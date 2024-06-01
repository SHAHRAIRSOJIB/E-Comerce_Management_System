using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts _products;
        public ProductController(IProducts products)
        {
            _products = products;
        }
        [HttpPost]
        public int Add(Products entity)
        {
            _products.Add(entity);
            return entity.Id;

        }
        [HttpGet]
        public List<Products> GetAll()
        {
            List<Products> productList = _products.GetAll();
            return productList;
        }
        [HttpGet]
        [Route("GetById")]
        public Products GetById(int id)
        {
            Products product = _products.GetById(id);
            return product;
        }
        [HttpPut]
        public int Put(Products entity)
        {
            _products.Update(entity);
            return entity.Id;
        }
        [HttpDelete]
        public int Delete(Products entity)
        {
            _products.Delete(entity);
            return entity.Id;
        }
        [HttpGet]
        [Route("GetProductDetails")]
        public List<ProductDetailsView> GetProductDetails()
        {
            var productDetialsList = _products.GetProductDetails();
            return productDetialsList;
        }

    }
}
