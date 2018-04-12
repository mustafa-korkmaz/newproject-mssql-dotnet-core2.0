using System;

namespace Services
{
    interface INotificationService
    {
        /// <summary>
        /// sample notification service method
        /// </summary>
        /// <param name="message"></param>
        void SendNotification(string message);
    }
}
