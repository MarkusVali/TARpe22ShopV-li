using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe22ShopVäli.Core.Dto;
using TARpe22ShopVäli.Core.ServiceInterface;
using TARpe22ShopVäli.Data;
using TARpe22ShopVäli.Models.Car;

namespace TARpe22ShopVäli.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARpe22ShopVäliContext _context;
        private readonly ICarsServices _carsServices;
        private readonly IFilesServices _filesServices;
        public CarsController
            (
                TARpe22ShopVäliContext context,
                ICarsServices carsServices,
                IFilesServices filesServices
            )
        {
            _context = context;
            _carsServices = carsServices;
            _filesServices = filesServices;
        }
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel Car = new CarCreateUpdateViewModel();
            return View("CreateUpdate", Car);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = new Guid(),
                Brand = vm.Brand,
                Mark = vm.Mark,
                CarShape = vm.CarShape,
                CarType = vm.CarType,
                LicensePlate = vm.LicensePlate,
                LicensePlateTemplate = vm.LicensePlateTemplate,
                ManufactureDate = vm.ManufactureDate,
                SeatAmount = vm.SeatAmount,
                OriginCountry = vm.OriginCountry,
                HasAirConditioning = vm.HasAirConditioning,
                IsCarSold = vm.IsCarSold,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new CarFileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var Car = await _carsServices.GetAsync(id);
            if (Car == null)
            {
                return NotFound();
            }
            var photos = await _context.CarFilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image.gif;base64,{0}", Convert.ToBase64String(y.ImageData))

                }).ToArrayAsync();
            var vm = new CarCreateUpdateViewModel();

            vm.Id = Car.Id;
            vm.Brand = Car.Brand;
            vm.Mark = Car.Mark;
            vm.CarShape = Car.CarShape;
            vm.CarType = Car.CarType;
            vm.LicensePlate = Car.LicensePlate;
            vm.LicensePlateTemplate = Car.LicensePlateTemplate;
            vm.ManufactureDate = Car.ManufactureDate;
            vm.SeatAmount = Car.SeatAmount;
            vm.OriginCountry = Car.OriginCountry;
            vm.HasAirConditioning = Car.HasAirConditioning;
            vm.IsCarSold = Car.IsCarSold;
            vm.CreatedAt = Car.CreatedAt;
            vm.ModifiedAt = Car.ModifiedAt;
            vm.Image.AddRange(photos);

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Mark = vm.Mark,
                CarShape = vm.CarShape,
                CarType = vm.CarType,
                LicensePlate = vm.LicensePlate,
                LicensePlateTemplate = vm.LicensePlateTemplate,
                ManufactureDate = vm.ManufactureDate,
                SeatAmount = vm.SeatAmount,
                OriginCountry = vm.OriginCountry,
                HasAirConditioning = vm.HasAirConditioning,
                IsCarSold = vm.IsCarSold,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image.Select(x => new CarFileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

            var Car = await _carsServices.GetAsync(id);
            if (Car == null)
            {
                return NotFound();
            }
            var photos = await _context.CarFilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new CarDetailsViewModel();

            vm.Id = Car.Id;
            vm.Brand = Car.Brand;
            vm.Mark = Car.Mark;
            vm.CarShape = Car.CarShape;
            vm.CarType = Car.CarType;
            vm.LicensePlate = Car.LicensePlate;
            vm.LicensePlateTemplate = Car.LicensePlateTemplate;
            vm.ManufactureDate = Car.ManufactureDate;
            vm.SeatAmount = Car.SeatAmount;
            vm.OriginCountry = Car.OriginCountry;
            vm.HasAirConditioning = Car.HasAirConditioning;
            vm.IsCarSold = Car.IsCarSold;
            vm.CreatedAt = Car.CreatedAt;
            vm.ModifiedAt = Car.ModifiedAt;
            vm.Image.AddRange(photos);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            var Car = await _carsServices.GetAsync(id);
            if (Car == null)
            {
                return NotFound();
            }
            var photos = await _context.CarFilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.CarId,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData)),
                }).ToArrayAsync();

            var vm = new CarDeleteViewModel();


            vm.Id = Car.Id;
            vm.Brand = Car.Brand;
            vm.Mark = Car.Mark;
            vm.CarShape = Car.CarShape;
            vm.CarType = Car.CarType;
            vm.LicensePlate = Car.LicensePlate;
            vm.LicensePlateTemplate = Car.LicensePlateTemplate;
            vm.ManufactureDate = Car.ManufactureDate;
            vm.SeatAmount = Car.SeatAmount;
            vm.OriginCountry = Car.OriginCountry;
            vm.HasAirConditioning = Car.HasAirConditioning;
            vm.IsCarSold = Car.IsCarSold;
            vm.CreatedAt = Car.CreatedAt;
            vm.ModifiedAt = Car.ModifiedAt;
            vm.Image.AddRange(photos);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var CarId = await _carsServices.Delete(id);
            if (CarId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(ImageViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = file.ImageId
            };
            var image = await _filesServices.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
