namespace Explorer.Encounters.API.Dtos
{
    public class QuestionDto
    {
        public uint OrderInLecture { get; set; }
        public string Content { get; set; }
        public ICollection<AnswerDto> Answers { get; set; }
    }
}
