using System;
using System.Linq;

namespace App.Support.Common
{
    public class DiscountCodeHelper
    {
        public static string RandomString(int length = 5)
        {
            var random = new Random();
            var strings = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(strings, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
        public static string ReplaceDash(string code)
        {
            return code.Replace("-", "");
        }
    }
}