using CFinance.Context;
using CFinance.Context.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace CFinance.WebAPI.Services;

public static class UserService
{
    private static List<User> Users { get; set; }

    static UserService()
    {
    }

    public static List<User> GetAll()
    {
        using (CFinanceDbContext appContext = new CFinanceDbContext())
        {
            return appContext.Users.ToList();
        }
    }

    public static User? Get(int uid)
    {
        using (CFinanceDbContext appContext = new CFinanceDbContext())
        {
            var Portfolios = appContext.Portfolios.ToList();
            var PTC = appContext.PortfolioCompany.ToList();

            Users = appContext.Users.ToList();
            return Users.FirstOrDefault(u => u.UserID == uid);
        }
    }

    public static User? Login(string username, string password)
    {
        using (CFinanceDbContext appContext = new CFinanceDbContext())
        {
            var Portfolios = appContext.Portfolios.ToList();
            var PTC = appContext.PortfolioCompany.ToList();

            Users = appContext.Users.ToList();
            return Users.FirstOrDefault(u => (u.UserName == username) && (u.CheckPassword(password)));
        }
    }
    public static bool Add(User newUser)
    {
        using (CFinanceDbContext appContext = new CFinanceDbContext())
        {
            Users = appContext.Users.ToList();

            if (Users.Any(x => (x.UserName == newUser.UserName) || (x.Email == newUser.Email)))
            {
                return false;
            }


            newUser.HashPassword();
            appContext.Users.Add(newUser);
            appContext.SaveChanges();
        }

        return true;
    }

    public static void Delete(int uid)
    {
        using (CFinanceDbContext appContext = new CFinanceDbContext())
        {
            var user = new User() { UserID = uid };

            appContext.Users.Attach(user);
            appContext.Users.Remove(user);

            appContext.SaveChanges();
        }
    }

    public static void Update(int uid)
    {
        using (CFinanceDbContext appContext = new CFinanceDbContext())
        {
            var user = new User() { UserID = uid };

            appContext.Users.Attach(user);
            appContext.Users.Update(user);

            appContext.SaveChanges();
        }
    }

    public static void Subscribe(int uid)
    {
        using (CFinanceDbContext appContext = new CFinanceDbContext())
        {
            var user = appContext.Users.FirstOrDefault(x => x.UserID == uid);

            if (user != null)
            {
                user.SubscriptionStatus = true;
                
                appContext.SaveChanges();
            }
        }
    }

}

