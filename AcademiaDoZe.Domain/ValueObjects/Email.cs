//Alvaro Machado Feltrin
namespace AcademiaDoZe.Domain.ValueObjects;

public class Email
{
    public string EnderecoEmail { get; }
    public Email(string enderecoEmail)
    {
        EnderecoEmail = enderecoEmail;
    }
}
