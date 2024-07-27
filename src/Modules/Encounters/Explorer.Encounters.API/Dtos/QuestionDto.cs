namespace Explorer.Encounters.API.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public uint OrderInQuiz { get; set; }
        public string Content { get; set; }
        public ICollection<AnswerDto> Answers { get; set; }
    }
}
