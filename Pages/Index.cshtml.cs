using DTOLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webshopgaragemanager.DataAccess;

namespace webshopgaragemanager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDataAccess _dataAccess;
        public IndexModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            Item = (List<ItemDTO>)_dataAccess.GetAllitems();
        }
        public List<ItemDTO> Item { get; set; }     
        public static string SearchTerm = "";
        public static int HighestTerm = 0;
        public void OnGet()
        {
        }
        public void OnPost()
        {
        }
        public void OnPostAddItem()
        {
            var item_url = Request.Form["item_url"];
            var item_name = Request.Form["item_name"];
            var item_price = Request.Form["item_price"];
            var item_itemid = Request.Form["item_itemid"];
            var MyObj = new ItemDTO();
            MyObj.imgUrl = item_url;
            MyObj.name = item_name;
            MyObj.price = Convert.ToInt32(item_price);
            MyObj.itemid = Convert.ToInt32(item_itemid);
            
            shoppingCartModel.ShoppingCartItem.Add(MyObj);
            var MyObjTotalPrice = new ShoppingCartDTO();
            MyObjTotalPrice.CheckOutPrice += MyObj.price;
            MyObjTotalPrice.CheckOutPriceTotal = MyObjTotalPrice.CheckOutPrice;
        }

        public void OnPostSearchItem()
        {
            SearchTerm = Request.Form["fname"];
        }

        public void OnPostHighest()
        {
            HighestTerm = Convert.ToInt32(Request.Form["Highest"]);
        }
        
        [BindProperty]
        public string SortTerm { get; set; }
        public IActionResult OnPostSort()
        {
            OnGet();
            switch (SortTerm)
            {
                case "Name":
                    Item = Item.OrderBy(o => o.name).ToList();
                    break;

                case "LPrice":
                    Item = Item.OrderBy(o => o.price).ToList();
                    break;

                case "HPrice":
                    Item = Item.OrderByDescending(o => o.price).ToList();
                    break;
            }
            return Page();
        }
    }
}
