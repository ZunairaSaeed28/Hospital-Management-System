using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class MedicalrecordController : Controller
    {
        private readonly HospitalManagementDatabaseContext _context;

        public MedicalrecordController(HospitalManagementDatabaseContext context)
        {
            _context = context;
        }

        // GET: Medicalrecord
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medicalrecords.ToListAsync());
        }

        // GET: Medicalrecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalrecord = await _context.Medicalrecords
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (medicalrecord == null)
            {
                return NotFound();
            }

            return View(medicalrecord);
        }

        // GET: Medicalrecord/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicalrecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordId,PatientId,Diagnosis,Prescription,VisitDate")] Medicalrecord medicalrecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalrecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalrecord);
        }

        // GET: Medicalrecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalrecord = await _context.Medicalrecords.FindAsync(id);
            if (medicalrecord == null)
            {
                return NotFound();
            }
            return View(medicalrecord);
        }

        // POST: Medicalrecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordId,PatientId,Diagnosis,Prescription,VisitDate")] Medicalrecord medicalrecord)
        {
            if (id != medicalrecord.RecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalrecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalrecordExists(medicalrecord.RecordId))
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
            return View(medicalrecord);
        }

        // GET: Medicalrecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalrecord = await _context.Medicalrecords
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (medicalrecord == null)
            {
                return NotFound();
            }

            return View(medicalrecord);
        }

        // POST: Medicalrecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalrecord = await _context.Medicalrecords.FindAsync(id);
            if (medicalrecord != null)
            {
                _context.Medicalrecords.Remove(medicalrecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalrecordExists(int id)
        {
            return _context.Medicalrecords.Any(e => e.RecordId == id);
        }
    }
}
