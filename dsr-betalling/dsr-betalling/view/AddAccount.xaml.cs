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
    public sealed partial class AddAccount : Page
    {
        public AddAccount()
        {
            this.InitializeComponent();
        }

        private void AddChipButton_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new MessageDialog("Chip Added");
            //dialog.ShowAsync();
        }

        private async void DeleteChipButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Chip deleted");
            await dialog.ShowAsync();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Congratulations! A new Account has been registered");
            await dialog.ShowAsync();
            NavigationHelper.Navigate(typeof(Sale));
        }

        private void SalesButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(Sale));
        }

        private void AccountManagerButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(AccountManager));
        }

        private void LogOutButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(MainPage));
        }
    }
}
