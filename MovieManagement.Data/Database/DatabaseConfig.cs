using Microsoft.Data.Sqlite;

namespace MovieManagement.Data.Database
{
    public static class DatabaseConfig
    {
        // Caminho da base de dados SQLite
        private const string ConnectionString="Data Source=MovieManagement.db"; //Indica ao SQLite que a base de dados se chama: MovieManagement.db

        // Cria e devolve uma ligação à base de dados
        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(ConnectionString);
        }
    }
}