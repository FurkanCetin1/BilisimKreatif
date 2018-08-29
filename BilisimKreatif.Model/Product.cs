using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BilisimKreatif.Model
{
    public class Product:BaseEntity
    {
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
    }
}
