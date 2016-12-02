using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace dsr_webservice.Controllers
{
    public class ChipsController : ApiController
    {
        private readonly dsr_betalling db = new dsr_betalling();

        // GET: api/Chips
        public IQueryable<Chip> GetChips()
        {
            return db.Chips;
        }

        // GET: api/Chips/5
        [ResponseType(typeof(Chip))]
        public async Task<IHttpActionResult> GetChip(int id)
        {
            var chip = await db.Chips.FindAsync(id);
            if (chip == null)
                return NotFound();

            return Ok(chip);
        }

        // PUT: api/Chips/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChip(int id, Chip chip)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != chip.Id)
                return BadRequest();

            db.Entry(chip).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChipExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Chips
        [ResponseType(typeof(Chip))]
        public async Task<IHttpActionResult> PostChip(Chip chip)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Chips.Add(chip);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = chip.Id}, chip);
        }

        // DELETE: api/Chips/5
        [ResponseType(typeof(Chip))]
        public async Task<IHttpActionResult> DeleteChip(int id)
        {
            var chip = await db.Chips.FindAsync(id);
            if (chip == null)
                return NotFound();

            db.Chips.Remove(chip);
            await db.SaveChangesAsync();

            return Ok(chip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool ChipExists(int id)
        {
            return db.Chips.Count(e => e.Id == id) > 0;
        }
    }
}