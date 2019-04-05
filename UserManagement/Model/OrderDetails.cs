using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Model
{
    public class OrderDetails
    {
        public int OrderNo { get; set; }

        public string OrderName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

    }
}