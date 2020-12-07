using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Repository.Interfaces.Order;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Order;

namespace TopLearn.Core.Repository.Services.Order
{
    public class OrderDetailService : BaseService<OrderDetail>, IOrderDetailService
    {
        private readonly TopLearnContext _context;
        public OrderDetailService(TopLearnContext context) : base(context)
        {
            _context = context;
        }
    }
}
