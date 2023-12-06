using Microsoft.EntityFrameworkCore;
using ValiShop.Core.Domain;
using ValiShop.Core.Dto;
using ValiShop.Core.ServiceInterface;
using ValiShop.Data;

namespace ValiShop.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly ValiShopContext _context;
        private readonly IFilesServices _files;

        public CarsServices(ValiShopContext context, IFilesServices files)
        {
            _context = context;
            _files = files;

        }

        public async Task<Car> Create(CarDto dto)
        {
            Car Car = new Car();
            CarFileToDatabase file = new CarFileToDatabase();
            Car.Id = dto.Id;
            Car.CreatedAt = dto.CreatedAt;
            Car.ModifiedAt = dto.ModifiedAt;

            await _context.Cars.AddAsync(Car);
            if (dto.Files != null)
            {
                _files.CarUploadFilesToDatabase(dto, Car);
            }
            await _context.SaveChangesAsync();

            return Car;
        }
        public async Task<Car> Update(CarDto dto)
        {
            var domain = new Car()
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
            };

            if (dto.Files != null)
            {
                _files.CarUploadFilesToDatabase(dto, domain);
            }

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
        public async Task<Car> Delete(Guid id)
        {
            var CarId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Cars.Remove(CarId);
            await _context.SaveChangesAsync();
            var images = await _context.CarFilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new CarFileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    CarId = y.CarId
                }).ToArrayAsync();

            await _files.CarRemoveImagesFromDatabase(images);
            _context.Cars.Remove(CarId);

            return CarId;

        }
        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
