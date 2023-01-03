using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HavaYoluMVC.Models
{
    public class MVCPilotmodel
    {
        public int PilotNo { get; set; }
        [Required(ErrorMessage = "Sirket Adi girilmesi zorunludur")]//boş gecilemez demek
        public string PilotAdi { get; set; }
        public int PilotYas { get; set; }
        public int? PilotTecrube { get; set; } //int yanındaki soru işareti boş gecilebilir anlamında

        public int? UcakNo { get; set; }

    }
}