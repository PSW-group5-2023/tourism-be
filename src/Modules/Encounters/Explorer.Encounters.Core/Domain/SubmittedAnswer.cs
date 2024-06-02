using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Explorer.Encounters.Core.Domain
{
    public class SubmittedAnswer : ValueObject
    {
        public string Content { get; init; }
        public uint OrderInQuiz { get; init; }

        [JsonConstructor]
        public SubmittedAnswer(string content, uint orderInQuiz)
        {
            Content = content;
            OrderInQuiz = orderInQuiz;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Content;
        }
    }
}
