using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class RandomStringGenerator
    {
        static Random random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 11)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
    public class BarcodeResult
    {
        public string Barcode { get; set; }
        public string Error { get; set; }
        public string Url { get; set; }
    }
}