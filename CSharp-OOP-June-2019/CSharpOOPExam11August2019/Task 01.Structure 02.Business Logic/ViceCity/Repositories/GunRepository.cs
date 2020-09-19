using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => models.AsReadOnly();

        public void Add(IGun model)
        {
            if (models.All(x => x.Name != model.Name))
            {
                models.Add(model);
            }
        }

        public bool Remove(IGun model)
        {
            if (models.Any(x => x.Name == model.Name))
            {
                var gunToRemove = models.FirstOrDefault(x => x.Name == model.Name);
                return models.Remove(gunToRemove);
            }

            return false;
        }

        public IGun Find(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
