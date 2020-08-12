namespace LekarnaApi.Controllers
{
    using LekarnaApi.Data;
    using LekarnaApi.Data.Models;
    using LekarnaApi.Infrastructure;
    using LekarnaApi.Models.Pharmacy;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    public class PharmacyController : ApiController
    {
        private readonly LekarnaDbContext data;

        public PharmacyController(LekarnaDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        [HttpPost]

        public async Task<ActionResult> Create(CreatePharmacyRequestModel model)
        {
            var userId = this.User.GetId();

            var pharmacy = new Pharmacy
            {
                Address = model.Address,
                Country = model.Country,
                City = model.City,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            this.data.Add(pharmacy);

            await this.data.SaveChangesAsync();

            return Created(nameof(this.Create), pharmacy.Id);
        }
    }
}
