using IDROBE.API.Entities.Common;
using IDROBE.API.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace IDROBE.API.Entities.Main
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // "Whats New" 
        public bool IsNew { get; set; }

        // Relation
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Relation
        public ICollection<Product> Products { get; set; }
    }

    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Relation
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }

    //public class User
    //{
    //    public int UserId { get; set; }
    //    public string Username { get; set; }
    //    public string Email { get; set; }
    //    public string Password { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Address { get; set; }

    //    // Relation
    //    public ICollection<Order> Orders { get; set; }
    //    public ICollection<Favorite> Favorites { get; set; }
    //}

    public class OrderDetails : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        // Relation
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public class Favorite : BaseEntity
    {

        // Relation
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    //public class AppUser : IdentityUser<string>
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public DateTime BirthDate { get; set; }
    //    public string? RefreshToken { get; set; }
    //    public DateTime? RefreshTokenEndTime { get; set; }
    //    public string Address { get; set; }

    //    // Relation
    //    public ICollection<Order> Orders { get; set; }
    //    public ICollection<Favorite> Favorites { get; set; }
    //}

    //public class AppRole : IdentityRole<string>
    //{
    //}

    //public class BaseEntity
    //{
    //    public int Id { get; set; }
    //}
}
