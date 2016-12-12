using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using dsr_betalling.Annotations;
using dsr_betalling.Common;
using dsr_betalling.Handler;
using dsr_betalling.Model;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace dsr_betalling.ViewModel
{
    public class vmAddEditAccount : INotifyPropertyChanged
    {
        private string _accountHolderFirstName;
        private float _balance;
        private string _chipId;
        private ObservableCollection<Chip> _chipObservableCollection;
        private float _funds;
        private bool _loadingIcon;
        private ObservableCollection<Purchase> _orderHistoryObservableCollection;

        public vmAddEditAccount(int accountId, int fkAccount, int selectedIndex) : this()
        {
            AccountId = accountId;
            Fk_Account = fkAccount;
            SelectedIndex = selectedIndex;
            ChipObservableCollection = new ObservableCollection<Chip>();
            OrderHistoryObservableCollection = new ObservableCollection<Purchase>();
            PopulateChip(); //Populate is only for EditAccount
            //PopulateHistory();

            AddAccountCommand = new RelayCommand(AddAccount);
            UpdateAccountCommand = new RelayCommand(EditAccount);
            AddChipCommand = new RelayCommand(AddChip);
            DeleteChipCommand = new RelayCommand(DeleteChip);
            //AddFundsCommand = new RelayCommand(AddFunds());
        }

        public vmAddEditAccount()
        {
        }

        public ObservableCollection<Purchase> OrderHistoryObservableCollection
        {
            get { return _orderHistoryObservableCollection; }
            set
            {
                _orderHistoryObservableCollection = value;
                OnPropertyChanged();
            }
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

        private string AccountHolderName
        {
            get { return _accountHolderFirstName; }
            set
            {
                _accountHolderFirstName = value;
                OnPropertyChanged();
            }
        }

        private string ChipId
        {
            get { return _chipId; }
            set
            {
                _chipId = value;
                OnPropertyChanged();
            }
        }

        private float Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                OnPropertyChanged();
            }
        }

        private float Funds
        {
            get { return _funds; }
            set
            {
                _funds = value;
                OnPropertyChanged();
            }
        }

        private bool LoadingIcon
        {
            get { return _loadingIcon; }
            set
            {
                _loadingIcon = value;
                OnPropertyChanged();
            }
        }

        private int Fk_Account { get; }
        public int SelectedIndex { get; }
        private int AccountId { get; }

        public ICommand AddAccountCommand { get; set; }
        public ICommand UpdateAccountCommand { get; set; }
        public ICommand AddChipCommand { get; set; }
        public ICommand DeleteChipCommand { get; set; }
        public ICommand AddFundsCommand { get; set; }

        public bool AddFunds(float funds)
        {
            var account = AccountHandler.GetAccount(AccountId).Result;
            account.AddFunds(funds);
            return AccountHandler.UpdateAccount(account).Result;
            // point to handler which have the add funds method.
        }

        private void AddAccount()
        {
            try
            {
                var result = AccountHandler.CreateAccount(new Account(AccountId, AccountHolderName, Balance)).Result;
                if (!result) throw new ArgumentException("Error creating new account.");
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        /// <summary>
        ///     Receives data from user and sends it to UpdateAccount.
        /// </summary>
        private void EditAccount()
        {
            try
            {
                var result = AccountHandler.UpdateAccount(new Account(AccountId, AccountHolderName, Balance)).Result;
                if (!result) throw new ArgumentException("Error updating account");
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        /// <summary>
        ///     Receives data from user and sends it to AddChipToAccountAsync
        /// </summary>
        private void AddChip()
        {
            try
            {
                var result = ChipHandler.AddChipToAccountAsync(ChipId, AccountId).Result;
                if (result) ChipObservableCollection.Add(new Chip(ChipId, AccountId));
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        /// <summary>
        ///     Sends a ChipId for the ChipHandler to delete.
        /// </summary>
        private async void DeleteChip()
        {
            try
            {
                var result = await ChipHandler.DeleteChipFromAccountAsync(SelectedIndex.ToString(ChipId));
                if (!result) return;
                if (SelectedIndex > -1)
                    ChipObservableCollection.RemoveAt(SelectedIndex);
                else
                    throw new ArgumentException("Failed deleting a chip.");
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        /// <summary>
        ///     Populates a list when page in loaded.
        /// </summary>
        private async void PopulateChip()
        {
            try
            {
                LoadingIcon = true;
                var listOfChips = await ChipHandler.GetChipList();
                foreach (var chip in listOfChips)
                    ChipObservableCollection.Add(chip);
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