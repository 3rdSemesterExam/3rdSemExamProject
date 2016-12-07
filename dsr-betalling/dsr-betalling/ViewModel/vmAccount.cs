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

        public ObservableCollection<Account> AccountObservableCollection
        {
            get { return _accountObservableCollection; }
            set
            {
                _accountObservableCollection = value;
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

        public int SelectedIndex { get; set; }

        public ICommand DeleteAccountCommand { get; set; }
        
        public vmAccount()
        {
            Populate();
            AccountObservableCollection = new ObservableCollection<Account>();

            DeleteAccountCommand = new RelayCommand();
        }

        public async void RemoveAccount(int accountId)
        {
            if (SelectedIndex > -1)
                AccountObservableCollection.RemoveAt(SelectedIndex);
            await AccountHandler.DeleteAccountAsync(SelectedIndex);
        }
   

        /// <summary>
        /// Populates a list when page in loaded.
        /// </summary>
        private async void Populate()
        {
            try
            {
                LoadingIcon = true;
                var listOfAccounts = await Facade.GetListAsync(new Account());
                //var listOfAccounts = AccountObservableCollection;
                foreach (var account in listOfAccounts)
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
        }
        #endregion
    }
}
