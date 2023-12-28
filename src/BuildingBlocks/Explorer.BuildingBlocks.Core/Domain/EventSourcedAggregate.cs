using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.BuildingBlocks.Core.Domain
{
    public class EventSourcedAggregate : Entity
    {
        public List<DomainEvent> Changes { get; set; }

        public EventSourcedAggregate()
        {
            Changes = new List<DomainEvent>();
        }

    }
}
