using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesUI.Data;
using MoviesUI.Services;

namespace MoviesUI.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ActorsApiClient _actorsApriClient;

        public bool IsSuccessStatusCode { get; private set; }

        public ActorsController(ApplicationDbContext context, ActorsApiClient actorsApiClient)
        {
            _context = context;
            _actorsApriClient = actorsApiClient;
        }

        // GET: Actors
        public async Task<IActionResult> Index()
        {
            return View(await _actorsApriClient.GetActorsList());
        }

        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            // Amended to use webapi

            int ActorId = id.Value;
            var actor = await _actorsApriClient.GetActorItem(ActorId);

            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);

        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _actorsApriClient.CreateActorItem(actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Amended to use webapi

            int ActorId = id.Value;
            var actor = await _actorsApriClient.GetActorItem(ActorId);

            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age")] Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            // Webapi call
            if (ModelState.IsValid)
            {
                await _actorsApriClient.UpdateActorItem(id, actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            // Amended to use webapi

            int ActorId = id.Value;
            var actor = await _actorsApriClient.GetActorItem(ActorId);

            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Call delete service
            await _actorsApriClient.DeleteActorItem(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actor.Any(e => e.Id == id);
        }
    }
}
