using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class DataEntry
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}