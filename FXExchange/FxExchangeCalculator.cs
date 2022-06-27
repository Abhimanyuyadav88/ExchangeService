using FXExchange.Helper;
using FXExchange.Interfaces;
using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXExchange
{
    public class FxExchangeCalculator : IFxExchangeCalculator
    {
        static Dictionary<string, RateExchangeModel> exchangeRate;      

        public decimal ProcessExchange(string sourceCurrency, string targetCurrency, double quantity, Dictionary<string, RateExchangeModel> exchangeRequest)
        {
            return (decimal)((exchangeRate[sourceCurrency].Amount / exchangeRate[targetCurrency].Amount) * quantity);
        }

        Dictionary<string, RateExchangeModel> IFxExchangeCalculator.GetExchangeRate()
        {
            exchangeRate = RateExchange.GetExchangeRate();
            return exchangeRate;
        }

        
    }
}
