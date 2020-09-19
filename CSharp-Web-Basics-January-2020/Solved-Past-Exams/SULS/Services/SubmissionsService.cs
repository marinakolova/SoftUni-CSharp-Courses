using SULS.Models;
using SULS.ViewModels.Submissions;
using System;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public CreateFormViewModel CreateForm(string id)
        {
            return this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => new CreateFormViewModel
                {
                    Name = x.Name,
                    ProblemId = x.Id,
                }).FirstOrDefault();
        }

        public void Create(string code, string problemId, string userId)
        {
            var problem = this.db.Problems.FirstOrDefault(x => x.Id == problemId);

            var submission = new Submission
            {
                Code = code,
                AchievedResult = this.random.Next(0, problem.Points),
                CreatedOn = DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId
            };

            this.db.Submissions.Add(submission);

            this.db.SaveChanges();
        }

        public Submission FindSubmission(string id)
        {
            return this.db.Submissions.Find(id);
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.Find(id);
            this.db.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
