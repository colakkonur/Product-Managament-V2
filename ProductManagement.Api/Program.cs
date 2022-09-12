using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Queries.Product.GetProducts;
using ProductManagement.Infrastructure.Contexts;
using ProductManagement.Infrastructure.Repositories;
using ProductManagement.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// veritabanı bağlama
builder.Services.AddDbContext<ProductManagementDbContext>(options =>
    options.UseMySQL("server=94.73.146.49;password=jTy1B3n2.D6_:=gP;user id=u8425942_prod;database=u8425942_prod;"));

// MediatR Area
builder.Services.AddTransient<IProductRepository,ProductRepository>(); 
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddMediatR(typeof(GetProductsQuery).Assembly);

// apiyi tüm platformlardan gelen isteklere açık hale getirme
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(w =>
    {
        w.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseCors(); // apiyi tüm platformlardan gelen isteklere açık hale getirmeyi kullanma
app.UseStaticFiles(); // dosya kaydetme

app.UseAuthorization();

app.MapControllers();

app.Run();