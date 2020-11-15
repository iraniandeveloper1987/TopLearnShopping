using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.Core.DTOs.UserPanel
{
    public class SideBarUserPanelViewModel
    {
        [Display(Name = "تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "نام ونام خانوادگی")]
        public string FullName { get; set; }


        [Display(Name = "آواتار")]
        public string ImageName { get; set; }
    }
}
