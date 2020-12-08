using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Services.Interfaces.Base;

namespace TopLearn.Core.Repository.Interfaces.Order
{
    public interface IOrderService : IBaseService<DAL.Entities.Order.Order>
    {
        int AddOrder(string userName, int courseId);

        double UpdateSumOrder(int orderId);

        DAL.Entities.Order.Order GetOrderUserPanel(int orderId, string userName);

        List<DAL.Entities.Order.Order> GetAllOrdersByUserName(string userName);

        bool FinallyOrder(int orderId , string userName);

    }
}
