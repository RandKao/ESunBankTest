using Newtonsoft.Json;

namespace ESunBankTest.ViewModels.Connections
{
    public class vm_Data13223
    {
        [JsonProperty("月別")]
        public string Date { get; set; }

        [JsonProperty("轉存金融機構（金額）")]
        public decimal TransToFinancial { get; set; }
        [JsonProperty("股票及受益憑證（金額）")]
        public decimal StocksAndBenefit { get; set; }
        [JsonProperty("期貨（金額）")]
        public decimal Futures { get; set; }
        [JsonProperty("公債_金融債券_公司債（金額）")]
        public decimal Bonds { get; set; }
        [JsonProperty("證券化商品（金額）")]
        public decimal Securitized { get; set; }
        [JsonProperty("短期票券（金額）")]
        public decimal ShortTerm { get; set; }
        [JsonProperty("國外投資-自行運用（金額）")]
        public decimal ForeignInvestment { get; set; }
        [JsonProperty("委託經營-國內（金額）")]
        public decimal EntrustedDomestic { get; set; }
        [JsonProperty("委託經營-國外（金額）")]
        public decimal EntrustedOverseas { get; set; }
        [JsonProperty("房屋及土地（金額）")]
        public decimal RealEstate { get; set; }
        [JsonProperty("政府或公營事業貸款-經建貸款（金額）")]
        public decimal GovLoansEconomic { get; set; }
        [JsonProperty("政府或公營事業貸款-農保借款（金額）")]
        public decimal GovLoansAgriculture { get; set; }
        [JsonProperty("被保險人貸款（金額）")]
        public decimal InsuredLoans { get; set; }

    }
}
