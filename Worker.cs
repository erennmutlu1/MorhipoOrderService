using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MorhipoOrderService.DBContext;
using MorhipoOrderService.Models.MorhipoContext;
using MorhipoOrderService.Models.MorhipoModel;
using MorhipoOrderService.Models.MorhipoModels;
using MorhipoOrderService.Utils;

namespace MorhipoOrderService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                using (var dbContext = new MorhipoDBContext())
                {
                    var dnsl3 = dbContext.Morhipo.ToList();
                }
            }
            catch (Exception ex)
            {
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);


                string apiUsername = "";
                string apiPassword = "";
                string token = TokenManager.GetToken($"{apiUsername}:{apiPassword}");

                var client = new RestClient("https://mpapi.morhipo.com/mpstore/order/List");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Basic {token}");
                IRestResponse response = client.Execute(request);


                var deserializedTrendyolResponse = JsonConvert.DeserializeObject<MorhipoResponse>(response.Content);

                try
                {

                    using (var dbContext = new MorhipoDBContext())
                    {
                        foreach (Morhipo content in deserializedTrendyolResponse.data)
                        {

                            if (!dbContext.Morhipo.Any(a => a.orderId == content.orderId))
                            {

                                var shipmentAddress = new MorhipoShipmentAddressModel
                                {
                                    name = content.shipmentAddress.name,
                                    address = content.shipmentAddress.address,
                                    district = content.shipmentAddress.district,
                                    city = content.shipmentAddress.city,
                                    citycode = content.shipmentAddress.citycode,
                                    country = content.shipmentAddress.country,
                                    phoneNumber = content.shipmentAddress.phoneNumber,
                                    postalcode = content.shipmentAddress.postalcode
                                };

                                dbContext.Add(shipmentAddress);
                                _ = dbContext.SaveChanges();
                                long shipmentAddressId = shipmentAddress.Id;

                                var invoiceAddress = new MorhipoInvoiceAddressModel
                                {
                                    address = content.invoiceAddress.address,
                                    city = content.invoiceAddress.city,
                                    citycode = content.invoiceAddress.citycode,
                                    country = content.invoiceAddress.country,
                                    district = content.invoiceAddress.district,
                                    name = content.invoiceAddress.name,
                                    postalcode = content.invoiceAddress.postalcode,
                                    taxnumber = content.invoiceAddress.taxnumber,
                                    taxoffice = content.invoiceAddress.taxoffice
                                };
                                dbContext.Add(invoiceAddress);
                                _ = dbContext.SaveChanges();
                                long invoiceAddressId = invoiceAddress.Id;


                                var order = new MorhipoModel
                                {
                                    orderId = content.orderId,
                                    order = content.order,
                                    itemCount = content.itemCount,
                                    quantity = content.quantity,
                                    grossAmount = content.grossAmount,
                                    taxAmount = content.taxAmount,
                                    netAmount = content.netAmount,
                                    allowanceAmount = content.allowanceAmount,
                                    shopperId = content.shopperId,
                                    shopperEmail = content.shopperEmail,
                                    date = content.date,
                                    commitmentDate = content.commitmentDate,
                                    invoiceAddressId = invoiceAddressId,
                                    shipmentAddressId = shipmentAddressId
                                };
                                _ = dbContext.Add(order);
                                dbContext.SaveChanges();

                                var itemIdList = new List<long>();
                                foreach (var item in content.items)
                                {
                                    itemIdList.Add(item.itemid);
                                    dbContext.Add(new MorhipoItemsModel
                                    {
                                        itemid = item.itemid,
                                        itemIndex = item.itemIndex,
                                        statusTypeId = item.statusTypeId,
                                        statusDescription = item.statusDescription,
                                        packageId = item.packageId,
                                        packageStatusTypeId = item.packageStatusTypeId,
                                        packageStatusDescription = item.packageStatusDescription,
                                        pieceCount = item.pieceCount,
                                        sku = item.sku,
                                        merchantsku = item.merchantsku,
                                        barcode = item.barcode,
                                        productDescription = item.productDescription,
                                        quantity = item.quantity,
                                        unit = item.unit,
                                        unitPrice = item.unitPrice,
                                        grossAmount = item.grossAmount,
                                        taxAmount = item.taxAmount,
                                        netAmount = item.netAmount,
                                        allowanceAmount = item.allowanceAmount,
                                        commisionAmount = item.commisionAmount,
                                        commisionRate = item.commisionRate,
                                        currency = item.currency,
                                        vatcode = item.vatcode,
                                        cancelReason = item.cancelReason,
                                        attributes = JsonConvert.SerializeObject(item.attributes),
                                        lastUpdatedate = item.lastUpdatedate,
                                        lastUpatetime = item.lastUpatetime,
                                        timestamp = item.timestamp,
                                        image = item.image,
                                        morhipoProductId = item.morhipoProductId,
                                        cancelable = item.cancelable,




                                    });

                                }
                                dbContext.SaveChanges();

                                foreach (var itemId in itemIdList)
                                {
                                    dbContext.Add(new MorhipoOrderDetails
                                    {
                                        OrderId = content.orderId,
                                        ItemId = itemId
                                    });
                                }
                                dbContext.SaveChanges();




                            }
                        }

                    }
                }
                catch (Exception ex)
                {


                }

                _logger.LogInformation(response.Content);

                Console.WriteLine(response.Content);









                await Task.Delay(100 * 1000, stoppingToken);
            }
        }
    }
}
