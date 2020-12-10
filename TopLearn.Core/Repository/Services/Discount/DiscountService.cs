using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Enums;
using TopLearn.Core.Repository.Interfaces.Discount;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Discount;

namespace TopLearn.Core.Repository.Services.Discount
{
    public class DiscountService : BaseService<DAL.Entities.Discount.Discount>, IDiscountService
    {
        private readonly TopLearnContext _context;
        public DiscountService(TopLearnContext context) : base(context)
        {
            _context = context;
        }


        public DiscountStatusEnum UseDiscountCode(int orderId, string discountCode)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);

            var discount = _context.Discounts.FirstOrDefault(d => d.DiscountCode == discountCode);

            if (discount == null)
            {
                return DiscountStatusEnum.InvalidCode;
            }

            if (discount.EndDate != null && DateTime.Now > discount.EndDate)
            {
                return DiscountStatusEnum.ExpireCode;
            }

            if (discount.StartDate != null && DateTime.Now < discount.StartDate)
            {
                return DiscountStatusEnum.InValidDate;
            }

            if (discount.UsableCount != null && discount.UsableCount < 1)
            {
                return DiscountStatusEnum.FinishUsableDiscount;
            }

            if (_context.UserDiscounts.Any(ud => ud.DiscountId == discount.DiscountId && ud.UserId == order.UserId))
            {
                return DiscountStatusEnum.UsedInOrder;
            }

            if (discount.UsableCount > 0)
            {
                discount.UsableCount -= 1;
            }

            var discountPercent = order.SumOrder * discount.DiscountPercent / 100;

            order.SumOrder = order.SumOrder - discountPercent;

            _context.UserDiscounts.Add(new UserDiscount()
            {
                DiscountId = discount.DiscountId,
                UserId = order.UserId

            });

            _context.Orders.Update(order);
            _context.SaveChanges();


            return DiscountStatusEnum.Success;

        }
    }
}
