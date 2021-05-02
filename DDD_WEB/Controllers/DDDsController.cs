using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DDD_EXAMPLE.Controllers
{

    public class DDDsController : Controller
    {
        private readonly InterfaceDDDApp _InterfaceDDDApp;

        public DDDsController(InterfaceDDDApp InterfaceDDDApp)
        {
            _InterfaceDDDApp = InterfaceDDDApp;
        }

        // GET: DDDs
        public async Task<IActionResult> Index()
        {
            return View(await _InterfaceDDDApp.List());
        }

       
        // GET: DDDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DDDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Origin,Destiny,PricePerMinute")] DDD ddd)
        {
            if (ModelState.IsValid)
            {
                await _InterfaceDDDApp.AddDDD(ddd);

                if (ddd.Notifications.Any())
                {
                    foreach (var item in ddd.Notifications)
                    {
                        ModelState.AddModelError(item.PropertyName, item.Message);
                    }

                    return View("Create", ddd);
                }


            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DDDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dddd = await _InterfaceDDDApp.GetEntityById((int)id);
            if (dddd == null)
            {
                return NotFound();
            }
            return View(dddd);
        }

        // POST: DDDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Origin,Destiny,PricePerMinute")] DDD ddd)
        {
            if (id != ddd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _InterfaceDDDApp.UpdateDDD(ddd);

                    if (ddd.Notifications.Any())
                    {
                        foreach (var item in ddd.Notifications)
                        {
                            ModelState.AddModelError(item.PropertyName, item.Message);
                        }

                        return View("Edit", ddd);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DDDExists(ddd.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ddd);
        }

        // GET: DDDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ddd = await _InterfaceDDDApp.GetEntityById((int)id);
            if (ddd == null)
            {
                return NotFound();
            }

            return View(ddd);
        }

        // POST: DDDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ddd = await _InterfaceDDDApp.GetEntityById(id);
            await _InterfaceDDDApp.Delete(ddd);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DDDExists(int id)
        {

            var objeto = await _InterfaceDDDApp.GetEntityById(id);

            return objeto != null;
        }
    }
}