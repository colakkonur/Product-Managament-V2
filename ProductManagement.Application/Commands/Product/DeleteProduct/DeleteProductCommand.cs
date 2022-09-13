using MediatR;

namespace ProductManagement.Application.Commands.Product.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public DeleteProductCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}