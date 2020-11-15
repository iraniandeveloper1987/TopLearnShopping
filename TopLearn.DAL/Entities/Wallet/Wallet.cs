using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.DAL.Entities
{
    public class Wallet
    {
        public Wallet()
        {


        }
        [Key]
        public int WalletId { get; set; }

        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [Display(Name = "نوع تراکنش")]
        public int WalletTypeId { get; set; }


        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [Display(Name = "کاربر")]
        public int UserId { get; set; }


        [Display(Name = "شرح")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }

        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [Display(Name = "تاریخ ثبت")]
        public DateTime RegisterDate { get; set; }

        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [Display(Name = "مبلغ")]
        public int Amount { get; set; }


        [Display(Name = "وضعیت پرداخت")]
        public bool IsPay { get; set; }


        #region Navigation properties

        public virtual WalletType WalletType { get; set; }

        public virtual User User { get; set; }

        #endregion



    }
}
