using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendingEmail.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SendingEmail.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IMailService _mailservices;

    public HomeController(ILogger<HomeController> logger, IMailService mailservices)
    {
      _logger = logger;
      _mailservices = mailservices;
    }

    public IActionResult Index()
    {
      return View();
    }
    public IActionResult SendEmailCustom()
    {
      _mailservices.SendEmailCustom();
      return RedirectToAction("Index");
 
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
}
