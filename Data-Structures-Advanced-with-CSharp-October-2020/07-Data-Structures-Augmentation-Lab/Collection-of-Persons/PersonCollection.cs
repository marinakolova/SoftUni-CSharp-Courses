namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PersonCollection : IPersonCollection
    {
        private Dictionary<string, Person> peopleByEmail = new Dictionary<string, Person>();
        private Dictionary<string, SortedSet<Person>> peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
        private Dictionary<string, SortedSet<Person>> peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        private OrderedDictionary<int, SortedSet<Person>> peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();
        private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

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

            // Add by email
            this.peopleByEmail.Add(email, person);

            // Add by email domain
            this.peopleByEmailDomain.AppendValueToKey(email.Split('@')[1], person);

            // Add by {name + town}
            this.peopleByNameAndTown.AppendValueToKey(name + "|!|" + town, person);

            // Add by age
            this.peopleByAge.AppendValueToKey(age, person);

            // Add by {town + age}
            this.peopleByTownAndAge.EnsureKeyExists(town);
            this.peopleByTownAndAge[town].AppendValueToKey(age, person);
            
            return true;
        }

        public int Count 
        {
            get => this.peopleByEmail.Count;
        }

        public Person FindPerson(string email)
        {
            Person person = null;
            this.peopleByEmail.TryGetValue(email, out person);

            return person;
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            if (person == null)
            {
                // Person does not exist
                return false;
            }

            // Delete person from peopleByEmail
            this.peopleByEmail.Remove(email);

            // Delete person from peopleByEmailDomain
            this.peopleByEmailDomain[email.Split('@')[1]].Remove(person);
            
            // Delete person from peopleByNameAndTown
            this.peopleByNameAndTown[person.Name + "|!|" + person.Town].Remove(person);
            
            // Delete person from peopleByAge
            this.peopleByAge[person.Age].Remove(person);
            
            //Delete person from peopleByTownAndAge
            this.peopleByTownAndAge[person.Town][person.Age].Remove(person);

            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.peopleByEmailDomain.GetValuesForKey(emailDomain);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return this.peopleByNameAndTown.GetValuesForKey(name + "|!|" + town);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var peopleInRange = this.peopleByAge.Range(startAge, true, endAge, true);
            foreach (var peopleByAge in peopleInRange)
            {
                foreach (var person in peopleByAge.Value)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            if (!this.peopleByTownAndAge.ContainsKey(town))
            {
                // Return an empty sequence of people
                yield break;
            }

            var peopleInRange = this.peopleByTownAndAge[town].Range(startAge, true, endAge, true);
            foreach (var peopleByAge in peopleInRange)
            {
                foreach (var person in peopleByAge.Value)
                {
                    yield return person;
                }
            }
        }
    }
}
