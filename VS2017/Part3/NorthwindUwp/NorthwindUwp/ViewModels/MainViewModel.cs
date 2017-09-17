using NorthwindUwp.Helpers;
using NorthwindUwp.Services;
using Packt.CS7;
using System.Collections.ObjectModel;

namespace NorthwindUwp.ViewModels
{
    public class MainViewModel : Observable
    {
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return NorthwindDataService.GetCustomers();
            }
        }
    }
}
