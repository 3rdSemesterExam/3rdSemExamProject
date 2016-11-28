using System;
using Windows.UI.Popups;

namespace dsr_betalling.handler
{
    public static class ExceptionHandler
    {
        /// <summary>
        /// Denne metode viser en text box med en valgt fejl
        /// </summary>
        /// <param name="message"></param>
        public static async void ShowExceptionErrorAsync(string message)
        {
            var messageBox = new MessageDialog(message);
            await messageBox.ShowAsync();
        }
    }
}
