using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HavaYoluMVC.Models
{
    public class MVCUcakmodel
    {
        public int UcakNo { get; set; }
        [Required(ErrorMessage = "Sirket Adi girilmesi zorunludur")]//boş gecilemez demek
        public string UcakAdi { get; set; }
        public string UcakTipi { get; set; }
        public int? SirketNo { get; set; } //int yanındaki soru işareti boş gecilebilir anlamında

    }
}