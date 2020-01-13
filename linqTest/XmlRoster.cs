using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace linqTest
{
    class XmlRoster
    {
        List<CrewMember> roster;
        XElement xmlRoster;
        bool rosterUpToDate;

        public XmlRoster() {
            roster = new List<CrewMember>();
        }

        public XmlRoster(List<CrewMember> roster) {
            this.roster = roster;
        }

        public XElement GetXmlRoster() {
            if (!rosterUpToDate)
            {
                GenerateXmlRoster();
            } 
            return xmlRoster;
        }

        public void AddCrew(CrewMember newCrew) {
            rosterUpToDate = false;
            roster.Add(newCrew);
        }

        public void AddCrew(List<CrewMember> newRoster) {
            rosterUpToDate = false;
            roster.AddRange(newRoster);
        }

        public void RemoveCrew(CrewMember exCrew) {
            rosterUpToDate = false;
            roster.Remove(exCrew);
        }

        public void RemoveCrew(List<CrewMember> exCrew)
        {
            rosterUpToDate = false;
            foreach (CrewMember ex in exCrew) {
                roster.Remove(ex);
            }
        }

        public void GenerateXmlRoster() {
            XElement doc = new XElement("Crew");

            foreach (CrewMember crewMember in roster) {
                XElement crewMemberNode = new XElement("crewMember");
                crewMemberNode.Add(new XAttribute(
                    "Fname", crewMember.Fname
                    ));
                crewMemberNode.Add(new XAttribute(
                    "Lname", crewMember.Lname
                    ));
                crewMemberNode.Add(new XAttribute(
                    "Position", crewMember.Position
                    ));
                crewMemberNode.Add(new XAttribute(
                    "Rank", crewMember.Rank
                    ));
                doc.Add(crewMemberNode);
            }
            xmlRoster = doc;
            rosterUpToDate = true;
        }

        public void Print()
        {
            string sep = new string('=', 35);
            string title = " Current Crew ";
            string filler = new string('=', title.Length);
            if (!rosterUpToDate)
            {
                GenerateXmlRoster();    
            }
            Console.WriteLine("{0}{1}{0}", sep, title);
            foreach (XElement child in xmlRoster.Descendants()) {
                Console.WriteLine(child.ToString());
            }
            Console.WriteLine("{0}{1}{0}", sep, filler);
        }

        public void Write(string filename) {
            xmlRoster.Save(filename);
        }
    }
}
