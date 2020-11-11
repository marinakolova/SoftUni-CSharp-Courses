namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PersonCollectionSlow : IPersonCollection
    {
        private List<Person> people = new List<Person>();

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.FindPerson(email) != null)
            {
                // Person already exists
                return false;
            }
            
            var person = new Person()
            {
                Email = email,
                Name = name,
                Age = age,
                Town = town
            };
            this.people.Add(person);
            return true;
        }

        public int Count 
        { 
            get => this.people.Count; 
        }
        
        public Person FindPerson(string email)
        {
            return this.people.FirstOrDefault(p => p.Email == email);
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            return this.people.Remove(person);
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.people
                .Where(p => p.Email.EndsWith("@" + emailDomain))
                .OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return this.people
                .Where(p => p.Name == name && p.Town == town)
                .OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            return this.people
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            return this.people
                .Where(p => p.Town == town)
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }
    }
}
