
using AISSmartFactory.Data;
using AISSmartFactory.Models.Master;
using AISSmartFactory.Models.Quality;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class DefectTypesController : Controller
{
    private readonly ApplicationDbContext _context;

    public DefectTypesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // =========================================================
    // INDEX
    // =========================================================

    public async Task<IActionResult> Index()
    {
        var records = await _context.DefectTypes
            .OrderBy(x => x.Category)
            .ThenBy(x => x.Name)
            .ToListAsync();

        return View(records);
    }

    // =========================================================
    // DETAILS
    // =========================================================

    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
            return NotFound();

        var record = await _context.DefectTypes
            .FirstOrDefaultAsync(x => x.Id == id);

        if (record == null)
            return NotFound();

        return View(record);
    }

    // =========================================================
    // CREATE GET
    // =========================================================

    public IActionResult Create()
    {
        return View();
    }

    // =========================================================
    // CREATE POST
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        DefectType model)
    {
        if (await _context.DefectTypes
            .AnyAsync(x => x.Code == model.Code))
        {
            ModelState.AddModelError(
                nameof(model.Code),
                "Defect code already exists.");
        }

        if (!ModelState.IsValid)
            return View(model);

        _context.DefectTypes.Add(model);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Defect type created successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // EDIT GET
    // =========================================================

    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
            return NotFound();

        var model = await _context.DefectTypes
            .FindAsync(id);

        if (model == null)
            return NotFound();

        return View(model);
    }

    // =========================================================
    // EDIT POST
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        DefectType model)
    {
        if (id != model.Id)
            return NotFound();

        if (await _context.DefectTypes
            .AnyAsync(x =>
                x.Code == model.Code &&
                x.Id != model.Id))
        {
            ModelState.AddModelError(
                nameof(model.Code),
                "Defect code already exists.");
        }

        if (!ModelState.IsValid)
            return View(model);

        var existing = await _context.DefectTypes
            .FindAsync(id);

        if (existing == null)
            return NotFound();

        existing.Code = model.Code;
        existing.Name = model.Name;
        existing.Category = model.Category;
        existing.Severity = model.Severity;
        existing.Description = model.Description;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Defect type updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // DELETE GET
    // =========================================================

    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
            return NotFound();

        var record = await _context.DefectTypes
            .FirstOrDefaultAsync(x => x.Id == id);

        if (record == null)
            return NotFound();

        return View(record);
    }

    // =========================================================
    // DELETE POST
    // =========================================================

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var record = await _context.DefectTypes
            .FindAsync(id);

        if (record == null)
            return NotFound();

        var isUsed = await _context.QualityDefects
            .AnyAsync(x => x.DefectTypeId == id);

        if (isUsed)
        {
            TempData["Error"] =
                "This defect type cannot be deleted because it is already used in quality records.";

            return RedirectToAction(nameof(Index));
        }

        _context.DefectTypes.Remove(record);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Defect type deleted successfully.";

        return RedirectToAction(nameof(Index));
    }
}