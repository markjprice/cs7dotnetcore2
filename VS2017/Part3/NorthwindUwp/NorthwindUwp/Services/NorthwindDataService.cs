using Packt.CS7;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace NorthwindUwp.Services
{
    public static class NorthwindDataService
    {
        private static async Task<IEnumerable<Customer>> AllCustomers()
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("http://localhost:5001/");

                var serializer = new DataContractJsonSerializer(typeof(List<Customer>));

                var stream = await http.GetStreamAsync("api/customers");

                var customers = serializer.ReadObject(stream) as List<Customer>;

                return customers;
            }
        }

        public static ObservableCollection<Customer> GetCustomers()
        {
            return new ObservableCollection<Customer>(AllCustomers().Result);
        }
    }
}
