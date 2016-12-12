using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dsr_betalling.Common;
using dsr_betalling.Model;

namespace dsr_betalling.Handler
{
    public class ActivityLogHandler
    {
        /// <summary>
        ///     Adds an item to the Activity Log
        /// </summary>
        /// <param name="ActivityId"></param>
        /// <param name="AccountId"></param>
        /// <param name="UserId"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public static async Task<bool> AddActvityLogItem(int ActivityId, int AccountId, int UserId, float Amount)
        {
            return await Facade.PostAsync(new ActivityLog(ActivityId, AccountId, UserId, Amount, DateTime.Now));
        }

        /// <summary>
        ///     Gets an item from the Activity Log, by Activity Log Id
        /// </summary>
        /// <param name="ActivityLogItemId"></param>
        /// <returns></returns>
        public static async Task<ActivityLog> GetActivityLogItem(int ActivityLogItemId)
        {
            return await Facade.GetAsync(new ActivityLog(), ActivityLogItemId);
        }

        /// <summary>
        ///     Gets a List of activities, by Account Id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<ActivityLog>> GetActivtyLogListByAccountId(int accountId)
        {
            return await Facade.GetListByAccountIdAsync(new ActivityLog(), accountId);
        }

        /// <summary>
        ///     Gets a List of activities, by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<ActivityLog>> GetActivityLogListByUserId(int userId)
        {
            return await Facade.GetListByUserIdAsync(new ActivityLog(), userId);
        }
        /// <summary>
        ///     Gets a List of Activities, by Activity Id
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<ActivityLog>> GetActivityLogListByActivityId(int activityId)
        {
            return await Facade.GetListByActivityIdAsync(new ActivityLog(), activityId);
        }
    }
}