using System.ComponentModel.DataAnnotations;

namespace VersionTwo.Models 
{
    public class Vlog
    {
        public int Id { get; set; }
        public string VideoUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;
        // public string Image { get; set; } = null!;
    }
}
