using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorhipoOrderService.Context
{
    class MorhipoOrders
    {
       

        public class MorhipoData
        {
            public IList<Morhipo> data { get; set; }

        }

        public class ShipmentAddress
        {
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

        public class InvoiceAddress
        {
            public Int64 ID { get; set; }
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

        public class Attribute
        {
            public Int64 ID { get; set; }
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Item
        {
            public Int64 ID { get; set; }
            public Int64 itemid { get; set; }
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
            public Attribute attributes { get; set; }
            public DateTime lastUpdatedate { get; set; }
            public string lastUpatetime { get; set; }
            public Int64 timestamp { get; set; }
            public string image { get; set; }
            public Int64? morhipoProductId { get; set; }
            public bool cancelable { get; set; }
        }

        public class Content
        {
            public Int64 ID { get; set; }

            public string itemId { get; set; }
            public Int64 orderId { get; set; }
            public Int64 quantity { get; set; }
            public string unit { get; set; }
        }

        public class Package
        {
            public Int64 ID { get; set; }
            public string packageId { get; set; }
            public Int64 statusTypeId { get; set; }
            public string statusDescription { get; set; }
            public Int64 pieceCount { get; set; }
            public string trackingCode { get; set; }
            public string trackingUrl { get; set; }
            public string shippingPartner { get; set; }
            public Content content { get; set; }
        }

        public class Morhipo
        {


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
            public List<ShipmentAddress> shipmentAddress { get; set; }
            public List<InvoiceAddress> invoiceAddress { get; set; }
            public List<Item> items { get; set; }
            public List<Package> packages { get; set; }
            public List<Content> content { get; set; }
            public List<Attribute> attributes { get; set; }
            public List<Content> content1  { get; set; } //  Added later.


        }

























    }
}
