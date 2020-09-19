using SULS.Models;
using SULS.ViewModels.Home;
using SULS.ViewModels.Problems;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public ICollection<IndexProblemViewModel> GetAll()
        {
            var allProblems = this.db.Problems.Select(x => new IndexProblemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count
            }).ToList();

            return allProblems;
        }

        public ProblemDetailsViewModel GetDetails(string id)
        {
            return this.db.Problems.Where(x => x.Id == id).Select(
                x => new ProblemDetailsViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s =>
                        new ProblemDetailsSubmissionViewModel
                        {
                            CreatedOn = s.CreatedOn,
                            AchievedResult = s.AchievedResult,
                            SubmissionId = s.Id,
                            MaxPoints = x.Points,
                            Username = s.User.Username,
                        })
                }).FirstOrDefault();
        }
    }
}
