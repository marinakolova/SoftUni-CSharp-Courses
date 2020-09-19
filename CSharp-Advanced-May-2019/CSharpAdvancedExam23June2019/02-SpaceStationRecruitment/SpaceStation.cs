using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public void Add(Astronaut astronaut)
        {
            if (this.Capacity > this.data.Count)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            var astronautToRemove = this.GetAstronaut(name);

            if (astronautToRemove != null)
            {
                this.data.Remove(astronautToRemove);
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            return this.data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.Where(x => x.Name == name).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");
            for (int i = 0; i < this.data.Count - 1; i++)
            {
                sb.AppendLine(this.data[i].ToString());
            }
            sb.Append(this.data[this.data.Count - 1].ToString());

            return sb.ToString();
        }
    }
}
