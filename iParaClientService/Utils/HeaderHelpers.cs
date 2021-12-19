using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace iParaClientService.Utils
{
    public static class AmountHelpers
    {
        public static int SetAmount(this double value)
        {
            return (int)(value * 100);
        }

        public static double GetAmount(this int value)
        {
            return value / (double)100;
        }

        public static double GetAmount(this int? value)
        {
            if (!value.HasValue)
            {
                return 0;
            }

            return GetAmount(value.Value);
        }
    }
    public static class HeaderHelpers
    {
        public static string GetTransactionDateString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string CreateToken(string publicKey, string hashString)
        {
            HashAlgorithm algorithm = new SHA1Managed();
            var hashbytes = Encoding.UTF8.GetBytes(hashString);
            var inputbytes = algorithm.ComputeHash(hashbytes);
            //  var aftersha1= System.Text.Encoding.UTF8.GetString(inputbytes);
            var inputHashString = Convert.ToBase64String(inputbytes);
            return publicKey + ":" + inputHashString;
        }

        ///// <summary>
        ///// Verilen string'i SHA1 ile hashleyip Base64 formatına çeviren fonksiyondur. 
        ///// CreateToken'dan farklı olarak token oluşturmaz sadece hash hesaplar
        ///// </summary>
        ///// <param name="hashString"></param>
        ///// <returns></returns>
        //public static string ComputeHash(string hashString)
        //{
        //    HashAlgorithm algorithm = new SHA1Managed();
        //    var hashbytes = Encoding.UTF8.GetBytes(hashString);
        //    var inputbytes = algorithm.ComputeHash(hashbytes);
        //    var inputHashString = Convert.ToBase64String(inputbytes);
        //    return inputHashString;
        //}
    }

    public static class HashStringBuilderHelpers
    {
        public static string GetHashString(params string[] parameters)
        {
            string hashString = "";

            foreach (var parameter in parameters)
            {
                hashString += parameter;
            }

            return hashString;
        }
    }
}