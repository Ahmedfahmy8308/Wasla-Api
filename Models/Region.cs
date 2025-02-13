using System.ComponentModel.DataAnnotations;
namespace Wasla.Models
{
    public class Region
    {
        [Key]
        public string Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string GovernmentId { get; set; }
        public List<AvailableRegion> AvailableRegions { get; set; } = new List<AvailableRegion>();
    }
}