using AutoMapper;
using CFinance.Context;
using CFinance.Context.Models;
using CFinance.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace CFinance.WebAPI.Services
{
    public class CompanyService
    {
        private static List<Company> Companies { get; set; }
        private static List<Cashflows> Cashflows { get; set; }
        private static List<Metrics> Metrics { get; set; }
        private static List<BalanceSheet> BalanceSheets { get; set; }
        private static List<IncomeStatement> IncomeStatements { get; set; }

        private static CFinanceDbContext AppContext { get; set; }

        static CompanyService()
        {
            AppContext = new CFinanceDbContext();

            Companies = AppContext.Companies.ToList();
            Cashflows = AppContext.Cashflows.ToList();
            IncomeStatements = AppContext.IncomeStatements.ToList();
            BalanceSheets = AppContext.BalanceSheets.ToList();

            Metrics = AppContext.Metrics.ToList();
        }

        public static Company? Get(string ticker)
        {
            return Companies.FirstOrDefault(x => x.Ticker == ticker);
        }

        public static List<Company> GetAll() => Companies;

    }
}
