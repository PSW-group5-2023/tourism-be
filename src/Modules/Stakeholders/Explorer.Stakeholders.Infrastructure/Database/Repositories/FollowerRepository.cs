using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain.Followers;
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
        public List<Follower> GetFollowersNotifications(int id)
        {
            return _context.Followers.Where(f => f.FollowedId == id).ToList();
        }
        public Follower Create(Follower follower)
        {
            var followerUser = _context.Users.FirstOrDefault(u => u.Id == follower.FollowerId);
            if (followerUser == null) throw new ArgumentException("Follower with id: " + follower.FollowerId + " not found");
            var followedUser = _context.Users.FirstOrDefault(u => u.Id == follower.FollowedId);
            if (followedUser == null) throw new ArgumentException("Follower with id: " + follower.FollowedId + " not found");

            _context.Followers.Add(follower);
            _context.SaveChanges();
            return follower;
        }

        public void Delete(int followerId, int followedId)
        {
            var follower = _context.Followers.FirstOrDefault(f => f.FollowerId == followerId && f.FollowedId == followedId);
            if (follower == null) throw new KeyNotFoundException("Not found: " + followerId + " " + followedId);
            _context.Followers.Remove(follower);
            _context.SaveChanges();
        }

        public List<Follower> GetFollowings(int id)
        {
            return _context.Followers.Where(f => f.FollowerId == id).ToList();
        }
    }
}
