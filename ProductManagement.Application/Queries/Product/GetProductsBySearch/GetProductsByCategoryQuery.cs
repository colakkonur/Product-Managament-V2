using MediatR;

namespace ProductManagement.Application.Queries.Product.GetProductsBySearch;

public class GetProductsBySearchQuery : IRequest<List<GetProductsBySearchQueryResponse>>
{
    public string SearchText { get; set; }

    public GetProductsBySearchQuery(string text)
    {
        SearchText = text;
    }
}