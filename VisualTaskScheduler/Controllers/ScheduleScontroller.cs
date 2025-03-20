using Microsoft.AspNetCore.Mvc;

public class ScheduleController : Controller
{
    private readonly ApplicationDbContext _context;

    public ScheduleController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Schedule
    public async Task<IActionResult> Index()
    {
        var schedules = await _context.schedules
            .Include(s => s.Employee)
            .Include(s => s.Task)
            .Include(s => s.Shift)
            .ToListAsync();
        return View(schedules);
    }

    public IActionResult Create()
    {
        //Logic to display the form for creating a new task
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Schedule schedule)
    {
        if (ModelState.IsValid)
        {
            _context.Add(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(schedule);
    }
}