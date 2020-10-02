namespace _02.Data
{
    using _02.Data.Interfaces;
    using _02.Data.Models;
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Data : IRepository
    {
        private OrderedBag<IEntity> _entities;

        public Data()
        {
            this._entities = new OrderedBag<IEntity>();
        }

        public int Size
            => this._entities.Count;

        public void Add(IEntity entity)
        {
            this._entities.Add(entity);

            var parentNode = this.GetById((int)entity.ParentId);

            if (parentNode != null)
            {
                parentNode.Children.Add(entity);
            }
        }

        public IRepository Copy()
        {
            IRepository copy = new Data();

            foreach (var entity in this._entities)
            {
                copy.Add(entity);
            }

            return copy;
        }

        public IEntity DequeueMostRecent()
        {
            this.EnsureNotEmpty();
            return this._entities.RemoveFirst();
        }

        public List<IEntity> GetAll()
        {
            var all = new List<IEntity>(this.Size);

            foreach (var entity in this._entities)
            {
                all.Add(entity);
            }

            return all;
        }

        public List<IEntity> GetAllByType(string type)
        {
            if (type != typeof(Invoice).Name
                && type != typeof(StoreClient).Name
                && type != typeof(User).Name)
            {
                throw new InvalidOperationException("Invalid type: " + type);
            }
            
            var found = new List<IEntity>(this.Size);

            foreach (var entity in this._entities)
            {
                if (entity.GetType().Name == type)
                {
                    found.Add(entity);
                }
            }

            return found;
        }

        public IEntity GetById(int id)
        {
            if (id < 0 || id >= this.Size)
            {
                return null;
            }

            return this._entities[this.Size - 1 - id];
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            if (parentId < 0 || parentId >= this.Size)
            {
                return new List<IEntity>();
            }

            var parentNode = this.GetById(parentId);

            return parentNode.Children;
        }

        public IEntity PeekMostRecent()
        {
            this.EnsureNotEmpty();
            return this._entities.GetFirst();
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }
        }
    }
}
