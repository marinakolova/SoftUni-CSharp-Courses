using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using BandRegister.Data;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new BandRegisterDbContext())
            {
                var allBands = db.Bands.ToList();
                return View(allBands);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name, string members, double honorarium, string genre)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(members) || double.IsNaN(honorarium) || string.IsNullOrEmpty(genre))
            {
                return RedirectToAction("Index");
            }
            Band band = new Band
            {
                Name = name,
                Members = members,
                Honorarium = honorarium,
                Genre = genre
            };
            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Add(band);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToEdit = db.Bands.FirstOrDefault(t => t.Id == id);
                if (bandToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(bandToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new BandRegisterDbContext())
            {
                var bandToEdit = db.Bands.FirstOrDefault(t => t.Id == band.Id);
                bandToEdit.Name = band.Name;
                bandToEdit.Genre = band.Genre;
                bandToEdit.Honorarium = band.Honorarium;
                bandToEdit.Members = band.Members;

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                Band bandDetails = db.Bands.FirstOrDefault(t => t.Id == id);
                if (bandDetails == null)
                {
                    RedirectToAction("Index");
                }
                return View(bandDetails);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToDelete = db.Bands.FirstOrDefault(t => t.Id == band.Id);
                if (bandToDelete == null)
                {
                    RedirectToAction("Index");
                }
                db.Bands.Remove(bandToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}