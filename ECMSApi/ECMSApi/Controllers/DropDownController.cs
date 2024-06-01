using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : ControllerBase
    {
        private readonly ICategories _categories;
        private readonly ISizes _size;
        private readonly IInventoryLevels _inventory;
        private readonly IColor _color;
        public DropDownController(ICategories categories, ISizes size, IInventoryLevels inventory,IColor color)
        {
            _categories = categories;
            _size = size;
            _inventory = inventory;
            _color = color;

        }
        [HttpGet]
        [Route("GetCategoryListForDropDown")]
        public List<Categories> GetCategoryListForDropDown()
        {
            var list = _categories.GetCategoryListForDropDown().ToList();
            return list;
        }
        [HttpGet]
        [Route("GetSizeListForDropDown")]
        public List<Sizes> GetSizeListForDropDown()
        {
            var list = _size.GetSizeListForDropDown().ToList();
            return list;
        }
        [HttpGet]
        [Route("GetInvenoryLevelListForDropDown")]
        public List<InventoryLevels> GetInvenoryLevelListForDropDown()
        {
            var list = _inventory.GetInventoryListForDropdown().ToList();
            return list;
        }
        [HttpGet]
        [Route("GetAllColorList")]
        public List<Color> GetAllColorList()
        {
            var list = _color.GetAll().ToList();
            return list;

		}
        [HttpGet]
        [Route("GetColorById")]
        public string GetColorById(int id)
        {
            string color = _color.GetById(id);
            return color;
        }
		[HttpGet]
		[Route("GetSizeNameById")]
		public string GetSizeNameById(int id)
		{
			string sizeName = _size.GetSizeNameById(id);
			return sizeName;
		}

	}
}
