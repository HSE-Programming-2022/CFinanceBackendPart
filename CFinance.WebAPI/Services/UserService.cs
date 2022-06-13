using CFinance.Context;
using CFinance.Context.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace CFinance.WebAPI.Services;

public static class UserService
{
    private static List<User> Users { get; set; }
    private static CFinanceDbContext AppContext { get; set; }
    static UserService()
    {
        AppContext = new CFinanceDbContext();
        
        Users = AppContext.Users.ToList();
    }

    public static List<User> GetAll() => Users;

    public static User Get(int uid)
    {
        return Users.FirstOrDefault(u => u.UserID == uid);
    }

    public static bool Login(User user)
    {
        return (Users.Any(u => (u.UserName == user.UserName) && (u.CheckPassword(user.Password.GetHashCode()))));
    }
    public static bool Add(User newUser)
    {
        if (Users.Any(x => (x.UserName == newUser.UserName) || (x.Email == newUser.Email)))
        {
            return false;
        }

        AppContext.Users.Add(newUser);
        AppContext.SaveChanges();

        return true;
    }

    public static void Delete(int uid)
    {

        User user = new User() {UserID = uid};

        AppContext.Users.Attach(user);
        AppContext.Users.Remove(user);

        AppContext.SaveChanges();
    }

    public static void Update(int uid)
    {
        User user = new User() {UserID = uid};

        AppContext.Users.Attach(user);
        AppContext.Users.Update(user);

        AppContext.SaveChanges();
    }

}

