using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MorhipoOrderService.Context.MorhipoOrders;

namespace MorhipoOrderService.Models.MorhipoContext
{
    public class MorhipoPackages
    {
        [Key]
        public Int64 ID { get; set; }

        public string packageId { get; set; }
        public Int64 statusTypeID { get; set; }
        public string statusDescription  { get; set; }
        public Int64 pieceCount { get; set; }
        public string trackingCode { get; set; }
        public string trackingUrl { get; set; }
        public string shippingPartner { get; set; }
        public List<MorhipoContent> contents { get; set; }
     



    }
}
