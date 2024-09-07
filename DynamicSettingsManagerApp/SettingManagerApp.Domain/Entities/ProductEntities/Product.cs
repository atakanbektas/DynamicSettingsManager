using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Domain.Entities.ProductEntities
{
    // TEST AMAÇLI OLDUĞUNDAN DEFAULT DEĞERLER ATANDI.
    public class Product
    {
        static int counter = 1;

        public Product()
        {
            counter++; 
        }

        public int Id { get; set; }

        public string Name { get; set; } = "ÜRÜN - " + counter;

        public string PhotoURL { get; set; } = "https://cdn.secilstore.com/docs/images/product/half/10002411510019/0312/1.webp?x=gomzx";

        public decimal Price { get; set; } = new Random().Next(500,5000);
    }
}
