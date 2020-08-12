namespace LekarnaApi.Data.Models
{
    using LekarnaApi.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;


    public class User : IdentityUser
    {
        public IEnumerable<Pharmacy> pharmacies { get; set; } = new HashSet<Pharmacy>();

    }
}
