//Alvaro Machado Feltrin
using AcademiaDoZe.Infrastructure.Data;

namespace AcademiaDoZe.Application.Dependencylnjection;

public class RepositoryConfig
{
    public required string ConnectionString { get; set; }
    public required DatabaseType DatabaseType { get; set; }
}
