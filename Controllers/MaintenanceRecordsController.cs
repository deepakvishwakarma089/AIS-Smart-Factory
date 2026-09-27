
using AISSmartFactory.Data;
using AISSmartFactory.Models.Maintenance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class MaintenanceRecordsController : Controller
{
    private readonly ApplicationDbContext _context;

    public MaintenanceRecordsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // =========================================================
    // INDEX
    // =========================================================

    public async Task<IActionResult> Index()
    {
        var records = await _context.MaintenanceRecords
            .Include(x => x.Machine)
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

        var record = await _context.MaintenanceRecords
            .Include(x => x.Machine)
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

        var model = new MaintenanceRecord
        {
            StartTime = DateTime.Now,
            MaintenanceStatus = "Open"
        };

        return View(model);
    }

    // =========================================================
    // CREATE POST
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        MaintenanceRecord model)
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

        _context.MaintenanceRecords.Add(model);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Maintenance record created successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // EDIT GET
    // =========================================================

    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
            return NotFound();

        var model = await _context.MaintenanceRecords
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
        MaintenanceRecord model)
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

        var existing = await _context.MaintenanceRecords
            .FindAsync(id);

        if (existing == null)
            return NotFound();

        existing.MachineId = model.MachineId;

        existing.MaintenanceType =
            model.MaintenanceType;

        existing.MaintenanceStatus =
            model.MaintenanceStatus;

        existing.StartTime =
            model.StartTime;

        existing.EndTime =
            model.EndTime;

        existing.NextDueDate =
            model.NextDueDate;

        existing.ProblemDescription =
            model.ProblemDescription;

        existing.RootCause =
            model.RootCause;

        existing.CorrectiveAction =
            model.CorrectiveAction;

        existing.Technician =
            model.Technician;

        existing.SparePartsUsed =
            model.SparePartsUsed;

        existing.MachineRunningHours =
            model.MachineRunningHours;

        existing.Remarks =
            model.Remarks;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Maintenance record updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // DELETE GET
    // =========================================================

    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
            return NotFound();

        var record = await _context.MaintenanceRecords
            .Include(x => x.Machine)
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
        var record = await _context.MaintenanceRecords
            .FindAsync(id);

        if (record == null)
            return NotFound();

        _context.MaintenanceRecords.Remove(record);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Maintenance record deleted successfully.";

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // DROPDOWNS
    // =========================================================

    private async Task LoadDropdowns(
        MaintenanceRecord? model = null)
    {
        ViewBag.Machines = new SelectList(
            await _context.Machines
                .Where(x => x.IsActive)
                .OrderBy(x => x.MachineName)
                .ToListAsync(),
            "Id",
            "MachineName",
            model?.MachineId);
    }
}
