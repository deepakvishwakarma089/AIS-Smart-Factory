
using AISSmartFactory.Data;
using AISSmartFactory.Models.Quality;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class QualityInspectionsController : Controller
{
    private readonly ApplicationDbContext _context;

    public QualityInspectionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // =========================================================
    // INDEX
    // =========================================================

    public async Task<IActionResult> Index()
    {
        var records = await _context.QualityInspections
            .Include(x => x.ProductionRun)
            .Include(x => x.Operator)
            .OrderByDescending(x => x.InspectionTime)
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

        var record = await _context.QualityInspections
            .Include(x => x.ProductionRun)
            .Include(x => x.Operator)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (record == null)
            return NotFound();

        return View(record);
    }

    // =========================================================
    // CREATE GET
    // =========================================================

    public async Task<IActionResult> Create()
    {
        await LoadDropdowns();

        var model = new QualityInspection
        {
            InspectionTime = DateTime.Now
        };

        return View(model);
    }

    // =========================================================
    // CREATE POST
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        QualityInspection model)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdowns(model);
            return View(model);
        }

        _context.QualityInspections.Add(model);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Quality inspection created successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // EDIT GET
    // =========================================================

    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
            return NotFound();

        var model = await _context.QualityInspections
            .FindAsync(id);

        if (model == null)
            return NotFound();

        await LoadDropdowns(model);

        return View(model);
    }

    // =========================================================
    // EDIT POST
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        QualityInspection model)
    {
        if (id != model.Id)
            return NotFound();

        if (!ModelState.IsValid)
        {
            await LoadDropdowns(model);
            return View(model);
        }

        var existing = await _context.QualityInspections
            .FindAsync(id);

        if (existing == null)
            return NotFound();

        existing.ProductionRunId = model.ProductionRunId;
        existing.OperatorId = model.OperatorId;

        existing.InspectionType = model.InspectionType;
        existing.InspectionTime = model.InspectionTime;
        existing.Result = model.Result;
        existing.InspectorName = model.InspectorName;
        existing.Remarks = model.Remarks;
        existing.InspectionPhotoPath =
            model.InspectionPhotoPath;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Quality inspection updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // DELETE GET
    // =========================================================

    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
            return NotFound();

        var record = await _context.QualityInspections
            .Include(x => x.ProductionRun)
            .Include(x => x.Operator)
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
        var record = await _context.QualityInspections
            .FindAsync(id);

        if (record == null)
            return NotFound();

        _context.QualityInspections.Remove(record);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Quality inspection deleted successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // DROPDOWNS
    // =========================================================

    private async Task LoadDropdowns(
        QualityInspection? model = null)
    {
        ViewBag.ProductionRuns = new SelectList(
            await _context.ProductionRuns
                .OrderByDescending(x => x.StartTime)
                .ToListAsync(),
            "Id",
            "PieceNumber",
            model?.ProductionRunId);

        ViewBag.Operators = new SelectList(
            await _context.Operators
                .Where(x => x.IsActive)
                .OrderBy(x => x.EmployeeName)
                .ToListAsync(),
            "Id",
            "EmployeeName",
            model?.OperatorId);
    }
}

