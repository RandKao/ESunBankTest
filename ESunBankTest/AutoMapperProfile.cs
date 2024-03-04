using AutoMapper;
using ESunBankTest.Models.SystemDB;
using ESunBankTest.ViewModels.Connections;
using System.Globalization;

namespace ESunBankTest
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region GovData13223

            CreateMap<vm_Data13223, GovData13223>()
                .ForMember(x => x.Date, y => y.MapFrom(s => DateOnly.FromDateTime(DateTime.ParseExact(s.Date, "yyyy-MM", CultureInfo.InvariantCulture))))

                .ForMember(x => x.TransToFinancial, y => y.MapFrom(s => s.TransToFinancial))
                .ForMember(x => x.StocksAndBenefit, y => y.MapFrom(s => s.StocksAndBenefit))
                .ForMember(x => x.Futures, y => y.MapFrom(s => s.Futures))
                .ForMember(x => x.Bonds, y => y.MapFrom(s => s.Bonds))
                .ForMember(x => x.Securitized, y => y.MapFrom(s => s.Securitized))
                .ForMember(x => x.ShortTerm, y => y.MapFrom(s => s.ShortTerm))
                .ForMember(x => x.ForeignInvestment, y => y.MapFrom(s => s.ForeignInvestment))
                .ForMember(x => x.EntrustedDomestic, y => y.MapFrom(s => s.EntrustedDomestic))
                .ForMember(x => x.EntrustedOverseas, y => y.MapFrom(s => s.EntrustedOverseas))
                .ForMember(x => x.RealEstate, y => y.MapFrom(s => s.RealEstate))
                .ForMember(x => x.GovLoansEconomic, y => y.MapFrom(s => s.GovLoansEconomic))
                .ForMember(x => x.GovLoansAgriculture, y => y.MapFrom(s => s.GovLoansAgriculture))
                .ForMember(x => x.InsuredLoans, y => y.MapFrom(s => s.InsuredLoans))
                .ReverseMap();

            #endregion

        }
    }
}
