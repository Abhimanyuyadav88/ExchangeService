using FXExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FXExchange.Models;
using System.Threading.Tasks;
using FXExchange.Interfaces;

namespace FXExchange
{
    public class ProcessExchange : IProcessExchange
    {
        private readonly IFxExchangeCalculator fxExchangeCalculator;

        private readonly IFxExchangeValidator fxExchangeValidator;
        public ProcessExchange(IFxExchangeCalculator fxExchangeCalculatorService, IFxExchangeValidator fxExchangeValidatorService)
        {
            fxExchangeValidator = fxExchangeValidatorService;
            fxExchangeCalculator = fxExchangeCalculatorService;
        }

        public decimal ProcessExchangeRequest(string input, ErrorList errorMessages)
        {
            Dictionary<string, RateExchangeModel> exchangeRate = fxExchangeCalculator.GetExchangeRate();

            ExchangeRequest exchangeRequest = fxExchangeValidator.ValidateRequest(input, exchangeRate, errorMessages);

            if (!string.IsNullOrWhiteSpace(errorMessages.ErrorMessage))
            return -1;

            return fxExchangeCalculator.ProcessExchange(exchangeRequest.SourceCurrency, exchangeRequest.TargetCurrency, exchangeRequest.InputQuantity, exchangeRate);

        }


    }
}
