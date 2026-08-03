//Alvaro Machado Feltrin

namespace AcademiaDoZe.Domain.Entities;

public class AcessoAluno : Entity
{
    public int IdAluno{ get; private set; }
    public string Codigo { get; private set; }
    public bool Ativo { get; private set; }

    private AcessoAluno(int idAluno, string codigo)
    {
        IdAluno = idAluno;
        Codigo = codigo;
        Ativo = true;
    }
}
