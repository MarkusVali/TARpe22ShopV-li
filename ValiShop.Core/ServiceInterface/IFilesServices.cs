using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValiShop.Core.Domain;
using ValiShop.Core.Dto;

namespace ValiShop.Core.ServiceInterface
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
        void CarUploadFilesToDatabase(CarDto dto, Car domain);
        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
        Task<List<FileToDatabase>> CarRemoveImagesFromDatabase(CarFileToDatabaseDto[] dtos);
        void FilesToApi(RealEstateDto dto, RealEstate realEstate);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
    }
}
