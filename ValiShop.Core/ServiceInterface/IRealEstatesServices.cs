using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValiShop.Core.Domain;
using ValiShop.Core.Dto;

namespace ValiShop.Core.ServiceInterface
{
    public interface IRealEstatesServices
    {
        Task<RealEstate> Create(RealEstateDto dto);
        Task<RealEstate> GetAsync(Guid id);
        Task<RealEstate> Delete(Guid id);
        Task<RealEstate> Update(RealEstateDto dto);
    }
}
