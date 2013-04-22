using System.Configuration;

namespace MaplinkAPI.SOAP.UseExamples
{
    public class Token
    {
        private string _token;

        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(_token))
                {
                    var tokenNotFound = "TokenNotFound";
                    _token = ConfigurationManager.AppSettings["token"] ?? tokenNotFound;
                }

                return _token;
            }
        }
    }
}
