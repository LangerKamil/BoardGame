namespace GamesRental.Infrastructure.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int InStock { get; set; }
        public int Price { get; set; }
    }
}
