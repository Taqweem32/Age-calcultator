using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBMS.Models;

namespace DBMS.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly NeondbContext _context;

        public DiseaseController(NeondbContext context)
        {
            _context = context;
        }

        // GET: Disease
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diseases.ToListAsync());
        }

        // GET: Disease/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.Diseases
                .FirstOrDefaultAsync(m => m.Diseaseid == id);
            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        // GET: Disease/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disease/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Diseaseid,Diseasename")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disease);
        }

        // GET: Disease/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.Diseases.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }
            return View(disease);
        }

        // POST: Disease/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Diseaseid,Diseasename")] Disease disease)
        {
            if (id != disease.Diseaseid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseaseExists(disease.Diseaseid))
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
            return View(disease);
        }

        // GET: Disease/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.Diseases
                .FirstOrDefaultAsync(m => m.Diseaseid == id);
            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        // POST: Disease/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disease = await _context.Diseases.FindAsync(id);
            if (disease != null)
            {
                _context.Diseases.Remove(disease);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseaseExists(int id)
        {
            return _context.Diseases.Any(e => e.Diseaseid == id);
        }
    }
}
