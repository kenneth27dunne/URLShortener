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
        private IURLManager _URLManager;

        public URLController(IURLManager uRLManager)
        {
            _URLManager = uRLManager;
        }

        [HttpGet("GetByShortURL/{shortUrl}")]
        public async Task<IActionResult> GetByShortURL(string shortUrl)
        {
            try
            {
                return Ok(await _URLManager.GetByShortURL(shortUrl));
            }
            catch (Exception ex)
            {
                // log exception
                return BadRequest();
            }
        }

        [HttpPost("Generate/ShortURL")]
        public async Task<IActionResult> AddNewURL(string longUrl)
        {
            try
            {
                return Ok(await _URLManager.AddNewURL(longUrl));
            }
            catch (Exception ex)
            {
                // log exception
                return BadRequest();
            }
        }
    }
}
