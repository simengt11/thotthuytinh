﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using xNet;

namespace OMS.ViewModel
{
    public class OrderManagementUCViewModel : BaseViewModel
    {
        #region command

        public ICommand ButtonSearchCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand CreateOrderCommand { get; set; }
        public ICommand SaveOrderCommand { get; set; }

        public ICommand OrderDetailCommand { get; set; }
        public ICommand DeleteProductFromOrderCommand { get; set; }
        public ICommand AddProductToOrderCommand { get; set; }
        public ICommand UpdateProductToOrderCommand { get; set; }
        public ICommand SelectionChangedCallShipCommand { get; set; }

        public ICommand CheckPriceCommand { get; set; }
        public ICommand ListOrderDetailMouseMoveCommand { get; set; }

        public ICommand CreateShippingOrderCommand { get; set; }
        public ICommand CancelShippingOrderCommand { get; set; }

        #endregion command

        #region Variable

        public ObservableCollection<Orders> List { get; set; }
        public ObservableCollection<OrderDetail> ListOrderDetail { get; set; }
        public ObservableCollection<Orders> ListTemp { get; set; }
        public ObservableCollection<Products> ListProduct { get; set; }

        public List<String> ListProductName { get; set; }
        public string SelectedValue { get; set; }

        private Orders _SelectedItem { get; set; }

        public Orders SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem == null)
                    return;
                OrderID = SelectedItem.Id.ToString();
                switch (SelectedItem.Status)
                {
                    case "Chưa duyệt":
                        OrderStatus = 0;
                        break;

                    case "Đã đóng gói":
                        OrderStatus = 1;
                        break;

                    case "Đang vận chuyển":
                        OrderStatus = 2;
                        break;

                    case "Đã chuyển hàng":
                        OrderStatus = 3;
                        break;

                    default:
                        OrderStatus = 4;
                        break;
                }
                CustomerName = SelectedItem.Customer.Name;
                GrandPrice = SelectedItem.GrandPrice;
                CreatedDate = SelectedItem.CreatedTime;
                SubTotal = SelectedItem.SubPrice;
                ShippingAddress = SelectedItem.ShippingAddress;
                BillingAddress = SelectedItem.BillingAddress;
                CustomerPhone = SelectedItem.Customer.Phone;
                CallShip = SelectedItem.CallShip.Equals("Chưa gọi ship") ? 0 : 1;
                ShipPrice = Convert.ToInt32(SelectedItem.ShipPrice);
                ShipId = SelectedItem.ShipId;
                PackageHeight = SelectedItem.PackageHeight;
                PackageLenght = SelectedItem.PackageLenght;
                PackageWidth = SelectedItem.PackageWidth;
            }
        }

        private string _OrderID { get; set; }

        public string OrderID
        {
            get => _OrderID;
            set { _OrderID = value; OnPropertyChanged(); }
        }

        private int _OrderStatus { get; set; }

        public int OrderStatus
        {
            get => _OrderStatus;
            set { _OrderStatus = value; OnPropertyChanged(); }
        }

        private string _CustomerName { get; set; }

        public string CustomerName
        {
            get => _CustomerName;
            set { _CustomerName = value; OnPropertyChanged(); }
        }

        private string _CustomerPhone { get; set; }

        public string CustomerPhone
        {
            get => _CustomerPhone;
            set { _CustomerPhone = value; OnPropertyChanged(); }
        }

        private string _GrandPrice { get; set; }

        public string GrandPrice
        {
            get => _GrandPrice;
            set { _GrandPrice = value; OnPropertyChanged(); }
        }

        private string _SubTotal { get; set; }

        public string SubTotal
        {
            get => _SubTotal;
            set { _SubTotal = value; OnPropertyChanged(); }
        }

        private string _CreatedDate { get; set; }

        public string CreatedDate
        {
            get => _CreatedDate;
            set { _CreatedDate = value; OnPropertyChanged(); }
        }

        private string _BillingAddress { get; set; }

        public string BillingAddress
        {
            get => _BillingAddress;
            set { _BillingAddress = value; OnPropertyChanged(); }
        }

        private string _ShippingAddress { get; set; }

        public string ShippingAddress
        {
            get => _ShippingAddress;
            set { _ShippingAddress = value; OnPropertyChanged(); }
        }

        private int _CallShip { get; set; }

        public int CallShip
        {
            get => _CallShip;
            set { _CallShip = value; OnPropertyChanged(); }
        }

        private string _PackageWidth { get; set; }

        public string PackageWidth
        {
            get => _PackageWidth;
            set { _PackageWidth = value; OnPropertyChanged(); }
        }

        private string _PackageLenght { get; set; }

        public string PackageLenght
        {
            get => _PackageLenght;
            set { _PackageLenght = value; OnPropertyChanged(); }
        }

        private string _PackageHeight { get; set; }

        public string PackageHeight
        {
            get => _PackageHeight;
            set { _PackageHeight = value; OnPropertyChanged(); }
        }

        private string _SearchContent { get; set; }

        public string SearchContent
        {
            get => _SearchContent;
            set { _SearchContent = value; OnPropertyChanged(); }
        }

        private bool _isEnabledCallShip { get; set; }

        public bool isEnabledCallShip
        {
            get => _isEnabledCallShip;
            set { _isEnabledCallShip = value; OnPropertyChanged(); }
        }

        private bool _isEnabledCancelShip { get; set; }

        public bool isEnabledCancelShip
        {
            get => _isEnabledCancelShip;
            set { _isEnabledCancelShip = value; OnPropertyChanged(); }
        }

        private bool _AddOrderDetailButtonEnabled { get; set; }

        public bool AddOrderDetailButtonEnabled
        {
            get => _AddOrderDetailButtonEnabled;
            set { _AddOrderDetailButtonEnabled = value; OnPropertyChanged(); }
        }

        private bool _UpdateOrderDetailButtonEnabled { get; set; }

        public bool UpdateOrderDetailButtonEnabled
        {
            get => _UpdateOrderDetailButtonEnabled;
            set { _UpdateOrderDetailButtonEnabled = value; OnPropertyChanged(); }
        }

        private string _ProductQuantity { get; set; }

        public string ProductQuantity
        {
            get => _ProductQuantity;
            set { _ProductQuantity = value; OnPropertyChanged(); }
        }

        private string _UnitPrice { get; set; }

        public string UnitPrice
        {
            get => _UnitPrice;
            set { _UnitPrice = value; OnPropertyChanged(); }
        }

        private int _ShipPrice { get; set; }

        public int ShipPrice
        {
            get => _ShipPrice;
            set { _ShipPrice = value; OnPropertyChanged(); }
        }

        private string _ShipId { get; set; }

        public string ShipId
        {
            get => _ShipId;
            set { _ShipId = value; OnPropertyChanged(); }
        }

        private string _ComboboxProductListSelectedValue { get; set; }

        public string ComboboxProductListSelectedValue
        {
            get => _ComboboxProductListSelectedValue;
            set { _ComboboxProductListSelectedValue = value; OnPropertyChanged(); }
        }

        private int _OrderDetailId { get; set; }

        public int OrderDetailId
        {
            get => _OrderDetailId;
            set { _OrderDetailId = value; OnPropertyChanged(); }
        }

        public OrderDetail _OrderDtailSelectedItem { get; set; }

        public OrderDetail OrderDtailSelectedItem
        {
            get => _OrderDtailSelectedItem;
            set
            {
                _OrderDtailSelectedItem = value;
                OnPropertyChanged();
                try
                {
                    OrderDetailId = OrderDtailSelectedItem.Id;
                    ComboboxProductListSelectedValue = OrderDtailSelectedItem.Product.Name;
                    ProductQuantity = OrderDtailSelectedItem.Quantity.ToString();
                }
                catch (Exception e)
                {
                }
            }
        }

        public Orders orders;
        public Products products;
        public OrderDetail orderDetail;
        public Customers customers;
        public int AccountID;

        #endregion Variable

        #region Method

        public OrderManagementUCViewModel()
        {
            List = new ObservableCollection<Orders>();
            ListTemp = new ObservableCollection<Orders>();
            ListOrderDetail = new ObservableCollection<OrderDetail>();
            ListProduct = new ObservableCollection<Products>();
            orders = new Orders();
            products = new Products();
            orderDetail = new OrderDetail();
            customers = new Customers();
            var lg = new LoginViewModel();
            AccountID = lg.isVeryfy;

            SelectionChangedCommand = new RelayCommand<ComboBox>(p => true, p =>
            {
                List.Clear();
                ListProduct.Clear();
                ComboBoxItem comboBox = (ComboBoxItem)p.SelectedItem;
                SelectedValue = comboBox.Content.ToString();
                foreach (var item in orders.LoadData(SelectedValue))
                {
                    List.Add(item);
                    ListTemp.Add(item);
                }
                foreach (var item in products.LoadProduct())
                {
                    ListProduct.Add(item);
                }
            });

            ListOrderDetailMouseMoveCommand = new RelayCommand<object>(p => true, p =>
            {
                //auto fill subtotal and grand total
                SubTotal = CalculateSubTotal();
                if (Convert.ToInt32(GrandPrice) < Convert.ToInt32(SubTotal))
                    GrandPrice = SubTotal;
                if (Convert.ToInt32(SubTotal) == 0)
                    GrandPrice = "0";
            });

            ButtonSearchCommand = new RelayCommand<ComboBox>(p => true, p =>
            {
                int SelectedIndex = p.SelectedIndex;
                if (List != null)
                    List.Clear();

                if (SearchContent == null)
                {
                    foreach (var item in ListTemp)
                    {
                        List.Add(item);
                    }
                }
                else
                {
                    switch (SelectedIndex)
                    {
                        case 0:
                            try
                            {
                                int id = Convert.ToInt32(SearchContent);
                                FindOrderByID(id);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Mã hóa đơn chỉ bao gồm số!!");
                            }

                            break;

                        case 1:
                            FindOrderByCustomerName();
                            break;

                        default:
                            FindOrderByCustomerPhone();
                            break;
                    }
                }
            });

            CreateOrderCommand = new RelayCommand<object>(p => true, p =>
            {
                CreateOrder();
                foreach (var item in orders.LoadData(SelectedValue))
                {
                    List.Add(item);
                    ListTemp.Add(item);
                }
            });

            SaveOrderCommand = new RelayCommand<object>(p => true, p =>
            {
                if (MessageBox.Show("Bạn có muốn lưu?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    UpdateOrder();
                    ListTemp.Clear();
                    List.Clear();
                    foreach (var item in orders.LoadData(SelectedValue))
                    {
                        List.Add(item);
                        ListTemp.Add(item);
                    }
                }
            });

            SelectionChangedCallShipCommand = new RelayCommand<ComboBox>(p => true, p =>
            {
                int temp = p.SelectedIndex;

                if (temp == 0)
                {
                    isEnabledCallShip = true;
                    isEnabledCancelShip = false;
                }
                else
                {
                    isEnabledCallShip = false;
                    isEnabledCancelShip = true;
                }
            });

            OrderDetailCommand = new RelayCommand<object>(p => true, p =>
            {
                if (ListOrderDetail != null)
                    ListOrderDetail.Clear();
                foreach (var item in orderDetail.LoadDataToOrderDetail(SelectedValue, OrderID))
                {
                    ListOrderDetail.Add(item);
                }

                AddOrderDetailButtonEnabled = true;
                UpdateOrderDetailButtonEnabled = true;

                if (CallShip == 0)
                {
                    isEnabledCallShip = true;
                    isEnabledCancelShip = false;
                }
                else
                {
                    isEnabledCallShip = false;
                    isEnabledCancelShip = true;
                }
                AutoUpdatePackageDimension();
            });

            AddProductToOrderCommand = new RelayCommand<object>(p => true, p =>
            {
                string ProductIDTemp = null;
                int ProductQuantityTemp = 0;
                int ProductQuantityStock = 0;
                int OrderIDTemp = Convert.ToInt32(OrderID);
                if (ComboboxProductListSelectedValue == null || ProductQuantity == null)
                {
                    MessageBox.Show("Các trường * không được bỏ trống!");
                }
                else
                {
                    try
                    {
                        ProductQuantityTemp = Convert.ToInt32(ProductQuantity);
                        //Kiểm tra sản phẩm đã tồn tại trong hóa đơn chưa
                        foreach (var item in ListOrderDetail)
                        {
                            if (item.Product.Name.Contains(ComboboxProductListSelectedValue))
                            {
                                MessageBox.Show("Sản phẩm đã tồn tại trong hóa đơn!");
                                return;
                            }
                        }
                        //Lấy id sản phẩm
                        foreach (var item in ListProduct)
                        {
                            if (item.Name.Contains(ComboboxProductListSelectedValue))
                            {
                                ProductIDTemp = item.Id;
                                ProductQuantityStock = item.Quantity;
                            }
                        }
                        //Kiểm tra số lượng bán có nhiều hơn số lượng tồn không?
                        if (CheckProductQuantity(ProductQuantityTemp, ProductQuantityStock))
                        {
                            if (orderDetail.AddProductToOrder(OrderIDTemp, ProductIDTemp, ProductQuantityTemp, ProductQuantityStock))
                            {
                                MessageBox.Show("Đã thêm thành công!");
                                ListOrderDetail.Clear();
                                foreach (var item in orderDetail.LoadDataToOrderDetail(SelectedValue, OrderID))
                                {
                                    ListOrderDetail.Add(item);
                                }
                            }
                            else
                                MessageBox.Show("Xảy ra lỗi khi thêm sản phẩm vào hóa đơn!");
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Quantity phải là số!");
                        return;
                    }
                }
                AutoUpdatePackageDimension();
            });

            DeleteProductFromOrderCommand = new RelayCommand<object>(p => true, p =>
            {
                string ProductIDTemp = null;
                int ProductQuantityTemp = 0;
                int ProductQuantityStock = 0;
                if (OrderDetailId == 0)
                {
                    MessageBox.Show("Bạn hãy chọn sản phẩm cần xóa!");
                    return;
                }
                ProductQuantityTemp = Convert.ToInt32(ProductQuantity);
                //Lấy id sản phẩm
                foreach (var item in ListProduct)
                {
                    if (item.Name.Contains(ComboboxProductListSelectedValue))
                    {
                        ProductIDTemp = item.Id;
                        ProductQuantityStock = item.Quantity;
                    }
                }
                if (MessageBox.Show("Bạn có muốn xóa chi tiết có Id = " + OrderDetailId + " ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (orderDetail.DeleteProductFromOrder(OrderDetailId, ProductIDTemp, ProductQuantityTemp, ProductQuantityStock))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        ListOrderDetail.Clear();
                        foreach (var item in orderDetail.LoadDataToOrderDetail(SelectedValue, OrderID))
                        {
                            ListOrderDetail.Add(item);
                        }
                    }
                    else
                        MessageBox.Show("Đã xảy ra lỗi khi xóa chi tiết có Id = " + OrderDetailId);
                }
                AutoUpdatePackageDimension();
            });

            UpdateProductToOrderCommand = new RelayCommand<object>(p => true, p =>
            {
                var dB = new DBConnect();
                string ProductIDTemp = null;
                int ProductQuantityAfter = 0;
                int ProductQuantityBefore = 0;
                int ProductQuantityStock = 0;
                int temp = 0;
                int OrderIDTemp = Convert.ToInt32(OrderID);
                if (ComboboxProductListSelectedValue == null || ProductQuantity == null)
                {
                    MessageBox.Show("Các trường * không được bỏ trống!");
                }
                else
                {
                    try
                    {
                        //Lấy số lượng sau khi đã chỉnh sửa.
                        ProductQuantityAfter = Convert.ToInt32(ProductQuantity);
                        //Kiểm tra sản phẩm đã tồn tại trong hóa đơn chưa
                        foreach (var item in ListOrderDetail)
                        {
                            if (item.Product.Name.Contains(ComboboxProductListSelectedValue))
                            {
                                temp++;
                            }
                            if (temp > 1)
                            {
                                MessageBox.Show("Sản phẩm đã tồn tại trong hóa đơn!");
                                return;
                            }
                        }
                        //Lấy số lượng ban đầu trước khi sửa
                        foreach (var item in ListOrderDetail)
                        {
                            if (item.Product.Name.Contains(ComboboxProductListSelectedValue))
                            {
                                ProductQuantityBefore = item.Quantity;
                            }
                        }
                        //Lấy id sản phẩm
                        foreach (var item in ListProduct)
                        {
                            if (item.Name.Contains(ComboboxProductListSelectedValue))
                            {
                                ProductIDTemp = item.Id;
                                ProductQuantityStock = item.Quantity;
                                continue;
                            }
                        }

                        //Kiểm tra số lượng bán có nhiều hơn số lượng tồn không?
                        if (CheckProductQuantity(ProductQuantityAfter, ProductQuantityStock))
                        {
                            if (MessageBox.Show("Bạn có muốn lưu?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                if (orderDetail.UpdateProductOrder(OrderDetailId, ProductIDTemp, ProductQuantityAfter, ProductQuantityBefore, ProductQuantityStock))
                                {
                                    MessageBox.Show("Cập nhật thành công!");
                                    ListOrderDetail.Clear();
                                    foreach (var item in orderDetail.LoadDataToOrderDetail(SelectedValue, OrderID))
                                    {
                                        ListOrderDetail.Add(item);
                                    }
                                }
                                else
                                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật chi tiết có Id = " + OrderDetailId);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Quantity phải là số!");
                        return;
                    }
                }
                AutoUpdatePackageDimension();
            });

            CheckPriceCommand = new RelayCommand<object>(p => true, p => { CheckShip(ShippingAddress, Convert.ToInt32(PackageWidth), Convert.ToInt32(PackageLenght), Convert.ToInt32(PackageHeight), Convert.ToInt32(GrandPrice)); });

            CreateShippingOrderCommand = new RelayCommand<Button>(p => true, p =>
            {
                CreateShippingOrder(ShippingAddress, Convert.ToInt32(PackageWidth), Convert.ToInt32(PackageLenght), Convert.ToInt32(PackageHeight), Convert.ToInt32(GrandPrice));
                List.Clear();
                ListTemp.Clear();
                foreach (var item in orders.LoadData(SelectedValue))
                {
                    List.Add(item);
                    ListTemp.Add(item);
                }
            });

            CancelShippingOrderCommand = new RelayCommand<Button>(p => true, p =>
            {
                CancelShippingOrder(ShipId);
                List.Clear();
                ListTemp.Clear();
                foreach (var item in orders.LoadData(SelectedValue))
                {
                    List.Add(item);
                    ListTemp.Add(item);
                }
            });
        }

        public void FindOrderByID(int id)
        {
            int temp = 0;

            foreach (var item in ListTemp)
            {
                if (item.Id != id)
                    continue;
                List.Add(item);
                temp++;
            }
            if (temp == 0)
            {
                foreach (var item in ListTemp)
                {
                    List.Add(item);
                }
                MessageBox.Show("Không có kết quả cần tìm!");
            }
        }

        public void FindOrderByCustomerName()
        {
            int temp = 0;
            string CustomerNameTemp;
            foreach (var item in ListTemp)
            {
                CustomerNameTemp = item.Customer.Name.ToUpper();
                if (CustomerNameTemp.Contains(SearchContent.ToUpper()))
                {
                    List.Add(item);
                    temp++;
                }
            }
            if (temp == 0)
            {
                foreach (var item in ListTemp)
                {
                    List.Add(item);
                }
                MessageBox.Show("Không có kết quả cần tìm!");
            }
        }

        public void FindOrderByCustomerPhone()
        {
            int temp = 0;
            string CustomerPhoneTemp;
            foreach (var item in ListTemp)
            {
                CustomerPhoneTemp = item.Customer.Phone;
                if (CustomerPhoneTemp.Contains(SearchContent))
                {
                    List.Add(item);
                    temp++;
                }
            }
            if (temp == 0)
            {
                foreach (var item in ListTemp)
                {
                    List.Add(item);
                }
                MessageBox.Show("Không có kết quả cần tìm!");
            }
        }

        public bool CheckCustomerExist()
        {
            var dB = new DBConnect();
            string query = $"Select * From Customers Where Name = '{CustomerName}' and Phone = '{CustomerPhone}' limit 1;";
            if (dB.ExecuteQueryToGetIdAndCount(query) == 0)
                return false;
            return true;
        }

        public bool CheckProductQuantity(int temp, int stock)
        {
            if (temp > stock)
            {
                MessageBox.Show("Số lượng không đủ!");
                return false;
            }
            return true;
        }

        public void CreateOrder()
        {
            string CreatedDate = ConvertToTimeSpan(DateTime.Now.ToLocalTime().ToString());
            string CallShipTemp, OrderStatusTemp;

            //check field CustomerName, CustomerPhone, Shipping Adress, Billing Adress not null
            if (CustomerName == null || CustomerPhone == null || ShippingAddress == null || BillingAddress == null)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ các trường *");
                return;
            }

            //set value  to CallShipTemp and OrderStatusTemp
            if (CallShip == 0)
                CallShipTemp = "Chưa gọi ship";
            else
                CallShipTemp = "Đã gọi ship";
            switch (OrderStatus)
            {
                case 0:
                    OrderStatusTemp = "Chưa duyệt";
                    break;

                case 1:
                    OrderStatusTemp = "Đã đóng gói";
                    break;

                case 2:
                    OrderStatusTemp = "Đang vận chuyển";
                    break;

                case 3:
                    OrderStatusTemp = "Đã chuyển hàng";
                    break;

                default:
                    OrderStatusTemp = "Đã thanh toán";
                    break;
            }

            if (!CheckCustomerExist())
            {
                if (!customers.AddCustomer(CustomerName, CustomerPhone, BillingAddress))
                    MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng!");
            }
            if (orders.CreateOrder(CreatedDate, SubTotal, GrandPrice, CustomerName, CustomerPhone, OrderStatusTemp, ShippingAddress, BillingAddress, CallShipTemp, ShipPrice, PackageWidth, PackageHeight, PackageLenght, AccountID))
                MessageBox.Show("Thêm hóa đơn thành công! ");
            else
            {
                MessageBox.Show("Có lỗi phát sinh khi thêm đơn hàng!");
                List.Clear();
            }
        }

        public void UpdateOrder()
        {
            string UpdatedDate = ConvertToTimeSpan(DateTime.Now.ToLocalTime().ToString());
            string CallShipTemp = null, OrderStatusTemp;

            //check field CustomerName, CustomerPhone, Shipping Adress, Billing Adress not null
            if (CustomerName == null || CustomerPhone == null || ShippingAddress == null || BillingAddress == null)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ các trường *");
                return;
            }

            //set value  to CallShipTemp and OrderStatusTemp
            if (CallShip == 0)
                CallShipTemp = "Chưa gọi ship";
            else
                CallShipTemp = "Đã gọi ship";

            switch (OrderStatus)
            {
                case 0:
                    OrderStatusTemp = "Chưa duyệt";
                    break;

                case 1:
                    OrderStatusTemp = "Đã đóng gói";
                    break;

                case 2:
                    OrderStatusTemp = "Đang vận chuyển";
                    break;

                case 3:
                    OrderStatusTemp = "Đã chuyển hàng";
                    break;

                default:
                    OrderStatusTemp = "Đã thanh toán";
                    break;
            }

            if (!CheckCustomerExist())
            {
                if (!customers.AddCustomer(CustomerName, CustomerPhone, BillingAddress))
                    MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng!");
            }

            if (orders.UpdateOrder(UpdatedDate, SubTotal, GrandPrice, CustomerName, CustomerPhone, OrderStatusTemp, ShippingAddress, BillingAddress, CallShipTemp, ShipId, ShipPrice, PackageWidth, PackageHeight, PackageLenght, SelectedValue, OrderID, AccountID))
                MessageBox.Show("Cập nhật hóa đơn thành công! ");
            else
            {
                MessageBox.Show("Có lỗi phát sinh khi cập nhật hóa đơn!");
                List.Clear();
            }
        }

        private string CheckShip(string fullAddress, int width, int lenght, int height, int price)
        {
            string token = "653d044D18768F6c54BeB857d091B52cb2334a87";
            string url = @"https://services.giaohangtietkiem.vn/services/shipment/fee?";

            List<string> data = fullAddress.Split('-').ToList();
            int count = data.Count;
            string address = "";
            for (int i = 0; i < data.Count - 2; i++)
            {
                address += data[i] + " -";
            }
            string district = data[count - 2].Trim();
            string province = data[count - 1].Trim();
            string pick_address = "ký túc xá khu B";
            string pick_district = "Thủ Đức";
            string pick_province = "Hồ Chí Minh";
            int weight = (width * lenght * height) / 6000;
            int value = price;
            string request = $"{url}address={address}&district={district}&province={province}&pick_address={pick_address}&pick_district={pick_district}&pick_province={pick_province}&weight={weight}&value={value}";
            var httpRequest = new HttpRequest();
            httpRequest.AddHeader("Token", token);
            var json = JsonConvert.DeserializeObject(httpRequest.Get(request).ToString());
            var jToken = JToken.FromObject(json);
            string fee = jToken["fee"]["fee"].ToString();
            ShipPrice = Convert.ToInt32(fee);
            GrandPrice = (Convert.ToInt32(SubTotal) + ShipPrice).ToString();
            return fee;
        }

        public void CreateShippingOrder(string fullAddress, int width, int lenght, int height, int price)
        {
            string url = @"https://services.giaohangtietkiem.vn/services/shipment/order";
            string token = "653d044D18768F6c54BeB857d091B52cb2334a87";

            string pick_address = "ký túc xá khu B";
            string pick_district = "Thủ Đức";
            string pick_province = "Hồ Chí Minh";

            string shopName = "Dang Nhat Hai Long";
            string shopPhone = "0963209769";

            string customerName = CustomerName;
            string customerPhone = CustomerPhone;

            List<string> data = fullAddress.Split('-').ToList();
            int count = data.Count;
            string address = "";
            for (int i = 0; i < data.Count - 2; i++)
            {
                address += data[i] + " -";
            }
            string district = data[count - 2].Trim();
            string province = data[count - 1].Trim();

            string shipPrice = CheckShip(ShippingAddress, Convert.ToInt32(PackageWidth), Convert.ToInt32(PackageLenght), Convert.ToInt32(PackageHeight), Convert.ToInt32(GrandPrice));

            string jsonProducts = "{\"products\": [";

            foreach (var item in ListOrderDetail)
            {
                string tempProductWeight = "";
                foreach (var item1 in ListProduct)
                {
                    if (item1.Name.Contains(item.Product.Name))
                    {
                        tempProductWeight = item1.Weight;
                    }
                }
                string temp = $"{{\"name\": \"{item.Product.Name}\", \"weight\": {tempProductWeight}, \"quantity\": {item.Quantity}}},";
                jsonProducts += temp;
            }

            jsonProducts += "],";
            jsonProducts = jsonProducts.Replace("},]", "}]");

            string id = RandomShippingId();
            string jsonOrder =
                $"\"order\": {{\"id\": \"{id}\", \"pick_name\": \"{shopName}\", \"pick_address\": \"{pick_address}\", \"pick_province\": \"{pick_province}\", " +
                $"\"pick_district\": \"{pick_district}\", \"pick_tel\": \"{shopPhone}\", \"tel\": \"{customerPhone}\", \"name\": \"{customerName}\", " +
                $"\"address\": \"{address}\", \"province\": \"{province}\", \"district\": \"{district}\", \"is_freeship\": \"0\", " +
                $"\"pick_date\": \"{DateTime.Today.ToShortDateString()}\", \"pick_money\": {Convert.ToInt32(price)} }}}}";

            string fullJson = jsonProducts + jsonOrder;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("Token", token);
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(fullJson);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                var json = JsonConvert.DeserializeObject(responseText);
                var jToken = JToken.FromObject(json);
                if (jToken["success"].Contains("false"))
                {
                    MessageBox.Show("Tạo đơn hàng bên ship thất bại.");
                    return;
                }
                else
                {
                    ShipId = jToken["order"]["label"].ToString();
                }
            }

            try
            {
                var tempOrders = new Orders();
                tempOrders.UpdateShipId(OrderID, ShipId, shipPrice);
                MessageBox.Show("Tạo đơn hàng ship thành công.");
            }
            catch (Exception e)
            {
                MessageBox.Show("Tạo đơn hàng ship thất bại.");
            }
        }

        public void CancelShippingOrder(string label)
        {
            string url = @"https://services.giaohangtietkiem.vn/services/shipment/cancel/" + label;
            string token = "653d044D18768F6c54BeB857d091B52cb2334a87";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("Token", token);
            httpWebRequest.Method = "POST";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                var json = JsonConvert.DeserializeObject(responseText);
                var jToken = JToken.FromObject(json);
                if (jToken["success"].ToString().ToLower().Equals("true"))
                {
                    orders.UpdateCallShip(OrderID);
                    MessageBox.Show("Hủy thành công.");
                }
                else
                {
                    MessageBox.Show("Hủy đơn ship thất bại.");
                }
            }
        }

        public string CalculateSubTotal()
        {
            int temp = 0;
            foreach (var item in ListOrderDetail)
            {
                temp += Convert.ToInt32(item.Product.Price) * item.Quantity;
            }
            return temp.ToString();
        }

        public void AutoUpdatePackageDimension()
        {
            int PackageWidthTemp = 40;
            int PackageHeightTemp = 10;
            int PackageLenghtTemp = 40;
            int QuantityTemp = 0;

            foreach (var item in ListOrderDetail)
            {
                QuantityTemp += item.Quantity;
            }
            if (QuantityTemp > 0)
            {
                PackageHeight = (PackageHeightTemp * QuantityTemp).ToString();
                PackageWidth = PackageWidthTemp.ToString();
                PackageLenght = PackageLenghtTemp.ToString();
            }
            else
            {
                PackageHeight = "0";
                PackageWidth = "0";
                PackageLenght = "0";
            }
        }

        public string ConvertToTimeSpan(string time)
        {
            var dateTime = DateTime.Parse(time).ToLocalTime();
            var dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUnixTimeSeconds().ToString();
        }

        public string RandomShippingId()
        {
            return "id_" + ConvertToTimeSpan(DateTime.Now.ToString());
        }

        #endregion Method
    }
}