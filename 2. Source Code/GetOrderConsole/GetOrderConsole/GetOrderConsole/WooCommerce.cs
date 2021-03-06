﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using xNet;

namespace GetOrderConsole
{
    public class WooCommerce
    {
        private string _HostUrl = "";
        private string _ConsumerKey = "";
        private string _ConsumerSecret = "";
        private static string ApiUrl = @"/wp-json/wc/v2/";
        private HttpRequest _httpRequest;
        private DateTime _time1, _time2, _time3;

        public WooCommerce(DateTime time1, DateTime time2, DateTime time3, string HostUrl, string ConsumerKey, string ConsumerSecret)
        {
            _time1 = time1;
            _time2 = time2;
            _time3 = time3;
            _HostUrl = HostUrl;
            _ConsumerKey = ConsumerKey;
            _ConsumerSecret = ConsumerSecret;
            _httpRequest = new HttpRequest
            {
                Cookies = new CookieDictionary(),
                UserAgent =
                    "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36"
            };
        }

        public void GetData(int time)
        {
            string address = _HostUrl + ApiUrl + "orders/";
            RequestParams parameters = new RequestParams
            {
                ["consumer_key"] = _ConsumerKey,
                ["consumer_secret"] = _ConsumerSecret
            };
            string html = _httpRequest.Get(address, parameters).ToString();
            var json = JsonConvert.DeserializeObject(html);
            JToken jToken = JToken.FromObject(json);

            GetCustomers(jToken);
            GetOrdersAndOrderDetail(jToken, time);
        }

        private void GetCustomers(JToken jToken)
        {
            try
            {
                Customers tempCustomers = new Customers();
                foreach (var item in jToken)
                {
                    if (tempCustomers.CheckCustomerExists((string)item["billing"]["phone"]) >= 1)
                    {
                        continue;
                    }
                    Customers customers = new Customers();
                    customers.Name = (string)item["billing"]["first_name"] + " " + (string)item["billing"]["last_name"];
                    customers.Phone = (string)item["billing"]["phone"];
                    customers.Address = (string)item["billing"]["address_1"] + " - " + (string)item["billing"]["city"];
                    customers.Type = "Khách hàng";
                    tempCustomers.InsertCustomersToDb(customers);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("GetCustomers that bai" + e);
                throw;
            }
        }

        private void GetOrdersAndOrderDetail(JToken jToken, int time)
        {
            Orders tempOrders = new Orders();
            OrderDetail tempOrderDetail = new OrderDetail();
            Customers tempCustomers = new Customers();
            try
            {
                foreach (var item in jToken)
                {
                    if (tempOrders.GetOrderIdFromDb((string)item["order_key"]) != 0)
                    {
                        continue;
                    }

                    //DateTime createdTime = ConvertToTimeSpan((string)item["date_created"]);
                    //DateTime updatedTime = ConvertToTimeSpan((string)item["date_modified"]);
                    //if (Check(time, createdTime) == 1)
                    //{
                    //    continue;
                    //}

                    // ReSharper disable once ComplexConditionExpression
                    Orders orders = new Orders
                    {
                        OrderCode = (string)item["order_key"],
                        CreatedTime = ConvertToTimeSpan((string)item["date_created"]),
                        UpdatedTime = ConvertToTimeSpan((string)item["date_modified"]),
                        SubTotal = item["total"].ToString().Replace(".00", ""),
                        GrandPrice = item["total"].ToString().Replace(".00", ""),
                        CustomerId = tempCustomers.GetCustomerIdFromDb((string)item["billing"]["phone"]),
                        Status = "Chưa duyệt",
                        VerifyBy = 1,
                        OrderFrom = "WooCommerce",
                        Type = "Bán cho khách",
                        ShippingAddress = (string)item["billing"]["address_1"] + " - " + (string)item["billing"]["city"],
                        BillingAddress = (string)item["billing"]["address_1"] + " - " + (string)item["billing"]["city"],
                        CallShip = "Chưa gọi ship",
                        ShipId = "",
                        ShipPrice = "0",
                        PackageWidth = "0",
                        PackageHeight = "0",
                        PackageLenght = "0"
                    };
                    tempOrders.InsertOrdersToDb(orders);

                    int orderId = tempOrders.GetOrderIdFromDb((string)item["order_key"]);
                    //string productId = GetProductIdFromDb((string)item["sku"]);
                    foreach (var subItem in item["line_items"])
                    {
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = orderId,
                            ProductId = (string)subItem["sku"],
                            Quantity = (int)subItem["quantity"]
                        };
                        tempOrderDetail.InsertOrderDetailToDb(orderDetail);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("GetOrders that bai" + e);
                throw;
            }
        }

        private int Check(int time, DateTime createdTime)
        {
            switch (time)
            {
                case 1:
                    if (createdTime.ToShortDateString() == _time1.ToShortDateString() && _time1 <= createdTime && createdTime < _time2)
                        return 0;
                    break;

                case 2:
                    if (createdTime.ToShortDateString() == _time2.ToShortDateString() && _time2 <= createdTime && createdTime < _time3)
                        return 0;
                    break;

                case 3:
                    if (createdTime.ToShortDateString() == _time3.ToShortDateString() && _time3 <= createdTime)
                        return 0;
                    break;
            }

            return 1;
        }

        public DateTime ConvertToDateTime(string time)
        {
            return DateTime.Parse(time).ToLocalTime();
        }

        public string ConvertToTimeSpan(string time)
        {
            DateTime dateTime = DateTime.Parse(time).ToLocalTime();
            var dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUnixTimeSeconds().ToString();
        }
    }
}