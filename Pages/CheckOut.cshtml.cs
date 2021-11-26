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
    public class CheckOutModel : PageModel
    {
        private readonly IDataAccess _dataAccess;
        
        public CheckOutModel(IDataAccess dataAccess)
        {
            summa = 0;
            foreach (var cartitem in shoppingCartModel.ShoppingCartItem)
            {
                summa += cartitem.price;
            }
        }
        
        public static int summa;

    }
}
