using AutoMapper;
using CFinance.Context.Models;

namespace CFinance.WebAPI.Models
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {

            CreateMap<Company, CompanyResponse>();

            CreateMap<BalanceSheet, BalanceSheetResponse>();
            CreateMap<IncomeStatement, IncomeStatementResponse>();
            CreateMap<Cashflows, CashflowsResponse>();
            CreateMap<Metrics, MetricsResponse>();

        }
    }

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }

    public class PortfolioMappingProfile : Profile
    {
        public PortfolioMappingProfile()
        {
            CreateMap<Portfolio, PortfolioResponse>();
            CreateMap<PortfolioCompany, PortfolioCompanyResponse>();
        }
    }
}
