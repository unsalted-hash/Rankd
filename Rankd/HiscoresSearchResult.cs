using System.Numerics;

namespace Rankd
{
    public class HiscoresSearchResult
    {
        // TODO: Add minigames

        public Dictionary<string, HiscoresSkillInfo> Skills { get; } = new(23);

        public IronType IronType { get; set; }

        public int TotalLevel() => Skills.Values.Sum(x => x.Level);

        public BigInteger TotalExperience()
        {
            BigInteger total = 0;
            foreach (var skill in Skills.Values)
            {
                total += skill.Experience;
            }

            return total;
        }
    }
}
