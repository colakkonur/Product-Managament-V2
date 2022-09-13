using System.Xml.Serialization;
using MediatR;

namespace ProductManagement.Application.Commands.Product.UpdateProduct;

public class UpdateProductCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tags { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public PriceForUpdate Prices { get; set; }
    public ImageForUpdate Images { get; set; }
}
public class PriceForUpdate
{
    public double TaxRate { get; set; }
    public double TaxAmount { get; set; }
    public double Margin { get; set; }
    public double ShippingCost { get; set; }
}

public class ImageForUpdate
{
    public string Path { get; set; }
}