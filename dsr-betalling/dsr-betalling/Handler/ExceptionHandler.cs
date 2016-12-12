using System;
using Windows.UI.Popups;

namespace dsr_betalling.Handler
{
    public static class ExceptionHandler
    {
        /// <summary>
        ///     Show a messagebox containing the Exception Message
        /// </summary>
        /// <param name="message"></param>
        public static async void ShowExceptionErrorAsync(string message)
        {
            var messageBox = new MessageDialog(message);
            await messageBox.ShowAsync();
        }
    }
}