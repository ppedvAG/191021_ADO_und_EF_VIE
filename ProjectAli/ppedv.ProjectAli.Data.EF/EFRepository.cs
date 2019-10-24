using ppedv.ProjectAli.Domain;
using ppedv.ProjectAli.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.ProjectAli.Data.EF
{
    public class EFRepository : IRepository
    {
        public EFRepository()
        {
            context = new EFContext();
        }
        private EFContext context;

        public void Add<T>(T item) where T : Entity
        {
            context.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : Entity
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T GetByID<T>(int ID) where T : Entity
        {
            return context.Set<T>().Find(ID);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return context.Set<T>();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update<T>(T item) where T : Entity
        {
            // Update: Changetracker nur Änderungen bei geladenen Elementen erkennt
            // Trick:

            var loadedItem = GetByID<T>(item.ID); // Neu laden
            if(loadedItem != null)
            {
                context.Entry(loadedItem).CurrentValues.SetValues(item); // Schreibt die Werte 1:1 in loadedItem hinein
            }
        }
    }
}
