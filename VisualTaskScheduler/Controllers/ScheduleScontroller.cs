using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VisualTaskScheduler.Data;

namespace VisualTaskScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schedules = await _context.Schedules
                .Include(s => s.Employee)
                .Include(s => s.Task)
                .Include(s => s.Shift)
                .ToListAsync();
            return View(schedules);
        }

        public IActionResult Create()
        {
            // Logic to display the form for creating a new task
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
}