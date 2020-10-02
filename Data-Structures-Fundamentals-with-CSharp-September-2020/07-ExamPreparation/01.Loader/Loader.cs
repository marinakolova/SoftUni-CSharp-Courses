namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> _entities;

        public Loader()
        {
            this._entities = new List<IEntity>();
        }

        public int EntitiesCount
            => this._entities.Count;

        public void Add(IEntity entity)
        {
            this._entities.Add(entity);
        }

        public void Clear()
        {
            this._entities.Clear();
        }

        public bool Contains(IEntity entity)
        {
            return this._entities.Contains(entity);
        }

        public IEntity Extract(int id)
        {
            IEntity found = this.GetById(id);

            if (found != null)
            {
                this._entities.Remove(found);
            }

            return found;
        }

        public IEntity Find(IEntity entity)
        {
            return this.GetById(entity.Id);
        }

        public List<IEntity> GetAll()
        {
            var allEntities = new List<IEntity>(this.EntitiesCount);

            foreach (var entity in this._entities)
            {
                allEntities.Add(entity);
            }

            return allEntities;
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            for (int i = 0; i < this._entities.Count; i++)
            {
                yield return this._entities[i];
            }
        }

        public void RemoveSold()
        {
            this._entities
                .RemoveAll(x => x.Status == BaseEntityStatus.Sold);
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            int indexOfEntity = this._entities.IndexOf(oldEntity);
            this.ValidateEntity(indexOfEntity);
            this._entities[indexOfEntity] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            var retainedEntities = new List<IEntity>(this.EntitiesCount);

            foreach (var entity in this._entities)
            {
                if (entity.Status >= lowerBound
                    && entity.Status <= upperBound)
                {
                    retainedEntities.Add(entity);
                }
            }

            return retainedEntities;
        }

        public void Swap(IEntity first, IEntity second)
        {
            var indexOfFirst = this._entities.IndexOf(first);
            this.ValidateEntity(indexOfFirst);
            var indexOfSecond = this._entities.IndexOf(second);
            this.ValidateEntity(indexOfSecond);

            var temp = this._entities[indexOfFirst];
            this._entities[indexOfFirst] = this._entities[indexOfSecond];
            this._entities[indexOfSecond] = temp;
        }

        public IEntity[] ToArray()
        {
            return this._entities.ToArray();
        }

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            foreach (var entity in this._entities)
            {
                if (entity.Status == oldStatus)
                {
                    entity.Status = newStatus;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private IEntity GetById(int id)
        {
            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var currentEntity = this._entities[i];

                if (currentEntity.Id == id)
                {
                    return currentEntity;
                }
            }

            return null;
        }

        private void ValidateEntity(int index)
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Entity not found");
            }
        }
    }
}
