using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;


namespace CFinance.Context.Models
{
    public abstract class DbEntity
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Table("users")]
    public class User : DbEntity
    {
        [Column("user_id")][Key] public int UserID { get; set; }
        [Column("username")] public string UserName { get; set; }
        [Column("password")] public string Password { get; set; }
        [Column("email")] public string Email { get; set; }

        public bool CheckPassword(int attemptPassword)
        {
            return (attemptPassword == Password.GetHashCode());
        }
    }

    [Table("company")]
    public class Company : DbEntity
    {
        [Column("ticker")][Key] public string Ticker { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("description")] public string Description { get; set; }
        [Column("country")] public string Country { get; set; }
        [Column("address")] public string Address { get; set; }
        [Column("industry_id")] public int IndusrtyID { get; set; }
        [Column("sector_id")] public int SectorID { get; set; }

        public Cashflows Cashflow { get; set; }
        public Metrics Metrics { get; set; }
        public IncomeStatement IncomeStatement { get; set; }
        public BalanceSheet BalanceSheet { get; set; }



    }

    [Table("cash_flows")]
    public class Cashflows : DbEntity
    {
        [Key][Column("ticker")] public string Ticker { get; set; }
        [Column("currency_id")] public int CurrencyID { get; set; }
        [Column("operating_flow",TypeName="money")] public decimal? OperatingFlow { get; set; }
        [Column("financing_flow", TypeName = "money")] public decimal? FinancingFlow { get; set; }
        [Column("investment_flow", TypeName = "money")] public decimal? InvestmentFlow { get; set; }
        [Column("cashflow_delta", TypeName = "money")] public decimal? CashFlowDelta { get; set; }

        [JsonIgnore] public Company Company { get; set; }

    }

    [Table("metrics")]
    public class Metrics : DbEntity
    {
        [Key][Column("ticker")] public string? Ticker { get; set; }
        [Column("pe")] public double? pe { get; set; }
        [Column("dps")] public double? dps { get; set; }
        [Column("dividend_yield", TypeName = "money")] public decimal? dividend_yield { get; set; }
        [Column("eps")] public double? eps { get; set; }
        [Column("rps")] public double? rps { get; set; }
        [Column("roe")] public double? roe { get; set; }
        [Column("beta")] public double? beta { get; set; }
        [Column("evr")] public double? evr { get; set; }
        [Column("roa")] public double? roa { get; set; }

        [JsonIgnore] public Company Company { get; set; }
    }

    [Table("income_statement")]
    public class IncomeStatement : DbEntity
    {
        [Key][Column("ticker")] public string Ticker { get; set; }
        [Column("ebitda", TypeName = "money")] public decimal? EBITDA { get; set; }
        [Column("ebit", TypeName = "money")] public decimal? EBIT { get; set; }
        [Column("ebt", TypeName = "money")] public decimal? EBT { get; set; }
        [Column("net_earnings", TypeName = "money")] public decimal? NetEarnings { get; set; }

        [JsonIgnore] public Company Company;
    }

    [Table("balance_sheet")]
    public class BalanceSheet : DbEntity
    {
        [Key][Column("ticker")] public string Ticker { get; set; }
        [Column("current_liabilities", TypeName = "money")] public decimal? CurrentLiabilities { get; set; }
        [Column("longterm_liabilities", TypeName = "money")] public decimal? LongtermLiabilities { get; set; }
        [Column("current_assets", TypeName = "money")] public decimal? CurrentAssets { get; set; }
        [Column("longterm_assets", TypeName = "money")] public decimal? LongtermAssets { get; set; }
        [Column("invested_capital", TypeName = "money")] public decimal? InvestedCapital { get; set; }
        [Column("retained_earnings", TypeName = "money")] public decimal? RetainedEarnings { get; set; }

        [JsonIgnore] public Company Company { get; set; }
    }
}
