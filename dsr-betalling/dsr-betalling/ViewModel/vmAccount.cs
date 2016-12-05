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
        public ObservableCollection<Account> AccountObservableCollection { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
        

        public vmAccount()
        {
            //AccountManager
            AccountObservableCollection = new ObservableCollection<Account>();
   
            //AddAccoun

            //EditAccount

        }

        // AccountManager
        public async void RemoveAccount(int accountId)
        {
            //AccountHandler.DeleteAccountAsync(accountId);
        }

        //AddAccount

        //EditAccount

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
