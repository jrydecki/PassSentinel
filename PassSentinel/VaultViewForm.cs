using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PassSentinel
{
    public partial class VaultViewForm : Form
    {
        private static System.Timers.Timer lockTimer;

        private Sentinel sentinel;
        private VaultItemDAO dao;
        private ListViewItem SelectedListViewItem;

        public bool Lock;

        public VaultViewForm(Int64 userID, char[] password)
        {
            InitializeComponent();

            // Set Global Strings
            string db_file = (string)Config.Get("db_path");
            Globals.UserID = userID;

            // Set Database Variables
            this.dao = new VaultItemDAO();
            Globals.Username = Globals.DB.GetUsername(Globals.UserID);

            // Set Preferences
            SetPreferences();

            // Initialize Sentinel
            this.sentinel = new Sentinel();
            this.sentinel.DeriveKey(Globals.DB.GetMasterSalt(Globals.Username), password);
            Array.Clear(password, 0, password.Length);

            this.Lock = false;

            // Initialize Inactivity Timer
            StartInactivityTimer();

            // Create any necessary ListView Columns
            CreateColumns();

            // Populate Vault Items
            vaultListView.ItemActivate += vaultListView_ItemActivate;
            PopulateListView();

            // Set Button Anchors
            settingsBtn.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            importBtn.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            lockBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        } // end constructor

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ClearSentinel();
            base.OnFormClosing(e);
        } // end OnFormClosing


        private void OnUserActivity(object sender, EventArgs e)
        {
            if (Preferences.InactivityTimer != -1)
            {
                lockTimer.Stop();
                lockTimer.Start();
            }
        } // end OnUserActivity

        private void OnInactivityTimeout(object sender, ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(LockApp));
            else
                LockApp();
        } // end OnInactivityTimeout

        private void StartInactivityTimer()
        {
            if (Preferences.InactivityTimer != -1)
            {
                lockTimer = new System.Timers.Timer(Preferences.InactivityTimer * 60 * 1000);
                lockTimer.Elapsed += OnInactivityTimeout;
                lockTimer.AutoReset = false;
                Application.Idle += OnUserActivity;
                this.Click += OnUserActivity;
                this.KeyPress += OnUserActivity;
            }
        } // end StartInactivityTimer

        private void RestartInactivityTimer()
        {
            // Fully Recreate/Reinitialize/Restart the Inactivity Timer
            // Assumes the Timer is already running/started

            if (lockTimer != null)
            {
                Application.Idle -= OnUserActivity;
                this.Click -= OnUserActivity;
                this.KeyPress -= OnUserActivity;
                lockTimer.Stop();
                lockTimer.Dispose();
                lockTimer = null;
            }
            StartInactivityTimer();
        } // end RecreateInactivityTimer

        public void ClearSentinel()
        {
            sentinel.DestroyKey();
        } // end ClearSentinel

        private void VaultViewForm_Load(object sender, EventArgs e)
        {

        }

        private void vaultListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetPreferences()
        {
            Dictionary<string, object> dict = Globals.DB.GetPreferences();
            Preferences.RandomPasswordLength = (int)dict["RandomPasswordLength"];
            Preferences.GenerateSymbols = (bool)dict["GenerateSymbols"];
            Preferences.SearchUsername = (bool)dict["SearchUsername"];
            Preferences.SearchNotes = (bool)dict["SearchNotes"];
            Preferences.SearchURL = (bool)dict["SearchURL"];
            Preferences.InactivityTimer = (int)dict["InactivityTimer"];
            Preferences.ViewUsername = (bool)dict["ViewUsername"];
            Preferences.ViewURL = (bool)dict["ViewURL"];
        } // end SetPreferences

        private void CreateColumns()
        {
            while (vaultListView.Columns.Count > 2)
            {
                vaultListView.Columns.RemoveAt(2);
            }

            if (Preferences.ViewUsername)
            {
                vaultListView.Columns.Add("Username", 150, HorizontalAlignment.Left);
            }

            if (Preferences.ViewURL)
            {
                vaultListView.Columns.Add("URL", 150, HorizontalAlignment.Left);
            }
        } // end CreateColumns

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            AddVaultItemForm addForm = new AddVaultItemForm(this.sentinel, this.dao);
            addForm.ShowDialog();

            RefreshItems();

            return;

        } // end addItemBtn_Click


        private void PopulateListView()
        {
            List<VaultItem> vaultItems = dao.GetAll();


            foreach (VaultItem vaultItem in vaultItems)
            {
                vaultListView.Items.Add(VaultToListItem(vaultItem));
            }

        } // end PopulateListView

        private void RefreshItems()
        {
            searchTextBox.Text = "";
            vaultListView.Items.Clear();
            CreateColumns();
            PopulateListView();
        } // end RefreshItems


        private ListViewItem VaultToListItem(VaultItem vaultItem)
        {
            ListViewItem listItem = new ListViewItem();

            // Default Columns
            listItem.SubItems.Add("ID");
            listItem.SubItems.Add("Name");
            listItem.SubItems[0].Text = vaultItem.ID.ToString();
            listItem.SubItems[1].Text = vaultItem.Name;

            // Preferred Columns
            int i = 2;
            if (Preferences.ViewUsername)
            {
                listItem.SubItems.Add("Username");
                listItem.SubItems[i].Text = Util.Decode(sentinel.Decrypt(vaultItem.Username, vaultItem.IV));
                i++;
            }

            if (Preferences.ViewURL)
            {
                listItem.SubItems.Add("URL");
                listItem.SubItems[i].Text = Util.Decode(sentinel.Decrypt(vaultItem.URL, vaultItem.IV));
            }


            return listItem;
        } // end VaultToListItem

        private VaultItem GetCurrentVaultItem()
        {
            return this.dao.Get(Int32.Parse(SelectedListViewItem.SubItems[0].Text));
        }

        private void copyPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VaultItem vaultItem = GetCurrentVaultItem();
            byte[] plaintext = sentinel.Decrypt(vaultItem.Password, vaultItem.IV);
            Clipboard.SetText(Util.Decode(plaintext));
        } // end copyPasswordToolStripMenuItem_Click


        private void vaultListView_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = vaultListView.GetItemAt(e.X, e.Y);
                SelectedListViewItem = item;
            }

        } // end vaultListView_MouseClick

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditVaultItem();
        } // end editToolStripMenuItem_Click

        private void EditVaultItem()
        {
            EditVaultItemForm editForm = new EditVaultItemForm(GetCurrentVaultItem(), sentinel, dao);
            editForm.ShowDialog();

            RefreshItems();
        } // end EditVaultItem

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfirmForm confirmForm = new ConfirmForm();
            confirmForm.SetText("Are you sure you want to permanently delete this item?");
            confirmForm.ShowDialog();

            if (confirmForm.GetConfirmed())
            {
                dao.Delete(GetCurrentVaultItem());
            }

            RefreshItems();

        } // end deleteToolStripMenuItem_Click

        private void vaultListView_ItemActivate(object sender, EventArgs e)
        {
            SelectedListViewItem = vaultListView.SelectedItems[0];
            EditVaultItem();
        } // end vaultListView_ItemActivate

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this.sentinel);
            settingsForm.ShowDialog();

            if (settingsForm.Logout)
                Logout();

            else
            {
                RefreshItems();
                RestartInactivityTimer();
            }

        } // end settingsBtn_Click

        private void Logout()
        {
            ClearSentinel();
            string applicationPath = Application.ExecutablePath;
            Process.Start(applicationPath);
            Application.Exit();
        } // end Logout

        private void importBtn_Click(object sender, EventArgs e)
        {
            ImportForm importForm = new ImportForm(sentinel);
            importForm.ShowDialog();

            RefreshItems();
        } // end importBtn_Click

        private List<VaultItem> SearchItemsByTerm(string term)
        {
            List<VaultItem> allVaultItems = dao.GetAll();

            List<VaultItem> resultItems = new List<VaultItem>();

            foreach (VaultItem item in allVaultItems)
            {
                // Check 'Name' Field
                if (item.Name.ToLower().Contains(term.ToLower()))
                {
                    resultItems.Add(item);
                    continue;
                }

                // Check 'Username' Field
                if (Preferences.SearchUsername)
                    if (Util.Decode(sentinel.Decrypt(item.Username, item.IV)).ToLower().Contains(term.ToLower()))
                    {
                        resultItems.Add(item);
                        continue;
                    }

                // Check 'Notes' Field
                if (Preferences.SearchNotes)
                    if (Util.Decode(sentinel.Decrypt(item.Notes, item.IV)).ToLower().Contains(term.ToLower()))
                    {
                        resultItems.Add(item);
                        continue;
                    }

                // Check 'URL' Field
                if (Preferences.SearchURL)
                    if (Util.Decode(sentinel.Decrypt(item.URL, item.IV)).ToLower().Contains(term.ToLower()))
                    {
                        resultItems.Add(item);
                        continue;
                    }

            } // end foreach

            return resultItems;

        } // end SearchItemsByTerm

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string term = searchTextBox.Text.Trim();

            // Show Everything if Nothing Searched
            if (String.IsNullOrWhiteSpace(term))
            {
                RefreshItems();
                return;
            }

            // Get Searched Items
            List<VaultItem> items = SearchItemsByTerm(term);

            // Populate List
            vaultListView.Items.Clear();
            foreach (VaultItem item in items)
                vaultListView.Items.Add(VaultToListItem(item));


        } // end searchTextBox_TextChanged

        private void lockBtn_Click(object sender, EventArgs e)
        {
            LockApp();
        } // end lockBtn_Click

        private void LockApp()
        {
            this.Lock = true;
            ClearSentinel();
            this.Close();
        } // end LockApp


        private void generateBtn_Click(object sender, EventArgs e)
        {
            GenerateForm genForm = new GenerateForm();
            genForm.ShowDialog();

        } // end generateBtn_Click


    } // end form class
} // end namespace
