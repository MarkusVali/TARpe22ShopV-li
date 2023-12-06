using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValiShop.Core.Domain;
using ValiShop.Core.Dto;

namespace ValiShop.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarDto dto);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
        Task<Car> GetAsync(Guid id);
    }
}
