using Rankd.Properties;
using System.Text;

namespace Rankd
{

    public partial class Form1 : Form
    {
        private int totalUsers = 0;
        private int totalUsersSearched = 0;

        public Form1()
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
                resultsGridView.Enabled = false;
                searchButton.Enabled = false;
                searchButton.Text = "Searching...";
            }
            else
            {
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
    }
}