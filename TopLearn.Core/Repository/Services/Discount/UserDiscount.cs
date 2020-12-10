using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Repository.Interfaces.Discount;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Discount;

namespace TopLearn.Core.Repository.Services.Discount
{
    public class UserDiscountService : BaseService<UserDiscount>, IUserDiscountService
    {
        private readonly TopLearnContext _context;
        public UserDiscountService(TopLearnContext context) : base(context)
        {
            _context = context;
        }
    }
}
