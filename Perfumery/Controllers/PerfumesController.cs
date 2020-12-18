using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Perfumery.Models;
using Perfumery.viewModels;

namespace Perfumery.Controllers
{
    public class PerfumesController : Controller
    {
        private readonly PerfumeryConext _context;

        public PerfumesController(PerfumeryConext context)
        {
            _context = context;
        }

        // GET: Perfumes
        public async Task<IActionResult> Index()
        {
            var perfumes = await _context.Perfumes.ToListAsync();
            ViewBag.list = perfumes;
            return View();
        }

        // GET: Perfumes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfume == null)
            {
                return NotFound();
            }
            ViewBag.perf = perfume;
            return View();
        }

        // GET: Perfumes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfumes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PerfumeDto perfume)
        {
            var imagebase64 ="";
            using (var ms=new MemoryStream())
            {
                perfume.Image.CopyTo(ms);
                byte[] fileByts = ms.ToArray();
                imagebase64 = Convert.ToBase64String(fileByts);
            }
            var newPerfume = new Perfume()
            {
                Image = string.Format("data:image/png;base64,{0}",imagebase64),
                Price = perfume.Price,
                Name = perfume.Name,
                Description = perfume.Description,

            };
            if (ModelState.IsValid)
            {
                _context.Add(newPerfume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfume);
        }

        // GET: Perfumes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfumes.FindAsync(id);
            if (perfume == null)
            {
                return NotFound();
            }
            return View(perfume);
        }

        // POST: Perfumes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PerfumeDto perfumeDto)
        {
            var perfume = await _context.Perfumes
               .FirstOrDefaultAsync(m => m.Id == perfumeDto.Id);
            var imagebase64 = "";
            using (var ms = new MemoryStream())
            {
                perfumeDto.Image.CopyTo(ms);
                byte[] fileByts = ms.ToArray();
                imagebase64 = Convert.ToBase64String(fileByts);
            }

            perfume.Image = string.Format("data:image/png;base64,{0}", imagebase64);
            perfume.Price = perfume.Price;
                perfume.Name = perfume.Name;
            perfume.Description = perfume.Description;

            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfumeExists(perfume.Id))
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
            return View(perfume);
        }

        // GET: Perfumes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfume == null)
            {
                return NotFound();
            }

            return View(perfume);
        }

        // POST: Perfumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfume = await _context.Perfumes.FindAsync(id);
            _context.Perfumes.Remove(perfume);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfumeExists(int id)
        {
            return _context.Perfumes.Any(e => e.Id == id);
        }
    }
}
