namespace CFinance.WebAPI.Models
{
    public class CompanyResponse
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public int IndusrtyID { get; set; }
        public int SectorID { get; set; }

        public CashflowsResponse Cashflow { get; set; }
        public MetricsResponse Metrics { get; set; }
        public IncomeStatementResponse IncomeStatement { get; set; }
        public BalanceSheetResponse BalanceSheet { get; set; }
    }

    public class BalanceSheetResponse
    {
        public decimal? CurrentLiabilities { get; set; }
        public decimal? LongtermLiabilities { get; set; }
        public decimal? CurrentAssets { get; set; }
        public decimal? LongtermAssets { get; set; }
        public decimal? InvestedCapital { get; set; }
        public decimal? RetainedEarnings { get; set; }
    }

    public class CashflowsResponse
    {
        public int CurrencyID { get; set; }
        public decimal? OperatingFlow { get; set; }
        public decimal? FinancingFlow { get; set; }
        public decimal? InvestmentFlow { get; set; }
        public decimal? CashFlowDelta { get; set; }
    }

    public class MetricsResponse
    {
        public double? pe { get; set; }
        public double? dps { get; set; }
        public decimal? dividend_yield { get; set; }
        public double? eps { get; set; }
        public double? rps { get; set; }
        public double? roe { get; set; }
        public double? beta { get; set; }
        public double? evr { get; set; }
        public double? roa { get; set; }
    }

    public class IncomeStatementResponse
    {
        public decimal? EBITDA { get; set; }
        public decimal? EBIT { get; set; }
        public decimal? EBT { get; set; }
        public decimal? NetEarnings { get; set; }
    }

    public class UserResponse
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
