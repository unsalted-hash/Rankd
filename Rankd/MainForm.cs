using Rankd.Properties;
using System.Text;

namespace Rankd
{
    /// <summary>
    /// Main form for the Rankd application
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Creates in instance of the main Rankd form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// Handles the retrieval of a user's stats
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="result">User's stats</param>
        public void AddResult(string user, HiscoresSearchResult result)
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
        /// Parses information in the users textbox to get an enumerable of usernames
        /// </summary>
        /// <returns>Enumerable of usernames from the users textbox</returns>
        public IEnumerable<string> GetUsernames()
        {
            // return trimmed, non-null strings from the users textbox
            return usersTextBox.Text.Split(",")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim());
        }

        /// <summary>
        /// Handles the click event of the export button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            // disable UI while exporting
            contentPanel.Enabled = false;

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

            // re-enable UI
            contentPanel.Enabled = true;
        }

        /// <summary>
        /// Handles the click event of the search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // clear results and reset column sorts
            resultsGridView.Rows.Clear();
            foreach (DataGridViewColumn column in resultsGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // disable UI while searching
            contentPanel.Enabled = false;

            // gather names from textbox
            var usernames = GetUsernames();

            // begin task to retrieve stats
            Task.Run(() =>
            {
                var searchResults = HiscoresScraper.GetCurrentStatsAsync(usernames).Result;

                Invoke(() =>
                {
                    foreach (var result in searchResults)
                    {
                        AddResult(result.Key, result.Value);
                    }

                    contentPanel.Enabled = true;
                });
            });
        }
    }
}