using Explorer.Stakeholders.Core.Domain; 
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class FollowerRepository : IFollowerRepository
    {
        private readonly StakeholdersContext _context;

        public FollowerRepository(StakeholdersContext context)
        {
            _context = context;
        }

        public Follower Get(int id)
        {
            var follower = _context.Followers.Find(id);
            if (follower == null) throw new KeyNotFoundException("Not found: " + id);
            return follower;
        }
        public Follower Create(Follower follower)
        {
            _context.Followers.Add(follower);
            _context.SaveChanges();
            return follower;
        }

        public void Delete(int followerId, int followedId)
        {
            var follower = _context.Followers.First(f => f.FollowerId == followerId && f.FollowedId == followedId);
            _context.Followers.Remove(follower);
            _context.SaveChanges();
        }        
    }
}
