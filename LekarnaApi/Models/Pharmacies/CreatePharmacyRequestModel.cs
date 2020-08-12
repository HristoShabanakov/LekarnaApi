namespace LekarnaApi.Models.Pharmacy
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Validation.PharmacyValidations;

    public class CreatePharmacyRequestModel
    {
        [MaxLength(MaxCountryLength)]
        public string Country { get; set; }

        [MaxLength(MaxCityLength)]
        public string City { get; set; }

        [MaxLength(MaxAddressLength)]
        public string Address { get; set; }

        public string ImageUrl { get; set; }
    }
}
