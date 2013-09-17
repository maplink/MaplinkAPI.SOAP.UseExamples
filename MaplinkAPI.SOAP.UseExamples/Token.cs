using System.Configuration;

namespace MaplinkAPI.SOAP.UseExamples
{
    public static class Token
    {
        private static string _token;

        public static string Value
        {
            get
            {
                if (!string.IsNullOrEmpty(_token)) 
                    return _token;

                const string tokenNotFound = "TokenNotFound";
                _token = ConfigurationManager.AppSettings["token"] ?? tokenNotFound;

                return _token;
            }
        }
    }
}
