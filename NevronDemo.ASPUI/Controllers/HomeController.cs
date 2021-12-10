using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NevronDemo.Application.Numbers.Commands.AddNumber;
using NevronDemo.Application.Numbers.Commands.DeleteNumber;
using NevronDemo.Application.Numbers.Queries.GetNumbersList;
using NevronDemo.Application.Numbers.Queries.GetNumbersSum;
using NevronDemo.ASPUI.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NevronDemo.ASPUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> AddNumber()
        {
            await Mediator.Send(new AddNumberCommand());
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> NumbersList()
        {
            var numbers = await Mediator.Send(new GetNumberListQuery());
            return PartialView( "_NumbersList",numbers);
        }
        
        [HttpGet]
        public async Task<IActionResult> NumbersSum()
        {
            var sum = await Mediator.Send(new GetNumbersSumQuery());
            return PartialView("_NumbersSum", sum);
        }

        [HttpPost]
        public async Task<IActionResult> ClearNumbers()
        {
            await Mediator.Send(new DeleteNumberCommand());
            return Json(new { success = true });
        }

    }
}
