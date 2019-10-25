using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.ProjectAli.Data.EF;
using ppedv.ProjectAli.Domain;
using ppedv.ProjectAli.Logic;

namespace ppedv.ProjectAli.UI.ASP.Controllers
{
    public class AirportController : Controller
    {
        public AirportController()
        {
            core = new Core(new EFRepository());
        }
        private Core core;


        // GET: Airport
        public ActionResult Index()
        {
            return View(core.GetAllAirports());
        }

        // GET: Airport/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.GetByID<Airport>(id));
        }

        // GET: Airport/Create
        public ActionResult Create()
        {
            return View(new Airport());
        }

        // POST: Airport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Airport newItem)
        {
            try
            {
                // TODO: Add insert logic here
                var date = DateTime.Now;
                newItem.CreationDate = date;
                newItem.ModifiedDate = date;

                core.Repository.Add(newItem);
                core.Repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Airport/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Repository.GetByID<Airport>(id));
        }

        // POST: Airport/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Airport editedItem)
        {
            try
            {
                var loadedItem = core.Repository.GetByID<Airport>(id);
                if(loadedItem != null)
                {
                    core.Repository.Update(editedItem);
                    core.Repository.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Index)); // Idee: Andere Seite bei Fehler
            }
            catch
            {
                return View();
            }
        }

        // GET: Airport/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Repository.GetByID<Airport>(id));
        }

        // POST: Airport/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var loadedItem = core.Repository.GetByID<Airport>(id);
                if (loadedItem != null)
                {
                    core.Repository.Delete(loadedItem);
                    core.Repository.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Index)); // Idee: Andere Seite bei Fehler
            }
            catch
            {
                return View();
            }
        }
    }
}