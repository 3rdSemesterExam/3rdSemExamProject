﻿using System;
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
    public class vmAccount : INotifyPropertyChanged
    {
        
        private ObservableCollection<Account> _accountObservableCollection;
        private bool _loadingIcon;
        private ObservableCollection<Account> _registeredAccountsCollection;


        public ObservableCollection<Account> RegisteredAccountsCollection
        {
            get { return _registeredAccountsCollection; }
            set { _registeredAccountsCollection = value; }
        }

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
        public int AccountId { get; set; }

        public ICommand DeleteAccountCommand { get; set; }

        public vmAccount()
        {
            RegisteredAccountsCollection = new ObservableCollection<Account>();
            AccountObservableCollection = new ObservableCollection<Account>();
            Populate();

            RegisteredAccountsCollection.Add(new Account());
            RegisteredAccountsCollection.Add(new Account());
            RegisteredAccountsCollection.Add(new Account());
            RegisteredAccountsCollection.Add(new Account());

            AccountObservableCollection.Add(new Account());
            AccountObservableCollection.Add(new Account());
            AccountObservableCollection.Add(new Account());

      

            //DeleteAccountCommand = new RelayCommand(RemoveAccount);
        }

        /// <summary>
        /// The last line in this method might get some serious refactoring
        /// </summary>
        //public async void RemoveAccount()
        //{
        //    if (SelectedIndex > -1)
        //        AccountObservableCollection.RemoveAt(SelectedIndex);
        //    await AccountHandler.DeleteAccountAsync(Int32.Parse(SelectedIndex.ToString(AccountId.ToString())));
        //}

        /// <summary>
        /// Populates a list when page in loaded.
        /// </summary>
        private void Populate()
        {
            try
            {
                LoadingIcon = true;
                //var listOfAccounts = await Facade.GetListAsync(new Account());
                var listOfAccounts = AccountObservableCollection;
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
