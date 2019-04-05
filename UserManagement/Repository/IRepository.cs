using System.Collections.Generic;
using UserManagement.Model;

namespace UserManagement.Repository
{
    public interface IRepository<T> where T : class
    {
        int Create(T t);


        //  bool Update(T t);
        IEnumerable<OrderDetails> Get();
    }

    public interface IUpdateUsersRepository
    {
        bool UpdateOrderName(string currentname, string newname);
        bool UpdateQuantity(int orderid,int newquantity);
    }

    public interface IUpdateDeleteRepository
    {
        bool Deletebyorderno(int orderno);
       
    }


}
