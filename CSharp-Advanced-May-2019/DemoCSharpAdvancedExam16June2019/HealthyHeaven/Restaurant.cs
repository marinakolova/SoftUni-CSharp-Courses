using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;

        public string Name { get; set; }

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)
        {
            if (this.data.Where(x => x.Name == name).ToList().Count > 0)
            {
                this.data.Remove(this.data.Where(x => x.Name == name).First());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Salad GetHealthiestSalad()
        {
            return this.data.OrderBy(x => x.GetTotalCalories()).First();
        }

        public string GenerateMenu()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.data.Count} salads:");

            for (int i = 0; i < this.data.Count - 1; i++)
            {
                sb.AppendLine($"{this.data[i].ToString()}");
            }

            sb.Append($"{this.data[this.data.Count - 1].ToString()}");

            return sb.ToString();
        }
    }
}
