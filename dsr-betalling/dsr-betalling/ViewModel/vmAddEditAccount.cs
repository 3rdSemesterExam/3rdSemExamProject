using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dsr_betalling.Annotations;
using dsr_betalling.Common;
using dsr_betalling.Handler;
using dsr_betalling.Model;

namespace dsr_betalling.ViewModel
{
    public class vmAddEditAccount : INotifyPropertyChanged
    {
        private bool _loadingIcon;
        private ObservableCollection<Chip> _chipObservableCollection;
        private float _balance;
        private float _funds;
        private string _chipId;
        private string _accountHolderLastName;
        private string _accountHolderFirstName;
        private ObservableCollection<Purchase> _orderHistoryObservableCollection;

        public ObservableCollection<Purchase> OrderHistoryObservableCollection
        {
            get { return _orderHistoryObservableCollection; }
            set { _orderHistoryObservableCollection = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Chip> ChipObservableCollection
        {
            get { return _chipObservableCollection; }
            set
            {
                _chipObservableCollection = value;
                OnPropertyChanged();
            }
        }

        public int Id { get; set; }

        //NOTE: AccountHolderName is split into FirstName and LastName
        public string AccountHolderName
        {
            get { return _accountHolderFirstName; }
            set { _accountHolderFirstName = value; OnPropertyChanged(); }
        }

        public string ChipId
        {
            get { return _chipId; }
            set { _chipId = value; OnPropertyChanged(); }
        }

        public float Balance
        {
            get { return _balance; }
            set { _balance = value; OnPropertyChanged(); }
        }

        public float Funds
        {
            get { return _funds; }
            set { _funds = value; OnPropertyChanged(); }
        }
        public int Fk_Account { get; set; }
        public int SelectedIndex { get; set; }

        public bool LoadingIcon
        {
            get { return _loadingIcon; }
            set
            {
                _loadingIcon = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddAccountCommand { get; set; }
        public ICommand UpdateAccountCommand { get; set; }
        public ICommand AddChipCommand { get; set; }
        public ICommand DeleteChipCommand { get; set; }
        public ICommand AddFundsCommand { get; set; }

        public vmAddEditAccount()
        {
            ChipObservableCollection = new ObservableCollection<Chip>();

            //Populate is only for EditAccount
            Populate();

            AddAccountCommand = new RelayCommand(AddAccount);
            UpdateAccountCommand = new RelayCommand(EditAccount);
            AddChipCommand = new RelayCommand(AddChip);
            DeleteChipCommand = new RelayCommand(DeleteChip);
            //AddFundsCommand = new RelayCommand(AddFunds());

            OrderHistoryObservableCollection = new ObservableCollection<Purchase>();

            OrderHistoryObservableCollection.Add(new Purchase(1, 1, 500, DateTime.Now));
            OrderHistoryObservableCollection.Add(new Purchase(2, 1, 20, DateTime.Now));

            ChipObservableCollection.Add(new Chip());
            ChipObservableCollection.Add(new Chip());
            ChipObservableCollection.Add(new Chip());
        }

        public async void AddFunds(float funds)
        {
            // point to handler which have the add funds method.
        }

        //AddAccount
        //NOTE: AccountHolderName is split into FirstName and LastName
        public async void AddAccount()
        {
            await AccountHandler.CreateAccount(new Account(Id, AccountHolderName, Balance));
        }

        //EditAccount
        //NOTE: AccountHolderName is split into FirstName and LastName
        public async void EditAccount()
        {
            //await AccountHandler.UpdateAccountAsync(new Account(Id, AccountHolderFirstName, AccountHolderLastName, Balance));
        }

        public async void AddChip()
        {
            ChipObservableCollection.Add(new Chip());
            await ChipHandler.AddChipToAccountAsync(ChipId, Fk_Account);
        }

        public async void DeleteChip()
        {
            if (SelectedIndex > -1)
                ChipObservableCollection.RemoveAt(SelectedIndex);
            await ChipHandler.DeleteChipFromAccountAsync(SelectedIndex.ToString(ChipId));
        }

        /// <summary>
        /// Populates a list when page in loaded.
        /// </summary>
        private async void Populate()
        {
            try
            {
                LoadingIcon = true;
                //var listOfChips = await Facade.GetListAsync(new Chip());
                var listOfChips = ChipObservableCollection;
                foreach (var chip in listOfChips)
                {
                    ChipObservableCollection.Add(chip);
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
        #region NotifyPropertyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
