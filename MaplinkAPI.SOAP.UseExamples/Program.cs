using System;
using System.Linq;
using MaplinkAPI.SOAP.UseExamples.ServiceAddressFinder;

namespace MaplinkAPI.SOAP.UseExamples
{
    class Program
    {
        static void Main()
        {
            var addressFinder = new AddressFinder();
            
            var findAddressResponse = addressFinder.GetFindAddressResponse();
            ShowFindAddressResponse(findAddressResponse);

            Console.ReadLine();
        }

        private static void ShowFindAddressResponse(AddressInfo findAddressResponse)
        {
            Console.WriteLine("----- AddressFinder - FindAddress -----");
            Console.WriteLine("Page Count: {0}, Record Count: {1}", 
                findAddressResponse.pageCount, findAddressResponse.recordCount);

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