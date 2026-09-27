using AISSmartFactory.Data;
using AISSmartFactory.Models.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AISSmartFactory.Controllers;

public class OperatorsController : Controller
{
    private readonly ApplicationDbContext _context;

    public OperatorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Operators
    public async Task<IActionResult> Index()
    {
        var operators = await _context.Operators
            .OrderBy(x => x.EmployeeCode)
            .ToListAsync();

        return View(operators);
    }

    // GET: Operators/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var operatorData = await _context.Operators
            .FirstOrDefaultAsync(x => x.Id == id);

        if (operatorData == null)
        {
            return NotFound();
        }

        return View(operatorData);
    }

    // GET: Operators/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Operators/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Operator operatorData)
    {
        bool employeeExists = await _context.Operators
            .AnyAsync(x =>
                x.EmployeeCode == operatorData.EmployeeCode);

        if (employeeExists)
        {
            ModelState.AddModelError(
                nameof(operatorData.EmployeeCode),
                "Employee code already exists.");
        }

        if (ModelState.IsValid)
        {
            operatorData.CreatedAt = DateTime.UtcNow;
            operatorData.UpdatedAt = DateTime.UtcNow;
            operatorData.IsActive = true;

            _context.Operators.Add(operatorData);

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Operator created successfully.";

            return RedirectToAction(nameof(Index));
        }

        return View(operatorData);
    }

    // GET: Operators/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var operatorData = await _context.Operators
            .FindAsync(id);

        if (operatorData == null)
        {
            return NotFound();
        }

        return View(operatorData);
    }

    // POST: Operators/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        Operator operatorData)
    {
        if (id != operatorData.Id)
        {
            return NotFound();
        }

        bool employeeExists = await _context.Operators
            .AnyAsync(x =>
                x.EmployeeCode == operatorData.EmployeeCode &&
                x.Id != operatorData.Id);

        if (employeeExists)
        {
            ModelState.AddModelError(
                nameof(operatorData.EmployeeCode),
                "Employee code already exists.");
        }

        if (!ModelState.IsValid)
        {
            return View(operatorData);
        }

        try
        {
            var existingOperator = await _context.Operators
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingOperator == null)
            {
                return NotFound();
            }

            existingOperator.EmployeeCode =
                operatorData.EmployeeCode;

            existingOperator.EmployeeName =
                operatorData.EmployeeName;

            existingOperator.Department =
                operatorData.Department;

            existingOperator.Designation =
                operatorData.Designation;

            existingOperator.Shift =
                operatorData.Shift;

            existingOperator.ContactNumber =
                operatorData.ContactNumber;

            existingOperator.IsActive =
                operatorData.IsActive;

            existingOperator.UpdatedAt =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Operator updated successfully.";

            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OperatorExists(operatorData.Id))
            {
                return NotFound();
            }

            throw;
        }
    }

    // GET: Operators/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var operatorData = await _context.Operators
            .FirstOrDefaultAsync(x => x.Id == id);

        if (operatorData == null)
        {
            return NotFound();
        }

        return View(operatorData);
    }

    // POST: Operators/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var operatorData = await _context.Operators
            .FindAsync(id);

        if (operatorData == null)
        {
            return NotFound();
        }

        // Soft delete.
        // Historical production records remain untouched.
        operatorData.IsActive = false;
        operatorData.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Success"] =
            "Operator deactivated successfully.";

        return RedirectToAction(nameof(Index));
    }

    private bool OperatorExists(long id)
    {
        return _context.Operators
            .Any(x => x.Id == id);
    }
}