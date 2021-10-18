using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Models;
using URLShortenerBLL.Interface;

namespace URLShortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IURLManager _URLManager;
        public HomeController(ILogger<HomeController> logger, IURLManager URLManager)
        {
            _logger = logger;
            _URLManager = URLManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string longURL)
        {
            var shortUrl = await _URLManager.AddNewURL(longURL);
            ViewBag.ShortUrl = shortUrl;

            return View();
        }

        [HttpGet("{url:length(7)}")]
        public async Task<IActionResult> Index(string url)
        {
            var longURL = await _URLManager.GetByShortURL(url);
            return Redirect(longURL);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
