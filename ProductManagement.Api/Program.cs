using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Queries.Product.GetProducts;
using ProductManagement.Infrastructure.Contexts;
using ProductManagement.Infrastructure.Repositories;
using ProductManagement.Infrastructure.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// veritabanı bağlama
builder.Services.AddDbContext<ProductManagementDbContext>(options =>
    options.UseMySQL(builder.Configuration["ProductManagementDb:ConnectionString"]));
// ya da direkt UseMySQL("xyz") şeklinde verilebilir.

// MediatR Area
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddTransient<ISecurityRepository, SecurityRepository>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddMediatR(typeof(GetProductsQuery).Assembly);

// API'yi tüm platformlardan gelen isteklere açık hale getirme
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(w => { w.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2",new OpenApiSecurityScheme
    {
        Description = "Standart Authorization header using the Bearer scheme(\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//Authentiaciton Area
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Secret").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();