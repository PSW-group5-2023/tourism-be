using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Encounters.Core.Domain
{
    public class Question : Entity
    {
        public uint OrderInQuiz { get; init; }
        public string Content { get; init; }
        public ICollection<Answer> Answers { get; init; }

        public Question(uint orderInQuiz, string content, ICollection<Answer> answers)
        {
            OrderInQuiz = orderInQuiz;
            Content = content;
            Answers = answers;
        }
    }
}
