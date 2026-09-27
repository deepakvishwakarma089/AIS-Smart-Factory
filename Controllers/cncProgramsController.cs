using AISSmartFactory.Data;
using AISSmartFactory.Models.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class CncProgramsController : Controller
{
    private readonly ApplicationDbContext _context;

    public CncProgramsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CncPrograms
    public async Task<IActionResult> Index()
    {
        var programs = await _context.CncPrograms
            .Include(x => x.Machine)
            .Include(x => x.GlassType)
            .OrderBy(x => x.ProgramCode)
            .ToListAsync();

        return View(programs);
    }

    // GET: CncPrograms/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
            return NotFound();

        var program = await _context.CncPrograms
            .Include(x => x.Machine)
            .Include(x => x.GlassType)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (program == null)
            return NotFound();

        return View(program);
    }

    // GET: CncPrograms/Create
    public async Task<IActionResult> Create()
    {
        await LoadDropdowns();

        return View();
    }

    // POST: CncPrograms/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CncProgram program)
    {
        bool exists = await _context.CncPrograms
            .AnyAsync(x => x.ProgramCode == program.ProgramCode);

        if (exists)
        {
            ModelState.AddModelError(
                nameof(program.ProgramCode),
                "Program code already exists.");
        }

        if (ModelState.IsValid)
        {
            program.CreatedAt = DateTime.UtcNow;
            program.UpdatedAt = DateTime.UtcNow;
            program.IsActive = true;

            _context.CncPrograms.Add(program);

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "CNC program created successfully.";

            return RedirectToAction(nameof(Index));
        }

        await LoadDropdowns(program.MachineId, program.GlassTypeId);

        return View(program);
    }

    // GET: CncPrograms/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
            return NotFound();

        var program = await _context.CncPrograms
            .FindAsync(id);

        if (program == null)
            return NotFound();

        await LoadDropdowns(
            program.MachineId,
            program.GlassTypeId);

        return View(program);
    }

    // POST: CncPrograms/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        CncProgram program)
    {
        if (id != program.Id)
            return NotFound();

        bool exists = await _context.CncPrograms
            .AnyAsync(x =>
                x.ProgramCode == program.ProgramCode &&
                x.Id != program.Id);

        if (exists)
        {
            ModelState.AddModelError(
                nameof(program.ProgramCode),
                "Program code already exists.");
        }

        if (!ModelState.IsValid)
        {
            await LoadDropdowns(
                program.MachineId,
                program.GlassTypeId);

            return View(program);
        }

        try
        {
            var existing = await _context.CncPrograms
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
                return NotFound();

            existing.ProgramCode =
                program.ProgramCode;

            existing.ProgramName =
                program.ProgramName;

            existing.ProgramNumber =
                program.ProgramNumber;

            existing.MachineId =
                program.MachineId;

            existing.GlassTypeId =
                program.GlassTypeId;

            existing.OperationType =
                program.OperationType;

            existing.TargetCycleTime =
                program.TargetCycleTime;

            existing.Revision =
                program.Revision;

            existing.Description =
                program.Description;

            existing.IsActive =
                program.IsActive;

            existing.UpdatedAt =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "CNC program updated successfully.";

            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CncProgramExists(program.Id))
                return NotFound();

            throw;
        }
    }

    // GET: CncPrograms/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
            return NotFound();

        var program = await _context.CncPrograms
            .Include(x => x.Machine)
            .Include(x => x.GlassType)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (program == null)
            return NotFound();

        return View(program);
    }

    // POST: CncPrograms/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var program = await _context.CncPrograms
            .FindAsync(id);

        if (program == null)
            return NotFound();

        // Soft delete
        program.IsActive = false;
        program.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "CNC program deactivated successfully.";

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadDropdowns(
        long? selectedMachine = null,
        long? selectedGlassType = null)
    {
        var machines = await _context.Machines
            .Where(x => x.IsActive)
            .OrderBy(x => x.MachineCode)
            .ToListAsync();

        var glassTypes = await _context.GlassTypes
            .Where(x => x.IsActive)
            .OrderBy(x => x.GlassCode)
            .ToListAsync();

        ViewBag.Machines = new SelectList(
            machines,
            "Id",
            "MachineCode",
            selectedMachine);

        ViewBag.GlassTypes = new SelectList(
            glassTypes,
            "Id",
            "GlassCode",
            selectedGlassType);
    }

    private bool CncProgramExists(long id)
    {
        return _context.CncPrograms
            .Any(x => x.Id == id);
    }
}