using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoeses.Contracts.Interface;
using Shoeses.Entitis.Users;
using Shoeses.persistence.EF;
using Shoeses.persistence.EF.Addresses;
using Shoeses.persistence.EF.Categoryes;
using Shoeses.persistence.EF.Orders;
using Shoeses.persistence.EF.Products;
using Shoeses.persistence.EF.Promotions;
using Shoeses.persistence.EF.Reviews;
using Shoeses.persistence.EF.ShoppingCarts;
using Shoeses.persistence.EF.Users;
using Shoeses.Services.Addresses;
using Shoeses.Services.Addresses.Contracts;
using Shoeses.Services.Categoryes;
using Shoeses.Services.Categoryes.Contracts;
using Shoeses.Services.Categoryes.Contracts.Dtos;
using Shoeses.Services.Orders;
using Shoeses.Services.Orders.Contracts;
using Shoeses.Services.Products.Contracts;
using Shoeses.Services.Reviews.Contracts;
using Shoeses.Services.Reviews;
using Shoeses.Services.Users;
using Shoeses.Services.Users.Contracts;
using Shoeses.Services.Products;
using Shoeses.Services.Promotions;
using Shoeses.Services.Promotions.Contracts;
using Shoeses.Services.ShoppingCarts;
using Shoeses.Services.ShoppingCarts.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//add db
builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EFDataContext>(
    options => options.UseSqlServer(connectionString));
builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<EFDataContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<UserService, UserAppService>();
builder.Services.AddScoped<addressService, AddressAppService>();
builder.Services.AddScoped<userRepository, EFUserRepository>();
builder.Services.AddScoped<AdressRepository, EFAdressRepository>();
builder.Services.AddScoped<CategoryService, CategoryAppServiec>();
builder.Services.AddScoped<CatecoryesRepository, EFCategoryesRepository>();
builder.Services.AddScoped<ProductRepository,EFProductRepository>();
builder.Services.AddScoped<ReviewService, ReviewAppService>();
builder.Services.AddScoped<ReviewRepository, EFReviewRepository>();
builder.Services.AddScoped<ProductService, ProductAppService>();
builder.Services.AddScoped<ProductRepository, EFProductRepository>();
builder.Services.AddScoped<PromotionService, PromotionAppService>();
builder.Services.AddScoped<PromotionRepository, EFPromotionRepository>();
builder.Services.AddScoped<OrderRepository,EFOrderRepository>();
builder.Services.AddScoped<OrderService, OrderAppService>();
builder.Services.AddScoped<ShoppingCartService, ShoppingCartAppService>();
builder.Services.AddScoped<ShoppingCartRepository, EFShoppingCartRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
