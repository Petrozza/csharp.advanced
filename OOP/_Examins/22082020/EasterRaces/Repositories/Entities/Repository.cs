using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;
        public Repository()
        {
            models = new List<T>();
        }

        public void Add(T model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return models.ToList().AsReadOnly();
        }

        public T GetByName(string name)
        {
            T result = models.FirstOrDefault(e => nameof(e) == name);
            return result;
        }

        public bool Remove(T model)
        {
            return models.Remove(model);
        }
    }
}
