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
        public int Id { get; set; }

        private string _name = "ÜRÜN";
        public string Name
        {
            get => $"{_name}{Id}";
            set => _name = value;   
        }

        public string PhotoURL { get; set; } = "https://cdn.secilstore.com/docs/images/product/half/10002411510019/0312/1.webp?x=gomzx";

        public decimal Price { get; set; } = new Random().Next(500,5000);
    }
}
