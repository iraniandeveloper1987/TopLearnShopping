using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.Repository.Interfaces.Order;
using TopLearn.Core.Repository.Interfaces.User;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Order;

namespace TopLearn.Core.Repository.Services.Order
{
    public class OrderService : BaseService<DAL.Entities.Order.Order>, IOrderService
    {
        private readonly TopLearnContext _context;
        private readonly IUserService _userService;

        public OrderService(TopLearnContext context, IUserService userService) : base(context)
        {
            _context = context;
            _userService = userService;
        }

        public int AddOrder(string userName, int courseId)
        {
            var userId = _userService.GetUserIdByUserName(userName);

            var course = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);

            var order = _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.UserId == userId && !o.IsFinally);

            //  Dont Exist Open Order
            if (order == null)
            {
                order = new DAL.Entities.Order.Order()
                {
                    UserId = userId,
                    IsFinally = false,
                    CreateDate = DateTime.Now,
                    SumOrder = course.CoursePrice,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                            Count = 1,
                            Price = course.CoursePrice,
                            CourseId = course.CourseId

                        }
                    }

                };

                _context.Orders.Add(order);
            }
            //  Exist Order Open
            else
            {
                var orderDetail = _context.OrderDetails
                    .FirstOrDefault(od => od.OrderId == order.OrderId && od.CourseId == course.CourseId);

                //   Exist  Order with Same Course
                if (orderDetail != null)
                {
                    orderDetail.Count++;
                    _context.OrderDetails.Update(orderDetail);
                }
                //   Exist  Order with New Course
                else
                {
                    orderDetail = new OrderDetail()
                    {
                        CourseId = course.CourseId,
                        OrderId = order.OrderId,
                        Count = 1,
                        Price = course.CoursePrice,
                    };
                    _context.OrderDetails.Add(orderDetail);
                }
            }


            _context.SaveChanges();
            UpdateSumOrder(order.OrderId);


            return order.OrderId;

        }

        public double UpdateSumOrder(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            order.SumOrder = _context.OrderDetails.Where(od => od.OrderId == orderId).Sum(od => od.Price * od.Count);
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order.SumOrder;
        }

        public DAL.Entities.Order.Order GetOrderUserPanel(int orderId, string userName)
        {
            var userId = _userService.GetUserIdByUserName(userName);
            return _context.Orders.Include(o => o.OrderDetails)
                .ThenInclude(od => od.Course)
                .FirstOrDefault(o => o.UserId == userId && o.OrderId == orderId);
        }


    }
}
