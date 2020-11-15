using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.DAL.Entities
{
    public class RoleUser
    {
        public RoleUser()
        {
         
        }

        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }


        #region Navigation Properties

        public  virtual Role Role { get; set; }
        public virtual User User { get; set; }


        #endregion

    }
}
