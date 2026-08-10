//Alvaro Machado Feltrin
using AcademiaDoZe.Domain.Common;
using AcademiaDoZe.Domain.Services;

namespace AcademiaDoZe.Domain.ValueObjects;

public record Cpf
{
    public string Valor { get; }
    private Cpf(string valor)
    {
        Valor = valor;
    }

    public static Result<Cpf> Criar(string valor)
    {
        if (NormalizadoService.TextoVazioOuNulo(valor))
            return Result<Cpf>.Failure("Cpf", "CPF_OBRIGATORIO");

        var cpf = NormalizadoService.LimparEDigitos(valor);

        if (cpf.Length != 11)
            return Result<Cpf>.Failure("Cpf", "CPF_DIGITOS");

        if (cpf.Distinct().Count() == 1)
            return Result<Cpf>.Failure("Cpf", "CPF_INVALIDO");

        //if (!ValidarDigitos(cpf))
        //    return Result<Cpf>.Failure("Cpf", "CPF_INVALIDO");

        return Result<Cpf>.Success(new Cpf(cpf));
    }

    private static bool ValidarDigitos(string cpf)
    {
        var soma = 0;

        for (var i = 0; i < 9; i++)
            soma += (cpf[i] - '0') * (10 - i);

        var resto = soma % 11;
        var digito1 = resto < 2 ? 0 : 11 - resto;

        if (digito1 != cpf[9] - '0')
            return false;

        soma = 0;

        for (var i = 0; i < 10; i++)
            soma += (cpf[i] - '0') * (11 - i);

        resto = soma % 11;
        var digito2 = resto < 2 ? 0 : 11 - resto;

        return digito2 == cpf[10] - '0';
    }

    public override string ToString() => Valor;
}