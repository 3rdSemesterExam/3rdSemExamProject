using System.Collections.Generic;
using System.Threading.Tasks;
using dsr_betalling.Common;
using dsr_betalling.Model;

namespace dsr_betalling.Handler
{
    public class ActivityHandler
    {
        /// <summary>
        ///     Gets a List of Activities from the Webservice
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Activity>> GetActivityList()
        {
            return await Facade.GetListAsync(new Activity());
        }

        /// <summary>
        ///     Adds an Activity to the Webservice
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static async Task<bool> AddActivity(string title)
        {
            return await Facade.PostAsync(new Activity(title));
        }

        /// <summary>
        ///     Removes an Actvity from the Webservice, by Activity Id
        /// </summary>
        /// <param name="ActivityId"></param>
        /// <returns></returns>
        public static async Task<bool> RemoveActivity(int ActivityId)
        {
            return await Facade.DeleteAsync(new Activity(), ActivityId);
        }
    }
}