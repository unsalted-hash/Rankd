using HtmlAgilityPack;
using System.Globalization;

namespace Rankd
{
    /// <summary>
    /// Scrapes the Old School Runescape hiscores for account information
    /// </summary>
    public static class HiscoresScraper
    {
        // client that will be used to send and receive web requests
        private static readonly HttpClient client = new();

        // url to the osrs hiscores
        private const string hiscoresUrl = "https://secure.runescape.com/m=hiscore_oldschool";

        /// <summary>
        /// Searches a given username on the OSRS Hiscores for the most recent data
        /// </summary>
        /// <param name="username">User to search</param>
        /// <returns>The provided user's current stats</returns>
        public static async Task<HiscoresSearchResult> GetCurrentStatsAsync(string username)
        {
            // retrieve stats for each possible ironman type
            var ultimateStats = GetStatsAsync(username, IronType.Ultimate);
            var hardcoreStats = GetStatsAsync(username, IronType.Hardcore);
            var ironStats = GetStatsAsync(username, IronType.Iron);
            var regStats = GetStatsAsync(username, IronType.None);

            // wait for all 4 stat sets to be retrieved
            await Task.WhenAll(ultimateStats, hardcoreStats, ironStats, regStats);

            // store result in array
            var statCollection = new HiscoresSearchResult[]
            {
                ultimateStats.Result,
                hardcoreStats.Result,
                ironStats.Result,
                regStats.Result
            };

            // the stat set that has the most xp are the user's current stats
            // if player has no recorded xp in game, assume they are a regular player with
            var bestStats = statCollection.OrderByDescending(x => x.TotalExperience()).First();
            var currentStats = (bestStats.TotalExperience() == 0) ? regStats.Result : bestStats;
            return currentStats;
        }

        /// <summary>
        /// Creates a string that is a link to the OSRS Hiscores for a given player and ironman type
        /// </summary>
        /// <param name="username">User to search</param>
        /// <param name="ironType">Ironman type</param>
        /// <returns>URL to the OSRS Hiscores for a given player and ironman type</returns>
        public static string GetHiscoresUrl(string username, IronType ironType)
        {
            // replace spaces with url-friendly character sequence
            var searchName = username.Replace(" ", "%A0");

            // generate link based on provided ironman type
            return ironType switch
            {
                IronType.Iron => $"{hiscoresUrl}_ironman/hiscorepersonal?user1={searchName}",
                IronType.Hardcore => $"{hiscoresUrl}_hardcore_ironman/hiscorepersonal?user1={searchName}",
                IronType.Ultimate => $"{hiscoresUrl}_ultimate/hiscorepersonal?user1={searchName}",
                _ => $"{hiscoresUrl}/hiscorepersonal?user1={searchName}",
            };
        }

        /// <summary>
        /// Searches a given username on the OSRS Hiscores for a given ironman type
        /// </summary>
        /// <param name="username">User to search</param>
        /// <param name="ironType">Ironman type</param>
        /// <returns>The provided user's stats for a given ironman type</returns>
        public static async Task<HiscoresSearchResult> GetStatsAsync(string username, IronType ironType)
        {
            // hiscores result to return
            var result = new HiscoresSearchResult() { IronType = ironType };

            // retrieve hiscores web element
            var table = await GetHiscoresTableAsync(username, ironType);

            // ensure a table could be found
            if (table != null)
            {
                // loop through rows in the table
                var skillRows = table.Elements("tr");
                foreach (var row in skillRows)
                {
                    // find cells within the row
                    var cells = row.Elements("td").ToList();

                    // if the row has 5 cells and the 1th cell is not "Overall"
                    if (cells != null && cells.Count == 5 &&
                        !string.IsNullOrWhiteSpace(cells[1].InnerHtml) &&
                        !cells[1].InnerText.Contains("Overall"))
                    {
                        // parse skill name, rank, level, and xp
                        var skillName = cells[1].InnerText.Trim();
                        var skillInfo = new HiscoresSkillInfo()
                        {
                            Rank = int.Parse(cells[2].InnerText, NumberStyles.AllowThousands),
                            Level = int.Parse(cells[3].InnerText),
                            Experience = int.Parse(cells[4].InnerText, NumberStyles.AllowThousands),
                        };

                        // store skill info in the result object
                        result.Skills[skillName] = skillInfo;
                    }
                }
            }

            // return the populated result
            return result;
        }

        /// <summary>
        /// Sends a GET request to the OSRS Hiscores page and returns the hiscores table
        /// </summary>
        /// <param name="username">Username to search</param>
        /// <param name="ironType">Ironman type</param>
        /// <returns><see cref="HtmlNode"/> containing hiscores data</returns>
        private static async Task<HtmlNode?> GetHiscoresTableAsync(string username, IronType ironType)
        {
            // generate hiscores url from username and iron type
            var url = GetHiscoresUrl(username, ironType);

            // attempt to retrieve a response from the hiscores page
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

            // if a response could be received
            if (responseBody != null)
            {
                // load the response into an html doc
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(responseBody);

                // retrieve the hiscores node from the doc
                return doc.GetElementbyId("contentHiscores")?.Element("table");
            }

            // no response was received
            return null;
        }
    }
}
