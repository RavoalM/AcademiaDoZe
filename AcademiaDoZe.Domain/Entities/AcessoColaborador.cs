//Alvaro Machado Feltrin

namespace AcademiaDoZe.Domain.Entities;

public class AcessoColaborador : Entity
{
    public int IdColaborador { get; private set; }
    public string Codigo { get; private set; }
    public bool Ativo { get; private set; }

    private AcessoColaborador(int Idcolaborador, string codigo)
    {
        IdColaborador = Idcolaborador;
        Codigo = codigo;
        Ativo = true;
    }
}
