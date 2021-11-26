using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webshopgaragemanager.Models;

namespace webshopgaragemanager.Infrastructure
{
    public class CmsShoppingCartContext : DbContext
    {
        //DTO står för = DataTransfer object
        public CmsShoppingCartContext(DbContextOptions<CmsShoppingCartContext>options)
            :base(options)
        {

        }
        public DbSet<Page> Pages { get; set; }

    }
}
