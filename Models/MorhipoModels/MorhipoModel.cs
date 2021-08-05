using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MorhipoOrderService.Context.MorhipoOrders;

namespace MorhipoOrderService.Models.MorhipoModels
{
    public class MorhipoModel
    {
        [Key]
        public Int64 orderId { get; set; }
        public string order { get; set; }
        public Int64 itemCount { get; set; }
        public Int64 quantity { get; set; }
        public double grossAmount { get; set; }
        public double taxAmount { get; set; }
        public double netAmount { get; set; }
        public double allowanceAmount { get; set; }
        public string shopperId { get; set; }
        public string shopperEmail { get; set; }
        public DateTime date { get; set; }
        public DateTime commitmentDate { get; set; }

        public long shipmentAddressId { get; set; }
        public long invoiceAddressId { get; set; }
    }
}
