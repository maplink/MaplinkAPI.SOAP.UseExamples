using System;

namespace MaplinkAPI.SOAP.UseExamples
{
    class Program
    {
        static void Main()
        {
            var addressFinder = new AddressFinder();
            addressFinder.FindAddress();
            Console.ReadLine();
        }
    }
}