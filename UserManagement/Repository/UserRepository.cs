using System;
using System.Collections.Generic;
using System.Configuration;
using UserManagement.Model;
using UserManagement.DataBase;
using System.Linq;

namespace UserManagement.Repository
{
    enum userCreateStatus { UserCreationFailed, PasswordCreationFailed, RoleCreationFailed, Sucessful, Failure };
    public class UserRepository : IRepository<OrderDetails>, IUpdateUsersRepository,IUpdateDeleteRepository
        //<UserModel, MembershipModel, RoleModel, UserInRoleModel>
    { 
        string connectionString = ConfigurationManager.ConnectionStrings["SqlConString"].ConnectionString;

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger("UserManagementLogger");


        /// <summary>
        ///  Method to create user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public int Create(OrderDetails orderdetails)
        { 
            try
            {
                ListOfOrders.Orders.Add(orderdetails);
              
                return (int)userCreateStatus.Sucessful;
            }

            catch (Exception e)
            {
               
                _log.Info("New element in orders table not created"+e);
                return (int)userCreateStatus.Failure;
            }
            
        }
     
    public bool UpdateOrderName(string currentUsername, string newOrdername)
    {
           
           ListOfOrders.Orders.Where(x => x.OrderName.Contains(currentUsername)).First().OrderName=newOrdername;
          
           return true;
    }



        public bool UpdateQuantity(int orderid, int newquantity)
        {
            ListOfOrders.Orders.Where(x => x.OrderNo==orderid).First().Quantity = newquantity;
            return true;
        }


    
        public bool Deletebyorderno(int orderno)
        {
            ListOfOrders.Orders.RemoveAll(r => r.OrderNo == orderno);
            return true;
        }

        public IEnumerable<OrderDetails> Get()
        {
            return ListOfOrders.Orders;
        }

        
    }
}