namespace _01.DogVet
{
    using System;

    public class Dog
    {
        public Dog(string id, string name, Breed breed, int age, int vaccines)
        {
            this.Id = id;
            this.Name = name;
            this.Breed = breed;
            this.Age = age;
            this.Vaccines = vaccines;
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public Breed Breed { get; set; }

        public int Age { get; set; }

        public int Vaccines { get; set; }

        public Owner Owner { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Dog;
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}