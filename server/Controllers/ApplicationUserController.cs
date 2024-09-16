using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;

    public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
	{
		if (dto == null)
			return BadRequest("Invalid client request");

		var user = new ApplicationUser { UserName = dto.Email, Email = dto.Email };
		var result = await _userManager.CreateAsync(user, dto.Password);
		if (result.Succeeded)
		{
			await _signInManager.SignInAsync(user, isPersistent: false);
			return Ok(new { message = "Registration successful" });
		}

		return BadRequest(result.Errors);
	}

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        if (dto == null)
            return BadRequest("Invalid client request");

        var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.RememberMe, lockoutOnFailure: false);
        if (result.Succeeded)
            return Ok(new { message = "Login successful" });

        return Unauthorized(new { message = "Invalid login attempt" });
    }

	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		await _signInManager.SignOutAsync();
		return Ok(new { message = "Logout successful" });
	}
}
