using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace DataBaseLayer
{
    public class PG_Connection : IConnection
    {
        private static NpgsqlConnection _connection;

        public static string ConString;

        private static PG_Connection _instancia;
        public static PG_Connection Instancia
        {
            get
            {
                if (_instancia == null)
                {

                    _instancia = new PG_Connection(ConString);
                }

                return _instancia;
            }
            private set
            {
                _instancia = value;
            }
        }

        private PG_Connection(string conString)
        {
            CreateConnection(conString);
        }
        public bool CreateConnection(string conString)
        {
            _connection = new NpgsqlConnection(conString);

            if (TestConnection())
                return true;
            else
                return false;
            
        }

        public bool ExecuteNoRespQuery(string query)
        {
            throw new NotImplementedException();
        }

        public object ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteScript(string query)
        {
            _connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, _connection);

            cmd.ExecuteNonQuery();

            _connection.Close();

            return true;
        }

        public bool TestConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch
            {

                return false;
            }
            finally {

                _connection.Close();
            
            }
        }


    }
}
