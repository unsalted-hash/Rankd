using HtmlAgilityPack;
using System.Globalization;

namespace Rankd
{
    public static class HiscoresScraper
    {
        private static readonly HttpClient client = new();
        private const string hiscoresUrl = "https://secure.runescape.com/m=hiscore_oldschool";

        public static async Task<HiscoresSearchResult> GetCurrentStatsAsync(string username)
        {
            var ultimateStats = await GetStatsAsync(username, IronType.Ultimate);
            var hardcoreStats = await GetStatsAsync(username, IronType.Hardcore);
            var ironStats = await GetStatsAsync(username, IronType.Iron);
            var regStats = await GetStatsAsync(username, IronType.None);

            var statCollection = new HiscoresSearchResult[]  { ultimateStats, hardcoreStats, ironStats, regStats };
            var bestStats = statCollection.OrderByDescending(x => x.TotalExperience()).First();

            return (bestStats.TotalExperience() == 0) ? regStats : bestStats;
        }

        public static async Task<HiscoresSearchResult> GetStatsAsync(string username, IronType ironType)
        {
            var table = await GetHiscoresTableAsync(username, ironType);

            var result = new HiscoresSearchResult() { IronType = ironType };

            if (table != null)
            {
                // select rows where:
                // 1) row contains exactly 5 columns (minigame and header rows only have 4 cells)
                // 2) row is not the "Overall" row
                var skillRows = table.Elements("tr");
                foreach (var row in skillRows)
                {
                    var cells = row.Elements("td").ToList();
                    if (cells != null && cells.Count == 5 &&
                        !string.IsNullOrWhiteSpace(cells[1].InnerHtml) &&
                        !cells[1].InnerText.Contains("Overall"))
                    {
                        var skillName = cells[1].InnerText.Trim();
                        var skillInfo = new HiscoresSkillInfo()
                        {
                            Rank = int.Parse(cells[2].InnerText, NumberStyles.AllowThousands),
                            Level = int.Parse(cells[3].InnerText),
                            Experience = int.Parse(cells[4].InnerText, NumberStyles.AllowThousands),
                        };

                        result.Skills[skillName] = skillInfo;
                    }
                }
            }

            return result;
        }

        private static async Task<HtmlNode?> GetHiscoresTableAsync(string username, IronType ironType)
        {
            var url = GetHiscoresUrl(username, ironType);

            var attempts = 0;
            string? responseBody = null;
            while (attempts < 10 && responseBody == null)
            {
                attempts++;

                try
                {
                    responseBody = await client.GetStringAsync(url);
                }
                catch
                {
                    // TODO: Catch and log exception
                }
            }

            if (responseBody != null)
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(responseBody);

                var containerNode = doc.GetElementbyId("contentHiscores");

                return containerNode?.Element("table");
            }
            else
            {
                return null;
            }
        }

        public static string GetHiscoresUrl(string username, IronType ironType)
        {
            var searchName = username.Replace(" ", "%A0");

            return ironType switch
            {
                IronType.Iron => $"{hiscoresUrl}_ironman/hiscorepersonal?user1={searchName}",
                IronType.Hardcore => $"{hiscoresUrl}_hardcore_ironman/hiscorepersonal?user1={searchName}",
                IronType.Ultimate => $"{hiscoresUrl}_ultimate/hiscorepersonal?user1={searchName}",
                _ => $"{hiscoresUrl}/hiscorepersonal?user1={searchName}",
            };
        }
    }
}
