using MySql.Data.MySqlClient;
using ServiceCharacter.Infrastructure.Data.Exceptions;
using System.Data;


namespace ServiceCharacter.Infrastructure.Data.MySql
{
    public static class MySql
    {
        private const string ConnectionStr = "SERVER=localhost;DATABASE=database;UID=root;Password=;Pooling=true;";

        public static void Query(MySqlCommand command)
        {
            using var connection = new MySqlConnection(ConnectionStr);
            try
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw new ServerException(Server.ServerIsNotAvaliable);
            }
        }

        public static DataTable? QueryRead(MySqlCommand command)
        {
            using var connection = new MySqlConnection(ConnectionStr);
            try
            {
                connection.Open();
                command.Connection = connection;
                using var reader = command.ExecuteReader();
                DataTable dt = new(null);
                dt.Load(reader);
                return dt;
            }
            catch
            {
                throw new ServerException(Server.ServerIsNotAvaliable);
            }
        }
    }
}
