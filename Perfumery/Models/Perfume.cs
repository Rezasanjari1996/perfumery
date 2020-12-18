using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumery.Models
{
    public class Perfume
    {
        [Key]
        public int Id { get; set; }
       [Display(Name ="نام")] 
        public string Name { get; set; }
        [Display(Name = "عکس")]
        public string Image { get; set; }
        [Display(Name = "توضیحات")]
        public  string Description { get; set; }
        [Display(Name = "قیمت")]
        public double Price { get; set; }
    }
}
