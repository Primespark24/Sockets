using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Xml.Linq;

//Code written in part by Brycen Martin and Mason Caird who built this off of a code written by Jude

namespace linqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // We will need implictly typed variables for the return values
            // We need to know the type ahead of time!
            // The compiler cannot, however
            // var myLinqInt = 0;

            CrewMember mal = new CrewMember(
                    "Malcolm",
                    "Reynolds",
                    "Captain",
                        24
            );

            CrewMember zoe = new CrewMember(
                    "Zoe",
                    "Washburne",
                    "First Mate",
                    37
            );

            CrewMember jayne = new CrewMember(
                    "Jayne",
                    "Cobb",
                    "Public Relations",
                    20
                );

            CrewMember wash = new CrewMember(
                    "Hoban",
                    "Washburne",
                    "Pilot",
                    18
                );

            CrewMember inara = new CrewMember(
                    "Inara",
                    "Serra",
                    "Ambassador",
                    47
                );

            CrewMember book = new CrewMember(
                    "Derrial",
                    "Book",
                    "Shepherd",
                    54
                );

            CrewMember kaylee = new CrewMember(
                    "Kaywinnit",
                    "Frye",
                    "Engineer",
                    36
                );

            CrewMember simon = new CrewMember(
                    "Simon",
                    "Tam",
                    "Doctor",
                    60
                );

            CrewMember river = new CrewMember(
                    "River",
                    "Tam",
                    "Psyker",
                    40
                );

            List<CrewMember> roster = new List<CrewMember> {
                mal, zoe, jayne, wash, inara, book, kaylee, simon, river
            };

            XmlRoster xmlRoster = new XmlRoster(roster);

            CrewMember yoSaffBridge = new CrewMember(
                "Yolanda Saffron Bridget",
                "Unknown",
                "Hazard"
                );

            xmlRoster.AddCrew(yoSaffBridge);
            xmlRoster.Print();

            XElement serenity = xmlRoster.GetXmlRoster();
            Console.WriteLine(serenity);
            IEnumerable<XElement> tams = from crew in serenity.Descendants("crewMember")
                                         where (string)crew.Attribute("Lname") == "Tam"
                                         select crew;
            Console.WriteLine("Found {0} Tams. Two by two, hands of blue...", tams.Count());
            foreach (XElement tam in tams) {
                Console.WriteLine(tam);
            }

            Console.WriteLine();

            Console.WriteLine("All the Washburnes:");
            //finds all people with the last name Washburne
            var Washburnes = serenity.Descendants("crewMember").Where(t => (string) t.Attribute("Lname") == "Washburne")
                .OrderBy(t => (string)t.Attribute("fname")).Select(t => t);

            //prints out all washburnes first names
            foreach (var i in Washburnes)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            Console.WriteLine("All last name before the letter n:");
            //finds all people with a last name that starts with a letter before n
            var abM = from crew in serenity.Descendants("crewMember")
                      where (((string)crew.Attribute("Lname"))[0] < 'M')
                      select crew;

            //prints all crew with last names before that start with a letter before n in the alphabet
            foreach (var j in abM)
            {
                Console.WriteLine(j);
            }

            Console.WriteLine(); 

            Console.WriteLine("Average age of all crew members:");
            //finds the age of all people on board the ship and averages their age
            var ageAverage = serenity.Descendants("crewMember").Select(g => (int) g.Attribute("Age")).Average();
            
            //prints the average age of everyone on the ship
            Console.WriteLine("Average age on the ship is: " + ageAverage);

            Console.WriteLine();

            Console.WriteLine("People who work on the bridge of a ship:");
            //finds all people who would work on the bridge of a ship
            var highrank = serenity.Descendants("crewMember").Where(r => (string) r.Attribute("Position") == "Captain" || (string) r.Attribute("Position") == "First Mate" || (string) r.Attribute("Position") == "Pilot")
                .OrderBy(r => (string)r.Attribute("fname")).Select(r => r);

            //prints all people who would work on the bridge of a ship
            foreach (var r in highrank)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine();

            Console.WriteLine("People who don't work on the bridge of a ship:");
            //finds all people who would not work on a ships bridge
            var lowrank = serenity.Descendants("crewMember").Where(h => (string)h.Attribute("Position") != "Captain" && (string)h.Attribute("Position") != "First Mate" &&  (string)h.Attribute("Position") != "Pilot")
                .OrderBy(h => (string)h.Attribute("fname")).Select(h => h);

            //prints all people who would not work on a ships bridge
            foreach (var h in lowrank)
            {
                Console.WriteLine(h);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to clean your mess up!");
            Console.ReadLine();
        }
    }
}
