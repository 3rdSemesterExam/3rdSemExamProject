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
        private int _amount;
        private float _price;
        private int _fkProduct;

        //ProductItems
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged(); }
        }
        public float Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }
        public int Fk_Product
        {
            get { return _fkProduct; }
            set { _fkProduct = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<PurchaseItems> PurchaseItemsCollection { get; set; }

        // PurchaseCommands
        public ICommand AddPurchaseCommand { get; set; }
        public ICommand AddPurchaseItemsCommand { get; set; }

        public vmSale()
        {
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
