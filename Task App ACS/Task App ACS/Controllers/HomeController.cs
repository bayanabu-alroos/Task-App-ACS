using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task_App_ACS.Models;
using Task_App_ACS.Services;

namespace Task_App_ACS.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUserService _userService;

		public HomeController(ILogger<HomeController> logger, IUserService userService)
		{
			_logger = logger;
			_userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Search(string term)
		{
			try
			{
				var result = await _userService.SearchAsync(term);
				return Json(result);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in Search: {ex.Message}");
				return StatusCode(500, new { error = "حدث خطأ أثناء تنفيذ البحث. الرجاء المحاولة لاحقًا." });
			}

		}

	}
}
