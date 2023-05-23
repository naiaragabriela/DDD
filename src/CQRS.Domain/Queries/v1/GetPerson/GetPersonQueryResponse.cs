using CQRS.Domain.Commands.v1.UpdatePerson;

namespace CQRS.Domain.Queries.v1.GetPerson;

public class GetPersonQueryResponse
{
    public GetPersonQueryResponse(string name, string cpf, string email, DateTime dateBirth)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
        DateBirth = dateBirth;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public DateTime DateBirth { get; set;}
}