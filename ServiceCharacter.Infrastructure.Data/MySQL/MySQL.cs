﻿using MySql.Data.MySqlClient;
using ServiceCharacter.Infrastructure.Data.Exceptions;
using System.Data;


namespace ServiceCharacter.Infrastructure.Data.MySQL
{
    public class MySQL
    {
        private readonly static string connStr = "SERVER=localhost;DATABASE=database;UID=root;Password=;Pooling=true;";

        public static void Query(MySqlCommand command)
        {
            using MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                command.Connection = conn;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw new ServerException(Server.ServerIsNotAvaliable);
            }
        }

        public static DataTable? QueryRead(MySqlCommand command)
        {
            using MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                command.Connection = conn;
                using MySqlDataReader reader = command.ExecuteReader();
                using DataTable dt = new(null);
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