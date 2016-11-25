using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace dsr_webservice.Controllers
{
    public class PurchaseItemsController : ApiController
    {
        private readonly dsr_betalling db = new dsr_betalling();

        // GET: api/PurchaseItems
        public IQueryable<PurchaseItem> GetPurchaseItems()
        {
            return db.PurchaseItems;
        }

        // GET: api/PurchaseItems/5
        [ResponseType(typeof(PurchaseItem))]
        public async Task<IHttpActionResult> GetPurchaseItem(int id)
        {
            var purchaseItem = await db.PurchaseItems.FindAsync(id);
            if (purchaseItem == null)
                return NotFound();

            return Ok(purchaseItem);
        }

        // PUT: api/PurchaseItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPurchaseItem(int id, PurchaseItem purchaseItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != purchaseItem.Id)
                return BadRequest();

            db.Entry(purchaseItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseItemExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PurchaseItems
        [ResponseType(typeof(PurchaseItem))]
        public async Task<IHttpActionResult> PostPurchaseItem(PurchaseItem purchaseItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.PurchaseItems.Add(purchaseItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = purchaseItem.Id}, purchaseItem);
        }

        // DELETE: api/PurchaseItems/5
        [ResponseType(typeof(PurchaseItem))]
        public async Task<IHttpActionResult> DeletePurchaseItem(int id)
        {
            var purchaseItem = await db.PurchaseItems.FindAsync(id);
            if (purchaseItem == null)
                return NotFound();

            db.PurchaseItems.Remove(purchaseItem);
            await db.SaveChangesAsync();

            return Ok(purchaseItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool PurchaseItemExists(int id)
        {
            return db.PurchaseItems.Count(e => e.Id == id) > 0;
        }
    }
}