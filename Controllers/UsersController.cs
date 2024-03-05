using Microsoft.AspNetCore.Mvc;
using Tracker.Data;
using Tracker.DTO;
using Tracker.Models;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly NautinitTrackerContext _context;

        public UsersController(NautinitTrackerContext context)
        {
            _context = context;

        }

        // GET: api/<UsersController>
        [HttpGet]
        public List<UserDTO> Get()
        {
            var users = new List<User>();
            var usersDTO = new List<UserDTO>();
            users = _context.Users.ToList();
            foreach (var user in users)
            {
                usersDTO.Add(new UserDTO
                {
                    Uid = user.Uid,
                    Custno = user.Custno,
                    Name = user.Name,
                    Regdate = user.Regdate,
                    Status = user.Status
                });
            }
            return usersDTO;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            var user = new User();
            var userDTO = new UserDTO();
            user = _context.Users.FirstOrDefault(x=>x.Uid == id);
            if (user != null)
            {
                userDTO.Uid = user.Uid;
                userDTO.Custno = user.Custno;
                userDTO.Name = user.Name;
                userDTO.Regdate = user.Regdate;
                userDTO.Status = user.Status;
            }
            return userDTO;
            
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
