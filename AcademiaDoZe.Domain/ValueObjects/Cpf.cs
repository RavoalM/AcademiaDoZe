//Alvaro Machado Feltrin

namespace AcademiaDoZe.Domain.ValueObjects;

public record Cpf
{
    public string Valor { get; }
    public Cpf(string valor)
    {
        Valor = valor;
    }
}
