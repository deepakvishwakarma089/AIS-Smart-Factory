using AISSmartFactory.Data;
using AISSmartFactory.Models.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class GlassTypesController : Controller
{
    private readonly ApplicationDbContext _context;

    public GlassTypesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: GlassTypes
    public async Task<IActionResult> Index()
    {
        var glassTypes = await _context.GlassTypes
            .OrderBy(x => x.GlassCode)
            .ToListAsync();

        return View(glassTypes);
    }

    // GET: GlassTypes/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var glassType = await _context.GlassTypes
            .FirstOrDefaultAsync(x => x.Id == id);

        if (glassType == null)
        {
            return NotFound();
        }

        return View(glassType);
    }

    // GET: GlassTypes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: GlassTypes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GlassType glassType)
    {
        bool exists = await _context.GlassTypes
            .AnyAsync(x => x.GlassCode == glassType.GlassCode);

        if (exists)
        {
            ModelState.AddModelError(
                nameof(glassType.GlassCode),
                "Glass code already exists.");
        }

        if (ModelState.IsValid)
        {
            glassType.CreatedAt = DateTime.UtcNow;
            glassType.UpdatedAt = DateTime.UtcNow;
            glassType.IsActive = true;

            _context.GlassTypes.Add(glassType);

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Glass type created successfully.";

            return RedirectToAction(nameof(Index));
        }

        return View(glassType);
    }

    // GET: GlassTypes/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var glassType = await _context.GlassTypes
            .FindAsync(id);

        if (glassType == null)
        {
            return NotFound();
        }

        return View(glassType);
    }

    // POST: GlassTypes/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        GlassType glassType)
    {
        if (id != glassType.Id)
        {
            return NotFound();
        }

        bool exists = await _context.GlassTypes
            .AnyAsync(x =>
                x.GlassCode == glassType.GlassCode &&
                x.Id != glassType.Id);

        if (exists)
        {
            ModelState.AddModelError(
                nameof(glassType.GlassCode),
                "Glass code already exists.");
        }

        if (!ModelState.IsValid)
        {
            return View(glassType);
        }

        try
        {
            var existing = await _context.GlassTypes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.GlassCode =
                glassType.GlassCode;

            existing.GlassName =
                glassType.GlassName;

            existing.GlassCategory =
                glassType.GlassCategory;

            existing.Thickness =
                glassType.Thickness;

            existing.Width =
                glassType.Width;

            existing.Length =
                glassType.Length;

            existing.CoatingType =
                glassType.CoatingType;

            existing.Description =
                glassType.Description;

            existing.IsActive =
                glassType.IsActive;

            existing.UpdatedAt =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Glass type updated successfully.";

            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GlassTypeExists(glassType.Id))
            {
                return NotFound();
            }

            throw;
        }
    }

    // GET: GlassTypes/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var glassType = await _context.GlassTypes
            .FirstOrDefaultAsync(x => x.Id == id);

        if (glassType == null)
        {
            return NotFound();
        }

        return View(glassType);
    }

    // POST: GlassTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var glassType = await _context.GlassTypes
            .FindAsync(id);

        if (glassType == null)
        {
            return NotFound();
        }

        // Soft delete
        glassType.IsActive = false;
        glassType.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Glass type deactivated successfully.";

        return RedirectToAction(nameof(Index));
    }

    private bool GlassTypeExists(long id)
    {
        return _context.GlassTypes
            .Any(x => x.Id == id);
    }
}