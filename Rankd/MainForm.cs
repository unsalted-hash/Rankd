using Rankd.Properties;
using System.Text;

namespace Rankd
{
    /// <summary>
    /// Main form for the Rankd application
    /// </summary>
    public partial class MainForm : Form
    {
        // number of users to search for during a given iteration
        private int totalUsers = 0;

        // number of users found during a given iteration
        private int totalUsersSearched = 0;

        /// <summary>
        /// Creates in instance of the main Rankd form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region Control Event Handlers
        /// <summary>
        /// Handles the click event of the search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserSearchButton_Click(object sender, EventArgs e)
        {
            // clear results and reset column sorts
            resultsGridView.Rows.Clear();
            foreach (DataGridViewColumn column in resultsGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // search for stats, and prevent UI interactions while doing so
            BlockSearchInteractions(true);
            RetrieveStats();
        }

        /// <summary>
        /// Handles the click event of the export button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            // disable entire form while exporting
            Enabled = false;

            // create string builder to construct csv file
            var builder = new StringBuilder();

            // loop through each rowin the grid
            var rowData = new List<string>();
            foreach (DataGridViewRow row in resultsGridView.Rows)
            {
                // gather strings from each cell in the row
                // TODO: Include iron type
                for (var i = 1; i < row.Cells.Count; i++)
                {
                    var cell = row.Cells[i];
                    var cellText = cell.Value?.ToString() ?? string.Empty;
                    rowData.Add(cellText);
                }

                // append csv row to the builder
                builder.AppendLine(string.Join(',', rowData));
                rowData.Clear();
            }

            // save data to file
            var fileName = $"{DateTime.Now:yyyy-MM-dd}.csv";
            var savePath = Path.GetFullPath(fileName);
            File.WriteAllText(savePath, builder.ToString());
            MessageBox.Show($"Results exported to \"{savePath}\".");

            // re-enable the form
            Enabled = true;
        }
        #endregion

        /// <summary>
        /// Enables/disables UI elements related to searching
        /// </summary>
        /// <param name="block">Determines if UI elements should be enabled or disabled</param>
        private void BlockSearchInteractions(bool block)
        {
            if (block)
            {
                exportButton.Enabled = false;
                resultsGridView.Enabled = false;
                searchButton.Enabled = false;
                searchButton.Text = "Searching...";
            }
            else
            {
                exportButton.Enabled = true;
                resultsGridView.Enabled = true;
                searchButton.Enabled = true;
                searchButton.Text = "Search";
            }
        }

        /// <summary>
        /// Parses information in the users textbox to get an enumerable of usernames
        /// </summary>
        /// <returns>Enumerable of usernames from the users textbox</returns>
        private IEnumerable<string> GatherUsers()
        {
            // return trimmed, non-null strings from the users textbox
            return usersTextBox.Text.Split(",")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim());
        }

        /// <summary>
        /// Handles the completion of stat retrieval
        /// </summary>
        private void OnAllStatsRetrieved()
        {
            // unblock UI
            BlockSearchInteractions(false);
        }

        /// <summary>
        /// Handles the retrieval of a user's stats
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="result">User's stats</param>
        private void OnStatsRetrieved(string user, HiscoresSearchResult result)
        {
            // determine icon from iron type
            var ironIcon = result.IronType switch
            {
                IronType.Iron => Resources.ironman,
                IronType.Hardcore => Resources.hardcore,
                IronType.Ultimate => Resources.ultimate,
                _ => new Bitmap(1, 1)
            };

            // add row: iron type, name, total level, total exp
            resultsGridView.Rows.Add(ironIcon,
                user,
                result.TotalLevel(),
                result.TotalExperience());
        }

        /// <summary>
        /// Retrieves the current stat of each user in the users textbox from the OSRS Hiscores
        /// </summary>
        private void RetrieveStats()
        {
            // gather users from textbox
            var users = GatherUsers();

            // reset counts
            totalUsers = users.Count();
            totalUsersSearched = 0;

            // asynchronously get the current stats of each user
            foreach (var user in users)
            {
                Task.Run(() =>
                {
                    HiscoresScraper.GetCurrentStatsAsync(user).ContinueWith((t) =>
                    {
                        // add the results to the gridview
                        resultsGridView.Invoke(() => OnStatsRetrieved(user, t.Result));

                        // check to see if a result has been found for all users
                        totalUsersSearched++;
                        if (totalUsersSearched == totalUsers)
                        {
                            resultsGridView.Invoke(() => OnAllStatsRetrieved());
                        }
                    });
                });
            }
        }
    }
}