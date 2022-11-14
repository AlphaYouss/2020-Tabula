using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ASP_Tabula.DALs
{
    public class Databasehandler
    {
        private readonly IConfiguration config;

        private SqlConnection con { get; set; }

        public Databasehandler(IConfiguration config)
        {
            // Set config

            this.config = config;
            con = new SqlConnection(config.GetConnectionString("TabulaConnStr"));
        }

        public bool TestConnection()
        {
            // Test connection

            bool open = false;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    open = true;
                    con.Close();
                }
            }
            catch (Exception)
            {
                open = false;
            }
            return open;
        }

        public void OpenConnectionToDB()
        {
            con.Open();
        }

        public void CloseConnectionToDB()
        {
            con.Close();
        }

        public SqlConnection GetCon()
        {
            return con;
        }
    }
}