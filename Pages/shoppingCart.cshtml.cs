using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webshopgaragemanager.DataAccess;

namespace webshopgaragemanager.Pages
{
    public class shoppingCartModel : PageModel
    {
        private readonly IDataAccess _dataAccess;
        public shoppingCartModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            Customer = (List<CustomerDTO>)_dataAccess.GetAllCustomers();
            CustomerNameAndAddress = (List<ChosenCustomerItemDTO>)_dataAccess.GetAllChosenCustomerItemnames();
        }
        public static List<ItemDTO> ShoppingCartItem = new List<ItemDTO>();
        public static List<CustomerDTO> Customer { get; set; }
        public static List<ChosenCustomerItemDTO> CustomerNameAndAddress { get; set; }

        public static bool IsPaid;

        public static int Key;

        public IActionResult OnPost()
        {
            Key = Convert.ToInt32(Request.Form["item_name1"]);
            IsPaid = true;
            return RedirectToPage("./CheckOut");
        }
    }
}
