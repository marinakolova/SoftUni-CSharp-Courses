using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trips = this.tripsService.GetAll();

            return this.View(trips);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.StartPoint) || string.IsNullOrWhiteSpace(input.StartPoint)
                || string.IsNullOrEmpty(input.EndPoint) || string.IsNullOrWhiteSpace(input.EndPoint))
            {
                //return this.Error("Invalid Data!");
                return this.Redirect("/Trips/Add");
            }

            //TODO: Add DateTime Validation for input.DepartureTime

            if (input.Seats < 2 || input.Seats > 6)
            {
                //return this.Error("Number of seats must be between 2 and 6.");
                return this.Redirect("/Trips/Add");
            }

            if (string.IsNullOrEmpty(input.Description) || string.IsNullOrWhiteSpace(input.Description))
            {
                //return this.Error("Description cannot be empty!");
                return this.Redirect("/Trips/Add");
            }

            if (input.Description.Length > 80)
            {
                //return this.Error("Description's max length is 80 characters.");
                return this.Redirect("/Trips/Add");
            }

            this.tripsService.Add(input);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetById(tripId);

            if (trip == null)
            {
                return this.Error("Trip not found!");
            }

            var viewModel = this.tripsService.ShowDetails(tripId);

            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetById(tripId);

            if (trip == null)
            {
                return this.Error("Trip not found!");
            }

            if (trip.Seats <= 0)
            {
                //return this.Error("This trip has no free seats!");
                return this.Details(tripId);
            }

            try
            {
                this.tripsService.AddUserToTrip(tripId, this.User);
            }
            catch (Exception)
            {
                //return this.Error("You already joined this trip!");
                return this.Details(tripId);
            }

            return this.Redirect("/Trips/All");
        }
    }
}
