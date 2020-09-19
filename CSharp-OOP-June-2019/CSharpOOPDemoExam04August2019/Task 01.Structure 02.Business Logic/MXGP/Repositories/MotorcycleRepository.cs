using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> models;

        public MotorcycleRepository()
        {
            models = new List<IMotorcycle>();
        }

        public IMotorcycle GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Model == name);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return models.ToList();
        }

        public void Add(IMotorcycle model)
        {
            this.models.Add(model);
        }

        public bool Remove(IMotorcycle model)
        {
            return this.models.Remove(model);
        }
    }
}
