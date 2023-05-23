using CQRS.Domain.ValuesObjects.v1;

namespace CQRS.Domain.Queries.v1.ListPerson;

public class PersonItemQueryResponse
{
    public PersonItemQueryResponse(string name, string cpf, string email, DateTime dateBirth)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
        DateBirth = dateBirth;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set;}
    public DateTime DateBirth { get; set; }
}