using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace dsr_webservice.Controllers
{
    public class ActivityLogsController : ApiController
    {
        private readonly dsr_betalling db = new dsr_betalling();

        // GET: api/ActivityLogs
        public IQueryable<ActivityLog> GetActivityLogs()
        {
            return db.ActivityLogs;
        }

        // GET: api/ActivityLogs/5
        [ResponseType(typeof(ActivityLog))]
        public async Task<IHttpActionResult> GetActivityLog(int id)
        {
            var activityLog = await db.ActivityLogs.FindAsync(id);
            if (activityLog == null)
                return NotFound();

            return Ok(activityLog);
        }

        // PUT: api/ActivityLogs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActivityLog(int id, ActivityLog activityLog)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != activityLog.Id)
                return BadRequest();

            db.Entry(activityLog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLogExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ActivityLogs
        [ResponseType(typeof(ActivityLog))]
        public async Task<IHttpActionResult> PostActivityLog(ActivityLog activityLog)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.ActivityLogs.Add(activityLog);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = activityLog.Id}, activityLog);
        }

        // DELETE: api/ActivityLogs/5
        [ResponseType(typeof(ActivityLog))]
        public async Task<IHttpActionResult> DeleteActivityLog(int id)
        {
            var activityLog = await db.ActivityLogs.FindAsync(id);
            if (activityLog == null)
                return NotFound();

            db.ActivityLogs.Remove(activityLog);
            await db.SaveChangesAsync();

            return Ok(activityLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool ActivityLogExists(int id)
        {
            return db.ActivityLogs.Count(e => e.Id == id) > 0;
        }
    }
}