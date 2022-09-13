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
    public PriceN Prices { get; set; }
    public ImageN Images { get; set; }
}

public class PriceN
{
    public double TaxRate { get; set; }
    public double TaxAmount { get; set; }
    public double Margin { get; set; }
    public double ShippingCost { get; set; }
}

public class ImageN
{
    public string Path { get; set; }
}