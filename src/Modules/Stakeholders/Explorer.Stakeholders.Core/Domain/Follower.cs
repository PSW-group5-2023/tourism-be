using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class Follower : Entity
    {
        public long FollowerId { get; init; }
        public long FollowingId { get; init; }

        public Follower(long followerId, long followingId)
        {
            FollowerId = followerId;
            FollowingId = followingId;
        }

        private void Validate()
        {
            if (FollowerId == 0) throw new ArgumentException("Invalid FollowerId");
            if (FollowingId == 0) throw new ArgumentException("Invalid FollowingId");
        }
    }
}
