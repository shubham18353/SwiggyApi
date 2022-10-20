using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiggyApi.Models.Data;
using SwiggyApi.Models.RegisterAndLogin;

namespace SwiggyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly SwiggyDbContext _db;

        public AuthorizationController(SwiggyDbContext db)
        {
            _db = db;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationRequest r)
        {
            try
            {
                Register register = new Register();
                register.FirstName = r.FirstName;
                register.LastName = r.LastName;
                register.Username = r.Username;
                register.Password = r.Password;
                register.ConfirmPassword = r.ConfirmPassword;
                register.EmailAddress = r.EmailAddress;
                await _db.registers.AddAsync(register);
                await _db.SaveChangesAsync();
                return Ok(register);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            try
            {
                Login logs = new Login();
                var log = _db.registers.FindAsync(login.Username, login.Password).Result;

                if (log != null)
                {
                    logs.Username = login.Username;
                    logs.Password = login.Password;
                    logs.RememberMe = login.RememberMe;
                    await _db.Logins.AddAsync(logs);
                    await _db.SaveChangesAsync();
                    return Ok(log);
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
