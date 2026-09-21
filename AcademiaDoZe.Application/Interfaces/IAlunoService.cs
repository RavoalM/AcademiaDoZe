//Alvaro Machado Feltrin
using AcademiaDoZe.Application.DTOs;

namespace AcademiaDoZe.Application.Interfaces;

public interface IAlunoService
{
    /// Obtém um aluno por ID, incluindo o endereço mapeado quando disponível.
    Task<AlunoDto?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);

    /// Obtém a listagem completa de alunos cadastrados.
    Task<IEnumerable<AlunoDto>> ObterTodosAsync(CancellationToken cancellationToken = default);

    /// Cadastra um novo aluno após validação de CPF, email, senha e aplicação de hash Argon2id.
    Task<AlunoDto> AdicionarAsync(AlunoDto alunoDto, CancellationToken cancellationToken = default);

    /// Atualiza os dados de um aluno existente, preservando integridade de dados e hashing.
    Task<AlunoDto> AtualizarAsync(AlunoDto alunoDto, CancellationToken cancellationToken = default);

    /// Remove o cadastro de um aluno pelo ID.
    Task<bool> RemoverAsync(int id, CancellationToken cancellationToken = default);

    /// Obtém um aluno buscando pelo seu CPF.
    Task<AlunoDto?> ObterPorCpfAsync(string cpf, CancellationToken cancellationToken = default);

    /// Obtém um aluno buscando pelo seu email.
    Task<AlunoDto?> ObterPorEmailAsync(string email, CancellationToken cancellationToken = default);
 
    /// Obtém alunos filtrando pelo nome.
    Task<IEnumerable<AlunoDto>> ObterPorNomeAsync(string nome, CancellationToken cancellationToken = default);

    /// Verifica se já existe um aluno com o CPF informado.
    Task<bool> CpfJaExisteAsync(string cpf, int? id = null, CancellationToken cancellationToken = default);

    /// Verifica se já existe um aluno com o email informado.
    Task<bool> EmailJaExisteAsync(string email, int? id = null, CancellationToken cancellationToken = default);

    /// Realiza a troca de senha do aluno de forma segura gerando novo hash Argon2id.
    Task<bool> TrocarSenhaAsync(int id, string novaSenha, CancellationToken cancellationToken = default);
}
