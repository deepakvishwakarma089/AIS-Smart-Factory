using AISSmartFactory.Data;
using AISSmartFactory.Models.Production;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class CncProductionController : Controller
{
    private readonly ApplicationDbContext _context;

    public CncProductionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ========================================================
    // INDEX
    // ========================================================

    public async Task<IActionResult> Index()
    {
        var records = await _context.CncProductionEntries
            .OrderByDescending(x => x.ProductionDate)
            .ThenByDescending(x => x.Id)
            .ToListAsync();

        return View(records);
    }

    // ========================================================
    // DETAILS
    // ========================================================

    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
            return NotFound();

        var record =
            await _context.CncProductionEntries
                .FirstOrDefaultAsync(x => x.Id == id);

        if (record == null)
            return NotFound();

        return View(record);
    }

    // ========================================================
    // CREATE
    // ========================================================

    public IActionResult Create()
    {
        var model = new CncProductionEntry
        {
            ProductionDate = DateTime.Now,
            StartTime = DateTime.Now,
            PlannedQuantity = 0,
            QualityApproved = false,
            IsCompleted = false
        };

        return View(model);
    }

    // ========================================================
    // CREATE POST
    // ========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        CncProductionEntry model)
    {
        if (model.GoodQuantity + model.RejectedQuantity
            != model.ProducedQuantity)
        {
            ModelState.AddModelError(
                nameof(model.ProducedQuantity),
                "Produced quantity must equal Good + Rejected quantity.");
        }

        if (model.GoodQuantity < 0)
        {
            ModelState.AddModelError(
                nameof(model.GoodQuantity),
                "Good quantity cannot be negative.");
        }

        if (model.RejectedQuantity < 0)
        {
            ModelState.AddModelError(
                nameof(model.RejectedQuantity),
                "Rejected quantity cannot be negative.");
        }

        if (!ModelState.IsValid)
            return View(model);

        if (string.IsNullOrWhiteSpace(model.ProductionNumber))
        {
            model.ProductionNumber =
                "PRD-" +
                DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        model.CreatedAt = DateTime.UtcNow;
        model.UpdatedAt = DateTime.UtcNow;

        _context.CncProductionEntries.Add(model);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "CNC production entry created successfully.";

        return RedirectToAction(nameof(Index));
    }

    // ========================================================
    // EDIT
    // ========================================================

    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
            return NotFound();

        var model =
            await _context.CncProductionEntries.FindAsync(id);

        if (model == null)
            return NotFound();

        return View(model);
    }

    // ========================================================
    // EDIT POST
    // ========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        CncProductionEntry model)
    {
        if (id != model.Id)
            return NotFound();

        if (model.GoodQuantity + model.RejectedQuantity
            != model.ProducedQuantity)
        {
            ModelState.AddModelError(
                nameof(model.ProducedQuantity),
                "Produced quantity must equal Good + Rejected quantity.");
        }

        if (!ModelState.IsValid)
            return View(model);

        var existing =
            await _context.CncProductionEntries.FindAsync(id);

        if (existing == null)
            return NotFound();

        existing.ProductionDate = model.ProductionDate;
        existing.StartTime = model.StartTime;
        existing.EndTime = model.EndTime;

        existing.MachineId = model.MachineId;
        existing.OperatorId = model.OperatorId;
        existing.GlassTypeId = model.GlassTypeId;
        existing.CncProgramId = model.CncProgramId;
        existing.ToolId = model.ToolId;

        existing.PlannedQuantity = model.PlannedQuantity;
        existing.ProducedQuantity = model.ProducedQuantity;
        existing.GoodQuantity = model.GoodQuantity;
        existing.RejectedQuantity = model.RejectedQuantity;

        existing.CycleTimeSeconds =
            model.CycleTimeSeconds;

        existing.SpindleRpm =
            model.SpindleRpm;

        existing.FeedRate =
            model.FeedRate;

        existing.CuttingDepth =
            model.CuttingDepth;

        existing.CoolantPressure =
            model.CoolantPressure;

        existing.AirPressure =
            model.AirPressure;

        existing.MachineLoadPercent =
            model.MachineLoadPercent;

        existing.EnergyKwh =
            model.EnergyKwh;

        existing.QualityApproved =
            model.QualityApproved;

        existing.QualityRemarks =
            model.QualityRemarks;

        existing.Remarks =
            model.Remarks;

        existing.IsCompleted =
            model.IsCompleted;

        existing.UpdatedAt =
            DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Production entry updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    // ========================================================
    // DELETE
    // ========================================================

    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
            return NotFound();

        var record =
            await _context.CncProductionEntries
                .FirstOrDefaultAsync(x => x.Id == id);

        if (record == null)
            return NotFound();

        return View(record);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var record =
            await _context.CncProductionEntries.FindAsync(id);

        if (record == null)
            return NotFound();

        _context.CncProductionEntries.Remove(record);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Production entry deleted successfully.";

        return RedirectToAction(nameof(Index));
    }
}
