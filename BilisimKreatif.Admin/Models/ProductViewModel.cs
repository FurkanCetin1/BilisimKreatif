using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BilisimKreatif.Admin.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
    }
}
