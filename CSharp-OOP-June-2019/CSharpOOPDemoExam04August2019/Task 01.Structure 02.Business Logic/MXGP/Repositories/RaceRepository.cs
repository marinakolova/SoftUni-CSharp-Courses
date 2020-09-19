using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IRace GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return models.ToList();
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
