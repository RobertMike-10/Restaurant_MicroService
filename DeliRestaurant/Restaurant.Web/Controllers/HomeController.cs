using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;
using System.Diagnostics;

namespace Restaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger,
                              IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<ProductDto> list = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetAllProductsAsync<ResponseDto>("");
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response!.Result));
            }
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(IndexAsync));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}