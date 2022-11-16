namespace Rankd
{
    /// <summary>
    /// Contains data for any given
    /// </summary>
    public struct HiscoresSkillInfo
    {
        /// <summary>
        /// Current skill level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Total experience gained
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// Worldwide ranking based on experience
        /// </summary>
        public int Rank { get; set; }
    }
}
