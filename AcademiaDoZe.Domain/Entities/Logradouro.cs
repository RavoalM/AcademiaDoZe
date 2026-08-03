//Alvaro Machado Feltrin

using AcademiaDoZe.Domain.ValueObjects;

namespace AcademiaDoZe.Domain.Entities;

public class Logradouro : Entity
{
    public Cep Cep { get; private set; }
    public string Pais { get; private set; }
    public string Estado { get; private set; }
    public string Cidade { get; private set; }
    public string Bairro { get; private set; }
    public string Rua { get; private set; }
    public string? Complemento { get; private set; }

    public Logradouro(Cep cep, string pais, string estado, string cidade, string bairro, string rua, string? complemento)
    {
        Cep = cep;
        Pais = pais;
        Estado = estado;
        Cidade = cidade;
        Bairro = bairro;
        Rua = rua;
        Complemento = complemento;
    }
}
