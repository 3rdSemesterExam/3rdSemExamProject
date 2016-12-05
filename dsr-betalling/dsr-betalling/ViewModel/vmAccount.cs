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
    class vmAccount : INotifyPropertyChanged
    {
        private ObservableCollection<Account> _accountObservableCollection;
        private bool _loadingIcon;
        private ObservableCollection<Chip> _chipObservableCollection;


        public ObservableCollection<Account> AccountObservableCollection
        {
            get { return _accountObservableCollection; }
            set
            {
                _accountObservableCollection = value;
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
        public ICommand DeleteAccountCommand { get; set; }
        public ICommand UpdateAccountCommand { get; set; }
        public ICommand AddChipCommand { get; set; }
        public ICommand DeleteChipcomand { get; set; }
        //


        public vmAccount()
        {
            //AccountManager
            AccountObservableCollection = new ObservableCollection<Account>();

            //AddAccount
            ChipObservableCollection = new ObservableCollection<Chip>();


            //EditAccount

        }

        // AccountManager
        public async void RemoveAccount(int accountId)
        {
            //AccountHandler.DeleteAccountAsync(accountId);
        }

        //AddAccount
        public void AddAccount()
        {
            //AccountHandler.CreateAccountAsync();
        }

        //EditAccount
        public void EditAccount()
        {
            //AccountHandler.UpdateAccountAsync()
        }
    

    private async void Populate()
        {
            try
            {
                LoadingIcon = true;
                //var listOfProducts = await Facade.GetListAsync(new Product());
                var listOfProducts =  AccountObservableCollection;
                foreach (var account in listOfProducts)
                {
                    AccountObservableCollection.Add(account);
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
        #region MyRegion
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            #endregion
        }
    }
}
