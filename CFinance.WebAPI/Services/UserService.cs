using CFinance.Context;
using CFinance.Context.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace CFinance.WebAPI.Services;

public static class UserService
{
    private static List<User> Users { get; set; }
    private static List<Portfolio> portfolios { get; set; }
    private static List< PortfolioCompany> companies { get; set; }

    private static CFinanceDbContext AppContext { get; set; }
    static UserService()
    {
        AppContext = new CFinanceDbContext();
        
        Users = AppContext.Users.ToList();
        portfolios = AppContext.Portfolios.ToList();
        companies = AppContext.PortfolioCompany.ToList();
    }

    public static List<User> GetAll() => Users;

    public static User? Get(int uid)
    {
        return Users.FirstOrDefault(u => u.UserID == uid);
    }

    public static User? Login(string username, string password)
    {
        return Users.FirstOrDefault(u => (u.UserName == username) && (u.CheckPassword(password)));
    }
    public static bool Add(User newUser)
    {
        if (Users.Any(x => (x.UserName == newUser.UserName) || (x.Email == newUser.Email)))
        {
            return false;
        }

        
        newUser.HashPassword();
        AppContext.Users.Add(newUser);
        AppContext.SaveChanges();

        return true;
    }

    public static void Delete(int uid)
    {

        var user = new User() {UserID = uid};

        AppContext.Users.Attach(user);
        AppContext.Users.Remove(user);

        AppContext.SaveChanges();
    }

    public static void Update(int uid)
    {
        var user = new User() {UserID = uid};

        AppContext.Users.Attach(user);
        AppContext.Users.Update(user);

        AppContext.SaveChanges();
    }

}

