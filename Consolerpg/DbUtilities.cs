using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace Consolerpg
{
    public static class DbUtilities
    {
        public static string ConnectionString
        {
            get
            {
                string retorno = "Driver={MySQL ODBC 3.51 Driver};database=dbconsole;description=ConsoleRPG;option=0;pwd=******;port=0;server=localhost;uid=root";
                return retorno;
            }
        }

        private static OdbcConnection connection;

        public static OdbcConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public static void openConnection()
        {
            if (Connection == null)
                Connection = new OdbcConnection(ConnectionString);

            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                {
                    Connection.Open();

                    string query = "SET SESSION wait_timeout = 60";
                    OdbcCommand cmd = new OdbcCommand(query, Connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na conexão com o banco de dados. " + ex.Message);
            }
        }

        public static void closeConnection()
        {
            try
            {
                if (Connection != null)
                    Connection.Close();
            }
            catch (OdbcException e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void doQuery(string sQuery)
        {
            try
            {
                openConnection();

                OdbcCommand cmd = new OdbcCommand(sQuery, Connection);
                cmd.ExecuteNonQuery();

                closeConnection();
            }
            catch (OdbcException e)
            {
                closeConnection();
                throw new Exception(e.Message);
            }
        }

        public static void doInsert(string sTable, string sColumns, string sValues)
        {
            try
            {
                string tCommand = "INSERT INTO " + sTable.ToLower() +
                                    " (" + sColumns + ") " +
                                    "VALUES (" + sValues + ")";

                openConnection();
                OdbcCommand cmd = new OdbcCommand(tCommand, Connection);
                cmd.ExecuteNonQuery();
            }
            catch (OdbcException e)
            {
                closeConnection();
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        public static void doUpdate(string sTable, string sSet, string sConditions)
        {
            try
            {
                string tCommand = "UPDATE " + sTable.ToLower() +
                                    " SET " + sSet + " ";
                if (!sConditions.Equals(""))
                    tCommand += "WHERE " + sConditions;

                openConnection();
                OdbcCommand cmd = new OdbcCommand(tCommand, Connection);
                cmd.ExecuteNonQuery();
            }
            catch (OdbcException e)
            {
                closeConnection();
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        public static OdbcDataReader doSelect(string sTable, string sInnerTable, string sInnerRelation, string sColumns, string sConditions)
        {
            try
            {
                string tCommand = "SELECT " + sColumns +
                                    " FROM " + sTable.ToLower();

                if (!sInnerTable.Equals(""))
                    tCommand += " a INNER JOIN " + sInnerTable + " b" +
                                " ON " + sInnerRelation;

                if (!sConditions.Equals(""))
                    tCommand += " WHERE " + sConditions;

                openConnection();
                OdbcCommand cmd = new OdbcCommand(tCommand, Connection);
                OdbcDataReader reader;
                while (true)
                {
                    try
                    {
                        reader = cmd.ExecuteReader();
                        break;
                    }
                    catch
                    {
                        closeConnection();
                        openConnection();
                    }
                }
                return reader;
            }
            catch (OdbcException e)
            {
                closeConnection();
                return null;
                throw new Exception(e.Message);
            }
        }

        public static DataSet doSelectDataSet(string sTable, string sInnerTable, string sInnerRelation, string sColumns, string sConditions)
        {
            try
            {
                string tCommand = "SELECT " + sColumns +
                                    " FROM " + sTable.ToLower();

                if (!sInnerTable.Equals(""))
                    tCommand += " a INNER JOIN " + sInnerTable + " b" +
                                " ON " + sInnerRelation;

                if (!sConditions.Equals(""))
                    tCommand += " WHERE " + sConditions;

                openConnection();
                OdbcDataAdapter adapter = new OdbcDataAdapter(tCommand, Connection);
                closeConnection();
                DataSet ds = new DataSet();
                adapter.Fill(ds, sTable.ToLower());
                return ds;
            }
            catch (OdbcException e)
            {
                closeConnection();
                return null;
                throw new Exception(e.Message);
            }
        }
        public static DataTable doSelectDataTable(string sTable, string sInnerTable, string sInnerRelation, string sColumns, string sConditions)
        {
            try
            {
                string tCommand = "SELECT " + sColumns +
                                    " FROM " + sTable.ToLower();

                if (!sInnerTable.Equals(""))
                    tCommand += " a INNER JOIN " + sInnerTable + " b" +
                                " ON " + sInnerRelation;

                if (!sConditions.Equals(""))
                    tCommand += " WHERE " + sConditions;

                openConnection();
                OdbcDataAdapter adapter = new OdbcDataAdapter(tCommand, Connection);
                closeConnection();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (OdbcException e)
            {
                closeConnection();
                return null;
                throw new Exception(e.Message);
            }
        }

        public static void TestServer()
        {
            try
            {
                openConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static string GetPar(string p, string padrao)
        {
            OdbcDataReader reader = doSelect("TB_CFG_PARAMETRO", "", "", "*", "id_parametro = '" + p + "'");
            if (reader.Read())
            {
                return reader["tx_conteudo"].ToString();
            }
            return padrao;
        }
    }
}