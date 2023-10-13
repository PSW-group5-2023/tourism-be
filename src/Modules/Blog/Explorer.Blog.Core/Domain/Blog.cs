using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.Domain
{
    public class Blog : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatingDate { get; private set; }

        //pictures

        public BlogStatus BlodStatus { get; private set; }
    }

    public enum BlogStatus 
    { 
        DRAFT,
        PUBLISHED,
        CLOSED 
    }
}
