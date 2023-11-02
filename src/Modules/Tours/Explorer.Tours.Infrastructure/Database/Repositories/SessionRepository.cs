﻿using Explorer.Tours.Core.Domain.Sessions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ToursContext _context;

        public SessionRepository(ToursContext context)
        {
            _context = context;
        }

        public Session Create(Session session)
        {
            _context.Add(session);
            _context.SaveChanges();
            return session;
        }

        public Session Update(Session session)
        {
            try
            {
                _context.Update(session);
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }

            return session;
        }
    }
}
