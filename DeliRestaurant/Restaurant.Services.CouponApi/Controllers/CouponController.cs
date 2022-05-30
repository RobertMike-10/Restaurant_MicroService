using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.CouponApi.Models.Dto;
using Restaurant.Services.CouponApi.Repository;

namespace Restaurant.Services.CouponApi.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    public class CouponController : Controller
    {
        protected ResponseDto _response;
        private ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository;
            this._response = new ResponseDto();
        }

        [HttpGet("GetCoupon/{code}")]
        public async Task <dynamic> GetCouponForCode(string code)
        {
            try
            {
                CouponDto coupon = await _repository.GetCouponByCode(code);
                _response.Result = coupon;
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
