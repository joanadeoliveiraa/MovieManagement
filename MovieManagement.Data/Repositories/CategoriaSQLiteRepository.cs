using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;
using MovieManagement.Data.Database;

namespace MovieManagement.Data.Repositories
{
    public class CategoriaSQLiteRepository : ICategoriaRepository
    {
        public void Adicionar(Categoria categoria)
        {
            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Comando SQL para inserir uma nova categoria
            string sql = @"INSERT INTO Categorias (Nome)VALUES (@nome);
    ";

            // Cria o comando SQL
            using var command =new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Substitui o parâmetro @nome pelo valor recebido
            command.Parameters.AddWithValue("@nome",categoria.Nome);

            // Executa o INSERT
            command.ExecuteNonQuery();
        }





        public bool ExistirPorNome(string nome)
        {
            // Abre ligação à base de dados
            using var connection =DatabaseConfig.GetConnection();

            connection.Open();

            // Procura uma categoria com o nome indicado
            string sql = @"SELECT COUNT(*) FROM Categorias WHERE Nome = @nome;";

            // Cria o comando SQL
            using var command =new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Substitui @nome pelo valor recebido
            command.Parameters.AddWithValue("@nome",nome);

            // Executa a consulta e obtém o resultado
            long quantidade =(long)command.ExecuteScalar()!;

            // Se existir pelo menos uma categoria,
            // devolve true
            return quantidade > 0;
        }





        public Categoria? ObterPorNome(string nome)
        {
            // Abre ligação à base de dados
            using var connection =DatabaseConfig.GetConnection();

            connection.Open();

            // Procura uma categoria pelo nome
            string sql = @"SELECT Id, Nome FROM Categorias WHERE Nome = @nome;
    ";

            // Cria o comando SQL
            using var command =new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Substitui o parâmetro @nome pelo valor recebido
            command.Parameters.AddWithValue("@nome",nome);

            // Executa a consulta
            using var reader = command.ExecuteReader();

            // Se encontrou uma categoria
            if (reader.Read())
            {
                return new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                };
            }

            // Não encontrou nenhuma categoria
            return null;
        }





        public List<Categoria> ObterTodos()
        {
            // Lista onde vamos guardar as categorias lidas da BD
            List<Categoria> categorias = new();

            // Abre ligação à base de dados
            using var connection =DatabaseConfig.GetConnection();

            connection.Open();

            // Consulta SQL para obter todas as categorias
            string sql = @"SELECT Id, Nome FROM Categorias;";

            // Cria o comando SQL
            using var command = new Microsoft.Data.Sqlite.SqliteCommand(sql,connection);

            // Executa a consulta
            using var reader =command.ExecuteReader();

            // Percorre todas as linhas devolvidas
            while (reader.Read())
            {
                Categoria categoria = new() // Transformamos cada linha SQL num objeto C#.
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                };

                categorias.Add(categoria);
            }

            // Devolve a lista completa
            return categorias;
        }





        public bool Remover(int id)
        {
            // Abre ligação à base de dados
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // Comando SQL para remover uma categoria pelo Id
            string sql = @" DELETE FROM Categorias WHERE Id = @id;
    ";

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