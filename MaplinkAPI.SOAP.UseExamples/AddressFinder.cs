using MaplinkAPI.SOAP.UseExamples.ServiceAddressFinder;
using System;
using System.Configuration;
using System.Linq;

namespace MaplinkAPI.SOAP.UseExamples
{
    public class AddressFinder
    {
        private string _token;

        public AddressFinder()
        {
            _token = new Token().Value;
        }

        public void FindAddress()
        {
            var address = new Address
            {
                street = "Avenida Paulista",
                houseNumber = "1000",
                city = new City { name = "São Paulo", state = "SP" }
            };

            var addressOptions = new AddressOptions
            {
                usePhonetic = true,
                searchType = 2,
                resultRange = new ResultRange { pageIndex = 1, recordsPerPage = 10 }
            };

            using (var addressFinderSoapClient = new AddressFinderSoapClient())
            {
                var findAddressResponse = addressFinderSoapClient.findAddress(address, addressOptions, _token);

                Console.WriteLine("----- AddressFinder - FindAddress -----");
                Console.WriteLine("Page Count: {0}, Record Count: {1}", findAddressResponse.pageCount, findAddressResponse.recordCount);

                findAddressResponse.addressLocation
                    .ToList()
                    .ForEach(addressLocation =>
                            Console.WriteLine
                            (
                                "Key: {0}, " +
                                "Street name: {1}, Street number: {2}, Zip code: {3}, District: {4}, " +
                                "City: {5}, State: {6}, " +
                                "Left zip code: {7}, Right zip code: {8}, Car access: {9}, " +
                                "Data Source: {10}, Latitude: {11}, Longitude: {12}",
                                addressLocation.key,
                                addressLocation.address.street, addressLocation.address.houseNumber,
                                addressLocation.address.zip, addressLocation.address.district,
                                addressLocation.address.city.name,
                                addressLocation.address.city.state,
                                addressLocation.zipL, addressLocation.zipR,
                                addressLocation.carAccess, addressLocation.dataSource,
                                addressLocation.point.y, addressLocation.point.x
                            ));
            }
        }
    }
}
