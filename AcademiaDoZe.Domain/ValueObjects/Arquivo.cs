//Alvaro Machado Feltrin

namespace AcademiaDoZe.Domain.ValueObjects;

public sealed record Arquivo //Deixar base para ver como vai ser realizado em aula
{ 
    public string Nome { get; } 
    public string Caminho { get; } 
    public Arquivo(string nome, string caminho) 
    {
        Nome = nome; 
        Caminho = caminho; 
    } 
}

