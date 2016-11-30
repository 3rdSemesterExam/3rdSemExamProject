﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace dsr_betalling.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Sale : Page
    {
        public Sale()
        {
            this.InitializeComponent();
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            PurchaseButton.Visibility = Visibility.Collapsed;
            ConfirmButton.Visibility = Visibility.Visible;
            ProductListView.IsEnabled = false;
            OrderedListView.IsEnabled = false;
            DiscountBox.IsEnabled = false;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            PurchaseButton.Visibility = Visibility.Visible;
            ConfirmButton.Visibility = Visibility.Collapsed;
            ProductListView.IsEnabled = true;
            OrderedListView.IsEnabled = true;
            DiscountBox.IsEnabled = true;
        }

        private void ProductListView_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            foreach (var item in ProductListView.SelectedItems)
            {
                OrderedListView.Items?.Add(item.ToString());
            }
        }

        private void OrderedListView_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            OrderedListView.Items?.RemoveAt(OrderedListView.SelectedIndex);
        }
    }
}
