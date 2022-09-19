using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ProductManagement.Application.Commands.Product.CreateProduct;

public class CreateProductCommand : IRequest
{
    [Required, MaxLength(200)] public string Title { get; set; }
    [Required, MaxLength(1000)] public string Description { get; set; }
    [Required, MaxLength(200)] public string Tags { get; set; }
    [Required] public int Quantity { get; set; }
    [Required] public int CategoryId { get; set; }
    [Required] public int CompanyId { get; set; }
    [Required] public PricesForCreate Prices { get; set; }
    public ImagesForCreate Images { get; set; }
}

public class PricesForCreate
{
    [Required] public double TaxRate { get; set; }
    [Required] public double TaxAmount { get; set; }
    [Required] public double Margin { get; set; }
    [Required] public double ShippingCost { get; set; }
}

public class ImagesForCreate
{
    [MaxLength(200)] public string Path { get; set; }
}