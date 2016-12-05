﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dsr_betalling.Handler;
using dsr_betalling.Common;
using dsr_betalling.Annotations;
using dsr_betalling.Model;

namespace dsr_betalling.ViewModel
{
    class vmSale : INotifyPropertyChanged
    {
        private ObservableCollection<PurchaseItems> _purchaseItems;
        private ObservableCollection<Product> _productList;

        public ObservableCollection<Product> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PurchaseItems> PurchaseItems
        {
            get { return _purchaseItems; }
            set
            {
                _purchaseItems = value;
                OnPropertyChanged();
            }
        }

        public float Discount { get; set; }
        public string ChipId { get; set; }

        // PurchaseCommands
        public ICommand MakePurchaseCommand { get; set; }

        public vmSale()
        {
            ProductList = new ObservableCollection<Product>();
            PurchaseItems = new ObservableCollection<PurchaseItems>();
            Populate();
        }

        private async void Populate()
        {
            try
            {
                //LoadingIcon = True;
                var listOfProducts = await Facade.GetListAsync(new Product());
                foreach (var product in listOfProducts)
                {
                    ProductList.Add(product);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // LoadingIcon = False;
            }
        }

        public void MakePurchase()
        {
            // PurchaseHandler.MakePurchase(PurchaseItemsList, ChipId, Discount);   
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
