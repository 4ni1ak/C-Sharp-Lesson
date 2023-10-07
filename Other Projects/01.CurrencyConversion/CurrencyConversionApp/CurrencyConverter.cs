using System;
using System.Net;
using System.Xml;

namespace CurrencyConversionApp
{
    public class CurrencyConverter
    {
        private XmlDocument exchangeRateData;

        public CurrencyConverter(string exchangeRateDataUrl)
        {
            using (WebClient client = new WebClient())
            {
                string xmlData = client.DownloadString(exchangeRateDataUrl);
                exchangeRateData = new XmlDocument();
                exchangeRateData.LoadXml(xmlData);
            }
        }

        public void ShowAvailableCurrencies()
        {
            XmlNodeList currencyNodes = exchangeRateData.SelectNodes("/Tarih_Date/Currency");
            Console.WriteLine("Available Currencies:");
            foreach (XmlNode currencyNode in currencyNodes)
            {
                string kod = currencyNode.Attributes["Kod"].Value;
                string isim = currencyNode.SelectSingleNode("Isim").InnerText;
                Console.WriteLine($"{kod} - {isim}");
            }
        }

        public double ConvertCurrency(double amount, string sourceCurrency, string targetCurrency)
        {
            sourceCurrency = sourceCurrency.ToUpper();
            targetCurrency = targetCurrency.ToUpper();

            XmlNode sourceCurrencyNode = exchangeRateData.SelectSingleNode($"/Tarih_Date/Currency[@Kod='{sourceCurrency}']");
            XmlNode targetCurrencyNode = exchangeRateData.SelectSingleNode($"/Tarih_Date/Currency[@Kod='{targetCurrency}']");

            if (sourceCurrencyNode != null && targetCurrencyNode != null)
            {
                double sourceExchangeRate = double.Parse(sourceCurrencyNode.SelectSingleNode("ForexBuying").InnerText);
                double targetExchangeRate = double.Parse(targetCurrencyNode.SelectSingleNode("ForexSelling").InnerText);

                double result = (amount * sourceExchangeRate) / targetExchangeRate;
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid currency codes.");
            }
        }
    }
}
