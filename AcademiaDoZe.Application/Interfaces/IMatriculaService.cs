//Alvaro Machado Feltrin
using AcademiaDoZe.Application.DTOs;
using AcademiaDoZe.Application.Enums;

namespace AcademiaDoZe.Application.Interfaces;

public interface IMatriculaService
{
    /// Obtém uma matrícula pelo ID, enriquecida com os dados do aluno.
    Task<MatriculaDto?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);

    /// Obtém todas as matrículas cadastradas.
    Task<IEnumerable<MatriculaDto>> ObterTodasAsync(CancellationToken cancellationToken = default);

    /// Cadastra uma nova matrícula para o aluno, calculando automaticamente a DataFim e validando que o aluno não possua outra matrícula ativa.
    Task<MatriculaDto> AdicionarAsync(MatriculaDto matriculaDto, CancellationToken cancellationToken = default);

    /// Atualiza os dados de uma matrícula existente.
    Task<MatriculaDto> AtualizarAsync(MatriculaDto matriculaDto, CancellationToken cancellationToken = default);

    /// Remove uma matrícula pelo ID.
    Task<bool> RemoverAsync(int id, CancellationToken cancellationToken = default);

    /// Obtém o histórico de matrículas de um aluno específico.
    Task<IEnumerable<MatriculaDto>> ObterPorAlunoIdAsync(int alunoId, CancellationToken cancellationToken = default);

    /// Obtém a matrícula ativa vigente de um aluno, se houver.
    Task<MatriculaDto?> ObterMatriculaAtivaPorAlunoAsync(int alunoId, CancellationToken cancellationToken = default);

    /// Verifica se o aluno possui atualmente uma matrícula ativa.
    Task<bool> PossuiMatriculaAtivaAsync(int alunoId, CancellationToken cancellationToken = default);

    /// Obtém todas as matrículas ativas no sistema ou filtradas por aluno.
    Task<IEnumerable<MatriculaDto>> ObterAtivasAsync(int alunoId = 0, CancellationToken cancellationToken = default);

    /// Obtém as matrículas que estão prestes a vencer dentro do número de dias especificado.
    Task<IEnumerable<MatriculaDto>> ObterVencendoEmDiasAsync(int dias, CancellationToken cancellationToken = default);

    /// Obtém matrículas filtrando pelo tipo de plano contratado (Mensal, Trimestral, Semestral, Anual).
    Task<IEnumerable<MatriculaDto>> ObterPorPlanoAsync(AppMatriculaPlano plano, CancellationToken cancellationToken = default);
}
