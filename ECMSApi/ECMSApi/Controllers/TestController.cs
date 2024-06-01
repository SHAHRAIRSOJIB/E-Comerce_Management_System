using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECMSApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly ITest _Test;
		public TestController(ITest test)
		{
			_Test = test;
		}
		[HttpPost]
		public int Post(tblTest entity)
		{
			 _Test.Add(entity);
			return entity.id;
		}
		[HttpGet]
		public List<tblTest> GetAll()
		{
			var list = _Test.GetAll();
			return list;

		}

	}
}
