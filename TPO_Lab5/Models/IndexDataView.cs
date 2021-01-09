using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TPO_Lab1;

namespace TPO_Lab5.Models
{
    public class IndexDataView
    {
        public IReadOnlyDictionary<string, Product> Products { get; set; }
        public int PriceBuy { get; set; }
    }
}
