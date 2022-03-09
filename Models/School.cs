namespace Forum.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PricipalId { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public string AvatarUrl { get; set; }
        public string SchoolCode { get; set; }
        public string Description { get; set; }
    }
}
