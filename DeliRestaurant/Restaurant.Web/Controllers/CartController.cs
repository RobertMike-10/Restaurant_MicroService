using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICouponService _couponService;

        public CartController(ICartService cartService, ICouponService couponService)
        {
            _cartService = cartService;
            _couponService = couponService;
        }

        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartBasedOnUser());
        }


        public async Task<IActionResult> Remove(int cartDetailsId)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value!;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _cartService.RemoveFromCartAsync<ResponseDto>(cartDetailsId, accessToken);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(CartIndex));
            }

            return View();
        }

        public async Task<IActionResult> ClearCart()
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value!;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _cartService.ClearCart<ResponseDto>(userId, accessToken);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(CartIndex));
            }

            return View();
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

                cartDto.CartDetails.ToList().ForEach(d => cartDto.CartHeader.OrderTotal += (d.Product.Price * d.Count));

                if (!string.IsNullOrEmpty(cartDto.CartHeader.CouponCode))
                {
                    var coupon = await _couponService.GetCoupon<ResponseDto>(cartDto.CartHeader.CouponCode, accessToken!);
                    if (coupon != null && coupon.isSuccess)
                    {
                        CouponDto couponObj = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(coupon.Result));
                        if (ValidateCoupon(couponObj))
                            cartDto.CartHeader.DiscountTotal = (couponObj.DiscountAmount/100) * cartDto.CartHeader.OrderTotal;
                    }

                }
               
                cartDto.CartHeader.OrderTotal -= cartDto.CartHeader.DiscountTotal;

            }
            return cartDto;
        }


        [HttpPost]
        [ActionName("ApplyCoupon")]
        public async Task<IActionResult> ApplyCoupon(CartDto cart)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            if (cart.CartHeader.CouponCode!=null)
            { 
               var coupon = await _couponService.GetCoupon<ResponseDto>(cart.CartHeader.CouponCode!, accessToken!);
               if (coupon != null && coupon.isSuccess)
               {

                    CouponDto couponObj = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(coupon.Result));
                    if (ValidateCoupon(couponObj))
                    {
                      
                       var response = await _cartService.ApplyCoupon<ResponseDto>(cart, accessToken);

                       if (response != null && response.isSuccess)
                       {
                         return RedirectToAction(nameof(CartIndex));
                       }
                    }
                }
            }
            return RedirectToAction(nameof(CartIndex));
        }

        [HttpPost]
        [ActionName("RemoveCoupon")]
        public async Task<IActionResult> RemoveCoupon(CartDto cart)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _cartService.RemoveCoupon<ResponseDto>(cart.CartHeader.UserId, accessToken);

            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        [HttpGet]
        [ActionName("CheckOut")]
        public async Task<IActionResult> CheckOut()
        {
            var cart = await LoadCartBasedOnUser();
            cart.CartHeader.Card = new CardDto();
            return View(cart);
        }


        private bool ValidateCoupon(CouponDto coupon)
        {
            if (coupon.ExpirationDate < DateTime.Now )
                return false;
            else
                return true;
        }
    }
}
