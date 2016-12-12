using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using dsr_betalling.Common;
using dsr_betalling.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace dsr_betalling.view
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LogInButton_OnClick(object sender, RoutedEventArgs e)
        {
            var vievmodel = (vmAccess) DataContext;
            if (vievmodel.LoginCommand.CanExecute(null))
                vievmodel.LoginCommand.Execute(null);
            NavigationHelper.Navigate(typeof(Sale));
        }
    }
}