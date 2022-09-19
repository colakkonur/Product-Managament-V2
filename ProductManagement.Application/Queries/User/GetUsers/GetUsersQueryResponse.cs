namespace ProductManagement.Application.Queries.User.GetUsers;

public class GetUsersQueryResponse
{
    public string NameSurname { get; set; }
    public string Mail { get; set; }
    public string Role { get; set; }
    public string Position { get; set; }
    public Company Company { get; set; }
}

public class Company
{
    public string Name { get; set; }
    public string FullAdress { get; set; }
}