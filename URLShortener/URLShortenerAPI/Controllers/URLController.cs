using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortenerBLL.Interface;

namespace URLShortener.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class URLController : Controller
    {
        private IURLManager _uRLManager;

        public URLController(IURLManager uRLManager)
        {
            _uRLManager = uRLManager;
        }

        [HttpGet("GetByShortURL/{shortUrl}")]
        public async Task<IActionResult> GetByShortURL(string shortUrl)
        {
            return Ok(await _uRLManager.GetByShortURL(shortUrl));
        }
    }
}
