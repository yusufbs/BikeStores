using LP_Authentication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LP_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateNewUser")]
        public IActionResult Post([FromBody] User user)
        {
            var userExistsWithEmail = _context.Users.SingleOrDefault(x => x.EmailId == user.EmailId);
            if (userExistsWithEmail == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Created("User registered successful", user);
            }
            else
            {
                return StatusCode(500, "Email already exists");
            }

        }

        [HttpPost("Login")]
        public IActionResult Login(UserLogin obj)
        {
            var user = _context.Users.SingleOrDefault(x => x.EmailId == obj.EmailId && x.Password == obj.Password);
            if (user == null)
            {
                return StatusCode(401, "Wrong Credentials");
            }
            else 
            {
                return StatusCode(200, user);
            }
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers() 
        { 
            var list  = _context.Users.ToList();
            return Ok(list);
        }
    }
}
