using IDROBE.API.Entities.Main;
using Microsoft.AspNetCore.Identity;

namespace IDROBE.API.Entities.Identity
{
    public class AppUser:IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndTime { get; set; }
        public string Address { get; set; }

        // Relation
        public ICollection<Order> Orders { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }

    public class AppRole:IdentityRole<string> 
    {
    }
}
