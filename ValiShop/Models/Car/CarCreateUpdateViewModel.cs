using System.ComponentModel.DataAnnotations;

namespace ValiShop.Models.Car
{
    public class CarCreateUpdateViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Mark { get; set; }
        public string CarShape { get; set; }
        public string CarType { get; set; }
        public string LicensePlate { get; set; }
        public string LicensePlateTemplate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int SeatAmount { get; set; }
        public string OriginCountry { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool IsCarSold { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
