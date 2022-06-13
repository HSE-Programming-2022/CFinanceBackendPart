using Microsoft.AspNetCore.Mvc;
using CFinance.Context.Models;
using CFinance.WebAPI.Services;
using Microsoft.OpenApi.Any;

namespace CFinance.WebAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    public UserController()
    {
    }

    [HttpGet]
    [ActionName("GetAllUsers")]
    public ActionResult<List<User>> GetAll() => UserService.GetAll();

    [HttpGet("{uid}")]
    [ActionName("GetUser")]
    public ActionResult<User> Get(int uid)
    {
        var user = UserService.Get(uid);

        if (user == null)
            return NotFound();

        return user;
    }

    [HttpGet]
    [ActionName("Login")]
    public IActionResult Login(User user)
    {
        if (UserService.Login(user))
            return Ok();

        return BadRequest();
    }

    [HttpPost]
    public IActionResult Register(User new_user)
    {
        if (UserService.Add(new_user))
        {
            return Ok();
        }

        return BadRequest();
    }

    [HttpDelete("{uid}")]
    public IActionResult Delete(int uid)
    {
        var user = UserService.Get(uid);

        if (user is null)
            return NotFound();

        UserService.Delete(uid);

        return NoContent();
    }

    [HttpPut("{uid}")]
    public IActionResult Update(int uid, User user)
    {
        if (uid != user.UserID)
            return BadRequest();

        var existingUser = UserService.Get(uid);
        if (existingUser is null)
            return NotFound();

        UserService.Update(uid);

        return NoContent();
    }
}

