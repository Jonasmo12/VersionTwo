using System.Diagnostics;
using System.Collections;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using VersionTwo.Models;
using VersionTwo.Data;

namespace VersionTwo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CallBackContext _vlog;

    public HomeController(
        ILogger<HomeController> logger, 
        CallBackContext context)
    {
        _logger = logger;
        _vlog = context;
    }
    

    public IActionResult Index()
    {
        List<Vlog> vlogs = _vlog.Vlogs.ToList();
        return View(vlogs);
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
