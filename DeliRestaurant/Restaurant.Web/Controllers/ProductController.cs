using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> products = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetAllProductsAsync<ResponseDto>(accessToken!);
            if (response != null && response.isSuccess)
            {
                products = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }

            return View(products);

        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.CreateProductAsync<ResponseDto>(product, accessToken!);
                if (response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));

                }
            }
            return View(product);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            ProductDto product;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken!);
            if (response != null && response.isSuccess)
            {
                product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProductAsync<ResponseDto>(product, accessToken!);
                if (response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(product);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            ProductDto product;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken!);
            if (response != null && response.isSuccess)
            {
                product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto product)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteProductAsync<ResponseDto>(product.ProductId, accessToken!);
             if ( response.isSuccess)
             {
                    return RedirectToAction(nameof(ProductIndex));
             }
            
            return View(product);
        }
    }
}
