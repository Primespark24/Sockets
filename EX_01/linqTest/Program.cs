using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Xml.Linq;

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

            var Washburnes = serenity.Descendants("crewMember").Where(t => (string) t.Attribute("Lname") == "Washburne")
                .OrderBy(t => (string)t.Attribute("fname")).Select(t => t);

            foreach (var i in Washburnes)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            var abM = from crew in serenity.Descendants("crewMember")
                      where (((string)crew.Attribute("Lname"))[0] < 'M')
                      select crew;


            foreach (var j in abM)
            {
                Console.WriteLine(j);
            }

            var ageAverage = serenity.Descendants("crewMember").Where(g => (int)g.Attribute(age))

            Console.ReadLine();
        }
    }
}
