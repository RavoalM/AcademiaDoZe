-- Alvaro Machado Feltrin
-- Observação: PRAGMA foreign_keys = ON deve ser executado por conexão na aplicação.
PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS tb_logradouro (
	id_logradouro INTEGER PRIMARY KEY AUTOINCREMENT,
	cep TEXT NOT NULL UNIQUE,
	nome TEXT NOT NULL,
	bairro TEXT NOT NULL,
	cidade TEXT NOT NULL,
	estado TEXT NOT NULL,
	pais TEXT NOT NULL DEFAULT 'Brasil'
);

CREATE INDEX IF NOT EXISTS ix_tb_logradouro_cep ON tb_logradouro(cep);
CREATE INDEX IF NOT EXISTS ix_tb_logradouro_cidade ON tb_logradouro(cidade);

CREATE TABLE IF NOT EXISTS tb_aluno (
	id_aluno INTEGER PRIMARY KEY AUTOINCREMENT,
	cpf TEXT NOT NULL UNIQUE,
	nome TEXT NOT NULL,
	nascimento TEXT NOT NULL, -- YYYY-MM-DD
	telefone TEXT NOT NULL,
	email TEXT NOT NULL,
	logradouro_id INTEGER NOT NULL,
	numero TEXT NOT NULL,
	complemento TEXT NULL,
	senha TEXT NOT NULL,
	foto BLOB NULL,
	FOREIGN KEY (logradouro_id) REFERENCES tb_logradouro(id_logradouro) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE INDEX IF NOT EXISTS ix_tb_aluno_cpf ON tb_aluno(cpf);

CREATE TABLE IF NOT EXISTS tb_colaborador (
	id_colaborador INTEGER PRIMARY KEY AUTOINCREMENT,
	cpf TEXT NOT NULL UNIQUE,
	nome TEXT NOT NULL,
	nascimento TEXT NOT NULL, -- YYYY-MM-DD
	telefone TEXT NOT NULL,
	email TEXT NOT NULL,
	logradouro_id INTEGER NOT NULL,
	numero TEXT NOT NULL,
	complemento TEXT NULL,
	senha TEXT NOT NULL,
	foto BLOB NULL,
	admissao TEXT NOT NULL, -- YYYY-MM-DD
	tipo INTEGER NOT NULL CHECK(tipo IN (0,1,2)), -- 0=Administrador,1=Atendente,2=Instrutor
	vinculo INTEGER NOT NULL CHECK(vinculo IN (0,1)), -- 0=CLT,1=Estágio
	FOREIGN KEY (logradouro_id) REFERENCES tb_logradouro(id_logradouro) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE INDEX IF NOT EXISTS ix_tb_colaborador_cpf ON tb_colaborador(cpf);

CREATE TABLE IF NOT EXISTS tb_matricula (
	id_matricula INTEGER PRIMARY KEY AUTOINCREMENT,
	aluno_id INTEGER NOT NULL,
	plano INTEGER NOT NULL CHECK(plano IN (0,1,2,3)), -- 0=Mensal,1=Trimestral,2=Semestral,3=Anual
	data_inicio TEXT NOT NULL, -- YYYY-MM-DD
	data_fim TEXT NOT NULL, -- YYYY-MM-DD
	objetivo TEXT NOT NULL,
	restricao_medica INTEGER NOT NULL DEFAULT 0,
	obs_restricao TEXT NULL,
	laudo_medico BLOB NULL,
	FOREIGN KEY (aluno_id) REFERENCES tb_aluno(id_aluno) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE INDEX IF NOT EXISTS ix_tb_matricula_aluno_id ON tb_matricula(aluno_id);
CREATE INDEX IF NOT EXISTS ix_tb_matricula_data_fim ON tb_matricula(data_fim);

CREATE TABLE IF NOT EXISTS tb_acesso (
	id_acesso INTEGER PRIMARY KEY AUTOINCREMENT,
	pessoa_tipo INTEGER NOT NULL CHECK(pessoa_tipo IN (0,1)), -- 0 = Aluno, 1 = Colaborador
	pessoa_id INTEGER NOT NULL,
	data_hora TEXT NOT NULL DEFAULT (CURRENT_TIMESTAMP)
);
CREATE INDEX IF NOT EXISTS ix_tb_acesso_pessoa ON tb_acesso(pessoa_tipo, pessoa_id);
CREATE INDEX IF NOT EXISTS ix_tb_acesso_data_hora ON tb_acesso(data_hora);

-- Triggers para validar integridade da associação polimórfica em tb_acesso
CREATE TRIGGER IF NOT EXISTS trg_tb_acesso_validate_insert
BEFORE INSERT ON tb_acesso
FOR EACH ROW
BEGIN
  SELECT
    CASE
      WHEN NEW.pessoa_tipo = 0 AND (SELECT id_aluno FROM tb_aluno WHERE id_aluno = NEW.pessoa_id) IS NULL THEN
        RAISE(ABORT, 'Aluno nao encontrado para tb_acesso.pessoa_id')
      WHEN NEW.pessoa_tipo = 1 AND (SELECT id_colaborador FROM tb_colaborador WHERE id_colaborador = NEW.pessoa_id) IS NULL THEN
        RAISE(ABORT, 'Colaborador nao encontrado para tb_acesso.pessoa_id')
    END;
END;

CREATE TRIGGER IF NOT EXISTS trg_tb_acesso_validate_update
BEFORE UPDATE ON tb_acesso
FOR EACH ROW
BEGIN
  SELECT
    CASE
      WHEN NEW.pessoa_tipo = 0 AND (SELECT id_aluno FROM tb_aluno WHERE id_aluno = NEW.pessoa_id) IS NULL THEN
        RAISE(ABORT, 'Aluno nao encontrado para tb_acesso.pessoa_id (UPDATE)')
      WHEN NEW.pessoa_tipo = 1 AND (SELECT id_colaborador FROM tb_colaborador WHERE id_colaborador = NEW.pessoa_id) IS NULL THEN
        RAISE(ABORT, 'Colaborador nao encontrado para tb_acesso.pessoa_id (UPDATE)')
    END;
END;