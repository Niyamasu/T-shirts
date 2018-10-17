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
    public class AdminTshirtController : Controller
    {
        // Fields
        private ITshirtRepository tshirtRepository;

        // Ctor.
        public AdminTshirtController(ITshirtRepository repo)
            => this.tshirtRepository = repo;
        

        // Methods
        [HttpGet]
        public IActionResult Index( int pageNumber = 1, int itemsPerPage = 4)
        => View(new GenericListViewModel<Tshirt>()
                    {
                        CollectionToSend = tshirtRepository.Tshirts
                                .OrderBy(t => t.Id)
                                .Skip((pageNumber - 1) * itemsPerPage)
                                .Take(itemsPerPage),
                        PagingInfo = new PagingInfo()
                        {
                            ItemsPerPage = itemsPerPage,
                            TotalItems = tshirtRepository.Tshirts.Count(),
                            CurrentPage = pageNumber
                        }
                    });

        [HttpGet]
        public ViewResult Create()
        {
            return View(new Tshirt());
        } // End of method Create.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]Tshirt tshirtModel)
        {
            if(ModelState.IsValid)
            {
                tshirtRepository.SaveTshirt(tshirtModel);
                TempData["SuccessMessage"] = $"{tshirtModel.Name} ({tshirtModel.Id}) "
                +"was successfully created";
                return RedirectToAction(nameof(Create));
            }else{
                return View(tshirtModel);    
            }
        } // End of method Create.

        [HttpGet]
        public ViewResult Edit (Guid id) 
            => View( (tshirtRepository[id]) != null ? 
                tshirtRepository[id]
                : throw new ArgumentNullException(nameof(id),
                    "Unable to find color to edit"));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tshirt tshirtModel)
        {
            if(ModelState.IsValid)
            {
                tshirtRepository.SaveTshirt(tshirtModel);
                TempData["SuccessMessage"] = $"{tshirtModel.Name} ({tshirtModel.Id}) "
                +"was successfully edited";
                return RedirectToAction(nameof(Edit));
            } else{
                return View(tshirtModel);
            }
        } // End of method Edit

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete ([FromForm]Guid tshirtId)
        {
            if(tshirtId != null)
            {
                Tshirt tshirt =  tshirtRepository.DeleteTshirt(tshirtId);
                if(tshirt != null)
                {
                    TempData["SuccessMessage"] = $"{tshirt.Name} ({tshirt.Id}) was deleted";
                    return RedirectToAction(nameof(Index));
                }else{
                    TempData["WarningMessage"] = $"Unable to delete {tshirtId} ";
                    return RedirectToAction(nameof(Index));
                }
            }else{
                TempData["ErrorMessage"] = $" Sorry, an unexpected error ocurred when deleting item";
                return RedirectToAction(nameof(Index));
            }
        } // End of method Delete

    } // End of class HomeController.

} // End of namespace Camisetas.Controllers.