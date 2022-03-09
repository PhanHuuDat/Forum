using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class View
    {
        [Key]
        public int Id { get; set; }
        public int Counter { get; set; }
        public int UserId { get; set; }
        public Account Account { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
