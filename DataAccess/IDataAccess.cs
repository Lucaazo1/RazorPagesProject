using DTOLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshopgaragemanager.DataAccess
{
    public interface IDataAccess
    {
        public IEnumerable<ItemDTO> GetAllitems();
        public IEnumerable<CustomerDTO> GetAllCustomers();
        public IEnumerable<ChosenCustomerItemDTO> GetAllChosenCustomerItemnames();
    }
}
