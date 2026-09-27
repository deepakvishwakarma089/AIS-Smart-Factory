using AISSmartFactory.Data;
using AISSmartFactory.Models.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class DowntimeReasonsController : Controller
{
    private readonly ApplicationDbContext _context;

    public DowntimeReasonsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var reasons = await _context.DowntimeReasons
            .OrderBy(x => x.Category)
            .ThenBy(x => x.ReasonCode)
            .ToListAsync();

        return View(reasons);
    }

    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
            return NotFound();

        var reason = await _context.DowntimeReasons
            .FirstOrDefaultAsync(x => x.Id == id);

        if (reason == null)
            return NotFound();

        return View(reason);
    }

    public IActionResult Create()
    {
        return View(new DowntimeReason
        {
            IsActive = true
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DowntimeReason reason)
    {
        var exists = await _context.DowntimeReasons
            .AnyAsync(x => x.ReasonCode == reason.ReasonCode);

        if (exists)
        {
            ModelState.AddModelError(
                nameof(reason.ReasonCode),
                "Reason code already exists.");
        }

        if (!ModelState.IsValid)
            return View(reason);

        reason.CreatedAt = DateTime.UtcNow;
        reason.UpdatedAt = DateTime.UtcNow;

        _context.DowntimeReasons.Add(reason);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Downtime reason created successfully.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
            return NotFound();

        var reason = await _context.DowntimeReasons.FindAsync(id);

        if (reason == null)
            return NotFound();

        return View(reason);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        DowntimeReason reason)
    {
        if (id != reason.Id)
            return NotFound();

        var exists = await _context.DowntimeReasons
            .AnyAsync(x =>
                x.ReasonCode == reason.ReasonCode &&
                x.Id != reason.Id);

        if (exists)
        {
            ModelState.AddModelError(
                nameof(reason.ReasonCode),
                "Reason code already exists.");
        }

        if (!ModelState.IsValid)
            return View(reason);

        var existing =
            await _context.DowntimeReasons.FindAsync(id);

        if (existing == null)
            return NotFound();

        existing.ReasonCode = reason.ReasonCode;
        existing.ReasonName = reason.ReasonName;
        existing.Category = reason.Category;
        existing.Description = reason.Description;
        existing.IsPlanned = reason.IsPlanned;
        existing.RequiresComment = reason.RequiresComment;
        existing.IsActive = reason.IsActive;
        existing.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Downtime reason updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
            return NotFound();

        var reason =
            await _context.DowntimeReasons
                .FirstOrDefaultAsync(x => x.Id == id);

        if (reason == null)
            return NotFound();

        return View(reason);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var reason =
            await _context.DowntimeReasons.FindAsync(id);

        if (reason == null)
            return NotFound();

        reason.IsActive = false;
        reason.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Downtime reason deactivated successfully.";

        return RedirectToAction(nameof(Index));
    }
}
