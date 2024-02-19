using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GashnyaLohotron;
using Gashnya.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Gashnya.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly User13Context _context;

        public UserController(User13Context context)
        {
            _context = context;
        }

        [HttpPost("AddUser")]
        public async void AddUser(UserDTO user)
        {
            _context.Add(new User
            {
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,
                UserBalance = user.UserBalance
            });
            _context.SaveChanges();
        }
        [HttpGet("GetUser")]
        public async Task<ActionResult<List<UserDTO>>> GetUser()
        {
            List<UserDTO> users = _context.Users.Include(s => s.Name).ToList().Select(s => new UserDTO
            {
                Id = s.Id,
                Name = s.Name,
                Login = s.Login,
                Password = s.Password
            }).ToList();
            return users;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> EditUser(int id, UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingUser = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
            if (existingUser == null)
            {
                return BadRequest();
            }
            existingUser.Name = userDTO.Name;
            existingUser.Password = userDTO.Password;
            existingUser.Login = userDTO.Login;
            existingUser.HistoryId = userDTO.HistoryId;
            existingUser.UserBalance = userDTO.UserBalance;

            _context.Entry(existingUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound(id);
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
