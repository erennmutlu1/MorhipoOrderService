using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorhipoOrderService.Models.MorhipoContext;

namespace MorhipoOrderService.Models.MorhipoModels
{
    public class MorhipoItemsModel
    {
        [Key]

        public long itemid { get; set; }
        public Int64 itemIndex { get; set; }
        public Int64 statusTypeId { get; set; }
        public string statusDescription { get; set; }
        public string packageId { get; set; }
        public Int64 packageStatusTypeId { get; set; }
        public string packageStatusDescription { get; set; }
        public Int64 pieceCount { get; set; }
        public string sku { get; set; }

        public string merchantsku { get; set; }
        public string barcode { get; set; }
        public string productDescription { get; set; }
        public Int64 quantity { get; set; }
        public string unit { get; set; }
        public double unitPrice { get; set; }
        public double grossAmount { get; set; }
        public double taxAmount { get; set; }
        public double netAmount { get; set; }
        public double allowanceAmount { get; set; }
        public double commisionAmount { get; set; }
        public double commisionRate { get; set; }
        public string currency { get; set; }
        public string vatcode { get; set; }
        public string cancelReason { get; set; }

        public string attributes { get; set; }
        public DateTime lastUpdatedate { get; set; }
        public string lastUpatetime { get; set; }
        public long timestamp { get; set; }

        public string image { get; set; }
        public long? morhipoProductId { get; set; }
        public bool cancelable { get; set; }












    }
}
