//Alvaro Machado Feltrin

namespace AcademiaDoZe.Domain.ValueObjects;

public sealed record Cep 
{ 
    public string Valor { get; } 
    public Cep(string valor) 
    { 
        Valor = valor; 
    } 
}
