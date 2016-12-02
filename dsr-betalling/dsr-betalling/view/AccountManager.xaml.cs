using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using dsr_betalling.Common;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace dsr_betalling.view
{
    /// <summary>
    /// An empty page that can be used on its own or Navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountManager : Page
    {
        public AccountManager()
        {
            this.InitializeComponent();
        }

        private async void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
