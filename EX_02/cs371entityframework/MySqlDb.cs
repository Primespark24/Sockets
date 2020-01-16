using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using cs371entityframework.Models;

namespace cs371entityframework
{
    public class MySqlDb
    {

        // This was our Query

        /*SELECT crew.fname, crew.lname, crew.age, roles.role
            FROM ((roles join crew on crew.roleid = roles.id) join roster on roster.crewid = crew.id) join ships on ships.id = roster.shipid

            //fname, Lname, age, roleid, name of ship
            SELECT crew.fname, crew.lname, crew.age, crew.roleid, ships.name
            FROM (crew join  roster on roster.crewid = crew.id) join ships on ships.id = roster.shipid

            //shipname and registration
            SELECT ships.name, ships.registration
            from ships*/
        
        private MySqlConnection conn;

        // Constructor
        public MySqlDb(string server, string user, string pw, string db) {
            var connStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = server,
                UserID = user,
                Password = pw,
                Database = db,
                OldGuids = true
            };

            // Making the conenction variable
            string connstr = connStringBuilder.ConnectionString;
            conn = new MySqlConnection(connstr);
        }

        // Method to open connection of db
        public void OpenConnection() {
            conn.Open();
        }

        // Method to close connection of db
        public void CloseConnection() {
            conn.Close();
        }

        // Gathers infomration with query to get all ships id name and registration
        // Adds them to a list<ship>
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

        // Grabs the crew name, age, role, ship name and registration.
        // Adds them to a list<Full Roster>
        public List<FullRoster> FullRosters()
        {
            List<FullRoster> fullyRolly = new List<FullRoster>();
            string sql = "SELECT crew.fname, crew.lname, crew.age, roles.role, ships.name, ships.registration FROM((roles join crew on crew.roleid = roles.id) join roster on roster.crewid = crew.id) join ships on ships.id = roster.shipid";
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    fullyRolly.Add(new FullRoster
                    {
                        Fname = (string)reader["fname"],
                        Lname = (string)reader["lname"],
                        Age = (int)reader["age"],
                        role = (string)reader["role"],
                        shipName = (string)reader["name"],
                        shipRegs = (string)reader["registration"]
                    });
                }
                reader.Close();
            }
            return fullyRolly;
        }

        // Grabs information of who can fly a plane
        // Adds any crew member to a list of FullRoster
        public List<FullRoster> PilotRosters()
        {
            List<FullRoster> fullyRolly = new List<FullRoster>();
            string sql = "SELECT crew.fname, crew.lname, crew.age, roles.role, ships.name, ships.registration FROM((roles join crew on crew.roleid = roles.id) join roster on roster.crewid = crew.id) join ships on ships.id = roster.shipid WHERE roles.pilotQualified = true";
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    fullyRolly.Add(new FullRoster
                    {
                        Fname = (string)reader["fname"],
                        Lname = (string)reader["lname"],
                        Age = (int)reader["age"],
                        role = (string)reader["role"],
                        shipName = (string)reader["name"],
                        shipRegs = (string)reader["registration"]
                    });
                }
                reader.Close();
            }
            return fullyRolly;
        }
    }  
}
            
            
            

