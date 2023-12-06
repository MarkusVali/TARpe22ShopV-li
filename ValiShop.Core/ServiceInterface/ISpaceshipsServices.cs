using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValiShop.Core.Domain;
using ValiShop.Core.Dto;

namespace ValiShop.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Create(SpaceshipDto dto);
        Task<Spaceship> Update(SpaceshipDto dto);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> GetAsync(Guid id);
    }
}
