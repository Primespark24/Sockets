using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace cs371ado
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build and open a connection
            // Magic strings should be replaced with objects when possible
            // string connstr = @"server=db4free.net;userid=cs371student;password=whitworth;database=cs371ado;old guids=true";
            var connStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = "db4free.net",
                UserID = "cs371student",
                Password = "whitworth",
                Database = "cs371ado",
                OldGuids = true             // Necessary for proper conversion of strings from the database
            };
            string connstr = connStringBuilder.ConnectionString;
            var conn = new MySql.Data.MySqlClient.MySqlConnection(connstr);
            conn.Open();
            Console.WriteLine("MySql version: {0}.", conn.ServerVersion);
            
            // Write a simple retrieval query
            string sql = "SELECT * FROM ships";
            var cmd = new MySqlCommand(sql, conn);
            // Readers are used for data retrieval
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine("Ship ID: {0}, ship name: {1}, registration number: {2}.", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            reader.Close();

            // Write a simple insertion query
            sql = "INSERT INTO crew (fname, lname, age, roleid) VALUES ('I cannot follow', 'simple instructions', 20, 8)";
            cmd.CommandText = sql;
            cmd.Connection = conn;
            // ExecuteNonQuery is used for pretty much every other SQL command
            int result = cmd.ExecuteNonQuery();

            Console.WriteLine("Insert result: {0}", result);

            // Check the results
            sql = "SELECT id, fname, lname, age FROM crew";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Crew ID: {0}, first name: {1}, last name: {2}, age: {3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            }
            reader.Close();

            // We can shift to paramterized SQL
            //sql = "DELETE FROM crew WHERE lname = 'simple instructions'";
            sql = "DELETE FROM crew WHERE lname = @Lname";
            MySqlParameter param = new MySqlParameter {
                ParameterName = "@Lname",
                Value = "simple instructions",
                MySqlDbType = MySqlDbType.VarChar,
                Size = 20
            };
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.Parameters.Add(param);
            result = cmd.ExecuteNonQuery();

            Console.WriteLine("Delete result: {0}", result);

            // Verify results
            sql = "SELECT id, fname, lname, age FROM crew";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Crew ID: {0}, first name: {1}, last name: {2}, age: {3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            }
            
            reader.Close();
            conn.Close();
        }
    }
}
