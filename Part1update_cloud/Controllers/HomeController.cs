using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Part1update_cloud.Data;
using Part1update_cloud.Models;

namespace Part1update_cloud.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbcontext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbcontext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    // GET: Home/Search
    [HttpGet]
    public async Task<IActionResult> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            ViewBag.Message = "Please enter a Booking ID or Event Name.";
            return View("SearchResults", new List<Booking>());
        }

        var bookings = await _context.Bookings
            .Where(b => b.BookingId.ToString().Contains(query) ||
                        _context.Events.Any(e => e.EventId == b.EventId && e.EventName.Contains(query)))
            .ToListAsync();

        return View("SearchResults", bookings);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}