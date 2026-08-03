
//Alvaro Machado Feltrin
using AcademiaDoZe.Domain.Entities;

namespace AcademiaDoZe.Domain.ValueObjects;

public class Endereco
{
    public Logradouro Logradouro { get; }
    public string Numero { get; }
    public string? Complemento { get; }


    private Endereco(Logradouro logradouro, string numeroCasa, string? complemento)
    {
        Logradouro = logradouro;
        Numero = numeroCasa;
        Complemento = complemento;
    }

}
