using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorhipoOrderService.Models.MorhipoContext
{
    public class MorhipoShipmentAddress
    {
        [Key]

        public Int64 ID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string citycode { get; set; }
        public string country { get; set; }
        public string postalcode { get; set; }
        public string phoneNumber { get; set; }



    }
}
