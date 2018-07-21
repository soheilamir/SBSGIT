using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface IOrdersMethod
    {
        IList<Orders> GetOrdersByUserId(long userId);
        Orders AddOrder(Orders orderToSave);
    }
}
