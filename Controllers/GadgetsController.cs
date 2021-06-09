using System.Linq;
using System.Threading.Tasks;
using Dotnet5.MVC.CRUD.EF.Data;
using Dotnet5.MVC.CRUD.EF.Data.Entities;
using Dotnet5.MVC.CRUD.EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.MVC.CRUD.EF.Controllers
{
    public class GadgetsController : Controller
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public GadgetsController(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allGadtets = await _myWorldDbContext.Gadgets.OrderByDescending(_ => _.Id).ToListAsync();
            var model = new GadgetsContainerVm
            {
                AllGadgets = allGadtets
            };
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Gadgets model)
        {
            _myWorldDbContext.Gadgets.Add(model);
            await _myWorldDbContext.SaveChangesAsync();
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var gadget = await _myWorldDbContext.Gadgets.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (gadget == null)
            {
                return NotFound();
            }
            return View("Edit", gadget);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Gadgets modelToUpdate)
        {
            _myWorldDbContext.Update(modelToUpdate);
            await _myWorldDbContext.SaveChangesAsync();
            return RedirectToAction("All");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var gadgetToDelete = await _myWorldDbContext.Gadgets.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (gadgetToDelete != null)
            {
                _myWorldDbContext.Gadgets.Remove(gadgetToDelete);
                await _myWorldDbContext.SaveChangesAsync();
            }
            return RedirectToAction("All");
        }
    }
}