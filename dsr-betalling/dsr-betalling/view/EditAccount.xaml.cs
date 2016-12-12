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
    public sealed partial class EditAccount : Page
    {
        public EditAccount()
        {
            InitializeComponent();
        }

        private async void AddChipButton_Click(object sender, RoutedEventArgs e)
        {
            var vievmodel = (vmAddEditAccount) DataContext;
            if (vievmodel.AddAccountCommand.CanExecute(null))
                vievmodel.AddAccountCommand.Execute(null);
            var dialog = new MessageDialog("Chip added!");
            await dialog.ShowAsync();
        }

        private async void DeleteChipButton_Click(object sender, RoutedEventArgs e)
        {
            var vievmodel = (vmAddEditAccount) DataContext;
            if (vievmodel.DeleteChipCommand.CanExecute(null))
                vievmodel.DeleteChipCommand.Execute(null);
            var dialog = new MessageDialog("Chip deleted!");
            await dialog.ShowAsync();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Changes have been saved!");
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

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(MainPage));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(AccountManager));
        }
    }
}