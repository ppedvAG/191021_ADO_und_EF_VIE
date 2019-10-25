using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ppedv.ProjectAli.Data.EF;
using ppedv.ProjectAli.Domain;

namespace ppedv.ProjectAli.UI.ASP.Controllers
{
    public class AircraftTypesController : Controller
    {
        private readonly EFContext _context;

        public AircraftTypesController()
        {
            _context = new EFContext();
        }

        // GET: AircraftTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AircraftType.ToListAsync());
        }

        // GET: AircraftTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraftType = await _context.AircraftType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aircraftType == null)
            {
                return NotFound();
            }

            return View(aircraftType);
        }

        // GET: AircraftTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AircraftTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Model,Manufacturer,WTC,ID,IsDeleted,CreationDate,ModifiedDate,DeletedDate")] AircraftType aircraftType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraftType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aircraftType);
        }

        // GET: AircraftTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraftType = await _context.AircraftType.FindAsync(id);
            if (aircraftType == null)
            {
                return NotFound();
            }
            return View(aircraftType);
        }

        // POST: AircraftTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Model,Manufacturer,WTC,ID,IsDeleted,CreationDate,ModifiedDate,DeletedDate")] AircraftType aircraftType)
        {
            if (id != aircraftType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraftType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftTypeExists(aircraftType.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aircraftType);
        }

        // GET: AircraftTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraftType = await _context.AircraftType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aircraftType == null)
            {
                return NotFound();
            }

            return View(aircraftType);
        }

        // POST: AircraftTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aircraftType = await _context.AircraftType.FindAsync(id);
            _context.AircraftType.Remove(aircraftType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftTypeExists(int id)
        {
            return _context.AircraftType.Any(e => e.ID == id);
        }
    }
}
