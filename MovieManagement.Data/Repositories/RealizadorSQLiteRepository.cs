using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using MovieManagement.Data.Database;

namespace MovieManagement.Data.Repositories
{
    public class RealizadorSQLiteRepository : IRealizadorRepository
    {
        public void Adicionar(Realizador realizador)
        {
            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Comando SQL para inserir um realizador
            string sql = @"INSERT INTO Realizadores (Nome, Pais) VALUES (@nome, @pais);";

            // Cria o comando SQL
            using var command = new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Substitui os parâmetros pelos valores recebidos
            command.Parameters.AddWithValue("@nome",realizador.Nome);

            command.Parameters.AddWithValue("@pais",realizador.Pais);

            // Executa o INSERT
            command.ExecuteNonQuery();
        }




        public bool ExistirPorNome(string nome)
        {
            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Procura um realizador pelo nome
            string sql = @"SELECT COUNT(*) FROM Realizadores WHERE Nome = @nome;";

            // Cria o comando SQL
            using var command = new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Substitui @nome pelo valor recebido
            command.Parameters.AddWithValue("@nome", nome);

            // Executa a consulta
            long quantidade = (long)command.ExecuteScalar()!;

            // Se existir pelo menos um realizador
            return quantidade > 0;
        }






        public Realizador? ObterPorNome(string nome)
        {
            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Procura um realizador pelo nome
            string sql = @"SELECT Id, Nome, Pais FROM Realizadores WHERE Nome = @nome;
    ";

            // Cria o comando SQL
            using var command = new Microsoft.Data.Sqlite.SqliteCommand(sql, connection);

            // Substitui @nome pelo valor recebido
            command.Parameters.AddWithValue("@nome", nome);

            // Executa a consulta
            using var reader = command.ExecuteReader();

            // Se encontrou um realizador
            if (reader.Read())
            {
                return new Realizador
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Pais = reader.GetString(2)
                };
            }

            // Não encontrou nenhum realizador
            return null;
        }




        public List<Realizador> ObterTodos()
        {
            // Lista onde vamos guardar os realizadores lidos da BD
            List<Realizador> realizadores = new();

            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Consulta SQL para obter todos os realizadores
            string sql = @"SELECT Id, Nome, Pais FROM Realizadores;
    ";

            // Cria o comando SQL
            using var command =new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Executa a consulta
            using var reader = command.ExecuteReader();

            // Percorre todas as linhas devolvidas
            while (reader.Read())
            {
                Realizador realizador = new()
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Pais = reader.GetString(2)
                };

                realizadores.Add(realizador);
            }

            // Devolve a lista completa
            return realizadores;
        }





        public bool Remover(int id)
        {
            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Comando SQL para remover um realizador pelo Id
            string sql = @"DELETE FROM Realizadores WHERE Id = @id;";

            // Cria o comando SQL
            using var command =new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Substitui @id pelo valor recebido
            command.Parameters.AddWithValue("@id",id);

            // Executa o DELETE
            int linhasAfetadas = command.ExecuteNonQuery();

            // Se removeu pelo menos uma linha devolve true
            return linhasAfetadas > 0;
        }
    }
}