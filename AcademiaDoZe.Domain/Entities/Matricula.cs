//Alvaro Machado Feltrin

using AcademiaDoZe.Domain.Enums;

namespace AcademiaDoZe.Domain.Entities;

public class Matricula : Entity
{
    public int IdAluno { get; private set; }
    public MatriculaPlano Plano { get; private set; }
    public MatriculaRestricoes Restricoes { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime DataFim { get; private set; }
    public decimal Valor { get; private set; }
    public bool Ativa { get; private set; }

    private Matricula(int idAluno, MatriculaPlano plano, MatriculaRestricoes restricoes, DateTime dataInicio, DateTime dataFim, decimal valor)
    {
        IdAluno = idAluno;
        Plano = plano;
        Restricoes = restricoes;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Valor = valor;
        Ativa = true;
    }
}
