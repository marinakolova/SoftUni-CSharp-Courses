namespace _02.Data.Interfaces
{
    using _02.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEntity : IComparable
    {
        int Id { get; set; }

        int? ParentId { get; set; }

        BaseEntityStatus Status { get; set; }

        List<IEntity> Children { get; }

        void AddChild(IEntity child);
    }
}
