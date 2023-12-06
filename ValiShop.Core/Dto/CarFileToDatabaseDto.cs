using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValiShop.Core.Dto
{
    public class CarFileToDatabaseDto
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? CarId { get; set; }
    }
}
