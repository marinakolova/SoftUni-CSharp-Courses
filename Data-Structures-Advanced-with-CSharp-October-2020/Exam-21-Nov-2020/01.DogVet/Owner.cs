namespace _01.DogVet
{
    public class Owner
    {
        public Owner(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Owner;
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