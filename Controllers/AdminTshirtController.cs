using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private IColorRepository colorRepository;
        private ISizeRepository sizeRepository;
        private IClothingRepository clothingRepository;
        private ITypeRepository typeRepository;

        // Ctor.
        public AdminTshirtController(ITshirtRepository tshirtRepo,
            IColorRepository colorRepo,
            ISizeRepository sizeRepo,
            IClothingRepository clothingRepo,
            ITypeRepository typeRepo)
            {
                this.tshirtRepository = tshirtRepo;
                this.colorRepository = colorRepo;
                this.sizeRepository = sizeRepo;
                this.clothingRepository = clothingRepo;
                this.typeRepository = typeRepo;
            } 
        

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
            return View(new TshirtViewModel());
        } // End of method Create.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]TshirtViewModel tshirtModel)
        {
            if(ModelState.IsValid)
            {
                Tshirt tshirt = ConvertToTshirt(tshirtModel);
                tshirtRepository.SaveTshirt(tshirt);
                TempData["SuccessMessage"] = $"{tshirt.Name} "
                +$"tshirt ({tshirt.Id}) "
                +"was successfully created";
                return RedirectToAction(nameof(Create));
            }else{
                return View(tshirtModel);    
            }
        } // End of method Create.

        [HttpGet]
        public ViewResult Edit (Guid id) 
            => View( (tshirtRepository[id]) != null ? 
                ConvertToTshirtViewModel(tshirtRepository[id])
                : throw new ArgumentNullException(nameof(id),
                    "Unable to find color to edit"));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TshirtViewModel tshirtModel)
        {
            if(ModelState.IsValid)
            {
                tshirtRepository.SaveTshirt( ConvertToTshirt(tshirtModel));
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
        private TshirtViewModel ConvertToTshirtViewModel(Tshirt tshirt)
        {
            TshirtViewModel tshirtViewModel = new TshirtViewModel();
            tshirtViewModel.Id = tshirt.Id;
            tshirtViewModel.Name = tshirt.Name;
            tshirtViewModel.Price = tshirt.Price;
            tshirtViewModel.Size = tshirt.Size.Id;
            tshirtViewModel.Type = tshirt.Type.Id;
            tshirtViewModel.Color = tshirt.Color.Id;
            tshirtViewModel.Clothing = tshirt.Clothing.Id;
            tshirtViewModel.Width = tshirt.Width;
            tshirtViewModel.Height = tshirt.Height;
            return tshirtViewModel;
        }

        private Tshirt ConvertToTshirt(TshirtViewModel tshirtViewModel)
        {
            Tshirt tshirt = new Tshirt(){
                Id = tshirtViewModel.Id,
                Name = tshirtViewModel.Name,
                Price = tshirtViewModel.Price,
                Width = tshirtViewModel.Width,
                Height = tshirtViewModel.Height
            };
            tshirt.Size = sizeRepository[tshirtViewModel.Size];
            tshirt.Type = typeRepository[tshirtViewModel.Type];
            tshirt.Color = colorRepository[tshirtViewModel.Color];
            tshirt.Clothing = clothingRepository[tshirtViewModel.Clothing];
            return tshirt;
        } // End of method ConvertToTshirt.

    } // End of class HomeController.

} // End of namespace Camisetas.Controllers.