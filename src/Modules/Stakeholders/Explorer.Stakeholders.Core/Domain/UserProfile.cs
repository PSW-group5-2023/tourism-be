using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class UserProfile : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public Uri ProfilePic { get; private set; }
        public string Biography { get; private set; }
        public string Motto { get; private set; }

        public UserProfile(string name, string lastName, Uri profilePic, string biography, string motto)
        {
            Name = name;
            LastName = lastName;
            ProfilePic = profilePic;
            Biography = biography;
            Motto = motto;

            Validate();
        }

        private void Validate()
        {
            if(string.IsNullOrEmpty(Name)) throw new ArgumentNullException("Name");
            if (string.IsNullOrEmpty(LastName)) throw new ArgumentNullException("Invalid last name");
            if (Uri.IsWellFormedUriString(ProfilePic.ToString(), UriKind.Absolute)) throw new ArgumentNullException("Invalid uri for profile picture");
            if (string.IsNullOrEmpty(Biography)) throw new ArgumentNullException("Invalid biography");
            if (string.IsNullOrEmpty(Motto)) throw new ArgumentNullException("Invalid motto");
        }
    }
}
