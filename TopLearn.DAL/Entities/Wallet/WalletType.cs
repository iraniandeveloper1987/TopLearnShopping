using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopLearn.DAL.Entities
{
    public class WalletType
    {
        public WalletType()
        {
            Wallets = new List<Wallet>();
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WalletTypeId { get; set; }


        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Title { get; set; }


        [Display(Name = "شرح")]
       [MaxLength(500, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Description { get; set; }




        #region Navigation Properties

        public virtual List<Wallet> Wallets { get; set; }

        #endregion



    }
}
