using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using dsr_betalling.Handler;

namespace dsr_betalling.Common
{
    class NavigationHelper
    {
        /// <summary>
        /// Denne klasse gør at man kan navigaere fra C# koden i stedet for Xaml koden
        /// </summary>
        private static Frame _frame;

        public static void Navigate(Type page)
        {
            try
            {
                _frame = (Window.Current.Content as Frame);
                _frame?.Navigate(page);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }
    }
}
