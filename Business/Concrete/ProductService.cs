using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IImageRepository imageRepository,IMapper mapper,ISizeRepository sizeRepository)
        {
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            _mapper = mapper;
            _sizeRepository = sizeRepository;
        }
        
        public async Task<int> AddProduct(object request)
        {
            var product = _mapper.Map<Product>(request);
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;
            await _productRepository.Create(product);
            return product.Id;
        }

        public async Task<int> AddSizeToProduct(int sizeId, int productId)
        {
            var product = await _productRepository.GetById(productId);
            var size = await _sizeRepository.GetById(sizeId);
            await _productRepository.AddSizeToProduct(product,size);
            return product.Id;


        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<IList<ProductCardDisplayResponse>> GetActiveProducts()
        {
            var products = await _productRepository.GetActiveProducts();
            var response = _mapper.Map<IList<ProductCardDisplayResponse>>(products);
            int length = products.Count();

            for (int i = 0; i < length; i++)
            {
                response[i].Url = products.ElementAt(i).Images.ElementAt(0)?.Url;
            }
            return response;
        }

        public async Task<ProductDisplayResponse> GetProduct(int id)
        {
            var product = await _productRepository.GetById(id);
            var response = _mapper.Map<ProductDisplayResponse>(product);
            var images = await _imageRepository.GetImagesByProduct(id);
            response.Sizes = _mapper.Map<IList<SizeDisplayResponse>>(await _sizeRepository.GetSizesByProduct(product));
            response.Images = _mapper.Map<IList<ImageDisplayResponse>>(images);
            return response;
        }

        public async Task<IList<ProductCardDisplayResponse>> GetProductByColor(int colorId)
        {
            var products = await _productRepository.GetProductsByColor(colorId);
            var response = _mapper.Map<IList<ProductCardDisplayResponse>>(products);
            int length = products.Count();
            return response;
        }

        public async Task<IList<ProductCardDisplayResponse>> GetProductByCreatedDate(DateTime time)
        {
            var products = await _productRepository.GetProductsByCreatedDate(time);
            var response = _mapper.Map<IList<ProductCardDisplayResponse>>(products);
            int length = products.Count();
            return response;
        }

        public async Task<IList<ProductCardDisplayResponse>> GetProductByName(string key)
        {
            var products = await _productRepository.GetProductsByName(key);
            var response = _mapper.Map<IList<ProductCardDisplayResponse>>(products);
            int length = products.Count();
            return response;
        }

        public async Task<IList<ProductCardDisplayResponse>> GetProductBySize(int sizeId)
        {
            var products = await _productRepository.GetProductsBySize(sizeId);
            var response = _mapper.Map<IList<ProductCardDisplayResponse>>(products);
            int length = products.Count();
            return response;
        }

        public async Task<IList<ProductCardDisplayResponse>> GetProductByUpdatedDate(DateTime time)
        {
            var products = await _productRepository.GetProductsByUpdatedDate(time);
            var response = _mapper.Map<IList<ProductCardDisplayResponse>>(products);
            int length = products.Count();
            return response;
        }

        public async Task<IList<ProductCardDisplayResponse>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            var response = _mapper.Map<IList<ProductCardDisplayResponse>>(products);
            int length = products.Count();
            return response;
        }

        public async Task<IList<ProductCardDisplayResponse>> GetUnactiveProducts()
        {
            var products = await _productRepository.GetUnactiveProducts();
            var response = _mapper.Map<IList<ProductCardDisplayResponse>>(products);
            int length = products.Count();
            return response;
        }

        public async Task<bool> IsProductExist(int id)
        {
            return await _productRepository.IsExist(id);
        }

        public async Task UpdateProduct(object request)
        {
            var product = _mapper.Map<Product>(request);
            product.UpdatedAt = DateTime.Now;
            await _productRepository.Update(product);
        }
    }
}
