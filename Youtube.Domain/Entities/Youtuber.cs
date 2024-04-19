namespace Youtube.Domain.Entities
{
    public class Youtuber
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Subscribers { get; set; }
        public int videos { get; set; }
        public int views { get; set; }
        public DateTime Joined { get; set; }
        public string? country { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
