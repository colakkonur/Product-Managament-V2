namespace ProductManagement.Application.Queries.GetProductById;

public class GetProductByIdQueryResponse
{
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tags { get; set; }
    public string Image { get; set; }
    public int? Quantity { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public ResposeStatus Status { get; set; }
}

public class ResposeStatus
{
    public int Type { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
}