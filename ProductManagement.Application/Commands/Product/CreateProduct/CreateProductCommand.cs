using MediatR;

namespace ProductManagement.Application.Commands.Product.CreateProduct;

public class CreateProductCommand : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tags { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public PricesForCreate Prices { get; set; }
    public ImagesForCreate Images { get; set; }
}

public class PricesForCreate
{
    public double TaxRate { get; set; }
    public double TaxAmount { get; set; }
    public double Margin { get; set; }
    public double ShippingCost { get; set; }
}

public class ImagesForCreate
{
    public string Path { get; set; }
}