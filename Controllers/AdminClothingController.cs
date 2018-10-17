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
    public class AdminClothingController : Controller
    {
        // Fields
        private IClothingRepository clothingRepository;
        
        // Ctor
        public AdminClothingController (IClothingRepository repo) 
            => clothingRepository = repo;

        [HttpGet]
        public ViewResult ClothingList(int pageNumber = 1, int itemsPerPage = 4) 
            => View(new GenericListViewModel<Clothing>()
            {
                CollectionToSend = clothingRepository.Clothings
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = pageNumber,
                    TotalItems = clothingRepository.Clothings.Count(),
                    ItemsPerPage = itemsPerPage
                }
            });

        [HttpGet]
        public ViewResult CreateClothing() => View(new Clothing());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateClothing(
                [FromForm]Clothing clothing)
        {
            if(ModelState.IsValid)
            {
                clothingRepository.SaveClothing(clothing);
                TempData["SuccessMessage"] = 
                    $"{clothing.Name} clothing ({clothing.Id}) "
                    +"was successfully created";
                return View(new Clothing());
            }
            else{ return View(clothing); }
        } // End of method CreateClothing.

        [HttpGet]
        public ViewResult EditClothing(Guid id) =>
            View((clothingRepository[id]) != null ? 
                clothingRepository[id]
                : throw new ArgumentNullException(nameof(id),
                    "Unable to find color to edit") );



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditClothing(Clothing clothing)
        {
            if(ModelState.IsValid)
            {
                clothingRepository.SaveClothing(clothing);
                TempData["SuccessMessage"] = $"{clothing.Name} "
                +$" clothing ({clothing.Id})"
                + " was successfully edited";
                return View(new Clothing());
            }else{
                return View(clothing);
            }
        } // End of method EditClothing.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteClothing([FromForm]Guid clothingId)
        {
            if(clothingId != null)
            {
                Clothing clothing = clothingRepository.DeleteClothing(clothingId);
                if(clothing != null)
                {
                    TempData["SuccessMessage"] = 
                    $"{clothing.Name} ({clothing.Id}) was deleted";
                    return RedirectToAction(nameof(ClothingList));
                }else{
                    TempData["WarningMessage"] = $"Unable to delete {clothingId} ";
                    return RedirectToAction(nameof(ClothingList));
                }
            }else{
                TempData["ErrorMessage"] = 
                    $" Sorry, an unexpected error ocurred when deleting item";
                return RedirectToAction(nameof(ClothingList));
            }
        } // End of method DeleteClothing.

    } // End of class AdminClothingController.
} // End of namespace Camisetas.Controllers.