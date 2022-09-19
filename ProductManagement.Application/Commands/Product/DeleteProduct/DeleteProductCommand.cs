using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ProductManagement.Application.Commands.Product.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public DeleteProductCommand(int id)
    {
        Id = id;
    }

    [Required] public int Id { get; set; }
}