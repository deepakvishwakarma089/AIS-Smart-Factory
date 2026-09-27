
using AISSmartFactory.Data;
using AISSmartFactory.Models.Production;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

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

        var record = await _context.CncProductionEntries
            .FirstOrDefaultAsync(x => x.Id == id);

        if (record == null)
            return NotFound();

        return View(record);
    }


    // ========================================================
    // CREATE - GET
    // ========================================================

    public async Task<IActionResult> Create()
    {
        var now = DateTime.Now;

        var model = new CncProductionEntry
        {
            ProductionDate = now,
            StartTime = now,
            PlannedQuantity = 0,
            ProducedQuantity = 0,
            GoodQuantity = 0,
            RejectedQuantity = 0,
            QualityApproved = false,
            IsCompleted = false
        };

        await LoadDropdownsAsync();

        return View(model);
    }


    // ========================================================
    // CREATE - POST
    // ========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CncProductionEntry model)
    {
        ValidateProductionQuantities(model);

        if (!ModelState.IsValid)
        {
            await LoadDropdownsAsync(model);
            return View(model);
        }

        if (string.IsNullOrWhiteSpace(model.ProductionNumber))
        {
            model.ProductionNumber =
                $"PRD-{DateTime.Now:yyyyMMddHHmmssfff}";
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
    // EDIT - GET
    // ========================================================

    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
            return NotFound();

        var model = await _context.CncProductionEntries
            .FindAsync(id);

        if (model == null)
            return NotFound();

        await LoadDropdownsAsync(model);

        return View(model);
    }


    // ========================================================
    // EDIT - POST
    // ========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        CncProductionEntry model)
    {
        if (id != model.Id)
            return NotFound();

        ValidateProductionQuantities(model);

        if (!ModelState.IsValid)
        {
            await LoadDropdownsAsync(model);
            return View(model);
        }

        var existing = await _context.CncProductionEntries
            .FindAsync(id);

        if (existing == null)
            return NotFound();


        // ----------------------------------------------------
        // BASIC INFORMATION
        // ----------------------------------------------------

        existing.ProductionDate = model.ProductionDate;
        existing.StartTime = model.StartTime;
        existing.EndTime = model.EndTime;

        existing.MachineId = model.MachineId;
        existing.OperatorId = model.OperatorId;
        existing.GlassTypeId = model.GlassTypeId;
        existing.CncProgramId = model.CncProgramId;
        existing.ToolId = model.ToolId;


        // ----------------------------------------------------
        // QUANTITY
        // ----------------------------------------------------

        existing.PlannedQuantity = model.PlannedQuantity;
        existing.ProducedQuantity = model.ProducedQuantity;
        existing.GoodQuantity = model.GoodQuantity;
        existing.RejectedQuantity = model.RejectedQuantity;


        // ----------------------------------------------------
        // CNC PROCESS PARAMETERS
        // ----------------------------------------------------

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


        // ----------------------------------------------------
        // QUALITY
        // ----------------------------------------------------

        existing.QualityApproved =
            model.QualityApproved;

        existing.QualityRemarks =
            model.QualityRemarks;


        // ----------------------------------------------------
        // STATUS
        // ----------------------------------------------------

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
    // DELETE - GET
    // ========================================================

    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
            return NotFound();

        var record = await _context.CncProductionEntries
            .FirstOrDefaultAsync(x => x.Id == id);

        if (record == null)
            return NotFound();

        return View(record);
    }


    // ========================================================
    // DELETE - POST
    // ========================================================

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var record = await _context.CncProductionEntries
            .FindAsync(id);

        if (record == null)
            return NotFound();

        _context.CncProductionEntries.Remove(record);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Production entry deleted successfully.";

        return RedirectToAction(nameof(Index));
    }


    // ========================================================
    // VALIDATION
    // ========================================================

    private void ValidateProductionQuantities(
        CncProductionEntry model)
    {
        if (model.PlannedQuantity < 0)
        {
            ModelState.AddModelError(
                nameof(model.PlannedQuantity),
                "Planned quantity cannot be negative.");
        }

        if (model.ProducedQuantity < 0)
        {
            ModelState.AddModelError(
                nameof(model.ProducedQuantity),
                "Produced quantity cannot be negative.");
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

        if (model.GoodQuantity + model.RejectedQuantity
            != model.ProducedQuantity)
        {
            ModelState.AddModelError(
                nameof(model.ProducedQuantity),
                "Produced quantity must equal Good + Rejected quantity.");
        }

        if (model.EndTime.HasValue &&
            model.EndTime.Value < model.StartTime)
        {
            ModelState.AddModelError(
                nameof(model.EndTime),
                "End time cannot be earlier than start time.");
        }

        if (model.CycleTimeSeconds.HasValue &&
            model.CycleTimeSeconds.Value < 0)
        {
            ModelState.AddModelError(
                nameof(model.CycleTimeSeconds),
                "Cycle time cannot be negative.");
        }

        if (model.SpindleRpm.HasValue &&
            model.SpindleRpm.Value < 0)
        {
            ModelState.AddModelError(
                nameof(model.SpindleRpm),
                "Spindle RPM cannot be negative.");
        }

        if (model.FeedRate.HasValue &&
            model.FeedRate.Value < 0)
        {
            ModelState.AddModelError(
                nameof(model.FeedRate),
                "Feed rate cannot be negative.");
        }

        if (model.CuttingDepth.HasValue &&
            model.CuttingDepth.Value < 0)
        {
            ModelState.AddModelError(
                nameof(model.CuttingDepth),
                "Cutting depth cannot be negative.");
        }

        if (model.CoolantPressure.HasValue &&
            model.CoolantPressure.Value < 0)
        {
            ModelState.AddModelError(
                nameof(model.CoolantPressure),
                "Coolant pressure cannot be negative.");
        }

        if (model.AirPressure.HasValue &&
            model.AirPressure.Value < 0)
        {
            ModelState.AddModelError(
                nameof(model.AirPressure),
                "Air pressure cannot be negative.");
        }

        if (model.MachineLoadPercent.HasValue &&
            (model.MachineLoadPercent.Value < 0 ||
             model.MachineLoadPercent.Value > 100))
        {
            ModelState.AddModelError(
                nameof(model.MachineLoadPercent),
                "Machine load must be between 0 and 100 percent.");
        }

        if (model.EnergyKwh.HasValue &&
            model.EnergyKwh.Value < 0)
        {
            ModelState.AddModelError(
                nameof(model.EnergyKwh),
                "Energy consumption cannot be negative.");
        }
    }


    // ========================================================
    // DROPDOWNS
    // ========================================================

    private async Task LoadDropdownsAsync(
        CncProductionEntry? model = null)
    {
        /*
         * We will populate these once the exact foreign-key
         * properties of CncProductionEntry are confirmed.
         *
         * ViewBag.Machines
         * ViewBag.Operators
         * ViewBag.GlassTypes
         * ViewBag.CncPrograms
         * ViewBag.Tools
         */

        await Task.CompletedTask;
    }
}