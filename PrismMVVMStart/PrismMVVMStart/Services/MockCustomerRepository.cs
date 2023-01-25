using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMVVMStart.Services
{
    internal class MockCustomerRepository : ICustomerRepository
    {
        public async Task<IEnumerable<string>> GetAllCustomers()
        {
            var l = new List<string>();
            for(int i = 0; i < 1000; i++) 
            { 
                l.Add(i.ToString());
            }
            return l;
        }
    }
}
