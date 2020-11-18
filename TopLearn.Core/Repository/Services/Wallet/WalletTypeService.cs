using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Repository.Interfaces.Wallet;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Repository.Services
{
    public class WalletTypeService : BaseService<WalletType>, IWalletTypeService
    {

        public WalletTypeService(TopLearnContext context) : base(context)
        {
        }
    }
}
