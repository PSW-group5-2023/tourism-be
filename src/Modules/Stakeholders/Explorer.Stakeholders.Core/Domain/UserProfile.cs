using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class UserProfile : Person
    {
        public Uri ProfilePic { get; private set; }
        public string Biography { get; private set; }
        public string Motto { get; private set; }

        public UserProfile() : base() { }

        public UserProfile(long userId, string name, string surname, string email, Uri profilePic, string biography, string motto) : base(userId, name, surname, email)
        {
            ProfilePic = profilePic;
            Biography = biography;
            Motto = motto;

            Validate();
        }

        private void Validate()
        {
            if(string.IsNullOrEmpty(Name)) throw new ArgumentNullException("Invalid name");
            if (string.IsNullOrEmpty(Surname)) throw new ArgumentNullException("Invalid surname");
            if(!Uri.TryCreate(ProfilePic.AbsoluteUri, UriKind.Absolute, out Uri result)) throw new ArgumentNullException("Invalid uri");
            if (string.IsNullOrEmpty(Biography)) throw new ArgumentNullException("Invalid biography");
            if (string.IsNullOrEmpty(Motto)) throw new ArgumentNullException("Invalid motto");
        }
    }
}
