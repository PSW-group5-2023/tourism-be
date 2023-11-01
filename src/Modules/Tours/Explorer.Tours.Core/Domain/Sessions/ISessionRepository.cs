using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.Sessions
{
    public interface ISessionRepository
    {
        Session Create(Session session);
    }
}
