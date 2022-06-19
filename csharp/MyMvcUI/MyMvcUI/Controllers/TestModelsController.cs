using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMvcUI.Data;
using MyMvcUI.Models;

namespace MyMvcUI.Controllers
{
    public class TestModelsController : Controller
    {
        private readonly MyMvcUIContext _context;

        public TestModelsController(MyMvcUIContext context)
        {
            _context = context;
        }

        // GET: TestModels
        public async Task<IActionResult> Index()
        {
              return _context.TestModel != null ? 
                          View(await _context.TestModel.ToListAsync()) :
                          Problem("Entity set 'MyMvcUIContext.TestModel'  is null.");
        }

        // GET: TestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TestModel == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // GET: TestModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title,ReleaseDate,Desc,Price")] TestModel testModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testModel);
        }

        // GET: TestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestModel == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModel.FindAsync(id);
            if (testModel == null)
            {
                return NotFound();
            }
            return View(testModel);
        }

        // POST: TestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title,ReleaseDate,Desc,Price")] TestModel testModel)
        {
            if (id != testModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestModelExists(testModel.id))
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
            return View(testModel);
        }

        // GET: TestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TestModel == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // POST: TestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TestModel == null)
            {
                return Problem("Entity set 'MyMvcUIContext.TestModel'  is null.");
            }
            var testModel = await _context.TestModel.FindAsync(id);
            if (testModel != null)
            {
                _context.TestModel.Remove(testModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestModelExists(int id)
        {
          return (_context.TestModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
