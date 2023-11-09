using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IFollowerRepository
    {
        Follower Get(int id);
        Follower Create(Follower follower);
        void Delete(int followerId, int followedId);
    }
}
