using System.ComponentModel.DataAnnotations;
namespace Wasla.Models
{
    public class AvailableRegion
    {
        [Key]
        public string Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string RegionId { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
    }
}
