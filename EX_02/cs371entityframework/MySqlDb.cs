using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using cs371entityframework.Models;

namespace cs371entityframework
{
    public class MySqlDb
    {
        private MySqlConnection conn;

        public MySqlDb(string server, string user, string pw, string db) {
            var connStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = server,
                UserID = user,
                Password = pw,
                Database = db,
                OldGuids = true
            };

            string connstr = connStringBuilder.ConnectionString;
            conn = new MySqlConnection(connstr);
        }

        public void OpenConnection() {
            conn.Open();
        }

        public void CloseConnection() {
            conn.Close();
        }

        public List<Ship> GetAllShips() {
            List<Ship> ships = new List<Ship>();
            string sql = "SELECT * FROM ships";
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read()) {
                    ships.Add(new Ship { 
                        Id = (int)reader["id"],
                        Name = (string)reader["Name"],
                        Registration = (string)reader["registration"]
                    });
                }
                reader.Close();
            }
            return ships;
        }

        // In class - Add method to get a single ship
        public Ship getShip(int shipId)
        {
            Ship ship = new Ship();
            string sql = "SELECT * FROM ships WHERE id = " + shipId;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    ship.Id = (int) reader["id"];
                    ship.Name = (string) reader["Name"];
                    ship.Registration = (string) reader["registration"];
                }
                reader.Close();
                return ship;
            }
        }

        // Homework four: models and method to print out a complete roster
        //      Crew member's full name, age and the role they fill, the ship's name and registration number

        
    }  
}
            
            
            

