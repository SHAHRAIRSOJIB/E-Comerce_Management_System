using ECMS.Models;
using Newtonsoft.Json;

namespace ECMS.Services
{
    public class DropDownService
    {
        public async Task<List<Category>> GetCategoryListAsync()
        {
            var categoryList = new List<Category>();
            using (HttpClient client = new HttpClient())
            { 
                client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
                string urlForCategory = client.BaseAddress + "api/DropDown/GetCategoryListForDropDown";
                var responseTask = client.GetAsync(urlForCategory);
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                 string apiResponse = await result.Content.ReadAsStringAsync();
                 List<Category> itemList = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                    categoryList = itemList;
                }
            }
            return categoryList;    
        }
        public async Task<List<Sizes>> GetSizeListAsync()
        {
            var sizeList = new List<Sizes>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
                string urlForSize = client.BaseAddress + "api/DropDown/GetSizeListForDropDown";
                var responseTask = client.GetAsync(urlForSize);
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string apiResponse = await result.Content.ReadAsStringAsync();
                    List<Sizes> itemList = JsonConvert.DeserializeObject<List<Sizes>>(apiResponse);
                    sizeList = itemList;
                }
            }
            return sizeList;
        }
        public async Task<List<InventoryLevel>> GetInventoryLevelListAsync()
        {
            var inventoryLevelList = new List<InventoryLevel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
                string urlForInventoryLevel = client.BaseAddress + "api/DropDown/GetInvenoryLevelListForDropDown";
                var responseTask = client.GetAsync(urlForInventoryLevel);
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string apiResponse = await result.Content.ReadAsStringAsync();
                    List<InventoryLevel> itemList = JsonConvert.DeserializeObject<List<InventoryLevel>>(apiResponse);
                    inventoryLevelList = itemList;
                }
            }
            return inventoryLevelList;
        }
		public async Task<List<Color>> GetColorListAsync()
		{
			var colorList = new List<Color>();
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
				string urlForColor = client.BaseAddress + "api/DropDown/GetAllColorList";
				var responseTask = client.GetAsync(urlForColor);
				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					string apiResponse = await result.Content.ReadAsStringAsync();
					List<Color> itemList = JsonConvert.DeserializeObject<List<Color>>(apiResponse);
					colorList = itemList;
				}
			}
			return colorList;
		}
	}
}
