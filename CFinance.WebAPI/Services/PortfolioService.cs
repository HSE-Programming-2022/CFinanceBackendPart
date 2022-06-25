using CFinance.Context;
using CFinance.Context.Models;
using CFinance.WebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CFinance.WebAPI.Services
{
    public class PortfolioService
    {
        public static List<Portfolio> GetPorfolioForUser(int uid)
        {
            using (CFinanceDbContext appContext = new CFinanceDbContext())
            {
                List<PortfolioCompany> companies = appContext.PortfolioCompany.ToList();
                List<Portfolio> userPortfolios = appContext.Portfolios.Where(x => x.UserID == uid).ToList();

                return userPortfolios;
            }
        }

        public static int CreatePortfolioForUser(int uid)
        {
            using (CFinanceDbContext appContext = new CFinanceDbContext())
            {
                Portfolio newPortfolio = new Portfolio()
                {
                    UserID = uid
                };

                appContext.Portfolios.Add(newPortfolio);

                appContext.SaveChanges();

                return newPortfolio.PortfolioID;
            }
        }

        public static bool AddPositionToPortfolio(string Ticker, int PortfolioID)
        {
            using (CFinanceDbContext appContext = new CFinanceDbContext())
            {
                var newPosition = new PortfolioCompany()
                {
                    PortfolioID = PortfolioID,
                    Ticker = Ticker
                };

                appContext.PortfolioCompany.Add(newPosition);

                appContext.SaveChanges();
            }

            return true;
        }

        public static void DeletePositionFromPortfolio(string Ticker, int PortfolioID)
        {
            using (CFinanceDbContext appContext = new CFinanceDbContext())
            {
                var newPosition = new PortfolioCompany()
                {
                    PortfolioID = PortfolioID,
                    Ticker = Ticker
                };

                appContext.PortfolioCompany.Remove(newPosition);

                appContext.SaveChanges();
            }
        }
    }
}
