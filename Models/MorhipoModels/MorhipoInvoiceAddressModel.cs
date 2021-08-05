using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorhipoOrderService.Models.MorhipoModel
{
    public class MorhipoInvoiceAddressModel
    {
        [Key]

        public long Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string citycode { get; set; }
        public string country { get; set; }
        public string postalcode { get; set; }
        public string taxoffice { get; set; }
        public string taxnumber { get; set; }
    }
}
