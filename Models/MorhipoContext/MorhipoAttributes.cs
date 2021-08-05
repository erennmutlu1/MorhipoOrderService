using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorhipoOrderService.Models.MorhipoContext
{
    public class MorhipoAttributes
    {
        [Key]
        public Int64 ID { get; set; }
        public string name { get; set; }
        public string  value { get; set; }

    }
}
