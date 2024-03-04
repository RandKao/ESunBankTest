CREATE TABLE [dbo].[GovData13223]
(
	[Date] DATE NOT NULL PRIMARY KEY, 
    [TransToFinancial] DECIMAL NOT NULL, 
    [StocksAndBenefit] DECIMAL NOT NULL, 
    [Futures] DECIMAL NOT NULL, 
    [Bonds] DECIMAL NOT NULL, 
    [Securitized] DECIMAL NOT NULL, 
    [ShortTerm] DECIMAL NOT NULL, 
    [ForeignInvestment] DECIMAL NOT NULL, 
    [EntrustedDomestic] DECIMAL NOT NULL, 
    [EntrustedOverseas] DECIMAL NOT NULL, 
    [RealEstate] DECIMAL NOT NULL, 
    [GovLoansEconomic] DECIMAL NOT NULL, 
    [GovLoansAgriculture] DECIMAL NOT NULL, 
    [InsuredLoans] DECIMAL NOT NULL
)
