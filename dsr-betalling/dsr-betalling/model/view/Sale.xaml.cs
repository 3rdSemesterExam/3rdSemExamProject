using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using dsr_betalling.Common;
using dsr_betalling.ViewModel;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace dsr_betalling.view
{
    /// <summary>
    /// An empty page that can be used on its own or Navigated to within a Frame.
    /// </summary>
    public sealed partial class Sale : Page
    {
        public Sale()
        {
            this.InitializeComponent();
        }

        private async void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            PurchaseButton.Visibility = Visibility.Collapsed;
            ConfirmButton.Visibility = Visibility.Visible;
            ProductListView.IsEnabled = false;
            OrderedListView.IsEnabled = false;
            DiscountBox.IsEnabled = false;
            ConfirmChipBox.Focus(FocusState.Keyboard);
            var dialog = new MessageDialog("Awaiting NFC scan");
            await dialog.ShowAsync();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var vievmodel = (vmSale)DataContext;
            if (vievmodel.MakePurchaseCommand.CanExecute(null))
                vievmodel.MakePurchaseCommand.Execute(null);
            PurchaseButton.Visibility = Visibility.Visible;
            ConfirmButton.Visibility = Visibility.Collapsed;
            ProductListView.IsEnabled = true;
            OrderedListView.IsEnabled = true;
            DiscountBox.IsEnabled = true;
            var dialog = new MessageDialog("Purchase completed");
            await dialog.ShowAsync();
        }

        private void ProductListView_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var vievmodel = (vmSale)DataContext;
            if (vievmodel.MoveItemCommand.CanExecute(null))
                vievmodel.MoveItemCommand.Execute(null);

            //foreach (var item in ProductListView.SelectedItems)
            //{
            //    OrderedListView.Items?.Add(item.ToString());
            //}
        }

        private void OrderedListView_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            OrderedListView.Items?.RemoveAt(OrderedListView.SelectedIndex);
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (PurchaseButton.Visibility == Visibility.Collapsed)
            {
                PurchaseButton.Visibility = Visibility.Visible;
                ConfirmButton.Visibility = Visibility.Collapsed;
                ProductListView.IsEnabled = true;
                OrderedListView.IsEnabled = true;
                DiscountBox.IsEnabled = true;
            }
            else
            {
                OrderedListView.Items?.Clear();
            }
        }

        private void AccountManagerButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(AccountManager));
        }

        private void SalesButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(Sale));
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(MainPage));
        }
    }
}
