using Business;
using Business.Concrete;
using Business.Mapping;
using DataAccess;
using DataAccess.Data;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service Configuration
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISizeService, SizeService>();


// EFEntityRepository Configuration
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<IAddressRepository, EFAddressRepository>();
builder.Services.AddScoped<ICustomerRepository,EFCustomerRepository >();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository >();
builder.Services.AddScoped<IColorRepository, EFColorRepository>();
builder.Services.AddScoped<IImageRepository, EFImageRepository>();
builder.Services.AddScoped<IInventoryRepository, EFInventoryRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddScoped<IPaymentRepository, EFPaymentRepository>();
builder.Services.AddScoped<ISizeRepository, EFSizeRepository>();

// Add Mapping
builder.Services.AddAutoMapper(typeof(MapProfile));

// Connect to Db
builder.Services.AddDbContext<ApiDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
