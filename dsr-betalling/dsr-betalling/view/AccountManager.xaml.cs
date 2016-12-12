using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using dsr_betalling.Common;
using dsr_betalling.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace dsr_betalling.view
{
    /// <summary>
    ///     An empty page that can be used on its own or Navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountManager : Page
    {
        public AccountManager()
        {
            InitializeComponent();
        }

        private async void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var vievmodel = (vmAccount) DataContext;
            if (vievmodel.DeleteAccountCommand.CanExecute(null))
                vievmodel.DeleteAccountCommand.Execute(null);
            var dialog = new MessageDialog("Account deleted!");
            await dialog.ShowAsync();
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(AddAccount));
        }

        private void EditAccountButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(EditAccount));
        }

        private void AccountManagerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(AccountManager));
        }

        private void SalesButton_Onclick(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(Sale));
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(MainPage));
        }
    }
}