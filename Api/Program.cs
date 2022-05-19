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


// EFEntityRepository Configuration
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<IAdrressRepository,EFAddressRepository >();
builder.Services.AddScoped<ICustomerRepository,EFCustomerRepository >();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository >();
builder.Services.AddScoped<IColorRepository, EFColorRepository>();
builder.Services.AddScoped<IImageRepository, EFImageRepository>();
builder.Services.AddScoped<IInventoryRepository, EFInventoryRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddScoped<IPaymentRepository, EFPaymentRepository>();
builder.Services.AddScoped<ISizeRepository, EFSizeRepository>();

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
