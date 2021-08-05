using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorhipoOrderService.Models.MorhipoContext
{
    public class MorhipoContent
    {
        [Key]
        public long ID { get; set; }
        public string itemId { get; set; }

        public ulong orderId { get; set; }

        public ulong quantity { get; set; }
        public string unit { get; set; }




    }
}
