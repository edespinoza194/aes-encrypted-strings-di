using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracker.DTO;
using Tracker.Models;
using Tracker.Utils;

namespace Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        [HttpGet("{text}")]
        public string Get(string text)
        {
           var result = string.Empty;
           result = AESService.Encrypt(text);
           return result;

        }
    }
}
