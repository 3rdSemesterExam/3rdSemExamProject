﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dsr_betalling.Handler;
using dsr_betalling.Common;
using dsr_betalling.Annotations;
using dsr_betalling.Model;
using dsr_betalling.ViewModel;

namespace dsr_betalling.ViewModel
{
    class vmSale : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _productList;
        private ObservableCollection<PurchaseItem> _purchaseItemObservableCollection;
        private bool _loadingIcon;

        /// <summary>
        /// Is bound to ProductsListView
        /// </summary>
        public ObservableCollection<Product> ProductList
        {
            get { return _productList; }
            set { _productList = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Is bound to OrderedListView
        /// </summary>
        public ObservableCollection<PurchaseItem> PurchaseItemObservableCollection
        {
            get { return _purchaseItemObservableCollection; }
            set { _purchaseItemObservableCollection = value; OnPropertyChanged(); }
        }

        public float Discount { get; set; }
        public string ChipId { get; set; }
        public int SelectedIndex { get; set; }

        public bool LoadingIcon
        {
            get { return _loadingIcon; }
            set { _loadingIcon = value; OnPropertyChanged(); }
        }

        // PurchaseCommands
        public ICommand MakePurchaseCommand { get; set; }
        public ICommand MoveItemCommand { get; set; }

        public vmSale()
        {
            ProductList = new ObservableCollection<Product>();
            PopulateListOfProducts();

            ProductList.Add(new Product());
            ProductList.Add(new Product());
            ProductList.Add(new Product());

            MakePurchaseCommand = new RelayCommand(MakePurchase);
            MoveItemCommand = new RelayCommand(MoveItem);
        }

        /// <summary>
        /// Populates a list when page in loaded.
        /// </summary>
        private async void PopulateListOfProducts()
        {
            try
            {
                LoadingIcon = true;
                var listOfProducts = await Facade.GetListAsync(new Product());
                //var listOfProducts = ProductList;
                foreach (var product in listOfProducts)
                {
                    ProductList.Add(product);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
        }

        /// <summary>
        /// Gets AccountId from chip. Verifies if account have funds registered. Adds purchase to purchase history
        /// </summary>
        public void MakePurchase()
        {
            try
            {
                var result = ChipHandler.GetAccountIdFromChipId(ChipId);
                //PurchaseHandler.MakePurchase(PurchaseItemsList, ChipId, Discount);   
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message); 
            }
        }

        //Will not work as intended
        /// <summary>
        /// Adds a selected item from the ProductsList to the OrderedList
        /// </summary>
        public void MoveItem()
        {
            try
            {
                if (SelectedIndex > -1)
                {
                    ProductList.Add(new Product());
                }
                else
                {
                    throw new ArgumentException("Failed moving item.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }
        #region PropertyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
