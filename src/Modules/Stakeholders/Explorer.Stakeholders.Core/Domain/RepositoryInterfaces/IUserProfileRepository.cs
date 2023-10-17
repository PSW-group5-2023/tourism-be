using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IUserProfileRepository
    {
        public UserProfile GetById(int id);
        public UserProfile Update(UserProfile userProfile, int id);
    }
}
