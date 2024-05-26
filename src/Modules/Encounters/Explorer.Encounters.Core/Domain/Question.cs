using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Encounters.Core.Domain
{
    public class Question : Entity
    {
        public uint OrderInLecture { get; init; }
        public string Content { get; init; }
        public ICollection<Answer> Answers { get; init; }

        public Question(uint orderInLecture, string content, ICollection<Answer> answers)
        {
            OrderInLecture = orderInLecture;
            Content = content;
            Answers = answers;
        }
    }
}
