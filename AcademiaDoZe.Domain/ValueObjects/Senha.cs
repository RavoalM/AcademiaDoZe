//Alvaro Machado Feltrin

namespace AcademiaDoZe.Domain.ValueObjects;

public class Senha
{
    public string Password { get; } //validar como funfa na aula
    private Senha(string senha)
    {
        Password = senha;
    }
}
