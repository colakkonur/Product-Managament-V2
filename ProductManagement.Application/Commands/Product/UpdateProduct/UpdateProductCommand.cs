using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ProductManagement.Application.Commands.Product.UpdateProduct;

public class UpdateProductCommand : IRequest
{
    public UpdateProductCommand(int id, string sTitle, string sDescription, string sTags, int iQuantity,
        int iCategoryId, double dTaxRate, double dTaxAmount, double dMargin, double dShippingCost, string sPath)
    {
        Id = id;
        Title = sTitle;
        Description = sDescription;
        Tags = sTags;
        Quantity = iQuantity;
        CategoryId = iCategoryId;
        Prices = new PriceForUpdate()
        {
            TaxRate = dTaxRate,
            TaxAmount = dTaxAmount,
            Margin = dMargin,
            ShippingCost = dShippingCost
        };
        Images = new ImageForUpdate()
        {
            Path = sPath
        };
    }

    public int Id { get; set; }
    [MaxLength(200)] public string Title { get; set; }
    [MaxLength(1000)] public string Description { get; set; }
    [MaxLength(200)] public string Tags { get; set; }
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
    [MaxLength(200)] public string Path { get; set; }
}