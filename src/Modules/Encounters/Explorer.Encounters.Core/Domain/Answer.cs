using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;

namespace Explorer.Encounters.Core.Domain
{
    public class Answer : ValueObject
    {
        public string Content { get; init; }
        public bool Correct { get; init; }

        [JsonConstructor]
        public Answer(string content, bool correct)
        {
            Content = content;
            Correct = correct;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Content;
        }
    }
}
