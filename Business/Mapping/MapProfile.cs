using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Address, AddressDisplayResponse>();
            CreateMap<Category, CategoryDisplayResponse>();
            CreateMap<Color, ColorDisplayResponse>();
            CreateMap<Customer, CustomerDisplayResponse>();
            CreateMap<Customer, CustomerListResponse>();
            CreateMap<Image, ImageDisplayResponse>();
            CreateMap<Inventory, InventoryDisplayResponse>();
            CreateMap<Order, OrderDisplayResponse>();
            CreateMap<Payment, PaymentDisplayResponse>();
            CreateMap<Product, ProductDisplayResponse>();
            CreateMap<Product, ProductCardDisplayResponse>();
            CreateMap<Size, SizeDisplayResponse>();
            
            CreateMap<AddAddressRequest, Address>();
            CreateMap<AddCategoryRequest, Category>();
            CreateMap<AddColorRequest, Color>();
            CreateMap<AddCustomerRequest, Customer>();
            CreateMap<AddImageRequest, Image>();
            CreateMap<AddInventoryRequest, Inventory>();
            CreateMap<AddOrderRequest, Order>();
            CreateMap<AddPaymentRequest, Payment>();
            CreateMap<AddProductRequest, Product>();
            CreateMap<AddSizeRequest, Size>();
        }
    }
}
