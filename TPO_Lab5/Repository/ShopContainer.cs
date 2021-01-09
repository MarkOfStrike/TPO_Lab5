using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TPO_Lab1;

namespace TPO_Lab5.Repository
{
    public class ShopContainer
    {
        private readonly Shop _shop;
        public Shop GetShop => _shop;
        public string ErrorMessage { get; set; }

        public ShopContainer()
        {
            _shop = new Shop();
        }
    }
}
