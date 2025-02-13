using System.ComponentModel.DataAnnotations;
namespace Wasla.Models
{
    public class Government
    {
        [Key]
        public string Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();
    }
}