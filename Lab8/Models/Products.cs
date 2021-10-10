using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Products
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}