using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumery.viewModels
{
    public class PerfumeDto
    {
        public int Id { get; set; }
        [Display(Name ="عنوان")]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        public double Price { get; set; }
    }
}
