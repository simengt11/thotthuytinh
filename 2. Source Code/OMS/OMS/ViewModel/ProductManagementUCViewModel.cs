﻿using Microsoft.Win32;
using OMS.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OMS.ViewModel
{
    public class ProductManagementUCViewModel : BaseViewModel
    {
        #region Command
        public ICommand LoadedCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand AddImage1Command { get; set; }
        public ICommand AddImage2Command { get; set; }
        public ICommand AddImage3Command { get; set; }

        #endregion Command

        #region Variable

        public ObservableCollection<Products> ListProduct { get; set; }
        public ObservableCollection<Products> ListTemp { get; set; }

        private Products _SelectedItem { get; set; }

        public Products SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem == null)
                    return;
                ProductId = SelectedItem.Id;
                ProductName = SelectedItem.Name;
                ProductDescription = SelectedItem.Description;
                ProductPrice = SelectedItem.Price;
                ProductWidth = SelectedItem.Width;
                ProductWeight = SelectedItem.Weight;
                ProductHeight = SelectedItem.Height;
                ProductLength = SelectedItem.Length;
                ProductImage1 = SelectedItem.Image1;
                ProductImage2 = SelectedItem.Image2;
                ProductImage3 = SelectedItem.Image3;
                ProductQuantity = Convert.ToInt32(SelectedItem.Quantity);
            }
        }

        private string _ProductId { get; set; }

        public string ProductId
        {
            get => _ProductId;
            set { _ProductId = value; OnPropertyChanged(); }
        }

        private string _ProductName { get; set; }

        public string ProductName
        {
            get => _ProductName;
            set { _ProductName = value; OnPropertyChanged(); }
        }

        private string _ProductDescription { get; set; }

        public string ProductDescription
        {
            get => _ProductDescription;
            set { _ProductDescription = value; OnPropertyChanged(); }
        }

        private string _ProductPrice { get; set; }

        public string ProductPrice
        {
            get => _ProductPrice;
            set { _ProductPrice = value; OnPropertyChanged(); }
        }

        private string _ProductWidth { get; set; }

        public string ProductWidth
        {
            get => _ProductWidth;
            set { _ProductWidth = value; OnPropertyChanged(); }
        }

        private string _ProductHeight { get; set; }

        public string ProductHeight
        {
            get => _ProductHeight;
            set { _ProductHeight = value; OnPropertyChanged(); }
        }

        private string _ProductWeight { get; set; }

        public string ProductWeight
        {
            get => _ProductWeight;
            set { _ProductWeight = value; OnPropertyChanged(); }
        }

        private string _ProductLength { get; set; }

        public string ProductLength
        {
            get => _ProductLength;
            set { _ProductLength = value; OnPropertyChanged(); }
        }

        private string _ProductImage1 { get; set; }

        public string ProductImage1
        {
            get => _ProductImage1;
            set { _ProductImage1 = value; OnPropertyChanged(); }
        }

        private string _ProductImage2 { get; set; }

        public string ProductImage2
        {
            get => _ProductImage2;
            set { _ProductImage2 = value; OnPropertyChanged(); }
        }

        private string _ProductImage3 { get; set; }

        public string ProductImage3
        {
            get => _ProductImage3;
            set { _ProductImage3 = value; OnPropertyChanged(); }
        }

        private int _ProductQuantity { get; set; }

        public int ProductQuantity
        {
            get => _ProductQuantity;
            set { _ProductQuantity = Convert.ToInt32(value); OnPropertyChanged(); }
        }

        private string _SearchContent { get; set; }

        public string SearchContent
        {
            get => _SearchContent;
            set { _SearchContent = value.ToUpper().Trim(); OnPropertyChanged(); }
        }

        public Products Products;
        public int AccountId;

        #endregion Variable

        #region Method

        public ProductManagementUCViewModel()
        {
            var loginVm = new LoginViewModel();
            AccountId = loginVm.isVeryfy;

            ListProduct = new ObservableCollection<Products>();
            ListTemp = new ObservableCollection<Products>();
            Products = new Products();

            LoadedCommand = new RelayCommand<Window>(p => true,
               p =>
               {
                   ListTemp.Clear();
                   ListProduct.Clear();
                   foreach (var item in Products.LoadProduct())
                   {
                       ListTemp.Add(item);
                       ListProduct.Add(item);
                   }
               });

            CreateCommand = new RelayCommand<Button>(p => true, p => { CreateProduct(); LoadProduct(); });
            UpdateCommand = new RelayCommand<Button>(p => true, p => { UpdateProduct(); LoadProduct(); });
            DeleteCommand = new RelayCommand<Button>(p => true, p => { DeleteProduct(); LoadProduct(); });
            AddImage1Command = new RelayCommand<Button>(p => true, p =>
            {
                string path = FindFilePath();
                if (path == "")
                    return;
                ProductImage1 = path;
            });
            AddImage2Command = new RelayCommand<Button>(p => true, p =>
            {
                string path = FindFilePath();
                if (path == "")
                    return;
                ProductImage2 = path;
            });
            AddImage3Command = new RelayCommand<Button>(p => true, p =>
            {
                string path = FindFilePath();
                if (path == "")
                    return;
                ProductImage3 = path;
            });
            SearchCommand = new RelayCommand<TextBox>(p => true, p => SearchProduct());
        }

        private void LoadProduct()
        {
            foreach (var item in Products.LoadProduct())
            {
                ListTemp.Add(item);
                ListProduct.Add(item);
            }
        }

        private void SearchProduct()
        {
            if (SearchContent == null)
            {
                ListProduct.Clear();
                foreach (var item in ListTemp)
                {
                    ListProduct.Add(item);
                    return;
                }
            }
            else
            {
                if (ListProduct == null || ListTemp == null)
                    return;
                ListProduct.Clear();
                foreach (var item in ListTemp)
                {
                    if (item.Id.ToUpper().Contains(SearchContent) || item.Name.ToUpper().Contains(SearchContent) || item.Description.ToUpper().Contains(SearchContent) ||
                        item.Price == SearchContent || item.Weight == SearchContent || item.Width == SearchContent ||
                        item.Height == SearchContent || item.Length == SearchContent || item.Image1.ToUpper().Contains(SearchContent) ||
                        item.Image2.ToUpper().Contains(SearchContent) || item.Image3.ToUpper().Contains(SearchContent) ||
                        item.Quantity.ToString() == SearchContent || item.CreatedBy.Id.ToString() == SearchContent)
                    {
                        ListProduct.Add(item);
                    }
                }

                if (ListProduct == null)
                {
                    foreach (var item in ListTemp)
                    {
                        ListProduct.Add(item);
                    }
                }
            }
        }

        private void CreateProduct()
        {
            if (!ProductName.Contains(ProductId))
            {
                MessageBox.Show("Tên sản phẩm cần có chứa mã sản phẩm.");
                return;
            }
            try
            {
                _ProductQuantity = Convert.ToInt32(_ProductQuantity);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Số hàng tồn phải là số nguyên.");
                return;
            }

            foreach (var item in ListProduct)
            {
                if (item.Id != ProductId)
                    continue;
                MessageBox.Show(@"Sản phẩm đã tồn tại.");
                return;
            }

            try
            {
                Products tempProduct = new Products
                {
                    Id = ProductId,
                    Name = ProductName,
                    Description = ProductDescription,
                    Weight = ProductWeight,
                    Width = ProductWidth,
                    Height = ProductHeight,
                    Length = ProductLength,
                    Price = ProductPrice,
                    Image1 = ProductImage1,
                    Image2 = ProductImage2,
                    Image3 = ProductImage3,
                    Quantity = ProductQuantity,
                    CreatedBy = new Accounts { Id = AccountId },
                    Status = "Chưa xóa"
                };
                Products.CreateProduct(tempProduct);
                ListProduct.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Tạo sản phẩm thất bại.");
            }
        }

        private void UpdateProduct()
        {
            try
            {
                _ProductQuantity = Convert.ToInt32(_ProductQuantity);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Số hàng tồn phải là số nguyên");
                return;
            }

            try
            {
                Products tempProduct = new Products
                {
                    Id = ProductId,
                    Name = ProductName,
                    Description = ProductDescription,
                    Weight = ProductWeight,
                    Width = ProductWidth,
                    Height = ProductHeight,
                    Length = ProductLength,
                    Price = ProductPrice,
                    Image1 = ProductImage1,
                    Image2 = ProductImage2,
                    Image3 = ProductImage3,
                    Quantity = ProductQuantity,
                };
                Products.UpdateProduct(tempProduct);
                ListProduct.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
        }

        private void DeleteProduct()
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Chọn sản phẩm muốn xóa.");
                return;
            }
            Products.DeleteProduct(SelectedItem.Id);
            ListProduct.Clear();
        }

        private string FindFilePath()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            return fileDialog.FileName;
        }

        #endregion Method
    }
}