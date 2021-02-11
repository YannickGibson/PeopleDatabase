using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewViewModel.Models
{
    public sealed class Person
    {
        public Person(string firstName, string lastName, DateTime birthDate, string socialSecurityNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.SocialSecurityNumber = socialSecurityNumber;
        }
        public override string ToString()
        {

            return string.Join(", ", this.FirstName, this.LastName, this.BirthDate, this.SocialSecurityNumber);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string SocialSecurityNumber { get; set; }
    }

    public sealed class DatabaseModel
    {
        static DatabaseModel instance = null;

        // Singleton design pattern
        private DatabaseModel()
        {
            this.database = new List<Person>();
        }
        public List<Person> GetAll()
        {
            return this.database;
        }
        public static DatabaseModel Database
        {
            // "Lazy Loading" - až někdo bude potřebovat databázi zpráv,
            // tak se vytvoří, ale ne dřív!
            get
            {
                if(instance == null)
                {
                    instance = new DatabaseModel();
                }
                
                return instance;
            }
        }
        public void AddPerson(string firstName, string lastName, DateTime birthDate, string socialSecurityNumber)
        {
            this.database.Add(new Person(firstName, lastName, birthDate, socialSecurityNumber));
        }

        private List<Person> database;
    }
}
