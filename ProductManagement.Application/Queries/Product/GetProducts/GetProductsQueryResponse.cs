namespace ProductManagement.Application.Queries.Product.GetProducts;

public class GetProductsQueryResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tags { get; set; }
    public string? Image { get; set; }
    public int? Quantity { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}