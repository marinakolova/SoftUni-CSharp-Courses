using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly MotorcycleRepository motorcycleRepository;
        private readonly RaceRepository raceRepository;
        private readonly RiderRepository riderRepository;

        public ChampionshipController()
        {
            motorcycleRepository = new MotorcycleRepository();
            raceRepository = new RaceRepository();
            riderRepository = new RiderRepository();
        }

        public string CreateRider(string riderName)
        {
            var rider = riderRepository.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            rider = new Rider(riderName);
            riderRepository.Add(rider);

            var result = $"Rider {riderName} is created.";

            return result;
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycle = motorcycleRepository.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            switch (type)
            {
                case "Speed":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;
                case "Power":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
            }

            motorcycleRepository.Add(motorcycle);

            var result = $"{type}Motorcycle {model} is created.";

            return result;
        }

        public string CreateRace(string name, int laps)
        {
            var race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);
            raceRepository.Add(race);

            var result = $"Race {name} is created.";

            return result;
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var rider = riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);

            var result = $"Rider {riderName} added in {raceName} race.";

            return result;
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            var motorcycle = motorcycleRepository.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            var result = $"Rider {riderName} received motorcycle {motorcycleModel}.";

            return result;
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var fastestRiders = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine($"Rider {fastestRiders[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {fastestRiders[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {fastestRiders[2].Name} is third in {raceName} race.");

            raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
