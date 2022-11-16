using System.Numerics;

namespace Rankd
{
    /// <summary>
    /// Results of a hiscores search on https://secure.runescape.com/m=hiscore_oldschool
    /// </summary>
    public class HiscoresSearchResult
    {
        // TODO: Add minigames

        /// <summary>
        /// Collection of skill data mapped by skill name
        /// </summary>
        public Dictionary<string, HiscoresSkillInfo> Skills { get; } = new(23);

        /// <summary>
        /// Type of ironman account
        /// </summary>
        public IronType IronType { get; set; }

        /// <summary>
        /// Sums the level of each skill
        /// </summary>
        /// <returns>Total of all stored levels</returns>
        public int TotalLevel() => Skills.Values.Sum(x => x.Level);

        /// <summary>
        /// Sums the experience of each skill
        /// </summary>
        /// <returns>Total experience of all stored skills</returns>
        public BigInteger TotalExperience()
        {
            // loop through each skill to sum experience
            // players can gain more xp than an Int32 can store so use BigInt instead
            BigInteger total = 0;
            foreach (var skill in Skills.Values)
            {
                total += skill.Experience;
            }

            return total;
        }
    }
}
