using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Camisetas.Infrastructure.Filters;
using Camisetas.Infrastructure;
using Camisetas.Models.ViewModels;
using Camisetas.Models;
using Camisetas.DAL;

namespace Camisetas.Controllers
{
    [RepositoryExceptionFilter]
    public class AdminColorController : Controller
    {
        // Fields
        private IColorRepository colorRepository;

        // Ctor
        public AdminColorController(IColorRepository color)
            => this.colorRepository = color;

        // Methods

        [HttpGet]
        public ViewResult ColorList(int pageNumber = 1, int itemsPerPage = 4) 
            => View(new GenericListViewModel<Color>()
            {
                CollectionToSend = colorRepository.Colors
                    .Skip((pageNumber - 1 ) * itemsPerPage )
                    .Take(itemsPerPage),
                PagingInfo = new PagingInfo(){
                    CurrentPage = pageNumber,
                    ItemsPerPage = itemsPerPage,
                    TotalItems = colorRepository.Colors.Count()
                }
            });

        [HttpGet]
        public ViewResult CreateColor() 
            => View(new Color());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateColor(
                [FromForm]Color color)
        {
            if(ModelState.IsValid)
            {
                colorRepository.SaveColor(color);
                TempData["SuccessMessage"] = 
                    $"{color.Name} color ({color.Id}) was successfully created";
                return View(new Color());
            }
            else{ return View(color); }
        } // End of method CreateColor.


        [HttpGet]
        public ViewResult EditColor(Guid id) =>
            View((colorRepository[id]) != null ? 
                colorRepository[id]
                : throw new ArgumentNullException(nameof(id),
                    "Unable to find color to edit") );



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditColor(Color color)
        {
            if(ModelState.IsValid)
            {
                colorRepository.SaveColor(color);
                TempData["SuccessMessage"] = $"{color.Name} color ({color.Id})"
                + " was successfully edited";
                return View();
            }else{
                return View(color);
            }
        } // End of method EditColor.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteColor([FromForm]Guid colorId)
        {
            if(colorId != null)
            {
                Color color = colorRepository.DeleteColor(colorId);
                if(color != null)
                {
                    TempData["SuccessMessage"] = 
                    $"{color.Name} ({color.Id}) was deleted";
                    return RedirectToAction(nameof(ColorList));
                }else{
                    TempData["WarningMessage"] = $"Unable to delete {colorId} ";
                    return RedirectToAction(nameof(ColorList));
                }
            }else{
                TempData["ErrorMessage"] = 
                    $" Sorry, an unexpected error ocurred when deleting item";
                return RedirectToAction(nameof(ColorList));
            }
        } // End of method DeleteColor.

    } // End of class AdminColorController.

} // End of namespace Camisetas.Controllers.