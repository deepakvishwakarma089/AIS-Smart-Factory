using AISSmartFactory.Data;
using AISSmartFactory.Models.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class ToolsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ToolsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Tools
    public async Task<IActionResult> Index()
    {
        var tools = await _context.Tools
            .OrderBy(x => x.ToolCode)
            .ToListAsync();

        return View(tools);
    }

    // GET: Tools/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
            return NotFound();

        var tool = await _context.Tools
            .FirstOrDefaultAsync(x => x.Id == id);

        if (tool == null)
            return NotFound();

        return View(tool);
    }

    // GET: Tools/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Tools/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Tool tool)
    {
        var exists = await _context.Tools
            .AnyAsync(x => x.ToolCode == tool.ToolCode);

        if (exists)
        {
            ModelState.AddModelError(
                nameof(tool.ToolCode),
                "Tool code already exists.");
        }

        if (!ModelState.IsValid)
            return View(tool);

        tool.CreatedAt = DateTime.UtcNow;
        tool.UpdatedAt = DateTime.UtcNow;
        tool.IsActive = true;

        _context.Tools.Add(tool);

        await _context.SaveChangesAsync();

        TempData["Success"] = "Tool created successfully.";

        return RedirectToAction(nameof(Index));
    }

    // GET: Tools/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
            return NotFound();

        var tool = await _context.Tools.FindAsync(id);

        if (tool == null)
            return NotFound();

        return View(tool);
    }

    // POST: Tools/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        Tool tool)
    {
        if (id != tool.Id)
            return NotFound();

        var exists = await _context.Tools
            .AnyAsync(x =>
                x.ToolCode == tool.ToolCode &&
                x.Id != tool.Id);

        if (exists)
        {
            ModelState.AddModelError(
                nameof(tool.ToolCode),
                "Tool code already exists.");
        }

        if (!ModelState.IsValid)
            return View(tool);

        var existingTool = await _context.Tools
            .FirstOrDefaultAsync(x => x.Id == id);

        if (existingTool == null)
            return NotFound();

        existingTool.ToolCode = tool.ToolCode;
        existingTool.ToolName = tool.ToolName;
        existingTool.ToolType = tool.ToolType;
        existingTool.ToolNumber = tool.ToolNumber;
        existingTool.Manufacturer = tool.Manufacturer;
        existingTool.Specification = tool.Specification;
        existingTool.Diameter = tool.Diameter;
        existingTool.Length = tool.Length;
        existingTool.MaximumRpm = tool.MaximumRpm;
        existingTool.ExpectedLife = tool.ExpectedLife;
        existingTool.CurrentLife = tool.CurrentLife;
        existingTool.LifeUnit = tool.LifeUnit;
        existingTool.IsActive = tool.IsActive;
        existingTool.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Success"] = "Tool updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    // GET: Tools/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
            return NotFound();

        var tool = await _context.Tools
            .FirstOrDefaultAsync(x => x.Id == id);

        if (tool == null)
            return NotFound();

        return View(tool);
    }

    // POST: Tools/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var tool = await _context.Tools.FindAsync(id);

        if (tool == null)
            return NotFound();

        // Soft delete
        tool.IsActive = false;
        tool.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Success"] = "Tool deactivated successfully.";

        return RedirectToAction(nameof(Index));
    }
}