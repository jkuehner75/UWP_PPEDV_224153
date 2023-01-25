using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace PrismMVVMStart.Services
{
    internal interface ICustomerRepository
    {
        Task<IEnumerable<string>> GetAllCustomers();
    }
}
