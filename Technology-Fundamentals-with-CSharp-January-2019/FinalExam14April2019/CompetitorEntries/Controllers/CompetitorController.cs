using CompetitorEntries.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CompetitorEntries.Controllers
{
    public class CompetitorController : Controller
    {
        private readonly CompetitorEntriesDbContext context;

        public CompetitorController(CompetitorEntriesDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                var allCompetitors = db.Competitors.ToList();
                return View(allCompetitors);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name, int age, string team, string category)
        {
            if (string.IsNullOrEmpty(name) || age <= 0 || string.IsNullOrEmpty(team) || string.IsNullOrEmpty(category))
            {
                return RedirectToAction("Index");
            }
            Competitor competitor = new Competitor
            {
                Name = name,
                Age = age,
                Team = team,
                Category = category
            };
            using (var db = new CompetitorEntriesDbContext())
            {
                db.Competitors.Add(competitor);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                var competitorToEdit = db.Competitors.FirstOrDefault(c => c.Id == id);
                if (competitorToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(competitorToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Competitor competitor)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new CompetitorEntriesDbContext())
            {
                var competitorToEdit = db.Competitors.FirstOrDefault(c => c.Id == competitor.Id);
                competitorToEdit.Name = competitor.Name;
                competitorToEdit.Age = competitor.Age;
                competitorToEdit.Team = competitor.Team;
                competitorToEdit.Category = competitor.Category;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                Competitor competitorDetails = db.Competitors.FirstOrDefault(c => c.Id == id);
                if (competitorDetails == null)
                {
                    RedirectToAction("Index");
                }
                return View(competitorDetails);
            }
        }

        [HttpPost]
        public IActionResult Delete(Competitor competitor)
        {
            using (var db = new CompetitorEntriesDbContext())
            {
                var competitorToDelete = db.Competitors.FirstOrDefault(c => c.Id == competitor.Id);
                if (competitorToDelete == null)
                {
                    RedirectToAction("Index");
                }
                db.Competitors.Remove(competitorToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}