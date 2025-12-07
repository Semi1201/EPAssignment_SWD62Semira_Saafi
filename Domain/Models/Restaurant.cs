using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Owner email (note corrected name)
        [Required]
        [EmailAddress]
        public string OwnerEmailAddress { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        // Navigation - one-to-many to MenuItem
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

        // IItemValidating implementation
        public List<string> GetValidators()
        {
            // See section below about configuration. This calls a static config helper
            // which you must implement in the MVC project (or in a shared project).
            // It returns site admin emails (not hardcoded here).
            return StaticConfigHelper.GetSiteAdmins();
        }

        public string GetCardPartial() => "_RestaurantCard"; // hardcoded partial name
    }
}
