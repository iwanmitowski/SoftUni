using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StockMarket
{
    public class Investor
    {
        private readonly HashSet<Stock> portfolio;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.portfolio = new HashSet<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => this.portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && stock.PricePerShare <= this.MoneyToInvest)
            {
                this.MoneyToInvest -= stock.PricePerShare;
                this.portfolio.Add(stock);
            }

        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var stock = FindStock(companyName);

            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (stock.PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }

            MoneyToInvest += sellPrice;
            this.portfolio.Remove(stock);

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return this.portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return this.portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var stock in portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
