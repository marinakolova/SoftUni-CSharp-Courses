using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        AllTripsViewModel GetAll();

        void Add(AddTripViewModel input);

        Trip GetById(string id);

        TripDetailsViewModel ShowDetails(string id);

        void AddUserToTrip(string tripId, string userId);
    }
}
