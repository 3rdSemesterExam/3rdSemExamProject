using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using dsr_betalling.Annotations;
using dsr_betalling.Common;
using dsr_betalling.Handler;

namespace dsr_betalling.ViewModel
{
    class vmAccess : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        public ICommand LoginCommand { get; set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public vmAccess()
        {
           LoginCommand = new RelayCommand(Login);
        }
    
        public void Login()
        {
            
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
