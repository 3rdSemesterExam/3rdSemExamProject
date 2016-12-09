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
        private float _balance;
        private float _funds;
        private string _chipId;
        private string _accountHolderFirstName;
        private ObservableCollection<Chip> _chipObservableCollection;
        private ObservableCollection<Purchase> _orderHistoryObservableCollection;

        public ObservableCollection<Purchase> OrderHistoryObservableCollection
        {
            get { return _orderHistoryObservableCollection; }
            set { _orderHistoryObservableCollection = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Chip> ChipObservableCollection
        {
            get { return _chipObservableCollection; }
            set { _chipObservableCollection = value; OnPropertyChanged(); }
        }

        public string AccountHolderName
        {
            get { return _accountHolderFirstName; }
            set { _accountHolderFirstName = value; OnPropertyChanged();}
        }

        public string ChipId
        {
            get { return _chipId; }
            set{ _chipId = value; OnPropertyChanged(); }
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

        public bool LoadingIcon
        {
            get { return _loadingIcon; }
            set { _loadingIcon = value; OnPropertyChanged(); }
        }
        private int Fk_Account { get; set; }
        public int SelectedIndex { get; set; }
        private int Id { get; set; }

        public ICommand AddAccountCommand { get; set; }
        public ICommand UpdateAccountCommand { get; set; }
        public ICommand AddChipCommand { get; set; }
        public ICommand DeleteChipCommand { get; set; }
        public ICommand AddFundsCommand { get; set; }

        public vmAddEditAccount(int id, int fkAccount)
        {
            Id = id;
            Fk_Account = fkAccount;
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

        public void AddFunds(float funds)
        {
            // point to handler which have the add funds method.
        }

        public void AddAccount()
        {
            try
            {
                var result = AccountHandler.CreateAccount(new Account(Id, AccountHolderName, Balance)).Result;
                if (!result) throw new ArgumentException("Error creating new account.");
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        /// <summary>
        /// Receives data from user and sends it to UpdateAccount.
        /// </summary>
        public void EditAccount()
        {
            try
            {
                var result = AccountHandler.UpdateAccount(new Account(Id, AccountHolderName, Balance)).Result;
                if (!result) throw new ArgumentException("Error updating account");
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        /// <summary>
        /// Receives data from user and sends it to AddChipToAccountAsync
        /// </summary>
        public void AddChip()
        {
            try
            {
                var result = ChipHandler.AddChipToAccountAsync(ChipId, Fk_Account).Result;
                if (result) ChipObservableCollection.Add(new Chip(ChipId, Fk_Account));
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        /// <summary>
        /// Sends a ChipId for the ChipHandler to delete.
        /// </summary>
        public async void DeleteChip()
        {
            try
            {
                var result =  await ChipHandler.DeleteChipFromAccountAsync(SelectedIndex.ToString(ChipId));
                if (result)
                {
                    if (SelectedIndex > -1)
                        ChipObservableCollection.RemoveAt(SelectedIndex);
                    else
                        throw new ArgumentException("Failed deleting a chip.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        /// <summary>
        /// Populates a list when page in loaded.
        /// </summary>
        private async void PopulateChip()
        {
            try
            {
                LoadingIcon = true;
                var listOfChips = await ChipHandler.GetChipList();
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
