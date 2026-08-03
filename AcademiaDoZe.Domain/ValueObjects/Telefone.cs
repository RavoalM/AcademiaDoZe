//Alvaro Machado Feltrin

namespace AcademiaDoZe.Domain.ValueObjects;

public class Telefone
{
    public string Numero { get; private set; }
    private Telefone(string numero)
    {
        Numero = numero;
    }
}