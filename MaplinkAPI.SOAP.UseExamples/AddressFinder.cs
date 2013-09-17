using MaplinkAPI.SOAP.UseExamples.ServiceAddressFinder;

namespace MaplinkAPI.SOAP.UseExamples
{
    public class AddressFinder
    {
        private readonly string _token;

        public AddressFinder()
        {
            _token = Token.Value;
        }

        public AddressInfo GetFindAddressResponse()
        {
            var address = GetAddress();
            var addressOptions = GetAddressOptions();

            using (var addressFinderSoapClient = new AddressFinderSoapClient())
            {
                var findAddressResponse = addressFinderSoapClient.findAddress(address, addressOptions, _token);
                return findAddressResponse;
            }
        }

        private Address GetAddress()
        {
            var address = new Address
            {
                street = "Avenida Paulista",
                houseNumber = "1000",
                city = new City {name = "São Paulo", state = "SP"}
            };
            return address;
        }

        private AddressOptions GetAddressOptions()
        {
            var addressOptions = new AddressOptions
            {
                usePhonetic = true,
                searchType = 2,
                resultRange = new ResultRange {pageIndex = 1, recordsPerPage = 10}
            };

            return addressOptions;
        }
    }
}
