//Alvaro Machado Feltrin
using AcademiaDoZe.Domain.ValueObjects;

namespace AcademiaDoZe.Domain.Entities;

public class Aluno : Pessoa
{
    public string Matricula { get; private set; }

    private Aluno(int id,
    string nome,
    Cpf cpf,
    Telefone telefone,
    DateOnly dataNascimento,
    Email email,
    Endereco endereco,
    Senha senha,
    Arquivo foto,
    string matricula)

    : base(id, nome, cpf, telefone, email, dataNascimento, endereco, senha, foto)
    {
        Matricula = matricula;
    }
}
