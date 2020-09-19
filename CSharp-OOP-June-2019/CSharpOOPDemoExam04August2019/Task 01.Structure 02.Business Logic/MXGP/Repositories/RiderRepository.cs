using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> models;

        public RiderRepository()
        {
            models = new List<IRider>();
        }

        public IRider GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return models.ToList();
        }

        public void Add(IRider model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRider model)
        {
            return this.models.Remove(model);
        }
    }
}
