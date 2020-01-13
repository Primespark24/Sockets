using System;
using System.Collections.Generic;
using System.Linq;
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
                    "Captain"
                );

            CrewMember zoe = new CrewMember(
                    "Zoe",
                    "Washburne",
                    "First Mate"
                );

            CrewMember jayne = new CrewMember(
                    "Jayne",
                    "Cobb",
                    "Public Relations"
                );

            CrewMember wash = new CrewMember(
                    "Hoban",
                    "Washburne",
                    "Pilot"
                );

            CrewMember inara = new CrewMember(
                    "Inara",
                    "Serra",
                    "Ambassador"
                );

            CrewMember book = new CrewMember(
                    "Derrial",
                    "Book",
                    "Shepherd"
                );

            CrewMember kaylee = new CrewMember(
                    "Kaywinnit",
                    "Frye",
                    "Engineer"
                );

            CrewMember simon = new CrewMember(
                    "Simon",
                    "Tam",
                    "Doctor"
                );

            CrewMember river = new CrewMember(
                    "River",
                    "Tam",
                    "Psyker"
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
        }
    }
}
