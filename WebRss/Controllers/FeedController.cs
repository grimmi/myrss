using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dotrss.Database;

namespace WebRss.Controllers
{
    public class FeedController : Controller
    {
        private FeedModelContainer db = new FeedModelContainer();

        // GET: /Feed/
        public async Task<ActionResult> Index()
        {
            return View(await db.Feeds.ToListAsync());
        }

        // GET: /Feed/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = await db.Feeds.FindAsync(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // GET: /Feed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Feed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Name,Uri,LastUpdated,FeedType")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                db.Feeds.Add(feed);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(feed);
        }

        // GET: /Feed/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = await db.Feeds.FindAsync(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // POST: /Feed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Name,Uri,LastUpdated,FeedType")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feed).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(feed);
        }

        // GET: /Feed/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = await db.Feeds.FindAsync(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // POST: /Feed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Feed feed = await db.Feeds.FindAsync(id);
            db.Feeds.Remove(feed);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
