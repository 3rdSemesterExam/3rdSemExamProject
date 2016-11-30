using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
//using dsr_betalling.handler;

namespace dsr_betalling.common
{
    class NavigationHelper
    {
        /// <summary>
        /// Denne klasse gør at man kan navigaere fra C# koden i stedet for Xaml koden
        /// </summary>
        private static Frame _frame;

        public static void navigate(Type page)
        {
            try
            {
                _frame = (Window.Current.Content as Frame);
                _frame?.Navigate(page); // Hvis _frame IKKE er null
            }
            catch (Exception ex)
            {
                throw new Exception();
                //ExceptionHandler.ShowExceptionErrorAsync(ex.Message);
            }
        }
    }
}
