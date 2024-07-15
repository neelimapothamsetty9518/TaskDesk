namespace TravelDeskWebapi.Model
{
    public class Manager
    {

        public int Id { get; set; }
        public string? RequestId { get; set; }
        public string? Status { get; set; }
        public string? Comments { get; set; }
        public string? ActorRole { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }


    }
}
