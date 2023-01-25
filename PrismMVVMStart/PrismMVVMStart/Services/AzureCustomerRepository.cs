using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMVVMStart.Services
{
    internal class AzureCustomerRepository : ICustomerRepository
    {
        public AzureCustomerRepository(IRegionManager r)
        {

        }

        public Task<IEnumerable<string>> GetAllCustomers()
        {
            throw new NotImplementedException("Cloud not ready.");
        }
    }
}
