namespace ProductManagement.Application.Queries.User.GetUserById;

public class GetUserByIdQueryResponse
{
    public int Id { get; set; }
    public string NameSurname { get; set; }
    public string Mail { get; set; }
    public string Role { get; set; }
    public string Position { get; set; }
    public Company Company { get; set; }
    public ResposeStatus Status { get; set; }
}

public class Company
{
    public string Name { get; set; }
    public string FullAdress { get; set; }
}

public class ResposeStatus
{
    public int Type { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
}