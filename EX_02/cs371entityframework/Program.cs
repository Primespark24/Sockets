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
    class Program
    {
        static void Main(string[] args)
        {
            // Makes a variable object fleet that holds database information
            MySqlDb fleet = new MySqlDb("cs1", "cs371student", "whitworth", "cs371ado");
            fleet.OpenConnection();
            // FullyRolly is a variabe representing a list of type Full Roster
            List<FullRoster> FullyRolly = fleet.FullRosters();
            fleet.OpenConnection();
            // Pilot Qualifier holds the list of crew who can pilot
            List<FullRoster> PilotQualifier = fleet.PilotRosters();
            
            // displays the roster
            Console.WriteLine("Full Roster:\n");
            foreach (FullRoster s in FullyRolly)
            {
                Console.WriteLine("First Name: {0} Last Name: {1} \nAge: {2} Role: {3} \nShip Name: {4} Ship Registration: {5}", s.Fname, s.Lname, s.Age, s.role, s.shipName, s.shipRegs);
                Console.WriteLine("\n");
            }

            // Displayes who can be a pilot
            Console.WriteLine("Pilot Qualified:\n");
            foreach (FullRoster s in PilotQualifier)
            {
                Console.WriteLine("First Name: {0} Last Name: {1} \nAge: {2} Role: {3} \nShip Name: {4} Ship Registration: {5}", s.Fname, s.Lname, s.Age, s.role, s.shipName, s.shipRegs);
                Console.WriteLine("\n");
            }
        }
    }
}
