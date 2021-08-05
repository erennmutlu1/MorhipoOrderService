using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MorhipoOrderService.Context.MorhipoOrders;

namespace MorhipoOrderService.Models.MorhipoModels
{
    public class MorhipoOrderDetails
    {
        [Key]
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ItemId { get; set; }
          
    }
}
