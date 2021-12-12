using System;

namespace iParaClientService.Utils
{
    public static class HeaderHelpers
    {
        public static string GetTransactionDateString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }

    public static class HashStringBuilderHelpers
    {
        public static string GetHashString(params string[] parameters)
        {
            string hashString = String.Empty;

            foreach (var parameter in parameters)
            {
                hashString += parameter;
            }

            return hashString;
        }
    }
}