namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        Dictionary<string, Dog> dogsById = new Dictionary<string, Dog>();
        Dictionary<string, Dictionary<string, Dog>> dogsByOwnerAndByName = new Dictionary<string, Dictionary<string, Dog>>();
        
        public int Size 
        {
            get => this.dogsById.Count;
        }

        public void AddDog(Dog dog, Owner owner)
        {
            if (this.Contains(dog))
            {
                throw new ArgumentException();
            }

            if (this.dogsByOwnerAndByName.ContainsKey(owner.Id)
                && this.dogsByOwnerAndByName[owner.Id].ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }

            if (!this.dogsByOwnerAndByName.ContainsKey(owner.Id))
            {
                this.dogsByOwnerAndByName[owner.Id] = new Dictionary<string, Dog>();
            }

            dog.Owner = owner;
            this.dogsById[dog.Id] = dog;
            this.dogsByOwnerAndByName[owner.Id][dog.Name] = dog;
        }

        public bool Contains(Dog dog)
        {
            return dogsById.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.dogsByOwnerAndByName.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.dogsByOwnerAndByName[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            return this.dogsByOwnerAndByName[ownerId][name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!this.dogsByOwnerAndByName.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.dogsByOwnerAndByName[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            var toRemove = this.dogsByOwnerAndByName[ownerId][name];
            this.dogsById.Remove(toRemove.Id);
            this.dogsByOwnerAndByName[ownerId].Remove(toRemove.Name);
            if (dogsByOwnerAndByName[ownerId].Count == 0)
            {
                this.dogsByOwnerAndByName.Remove(ownerId);
            }

            return toRemove;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.dogsByOwnerAndByName.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            return this.dogsByOwnerAndByName[ownerId].Values.ToList();
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            var found = this.dogsById.Values
                .Where(x => x.Breed == breed)
                .ToList();

            if (found.Count == 0)
            {
                throw new ArgumentException();
            }

            return found;
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!this.dogsByOwnerAndByName.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.dogsByOwnerAndByName[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            var toVaccinate = this.dogsByOwnerAndByName[ownerId][name];
            toVaccinate.Vaccines += 1;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!this.dogsByOwnerAndByName.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.dogsByOwnerAndByName[ownerId].ContainsKey(oldName))
            {
                throw new ArgumentException();
            }

            // an Owner cannot own two dogs with the same Name
            if (this.dogsByOwnerAndByName[ownerId].ContainsKey(newName))
            {
                throw new ArgumentException();
            }

            var toRename = this.dogsByOwnerAndByName[ownerId][oldName];
            toRename.Name = newName;
            this.dogsByOwnerAndByName[ownerId].Remove(oldName);
            this.dogsByOwnerAndByName[ownerId][newName] = toRename;
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            var found = this.dogsById.Values
                .Where(x => x.Age == age)
                .ToList();

            if (found.Count == 0)
            {
                throw new ArgumentException();
            }

            return found;
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            var found = this.dogsById.Values
                .Where(x => x.Age >= lo 
                            && x.Age <= hi)
                .ToList();

            if (found.Count == 0)
            {
                return Enumerable.Empty<Dog>();
            }

            return found;
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            var found = this.dogsById.Values
                .OrderBy(x => x.Age)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Owner.Name)
                .ToList();

            if (found.Count == 0)
            {
                return Enumerable.Empty<Dog>();
            }

            return found;
        }
    }
}