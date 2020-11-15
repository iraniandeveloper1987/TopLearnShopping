using System.Collections.Generic;

namespace TopLearn.Core.DTOs.Admin.User
{
    public class UsersForAdminViewModel
    {

        public List<DAL.Entities.User> Users { get; set; }

        public int NumberPage { get; set; }

        public int StepsForShow { get; set; }

    }
}
