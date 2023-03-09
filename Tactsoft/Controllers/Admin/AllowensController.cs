using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AllowensController : Controller
    {
        private readonly IAllowensService _allowensService;
        public AllowensController(IAllowensService allowensService)
        {
            this._allowensService = allowensService;
        }
        // GET: AllowensController
        public async Task<IActionResult> Index()
        {
            var Allow = await _allowensService.GetAllAsync();
            return View(Allow);
        }
            // GET: AllowensController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Allow = await _allowensService.FindAsync(id);
            return View(Allow);
        }

        // GET: AllowensController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllowensController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Allowens allowens)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _allowensService.InsertAsync(allowens);
                    TempData["Success"] = "Save Successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            TempData["Error"] = "Unable to Create";
            return View(allowens);
        }

        // GET: AllowensController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Allow = await _allowensService.FindAsync(x => x.Id == id);
            return View(Allow);
        }

        // POST: AllowensController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Allowens allowens)
        {
            try
            {
                var Allow = await _allowensService.FindAsync(x => x.Id == id);

                if (Allow ==null)
                {
                    NotFound();
                }
                Allow.AllowensName = allowens.AllowensName;
                Allow.Comment = allowens.Comment;

                await _allowensService.UpdateAsync(allowens);
                TempData["Success"] = "Update Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            TempData["Error"] = "Unable to update";
            return View(allowens);
        }

        // GET: AllowensController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            var Allow = await _allowensService.FindAsync(x => x.Id == id);
            return View(Allow);
        }

        // POST: AllowensController/Delete/5
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Allowens allowens)
        {
            var Allow = await _allowensService.FindAsync(id);
            if (Allow != null)
            {
                await _allowensService.DeleteAsync(allowens);
                TempData["successAlert"] = " remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
