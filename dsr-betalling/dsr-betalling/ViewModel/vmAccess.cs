using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using dsr_betalling.Annotations;
using dsr_betalling.Common;
using dsr_betalling.Handler;

namespace dsr_betalling.ViewModel
{
    public class vmAccess : INotifyPropertyChanged
    {
        private string _password;
        private string _username;

        public vmAccess()
        {
            LoginCommand = new RelayCommand(DsrLogin);
        }

        public ICommand LoginCommand { get; private set; }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Sends Username and Password to AuthorizationHandler.
        /// </summary>
        private async void DsrLogin()
        {
            try
            {
                var result = await AuthorizationHandler.DoLogin(Username, Password);
                if (!result)
                    throw new ArgumentException("Failed to log in");
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }

        #region NotifyPropertyChangedSupport

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            #endregion
        }
    }
}