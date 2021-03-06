using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.ShoppingCartApi.Messages;
using Restaurant.Services.ShoppingCartApi.Models.Dto;
using Restaurant.Services.ShoppingCartApi.Repository;

namespace Restaurant.Services.ShoppingCartApi.Controllers
{   

    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        protected ResponseDto _response;
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
            this._response = new ResponseDto();
        }

        [Authorize]
        [HttpGet("GetCart/{userId}")]
        public async Task<dynamic> GetCart(string userId)
        {
            try
            {
                CartDto cartDto = await _repository.GetCartUserById(userId);
                _response.Result = cartDto;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPost("AddCart")]
        public async Task<dynamic> AddCart(CartDto car)
        {
            try
            {
                CartDto? cartDto = await _repository.CreateUpdateCart(car);
                _response.Result = cartDto!;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPut("UpdateCart")]
        public async Task<dynamic> UpdateCart(CartDto car)
        {
            try
            {
                CartDto? cartDto = await _repository.CreateUpdateCart(car);
                _response.Result = cartDto!;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPost("RemoveCart")]
        public async Task<dynamic> RemoveCart([FromBody] int cartId)
        {
            try
            {              
                bool isSuccess = await _repository.RemoveFromCart(cartId);
                _response.Result = isSuccess;
            
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpDelete("ClearCart/{userId}")]
        public async Task<dynamic> ClearCart(string userId)
        {
            try
            {
                bool isSuccess = await _repository.ClearCart(userId);
                _response.Result = isSuccess;

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPost("ApplyCoupon")]
        public async Task<dynamic> ApplyCoupon([FromBody] CartDto cart)
        {
            try
            {
                bool isSuccess = await _repository.ApplyCoupon(cart.CartHeader.UserId, cart.CartHeader!.CouponCode!);
                _response.Result = isSuccess;

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPost("RemoveCoupon")]
        public async Task<dynamic> RemoveCoupon([FromBody] string userId)
        {
            try
            {
                bool isSuccess = await _repository.RemoveCoupon(userId);
                _response.Result = isSuccess;

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPost("Checkout")]
        public async Task<dynamic> Checkout(CheckoutHeaderDto checkoutHeader)
        {
            try
            {
                CartDto cart = await _repository.GetCartUserById(checkoutHeader.UserId);
                if (cart==null)
                {
                    return BadRequest();
                }
                checkoutHeader.CartDetails = cart.CartDetails;
                //logic add message procces order

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
