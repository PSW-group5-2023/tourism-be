using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Encounters.Core.Domain
{
    public class UserExperience : Entity
    {

        public long UserId { get; init; }
        public int XP { get; private set; }
        public int Level { get; private set; }

        public UserExperience(long userId, int xP)
        {
            UserId = userId;
            XP = xP;
            Level = CalculateLevel();
        }

        public int CalculateLevel()
        {
            Level = XP / 20 + 1;
            return Level;
        }
        public void AddXP(int xp)
        {
            XP += xp;
        }
    }
}
