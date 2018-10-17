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
    public class AdminSizeController : Controller
    {
        // Fields
        private ISizeRepository sizeRepository;

        // Ctor
        public AdminSizeController(ISizeRepository repo) => sizeRepository = repo;

        [HttpGet]
        public ViewResult SizeList(int pageNumber = 1, int itemsPerPage = 4) 
            => View(new GenericListViewModel<Size>()
            {
                CollectionToSend = sizeRepository.Sizes
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = pageNumber,
                    TotalItems = sizeRepository.Sizes.Count(),
                    ItemsPerPage = itemsPerPage
                }
            });

        [HttpGet]
        public ViewResult CreateSize() => View(new Size());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSize([FromForm]Size size)
        {
            if(ModelState.IsValid)
            {
                sizeRepository.SaveSize(size);
                TempData["SuccessMessage"] = 
                    $"{size.Name} ({size.Id}) was successfully created";
                return View(new Size());
            }
            else{ return View(size); }
        } // End of method CreateSize

        [HttpGet]
        public ViewResult EditSize(Guid id) =>
            View((sizeRepository[id]) != null ? 
                sizeRepository[id]
                : throw new ArgumentNullException(nameof(id),
                    "Unable to find size to edit") );



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSize(Size size)
        {
            if(ModelState.IsValid)
            {
                sizeRepository.SaveSize(size);
                TempData["SuccessMessage"] = $"{size.Name} ({size.Id})"
                + " was successfully edited";
                return View();
            }else{
                return View(size);
            }
        } // End of method EditColor.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSize([FromForm]Guid sizeId)
        {
            if(sizeId != null)
            {
                Size size = sizeRepository.DeleteSize(sizeId);
                if(size != null)
                {
                    TempData["SuccessMessage"] = 
                    $"{size.Name} size ({size.Id}) was deleted";
                    return RedirectToAction(nameof(SizeList));
                }else{
                    TempData["WarningMessage"] = $"Unable to delete {sizeId} ";
                    return RedirectToAction(nameof(SizeList));
                }
            }else{
                TempData["ErrorMessage"] = 
                    $" Sorry, an unexpected error ocurred when deleting item";
                return RedirectToAction(nameof(SizeList));
            }
        } // End of method DeleteColor.

    } // End of class AdminSizeController.

} // End of namespace Camisetas.Controllers.