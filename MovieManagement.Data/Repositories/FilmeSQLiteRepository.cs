using MovieManagement.Data.Database;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Enums;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data.Repositories
{
    public class FilmeSQLiteRepository : IFilmeRepository
    {
        public void Adicionar(Filme filme)
        {
            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Comando SQL para inserir um filme
            string sql = @"INSERT INTO Filmes (Titulo,Ano,Lingua,Classificacao,CategoriaId,RealizadorId) VALUES (@titulo, @ano, @lingua, @classificacao, @categoriaId, @realizadorId); ";

            // Cria o comando SQL
            using var command = new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Substitui os parâmetros pelos valores do filme
            command.Parameters.AddWithValue("@titulo", filme.Titulo);
            command.Parameters.AddWithValue("@ano", filme.Ano);
            command.Parameters.AddWithValue("@lingua", filme.Lingua);
            command.Parameters.AddWithValue("@classificacao", (int)filme.Classificacao);
            command.Parameters.AddWithValue("@categoriaId", filme.Categoria.Id);
            command.Parameters.AddWithValue("@realizadorId", filme.Realizador.Id);

            // Executa o INSERT
            command.ExecuteNonQuery();
        }



        public bool ExistePorTitulo(string titulo)
        {
            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();
                        connection.Open();

            // Procura um filme pelo título
            string sql = @"SELECT COUNT(*) FROM Filmes WHERE Titulo = @titulo;
    ";

            // Cria o comando SQL
            using var command = new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Substitui @titulo pelo valor recebido
            command.Parameters.AddWithValue("@titulo",titulo);

            // Executa a consulta
            long quantidade = (long)command.ExecuteScalar()!;

            // Se existir pelo menos um filme devolve true
            return quantidade > 0;
        }





        public Filme? ObterPorTitulo(string titulo)
        {
            // Percorre todos os filmes da base de dados
            foreach (Filme filme in ObterTodos())
            {
                if (filme.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return filme;
                }
            }
            return null;
        }





        public List<Filme> ObterTodos()
        {
            List<Filme> filmes = new();

            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Consulta SQL
            string sql = @"SELECT
            f.Id,
            f.Titulo,
            f.Ano,
            f.Lingua,
            f.Classificacao,
            c.Id,
            c.Nome,
            r.Id,
            r.Nome,
            r.Pais
        FROM Filmes f INNER JOIN Categorias c ON f.CategoriaId = c.Id INNER JOIN Realizadores r ON f.RealizadorId = r.Id;";

            // Cria o comando SQL
            using var command = new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Executa a consulta
            using var reader = command.ExecuteReader();

            // Percorre todas as linhas
            while (reader.Read())
            {
                Filme filme = new()
                {
                    Id = reader.GetInt32(0),
                    Titulo = reader.GetString(1),
                    Ano = reader.GetInt32(2),
                    Lingua = reader.GetString(3),
                    Classificacao = (ClassificacaoFilme)reader.GetInt32(4),

                    Categoria = new Categoria
                    {
                        Id = reader.GetInt32(5),
                        Nome = reader.GetString(6)
                    },

                    Realizador = new Realizador
                    {
                        Id = reader.GetInt32(7),
                        Nome = reader.GetString(8),
                        Pais = reader.GetString(9)
                    }
                };

                filmes.Add(filme);
            }

            return filmes;
        }





        public bool Remover(int id)
        {
            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Comando SQL para remover um filme pelo Id
            string sql = @"DELETE FROM Filmes WHERE Id = @id;";

            // Cria o comando SQL
            using var command =new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Substitui @id pelo valor recebido
            command.Parameters.AddWithValue("@id", id);

            // Executa o DELETE
            int linhasAfetadas = command.ExecuteNonQuery();

            // Se removeu pelo menos uma linha devolve true
            return linhasAfetadas > 0;
        }
    }
}