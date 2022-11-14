using System;
using System.Data;
using System.Data.SqlClient;

namespace WF_Tabula.DALs
{
    public class Databasehandler
    {
        private SqlConnectionStringBuilder builder { get; set; }
        private SqlConnection con { get; set; }
        public Databasehandler()
        {
            builder = new SqlConnectionStringBuilder();

            builder.DataSource = "mssql.fhict.local";
            builder.UserID = "dbi441585_tabula";
            builder.Password = "Semester2";
            builder.InitialCatalog = "dbi441585_tabula";

            con = new SqlConnection(builder.ConnectionString);
        }

        public bool TestConnection()
        {
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