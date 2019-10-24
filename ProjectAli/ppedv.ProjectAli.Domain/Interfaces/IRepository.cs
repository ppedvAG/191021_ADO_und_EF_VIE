using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.ProjectAli.Domain.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T item) where T : Entity;
        void Update<T>(T item) where T : Entity;
        void Delete<T>(T item) where T : Entity;
        T GetByID<T>(int ID) where T : Entity;
        IEnumerable<T> GetAll<T>() where T : Entity;
        // LINQ: DBSet in EF implementiert IQueryable
        IQueryable<T> Query<T>() where T : Entity; // repo.Query().Where(x => x. .....)
        void Save();
    }
}
