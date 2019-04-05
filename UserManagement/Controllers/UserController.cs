using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManagement.Model;
using UserManagement.Repository;
using UserManagement.Filters;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace UserManagement.Controllers
{
    [RoutePrefix("api/User")]
    [Logger]
    public class UserController : ApiController
    {
        IRepository<OrderDetails> _userRepository;
        IUpdateDeleteRepository _deleteRepository;
        IUpdateUsersRepository _updateRepository;


        public UserController(IRepository<OrderDetails> userRepository, 
            IUpdateUsersRepository updateUserRepository,
            IUpdateDeleteRepository deleteUserRepository)
        {
            _userRepository = userRepository;
            _updateRepository = updateUserRepository;
            _deleteRepository = deleteUserRepository;

        }
        [HttpGet]
        public IEnumerable<OrderDetails> Get()
        {
           return _userRepository.Get();
        }
       
        [HttpPost]
      
        public IHttpActionResult NewUser([FromBody]OrderDetails orderdetails)
        {
            try
            {
                var creationStatus = _userRepository.Create(orderdetails);

                if (creationStatus == 0)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "User creation failed"));
                    // return ResponseMessage(Request.CreateResponse(HttpStatusCode.Created, rm.GetString("creationSuccessful")));

                }

                else if(creationStatus == 1)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Password creation failed."));
                   
                }

                else if(creationStatus==2)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Role creation failed."));
                }

                else
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.Created, "User created successfully."));
                }
            }
            catch(Exception ex)
            {
                throw ex;
           
            }

        }



        
        [HttpPut]
        [Route("UpdateOrderName")]
        public IHttpActionResult UpdateOrderName(string currentOrdername, [FromBody]string newOrdername)
        {
           
            
                bool updateUsernameStatus = _updateRepository.UpdateOrderName(currentOrdername, newOrdername);

                if (updateUsernameStatus)
                {
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, "Username updated."));
                }
                else
                {
                    if(String.IsNullOrEmpty(currentOrdername) || String.IsNullOrEmpty(newOrdername))
                    {
                        var exceptionMessage = new ArgumentNullException("Existing or New username cannot be null.");
                        return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, exceptionMessage));
                    }

                    else
                    {
                        return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Username updation failed. Username does not exist."));
                    }
                 }
           
        }

        [HttpPut]
        [Route("UpdateOrderId")]
        public IHttpActionResult UpdateOrderId(int orderid, int newquantity)
        {
            bool updateUserRoleStatus = _updateRepository.UpdateQuantity(orderid, newquantity);

            //how do we pass a variable value in the create respone method
            //like <User025> role has been updated successully to <HR>
            //if (updateuserrolestatus)
            //{
            //    return responsemessage(request.createresponse(httpstatuscode.ok, "user role updated."));
            //}
            //else
            //{
            //    if (string.isnullorempty(currentusername) || string.isnullorempty(currentrole) || string.isnullorempty(newrole))
            //    {
            //        var exceptionmessage = new argumentnullexception("entered value cannot be null.");
            //        return responsemessage(request.createresponse(httpstatuscode.badrequest, exceptionmessage));
            //    }

            //    else
            //    {
            //        return responsemessage(request.createresponse(httpstatuscode.internalservererror, "user role updation failed. please retry."));
            //    }
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Username updation failed. Username does not exist."));

        }


        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult Delete([FromBody]int orderno)
        {
            bool deleteUserStatus = _deleteRepository.Deletebyorderno(orderno);
           

            if(deleteUserStatus)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, "Requested user " + orderno + " has been deleted."));
            }

            else
            { 
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Requested user " + orderno + " is not found."));
            }

        }

     
    }
}
