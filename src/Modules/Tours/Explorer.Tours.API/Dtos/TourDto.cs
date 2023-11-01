namespace Explorer.Tours.API.Dtos
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }
        public List<string> Tags { get; set; }
        public int Status { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }
        public int[] Equipment { get; set; }
    }
}
