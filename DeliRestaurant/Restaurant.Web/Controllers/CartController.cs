﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartBasedOnUser());
        }

        private async Task<CartDto> LoadCartBasedOnUser()
        {
            var userId  = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value!;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _cartService.GetCartUserByIdAsync<ResponseDto>(userId, accessToken);

            CartDto cartDto = new();
            if (response != null && response.isSuccess)
            {
                cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result));
            }
            
            if (cartDto.CartHeader != null)
            {

                cartDto.CartDetails.ToList().ForEach(d => cartDto.CartHeader.OrderTotal += (d.Product.Price *d.Count));
            }
            return cartDto;
        }
    }
}
