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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace dsr_betalling.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
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

        private void DeleteChipButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Chip deleted");
            dialog.ShowAsync();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Congratulations! A new Account has been registered");
            dialog.ShowAsync();
        }
    }
}
