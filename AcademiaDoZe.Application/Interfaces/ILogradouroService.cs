using AcademiaDoZe.Application.DTOs;
//Alvaro Machado Feltrin
namespace AcademiaDoZe.Application.Interfaces;

public interface ILogradouroService
{
    /// Obtém um logradouro pelo seu identificador único.
    Task<LogradouroDto?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);

    /// Obtém todos os logradouros cadastrados.
    Task<IEnumerable<LogradouroDto>> ObterTodosAsync(CancellationToken cancellationToken = default);
    
    /// Cadastra um novo logradouro após validar regras de formatação e unicidade de CEP.  
    Task<LogradouroDto> AdicionarAsync(LogradouroDto logradouroDto, CancellationToken cancellationToken = default);

    /// Atualiza os dados de um logradouro existente.
    Task<LogradouroDto> AtualizarAsync(LogradouroDto logradouroDto, CancellationToken cancellationToken = default);

    /// Remove um logradouro pelo identificador.
    Task<bool> RemoverAsync(int id, CancellationToken cancellationToken = default);

    /// Obtém um logradouro pelo seu CEP.
    Task<LogradouroDto?> ObterPorCepAsync(string cep, CancellationToken cancellationToken = default);

    /// Verifica se já existe um logradouro com o CEP informado.
    Task<bool> CepJaExisteAsync(string cep, int? id = null, CancellationToken cancellationToken = default);

    /// Obtém todos os logradouros de uma cidade específica.
    Task<IEnumerable<LogradouroDto>> ObterPorCidadeAsync(string cidade, CancellationToken cancellationToken = default);

    /// Obtém todos os logradouros de um bairro específico em uma cidade.
    Task<IEnumerable<LogradouroDto>> ObterPorBairroAsync(string cidade, string bairro, CancellationToken cancellationToken = default);
}
