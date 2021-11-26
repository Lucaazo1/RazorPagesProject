using DTOLibrary;
using Newtonsoft.Json;
using System;
using DataSourceLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshopgaragemanager.DataAccess
{
    public class DataAccessItems : IDataAccess
    {
        private readonly DataSource _dataSource;

        public DataAccessItems(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<ItemDTO> GetAllitems()
        {
            string jsonRes = _dataSource.ItemData();
            return JsonConvert.DeserializeObject<IEnumerable<ItemDTO>>(jsonRes);
        }
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            string jsonRes = _dataSource.CustomerData();
            return JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(jsonRes);
        }
        public IEnumerable<ChosenCustomerItemDTO> GetAllChosenCustomerItemnames()
        {
            string jsonRes = _dataSource.ChosenCustomerItemData();
            return JsonConvert.DeserializeObject<IEnumerable<ChosenCustomerItemDTO>>(jsonRes);
        }
    }
}
