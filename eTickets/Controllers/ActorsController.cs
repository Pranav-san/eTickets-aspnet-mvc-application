using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fullname, profilePicURL, Bio")] Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddAsync(actor);

            return RedirectToAction(nameof(Index));


        }

        //GET: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null)
                return View("NotFound");
            else
            {
                return View(actorDetails);
            }
        }

        //GET: Actors/Edit/1    
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null)
                return View("NotFound");
            else
            {
                return View(actorDetails);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id, Fullname, profilePicURL, Bio")] int id, Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Index));


        }

        //GET: Actors/Delete/1    
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null)
                return View("NotFound");
            else
            {
                return View(actorDetails);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed([Bind("Id, Fullname, profilePicURL, Bio")] int id, Actor actor)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));




        }

    }
}
