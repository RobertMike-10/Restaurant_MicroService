using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.CouponApi.DbContexts;
using Restaurant.Services.CouponApi.Models.Dto;

namespace Restaurant.Services.CouponApi.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CouponRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode)
        {
            var coupon = await _db.Coupons.FirstOrDefaultAsync(c => c.CouponCode== couponCode);

            return _mapper.Map<CouponDto>(coupon);
        }
    }
}
