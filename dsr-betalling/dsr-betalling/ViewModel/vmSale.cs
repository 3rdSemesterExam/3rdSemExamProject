using System;
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
        private int _productId;
        private float _productPrice;

        private float _totalPrice;

        // Product 
        public int ProductId
        {
            get { return _productId; }
            set  { _productId = value; OnPropertyChanged(); }
        }
        public float ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<PurchaseItems> PurchaseItemsCollection { get; set; }

        //Purchase
        public float TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; OnPropertyChanged(); }
        }

        // PurchaseCommands
        public Handler.PurchaseHandler PurchaseHandler{ get; }

        public ICommand AddPurchaseCommand { get; set; }
        public ICommand AddPurchaseItemsCommand { get; set; }

        public vmSale()
        {
            PurchaseHandler = new Handler.PurchaseHandler();
            
            //AddPurchaseCommand = new RelayCommand(PurchaseHandler.PostPurchase);
            //AddPurchaseItemsCommand = new RelayCommand(PurchaseHandler.PostPurchaseItems); 
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
