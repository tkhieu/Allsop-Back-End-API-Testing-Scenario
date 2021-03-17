using System;
using System.Text.Json.Serialization;

namespace Service.API.Promotion.ViewModels
{
    public class DiscountValidationRequestViewModel
    {
        public string Rule { get; set; }
        public string Operator { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
    }
}