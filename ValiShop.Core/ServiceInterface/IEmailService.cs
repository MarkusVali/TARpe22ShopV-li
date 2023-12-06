using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValiShop.Core.Dto;

namespace ValiShop.Core.ServiceInterface
{
    public interface IEmailService
    {
        void SendEmail(EmailDto dto);
    }
}
