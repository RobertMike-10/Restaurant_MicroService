using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.ProductApi.Models.Dto;
using Restaurant.Services.ProductApi.Repository;

namespace Restaurant.Services.ProductApi.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<dynamic> Get(int productId)
        {
            try
            {
                ProductDto product = await _repository.GetProductById(productId);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        public async Task<dynamic> Get()
        {
            try
            {
                IEnumerable<ProductDto> products = await _repository.GetProducts();
                _response.Result = products;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<dynamic> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto product = await _repository.CreateUpdateProduct(productDto);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut]
        public async Task<dynamic> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto product = await _repository.CreateUpdateProduct(productDto);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<dynamic> Delete(int productId)
        {
            try
            {
                _response.Result = await _repository.DeleteProduct(productId);
               
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
