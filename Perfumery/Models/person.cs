using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumery.Models
{
    public class person
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="لطفا نام را وارد کنید")]
        [Display(Name ="نام")]
        public string name { get; set; }
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string family { get; set; }
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string userName { get; set; }
        [Required(ErrorMessage = "لطفا پسورد را وارد کنید را وارد کنید")]
        [Display(Name = "پسورد")]
       [MinLength(8,ErrorMessage="حداقل 8 کارکتر وارد کنید")]
        public string password { get; set; }
    }
}
