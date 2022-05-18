using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.ProductApi.DbContexts;
using Restaurant.Services.ProductApi.Models;
using Restaurant.Services.ProductApi.Models.Dto;

namespace Restaurant.Services.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
           Product product = _mapper.Map<Product>(productDto);
          if (_db.Products.Any(x => x.ProductId == product.ProductId))
          {
                _db.Products.Update(product);
          }
          else
           {
                _db.Products.Add(product);
           }

            await _db.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product? product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product == null) return false;
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product? product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _db.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
