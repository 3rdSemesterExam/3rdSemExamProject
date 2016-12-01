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
using dsr_betalling.common;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace dsr_betalling.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditAccount : Page
    {
        public EditAccount()
        {
            this.InitializeComponent();
        }

        private async void AddChipButton_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new MessageDialog("Chip added!");
            //await dialog.ShowAsync();
        }

        private async void DeleteChipButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Chip deleted!");
            await dialog.ShowAsync();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Changes have been saved!");
            await dialog.ShowAsync();
            NavigationHelper.navigate(typeof(Sale));
        }

        private void SalesButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationHelper.navigate(typeof(Sale));
        }

        private void AccountManagerButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationHelper.navigate(typeof(AccountManager));
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.navigate(typeof(MainPage));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.navigate(typeof(AccountManager));
        }
    }
}
