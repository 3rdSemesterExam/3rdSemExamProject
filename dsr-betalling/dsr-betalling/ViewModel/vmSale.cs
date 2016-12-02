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
        private string _productName;
        private float _productPrice;
        private int _purchaseId;
        private int _fkAccount;
        private int _fkUser;
        private float _totalPrice;
        private DateTime _created;
        private string _resourceUri;
        private string _verboseName;

        // Product 
        public int ProductId
        {
            get { return _productId; }
            set  { _productId = value; OnPropertyChanged(); }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; OnPropertyChanged(); }
        }

        public float ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<PurchaseItems> PurchaseItemsCollection { get; set; }

        // Purchase
        //public int PurchaseId
        //{
        //    get { return _purchaseId; }
        //    set { _purchaseId = value; OnPropertyChanged(); }
        //}

        //public int FK_Account
        //{
        //    get { return _fkAccount; }
        //    set { _fkAccount = value; OnPropertyChanged(); }
        //}

        //public int FK_User
        //{
        //    get { return _fkUser; }
        //    set { _fkUser = value; OnPropertyChanged(); }
        //}

        //public float TotalPrice
        //{
        //    get { return _totalPrice; }
        //    set { _totalPrice = value; OnPropertyChanged(); }
        //}

        //public DateTime Created
        //{
        //    get { return _created; }
        //    set { _created = value; OnPropertyChanged(); }
        //}

        //public string ResourceUri
        //{
        //    get { return _resourceUri; }
        //    set { _resourceUri = value; OnPropertyChanged(); }
        //}

        public string VerboseName
        {
            get { return _verboseName; }
            set { _verboseName = value; OnPropertyChanged(); }
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
