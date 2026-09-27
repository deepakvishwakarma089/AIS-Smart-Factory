using AISSmartFactory.Data;
using AISSmartFactory.Models.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class MachinesController : Controller
{
    private readonly ApplicationDbContext _context;

    public MachinesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Machines
    public async Task<IActionResult> Index()
    {
        var machines = await _context.Machines
            .OrderBy(x => x.MachineCode)
            .ToListAsync();

        return View(machines);
    }

    // GET: Machines/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var machine = await _context.Machines
            .FirstOrDefaultAsync(x => x.Id == id);

        if (machine == null)
        {
            return NotFound();
        }

        return View(machine);
    }

    // GET: Machines/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Machines/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Machine machine)
    {
        if (await _context.Machines
            .AnyAsync(x => x.MachineCode == machine.MachineCode))
        {
            ModelState.AddModelError(
                nameof(machine.MachineCode),
                "Machine code already exists.");
        }

        if (ModelState.IsValid)
        {
            machine.CreatedAt = DateTime.UtcNow;
            machine.IsActive = true;

            _context.Machines.Add(machine);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Machine created successfully.";

            return RedirectToAction(nameof(Index));
        }

        return View(machine);
    }

    // GET: Machines/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var machine = await _context.Machines
            .FindAsync(id);

        if (machine == null)
        {
            return NotFound();
        }

        return View(machine);
    }

    // POST: Machines/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        Machine machine)
    {
        if (id != machine.Id)
        {
            return NotFound();
        }

        if (await _context.Machines.AnyAsync(
            x => x.MachineCode == machine.MachineCode &&
                 x.Id != machine.Id))
        {
            ModelState.AddModelError(
                nameof(machine.MachineCode),
                "Machine code already exists.");
        }

        if (ModelState.IsValid)
        {
            try
            {
                var existingMachine = await _context.Machines
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (existingMachine == null)
                {
                    return NotFound();
                }

                existingMachine.MachineCode =
                    machine.MachineCode;

                existingMachine.MachineName =
                    machine.MachineName;

                existingMachine.MachineType =
                    machine.MachineType;

                existingMachine.Manufacturer =
                    machine.Manufacturer;

                existingMachine.Model =
                    machine.Model;

                existingMachine.Controller =
                    machine.Controller;

                existingMachine.SerialNumber =
                    machine.SerialNumber;

                existingMachine.IPAddress =
                    machine.IPAddress;

                existingMachine.Port =
                    machine.Port;

                existingMachine.Location =
                    machine.Location;

                existingMachine.LineName =
                    machine.LineName;

                existingMachine.CommunicationProtocol =
                    machine.CommunicationProtocol;

                existingMachine.Description =
                    machine.Description;

                existingMachine.IsOnline =
                    machine.IsOnline;

                existingMachine.IsActive =
                    machine.IsActive;

                existingMachine.UpdatedAt =
                    DateTime.UtcNow;

                await _context.SaveChangesAsync();

                TempData["Success"] = "Machine updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(machine.Id))
                {
                    return NotFound();
                }

                throw;
            }
        }

        return View(machine);
    }

    // GET: Machines/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var machine = await _context.Machines
            .FirstOrDefaultAsync(x => x.Id == id);

        if (machine == null)
        {
            return NotFound();
        }

        return View(machine);
    }

    // POST: Machines/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var machine = await _context.Machines
            .FindAsync(id);

        if (machine == null)
        {
            return NotFound();
        }

        // Soft delete is safer for factory data.
        machine.IsActive = false;
        machine.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Success"] = "Machine deactivated successfully.";

        return RedirectToAction(nameof(Index));
    }

    private bool MachineExists(long id)
    {
        return _context.Machines
            .Any(e => e.Id == id);
    }
}