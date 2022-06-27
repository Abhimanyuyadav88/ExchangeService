﻿using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXExchange.Interfaces
{
    public interface IFxExchangeCalculator
    {
        Dictionary<string, RateExchangeModel> GetExchangeRate();

        decimal ProcessExchange(string sourceCurrency, string targetCurrency, double quantity, Dictionary<string, RateExchangeModel> exchangeRate);
    }
}
