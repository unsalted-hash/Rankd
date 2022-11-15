using Rankd.Properties;
using System.Text;

namespace Rankd
{
    public partial class MainForm : Form
    {
        private int totalUsers = 0;
        private int totalUsersSearched = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void RetrieveStats()
        {
            var users = GatherUsers();

            totalUsers = users.Count();
            totalUsersSearched = 0;

            foreach (var user in users)
            {
                Task.Run(() =>
                {
                    HiscoresScraper.GetCurrentStatsAsync(user).ContinueWith((t) =>
                    {
                        resultsGridView.Invoke(() => OnStatsRetrieved(user, t.Result));
                        totalUsersSearched++;

                        if (totalUsersSearched == totalUsers)
                        {
                            resultsGridView.Invoke(() => OnAllStatsRetrieved());
                        }
                    });
                });
            }
        }

        private void OnStatsRetrieved(string user, HiscoresSearchResult result)
        {
            var ironIcon = result.IronType switch
            {
                IronType.Iron => Resources.ironman,
                IronType.Hardcore => Resources.hardcore,
                IronType.Ultimate => Resources.ultimate,
                _ => new Bitmap(1, 1)
            };

            // iron, name, total level, total exp
            resultsGridView.Rows.Add(ironIcon, user,
                result.TotalLevel(),
                result.TotalExperience());

            // helps with lag during rapid datagridview population
            Application.DoEvents();
        }

        private void OnAllStatsRetrieved()
        {
            BlockSearchInteractions(false);
        }

        private IEnumerable<string> GatherUsers() =>
            usersTextBox.Text.Split(",").Select(x => x.Trim());

        private void UserSearchButton_Click(object sender, EventArgs e)
        {
            resultsGridView.Rows.Clear();
            foreach (DataGridViewColumn column in resultsGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            BlockSearchInteractions(true);
            RetrieveStats();
        }

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

        private void ImportUsernamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog()
            {
                DefaultExt = "txt",
            };

            fileDialog.ShowDialog();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            var builder = new StringBuilder();
            var rowData = new List<string>();
            foreach (DataGridViewRow row in resultsGridView.Rows)
            {
                for (var i = 1; i < row.Cells.Count; i++)
                {
                    var cell = row.Cells[i];
                    var cellText = cell.Value?.ToString() ?? string.Empty;
                    rowData.Add(cellText);
                }

                builder.AppendLine(string.Join(',', rowData));
                rowData.Clear();
            }

            var fileName = $"{DateTime.Now:yyyy-MM-dd}.csv";
            var savePath = Path.GetFullPath(fileName);

            File.WriteAllText(savePath, builder.ToString());
            MessageBox.Show($"Results exported to \"{savePath}\".");

            Enabled = true;
        }
    }
}