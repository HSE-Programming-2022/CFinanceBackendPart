using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CFinance.Context.Models;
using CFinance.WebAPI.Models;
using CFinance.WebAPI.Services;
using Microsoft.OpenApi.Any;

namespace CFinance.WebAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private IMapper _mapper;
    public UserController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    [ActionName("GetAllUsers")]
    public ActionResult<List<User>> GetAll() => UserService.GetAll();

    [HttpGet("{uid}")]
    [ActionName("GetUser")]
    public ActionResult<UserResponse> Get(int uid)
    {
        var user = UserService.Get(uid);

        if (user == null)
            return NotFound();

        UserResponse userResponse = _mapper.Map<UserResponse>(user);

        return userResponse;
    }

    [HttpGet]
    [ActionName("Login")]
    public ActionResult<UserResponse> Login(string username, string password)
    {
        var loggedUser = UserService.Login(username, password);

        if (loggedUser == null)
            return BadRequest();

        UserResponse userResponse = _mapper.Map<UserResponse>(loggedUser);

        return userResponse;
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

    [HttpPut]
    public IActionResult Subscribe(int UserId)
    {
        try
        {
            UserService.Subscribe(UserId);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}

