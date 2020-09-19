using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;

        private List<string> validFlourTypes = new List<string> { "white", "wholegrain" };
        private List<string> validBakingTechniques = new List<string> { "crispy", "chewy", "homemade" };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public string FlourType
        {
            get => this.flourType;
            set
            {
                if (!validFlourTypes.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                if (!validBakingTechniques.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in range [1..200].");
                }
                this.weight = value;
            }
        }

        public Dough()
        {

        }

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double CalculateCalories()
        {
            var flourTypeModifier = 1.0;
            var bakingTechModifier = 1.0;

            switch (this.FlourType.ToLower())
            {
                case "white":
                    flourTypeModifier = 1.5;
                    break;

                case "wholegrain":
                    flourTypeModifier = 1.0;
                    break;                    
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    bakingTechModifier = 0.9;
                    break;

                case "chewy":
                    bakingTechModifier = 1.1;
                    break;

                case "homemade":
                    bakingTechModifier = 1.0;
                    break;
            }

            return (BaseCaloriesPerGram * this.weight) * flourTypeModifier * bakingTechModifier;
        }
    }
}
