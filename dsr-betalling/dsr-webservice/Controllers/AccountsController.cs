﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace dsr_webservice.Controllers
{
    public class AccountsController : ApiController
    {
        private readonly dsr_betalling db = new dsr_betalling();

        // GET: api/Accounts
        public IQueryable<Account> GetAccounts()
        {
            return db.Accounts;
        }

        // GET: api/Accounts/5
        [ResponseType(typeof(Account))]
        public async Task<IHttpActionResult> GetAccount(int id)
        {
            var account = await db.Accounts.FindAsync(id);
            if (account == null)
                return NotFound();

            return Ok(account);
        }

        // PUT: api/Accounts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAccount(int id, Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != account.Id)
                return BadRequest();

            db.Entry(account).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Accounts
        [ResponseType(typeof(Account))]
        public async Task<IHttpActionResult> PostAccount(Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Accounts.Add(account);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = account.Id}, account);
        }

        // DELETE: api/Accounts/5
        [ResponseType(typeof(Account))]
        public async Task<IHttpActionResult> DeleteAccount(int id)
        {
            var account = await db.Accounts.FindAsync(id);
            if (account == null)
                return NotFound();

            db.Accounts.Remove(account);
            await db.SaveChangesAsync();

            return Ok(account);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool AccountExists(int id)
        {
            return db.Accounts.Count(e => e.Id == id) > 0;
        }
    }
}