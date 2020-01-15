using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

//mostly written by jude

namespace linqTest
{
    class CrewMember : IDisposable
    {
        private bool disposed = false;
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Position { get; set; }
        public string Rank { get; set; }
        public int Age { get; set; }

        public CrewMember(string fname = "none", string lname = "none", string position = "none", int age = 18, string rank = "none")
        {
            Fname = fname;
            Lname = lname;
            Position = position;
            Rank = rank;
            Age = age;

        }

        public CrewMember()
        {
        }

        // Finalize Method
        ~CrewMember()
        {
            Console.WriteLine("Initializing Clean-Up");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
