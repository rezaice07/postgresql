using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGDotNet6ConsoleApp
{
    public class PGDatabase
    {
        public DataSet ExecuteSQLStatement(String SQL)
        {
            var connectString = $"server=localhost;user id=usera; password=123; database=dvdrental;";
            var conn = new NpgsqlConnection(connectString);

            try
            {
                conn.Open();
                var sql = $"{SQL}";
                var cmd = new NpgsqlCommand(sql, conn);
                var rdr = cmd.ExecuteReader();
                conn.Close();
                var ds = new DataSet();
                var adap = new NpgsqlDataAdapter(cmd);
                adap.Fill(ds);

                cmd.Dispose();
                adap.Dispose();
                conn.Dispose();

                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
