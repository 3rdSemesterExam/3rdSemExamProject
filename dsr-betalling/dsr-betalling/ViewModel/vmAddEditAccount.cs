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

        public int Id { get; set; }

        //NOTE: AccountHolderName is split into FirstName and LastName
        public string AccountHolderName
        {
            get { return _accountHolderFirstName; }
            set
            {
                _accountHolderFirstName = value;
                OnPropertyChanged();
            }
        }

        public string ChipId
        {
            get { return _chipId; }
            set
            {
                _chipId = value;
                OnPropertyChanged();
            }
        }

        public float Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                OnPropertyChanged();
            }
        }

        public float Funds
        {
            get { return _funds; }
            set
            {
                _funds = value;
                OnPropertyChanged();
            }
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
            OrderHistoryObservableCollection = new ObservableCollection<Purchase>();
            Populate(); //Populate is only for EditAccount

            AddAccountCommand = new RelayCommand(AddAccount);
            UpdateAccountCommand = new RelayCommand(EditAccount);
            AddChipCommand = new RelayCommand(AddChip);
            DeleteChipCommand = new RelayCommand(DeleteChip);
            //AddFundsCommand = new RelayCommand(AddFunds());

            //MOCK OBJECTS
            //OrderHistoryObservableCollection.Add(new Purchase(1, 1, 500, DateTime.Now));
            //OrderHistoryObservableCollection.Add(new Purchase(2, 1, 20, DateTime.Now));

            //ChipObservableCollection.Add(new Chip());
            //ChipObservableCollection.Add(new Chip());
            //ChipObservableCollection.Add(new Chip());
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
                if (!result)
                {
                    throw new ArgumentException("Error creating new account.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        //EditAccount
        //NOTE: AccountHolderName is split into FirstName and LastName
        public void EditAccount()
        {
            try
            {
                var result = AccountHandler.UpdateAccount(new Account(Id, AccountHolderName, Balance)).Result;
                if (!result)
                {
                    throw new ArgumentException("Error updating account");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        public void AddChip()
        {
            try
            {
                var result = ChipHandler.AddChipToAccountAsync(ChipId, Fk_Account).Result;
                if (result)
                {
                    ChipObservableCollection.Add(new Chip(ChipId, Fk_Account));
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        public void DeleteChip()
        {
            try
            {
                var result = ChipHandler.DeleteChipFromAccountAsync(SelectedIndex.ToString(ChipId)).Result;
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
        private async void Populate()
        {
            try
            {
                LoadingIcon = true;
                var listOfChips = await Facade.GetListAsync(new Chip());
                //var listOfChips = ChipObservableCollection;
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
