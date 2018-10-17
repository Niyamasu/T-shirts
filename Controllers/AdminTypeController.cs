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
    public class AdminTypeController : Controller
    {
        // Fields
        private ITypeRepository typeRepository;

        // Ctor
        public AdminTypeController (ITypeRepository  repo)
            => typeRepository = repo;

        [HttpGet]
        public ViewResult TypeList(int pageNumber = 1, int itemsPerPage = 4)
            => View(new GenericListViewModel<Models.Type>()
            {
                CollectionToSend = typeRepository.Types
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage),
                PagingInfo =  new PagingInfo()
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = itemsPerPage,
                    TotalItems = typeRepository.Types.Count()
                }
            });

        [HttpGet]
        public ViewResult CreateType() => View(new Models.Type());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateType([FromForm]Models.Type type)
        {
            if(ModelState.IsValid)
            {
                typeRepository.SaveType(type);
                TempData["SuccessMessage"] = 
                    $"{type.Name} type ({type.Id}) was successfully created";
                return View(new Models.Type());
            }
            else{ return View(type); }
        } // End of method CreateType.

        [HttpGet]
        public ViewResult EditType(Guid id) =>
            View((typeRepository[id]) != null ? 
                typeRepository[id]
                : throw new ArgumentNullException(nameof(id),
                    "Unable to find size to edit") );
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditType(Models.Type type)
        {
            if(ModelState.IsValid)
            {
                typeRepository.SaveType(type);
                TempData["SuccessMessage"] = $"{type.Name} type ({type.Id})"
                + " was successfully edited";
                return View();
            }else{
                return View(type);
            }
        } // End of method EditColor.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteType([FromForm]Guid typeId)
        {
            if(typeId != null)
            {
                Models.Type type = typeRepository.DeleteType(typeId);
                if(type != null)
                {
                    TempData["SuccessMessage"] = 
                    $"{type.Name} type ({type.Id}) was deleted";
                    return RedirectToAction(nameof(TypeList));
                }else{
                    TempData["WarningMessage"] = $"Unable to delete {typeId} ";
                    return RedirectToAction(nameof(TypeList));
                }
            }else{
                TempData["ErrorMessage"] = 
                    $" Sorry, an unexpected error ocurred when deleting item";
                return RedirectToAction(nameof(TypeList));
            }
        } // End of method DeleteColor.
        
    } // End of class AdminTypeRepository.

} // End of namespace Camisetas.Controllers.