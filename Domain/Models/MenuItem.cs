using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class MenuItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }   // use decimal for money

        // Foreign key
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }

        // Navigation property so we can access the restaurant owner email
        public Restaurant Restaurant { get; set; }

        public string Status { get; set; }

        // IItemValidating implementation
        public List<string> GetValidators()
        {
            // Validator is the restaurant owner who owns this MenuItem.
            // We return the restaurant owner's email if available.
            var list = new List<string>();
            if (!string.IsNullOrWhiteSpace(Restaurant?.OwnerEmailAddress))
            {
                list.Add(Restaurant.OwnerEmailAddress);
            }
            // Optionally return empty list if restaurant not loaded
            return list;
        }

        public string GetCardPartial() => "_MenuItemCard"; // hardcoded partial name

    }
}
