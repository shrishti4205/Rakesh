using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.Model;

namespace UserManagement.DataBase
{
    public static class ListOfOrders
    {
        public static List<OrderDetails> Orders;
        static ListOfOrders()
        {
             Orders= new List<OrderDetails>();
        }

    }
}