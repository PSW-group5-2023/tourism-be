﻿using Explorer.Stakeholders.Core.Domain.Followers;
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
