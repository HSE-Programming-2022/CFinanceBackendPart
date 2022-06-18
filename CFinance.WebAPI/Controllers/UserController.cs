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
    public ActionResult<User> Login(string username, string password)
    {
        var loggedUser = UserService.Login(username, password);

        if (loggedUser == null)
            return BadRequest();

        return loggedUser;
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
}

