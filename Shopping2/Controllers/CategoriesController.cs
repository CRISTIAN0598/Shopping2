using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping2.Data;
using Shopping2.Data.Entities;
using Shopping2.Helpers;
using Vereyon.Web;
using static Shopping2.Helpers.ModalHelper;

namespace Shopping2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController: Controller
    {
        private readonly DataContext _context;
        private readonly IFlashMessage _flashMessage;

        public CategoriesController(DataContext context,IFlashMessage flashMessage)
        {
            _context = context;
            _flashMessage = flashMessage;
        }

        public async Task<IActionResult> Index()
        {
           
          return View(await _context.Category
              .Include(c => c.ProductCategories)
              .ToListAsync());

        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [NoDirectAccess]
        public async Task<IActionResult> Delete(int? id)
        {
            Category category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
            try
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
                _flashMessage.Info("Registro borrado.");
            }
            catch
            {
                _flashMessage.Danger("No se puede borrar la categoría porque tiene registros relacionados.");
            }

            return RedirectToAction(nameof(Index));
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Category());
            }
            else
            {
                Category category = await _context.Category.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0) //Insert
                    {
                        _context.Add(category);
                        await _context.SaveChangesAsync();
                        _flashMessage.Info("Registro creado.");
                    }
                    else //Update
                    {
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                        _flashMessage.Info("Registro actualizado.");
                    }
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe una categoría con el mismo nombre.");
                    }
                    else
                    {
                        _flashMessage.Danger(dbUpdateException.InnerException.Message);
                    }
                    return View(category);
                }
                catch (Exception exception)
                {
                    _flashMessage.Danger(exception.Message);
                    return View(category);
                }

                return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAll", _context.Category.Include(c => c.ProductCategories).ToList()) });

            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddOrEdit", category) });
        }

    }
}
