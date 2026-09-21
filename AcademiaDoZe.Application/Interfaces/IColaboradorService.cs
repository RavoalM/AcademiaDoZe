//Alvaro Machado Feltrin
using AcademiaDoZe.Application.DTOs;
using AcademiaDoZe.Application.Enums;

namespace AcademiaDoZe.Application.Interfaces;

public interface IColaboradorService
{

    /// Obtém um colaborador pelo seu ID.
    Task<ColaboradorDto?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);

    /// Obtém todos os colaboradores cadastrados.
    Task<IEnumerable<ColaboradorDto>> ObterTodosAsync(CancellationToken cancellationToken = default);

    /// Cadastra um novo colaborador após validação de CPF, email, senha e aplicação de hash Argon2id.
    Task<ColaboradorDto> AdicionarAsync(ColaboradorDto colaboradorDto, CancellationToken cancellationToken = default);

    /// Atualiza os dados de um colaborador existente.
    Task<ColaboradorDto> AtualizarAsync(ColaboradorDto colaboradorDto, CancellationToken cancellationToken = default);

    /// Remove um colaborador pelo ID.
    Task<bool> RemoverAsync(int id, CancellationToken cancellationToken = default);

    /// Obtém um colaborador buscando pelo seu CPF.
    Task<ColaboradorDto?> ObterPorCpfAsync(string cpf, CancellationToken cancellationToken = default);

    /// Obtém um colaborador buscando pelo seu email.
    Task<ColaboradorDto?> ObterPorEmailAsync(string email, CancellationToken cancellationToken = default);

    /// Obtém colaboradores filtrando pelo cargo/tipo (ex: Instrutor, Recepcionista, etc.).
    Task<IEnumerable<ColaboradorDto>> ObterPorTipoAsync(AppColaboradorTipo tipo, CancellationToken cancellationToken = default);

    /// Obtém colaboradores filtrando pelo regime/vínculo (ex: CLT, Estágio).
    Task<IEnumerable<ColaboradorDto>> ObterPorVinculoAsync(AppColaboradorVinculo vinculo, CancellationToken cancellationToken = default);

    /// Verifica se já existe um colaborador com o CPF informado.
    Task<bool> CpfJaExisteAsync(string cpf, int? id = null, CancellationToken cancellationToken = default);

    /// Verifica se já existe um colaborador com o email informado.
    Task<bool> EmailJaExisteAsync(string email, int? id = null, CancellationToken cancellationToken = default);

    /// Realiza a troca de senha do colaborador gerando novo hash Argon2id.
    Task<bool> TrocarSenhaAsync(int id, string novaSenha, CancellationToken cancellationToken = default);
}
