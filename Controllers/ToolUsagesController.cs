
using AISSmartFactory.Data;
using AISSmartFactory.Models.Tooling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class ToolUsagesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ToolUsagesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // =========================================================
    // INDEX
    // =========================================================

    public async Task<IActionResult> Index()
    {
        var records = await _context.ToolUsages
            .Include(x => x.Tool)
            .Include(x => x.Machine)
            .Include(x => x.ProductionRun)
            .OrderByDescending(x => x.StartTime)
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

        var record = await _context.ToolUsages
            .Include(x => x.Tool)
            .Include(x => x.Machine)
            .Include(x => x.ProductionRun)
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

        var model = new ToolUsage
        {
            StartTime = DateTime.Now
        };

        return View(model);
    }

    // =========================================================
    // CREATE POST
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        ToolUsage model)
    {
        if (model.EndTime.HasValue &&
            model.EndTime.Value < model.StartTime)
        {
            ModelState.AddModelError(
                nameof(model.EndTime),
                "End time cannot be earlier than start time.");
        }

        if (!ModelState.IsValid)
        {
            await LoadDropdowns(model);
            return View(model);
        }

        _context.ToolUsages.Add(model);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Tool usage record created successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // EDIT GET
    // =========================================================

    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
            return NotFound();

        var model = await _context.ToolUsages
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
        ToolUsage model)
    {
        if (id != model.Id)
            return NotFound();

        if (model.EndTime.HasValue &&
            model.EndTime.Value < model.StartTime)
        {
            ModelState.AddModelError(
                nameof(model.EndTime),
                "End time cannot be earlier than start time.");
        }

        if (!ModelState.IsValid)
        {
            await LoadDropdowns(model);
            return View(model);
        }

        var existing = await _context.ToolUsages
            .FindAsync(id);

        if (existing == null)
            return NotFound();

        existing.ToolId = model.ToolId;
        existing.MachineId = model.MachineId;
        existing.ProductionRunId = model.ProductionRunId;

        existing.StartTime = model.StartTime;
        existing.EndTime = model.EndTime;

        existing.UsageHours = model.UsageHours;
        existing.RemainingLifeHours =
            model.RemainingLifeHours;

        existing.Condition = model.Condition;
        existing.Remarks = model.Remarks;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Tool usage record updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // DELETE GET
    // =========================================================

    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
            return NotFound();

        var record = await _context.ToolUsages
            .Include(x => x.Tool)
            .Include(x => x.Machine)
            .Include(x => x.ProductionRun)
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
        var record = await _context.ToolUsages
            .FindAsync(id);

        if (record == null)
            return NotFound();

        _context.ToolUsages.Remove(record);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Tool usage record deleted successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // DROPDOWNS
    // =========================================================

    private async Task LoadDropdowns(
        ToolUsage? model = null)
    {
        ViewBag.Tools = new SelectList(
            await _context.Tools
                .Where(x => x.IsActive)
                .OrderBy(x => x.ToolName)
                .ToListAsync(),
            "Id",
            "ToolName",
            model?.ToolId);

        ViewBag.Machines = new SelectList(
            await _context.Machines
                .Where(x => x.IsActive)
                .OrderBy(x => x.MachineName)
                .ToListAsync(),
            "Id",
            "MachineName",
            model?.MachineId);

        ViewBag.ProductionRuns = new SelectList(
            await _context.ProductionRuns
                .OrderByDescending(x => x.StartTime)
                .ToListAsync(),
            "Id",
            "PieceNumber",
            model?.ProductionRunId);
    }
}
