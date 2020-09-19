using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public AllTripsViewModel GetAll()
        {
            var tripsList = this.db.Trips.Select(x => new TripViewModel()
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime,
                Seats = x.Seats,
                ImagePath = x.ImagePath
            }).ToList();


            var allTrips = new AllTripsViewModel()
            {
                Trips = tripsList
            };

            return allTrips;
        }

        public void Add(AddTripViewModel input)
        {
            var trip = new Trip()
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = input.DepartureTime,
                ImagePath = input.ImagePath,
                Seats = input.Seats,
                Description = input.Description
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public Trip GetById(string id)
        {
            return this.db.Trips.Find(id);
        }

        public TripDetailsViewModel ShowDetails(string id)
        {
            var trip = this.GetById(id);

            return new TripDetailsViewModel()
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime,
                ImagePath = trip.ImagePath,
                Seats = trip.Seats,
                Description = trip.Description
            };
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var trip = this.db.Trips.Find(tripId);

            this.db.UserTrips.Add(new UserTrip()
            {
                UserId = userId,
                TripId = tripId
            });

            trip.Seats -= 1;
            this.db.SaveChanges();
        }
    }
}
