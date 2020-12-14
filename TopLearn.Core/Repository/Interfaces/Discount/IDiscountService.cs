using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Enums;
using TopLearn.Core.Services.Interfaces.Base;

namespace TopLearn.Core.Repository.Interfaces.Discount
{
    public interface IDiscountService : IBaseService<DAL.Entities.Discount.Discount>
    {
        DiscountStatusEnum UseDiscountCode(int orderId, string discountCode);

        bool IsExistDiscountCode(string code);
    }
}
