using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.ShoppingCartApi.DbContexts;
using Restaurant.Services.ShoppingCartApi.Models;
using Restaurant.Services.ShoppingCartApi.Models.Dto;

namespace Restaurant.Services.ShoppingCartApi.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CartRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeaderDb = await _db.CartHeaders.FirstOrDefaultAsync(h => h.UserId == userId);
            if (cartHeaderDb != null)
            {
                _db.CartDetails
                    .RemoveRange(_db.CartDetails.Where(d => d.CartHeaderId == cartHeaderDb.CartHeaderId));
                _db.CartHeaders.Remove(cartHeaderDb);
                await _db.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<CartDto?> CreateUpdateCart(CartDto cartDto)
        {
            if ((cartDto != null) && (cartDto.CarDetails != null) && (cartDto.CarDetails.Count()>0) )
            {
                Cart cart = _mapper.Map<Cart>(cartDto);
                CartDetail detail = cart.CartDetails.First();
                await CreateUpdateProduct(cart, detail);

                var cartHeaderDb = await _db.CartHeaders.AsNoTracking()
                                                        .FirstOrDefaultAsync(h => h.UserId == cart.CartHeader.UserId);
                if(cartHeaderDb==null)
                {
                    _db.CartHeaders.Add(cart.CartHeader);
                    await _db.SaveChangesAsync();
                    await CreateDetail(cart.CartHeader, detail);
                }
                else
                {
                    var cartDetailsDb = await _db.CartDetails.AsNoTracking()
                                                             .FirstOrDefaultAsync(d => d.ProductId == detail.ProductId &&
                                                              d.CartHeaderId == cartHeaderDb.CartHeaderId);
                    if(cartDetailsDb ==null)
                    {
                        await CreateDetail(cart.CartHeader, detail);
                    }
                    else
                    {
                        detail.Product = null;
                        detail.Count += cartDetailsDb.Count;
                        _db.CartDetails.Update(detail);
                        await _db.SaveChangesAsync();
                    }
                }

                cartDto = _mapper.Map<CartDto>(cart);

            }
            return cartDto;
        }

        public async Task CreateDetail(CartHeader header, CartDetail detail)
        {

            detail.CartHeaderId = header.CartHeaderId;
            detail.Product = null;
            _db.CartDetails.Add(detail);
            await _db.SaveChangesAsync();
        }

        public async Task CreateUpdateProduct(Cart cart, CartDetail detail)
        {
            
            var productDb = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == detail.ProductId);
            if (productDb == null)
            {
                _db.Products.Add(detail.Product);
                await _db.SaveChangesAsync();
            }
            else //check for the price
            {
                if (productDb.Price != detail.Product.Price)
                {
                    productDb.Price = detail.Product.Price;
                    _db.Products.Update(productDb);
                    await _db.SaveChangesAsync();
                }
            }
            return;
        }

        public async Task<CartDto> GetCartUserById(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _db.CartHeaders.FirstOrDefaultAsync(h => h.UserId == userId)
            };

            if (cart.CartHeader != null)
            {
                cart.CartDetails = _db.CartDetails
                    .Where(d => d.CartHeaderId == cart.CartHeader.CartHeaderId).Include(p => p.Product);
            }
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveFromCart(int cartDetailId)
        {
            try
            {
                CartDetail? cartDetails = await _db.CartDetails
                    .FirstOrDefaultAsync(d => d.CartDetailId == cartDetailId);

                if (cartDetails!= null)
                {
                    int totalCountOfCartItems = _db.CartDetails
                        .Where(d => d.CartHeaderId == cartDetails.CartHeaderId).Count();

                    _db.CartDetails.Remove(cartDetails);

                    if (totalCountOfCartItems == 1)
                    {
                        var cartHeaderDb = await _db.CartHeaders
                            .FirstAsync(h => h.CartHeaderId == cartDetails.CartHeaderId);

                        _db.CartHeaders.Remove(cartHeaderDb);
                    }
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
