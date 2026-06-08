using Microsoft.Data.Sqlite;

namespace MovieManagement.Data.Database
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            // Abre uma ligação à base de dados SQLite
            using var connection = DatabaseConfig.GetConnection();

            connection.Open();

            // ======================================================
            // TABELA Categorias
            // ======================================================
            // Comando SQL responsável por criar a tabela CATEGORIAS
            // Apenas cria a tabela caso ela ainda não exista
            string sql = @"CREATE TABLE IF NOT EXISTS Categorias(Id INTEGER PRIMARY KEY AUTOINCREMENT,Nome TEXT NOT NULL);"; //  INTEGER PRIMARY KEY AUTOINCREMENT: Chave primária da tabela
                                                                                                                             // O SQLite gera automaticamente o próximo Id
                                                                                                                             // NOT NULL: Campo de texto obrigatório
                                                                                                                             // Não permite valores nulos

            // Cria o comando SQL associado à ligação aberta
            using var command = new SqliteCommand(sql, connection);

            // Executa o comando SQL
            // Neste caso cria a tabela Categorias na base de dados
            command.ExecuteNonQuery();


            // ======================================================
            // TABELA REALIZADORES
            // ======================================================
            // Comando SQL responsável por criar a tabela REALIZADORES
            string sqlRealizadores = @"CREATE TABLE IF NOT EXISTS Realizadores(Id INTEGER PRIMARY KEY AUTOINCREMENT,Nome TEXT NOT NULL,Pais TEXT NOT NULL);";

            // Cria e executa o comando SQL
            using var commandRealizadores = new SqliteCommand(sqlRealizadores, connection);

            commandRealizadores.ExecuteNonQuery();



            // ======================================================
            // TABELA FILMES
            // ======================================================
            // Comando SQL responsável por criar a tabela FILMES
            string sqlFilmes = @"CREATE TABLE IF NOT EXISTS Filmes(Id INTEGER PRIMARY KEY AUTOINCREMENT,Titulo TEXT NOT NULL,Ano INTEGER NOT NULL,Lingua TEXT NOT NULL,Classificacao INTEGER NOT NULL,CategoriaId INTEGER NOT NULL,RealizadorId INTEGER NOT NULL);";

            // Cria e executa o comando SQL
            using var commandFilmes = new SqliteCommand(sqlFilmes, connection);

            commandFilmes.ExecuteNonQuery();
        }
    }
}