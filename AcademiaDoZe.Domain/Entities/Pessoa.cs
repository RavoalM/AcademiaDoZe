//Alvaro Machado Feltrin
using AcademiaDoZe.Domain.ValueObjects;

namespace AcademiaDoZe.Domain.Entities;

public class Pessoa : Entity
{
    public string Nome { get; private set; }
    public Cpf Cpf { get; private set; }
    public Telefone NumeroCelular { get; private set; }
    public Email Email { get; private set; }
    public DateOnly DataNascimento { get; private set; }
    public Endereco Endereco { get; private set; }
    public Senha Senha { get; private set; }
    public Arquivo Foto { get; private set; }

    protected Pessoa(int id, string nome, Cpf cpf, Telefone telefone, Email email, DateOnly dataNascimento, Endereco endereco, Senha senha, Arquivo foto)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        NumeroCelular = telefone;
        Email = email;
        DataNascimento = dataNascimento;
        Endereco = endereco;
        Senha = senha;
        Foto = foto;
    }

}