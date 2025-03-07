namespace PassSentinel
{
    partial class VaultViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaultViewForm));
            vaultListView = new ListView();
            IDCol = new ColumnHeader();
            nameCol = new ColumnHeader();
            listItemContextMenuStrip = new ContextMenuStrip(components);
            copyPasswordToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            addItemBtn = new Button();
            importBtn = new Button();
            settingsBtn = new Button();
            searchTextBox = new TextBox();
            searchLabel = new Label();
            lockBtn = new Button();
            imageList1 = new ImageList(components);
            generateBtn = new Button();
            listItemContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // vaultListView
            // 
            vaultListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            vaultListView.Columns.AddRange(new ColumnHeader[] { IDCol, nameCol });
            vaultListView.ContextMenuStrip = listItemContextMenuStrip;
            vaultListView.FullRowSelect = true;
            vaultListView.GridLines = true;
            vaultListView.Location = new Point(123, 50);
            vaultListView.Name = "vaultListView";
            vaultListView.Size = new Size(338, 428);
            vaultListView.TabIndex = 0;
            vaultListView.UseCompatibleStateImageBehavior = false;
            vaultListView.View = View.Details;
            vaultListView.SelectedIndexChanged += vaultListView_SelectedIndexChanged;
            vaultListView.MouseClick += vaultListView_MouseClick;
            // 
            // IDCol
            // 
            IDCol.Text = "ID";
            IDCol.Width = 30;
            // 
            // nameCol
            // 
            nameCol.Text = "Name";
            nameCol.Width = 150;
            // 
            // listItemContextMenuStrip
            // 
            listItemContextMenuStrip.Items.AddRange(new ToolStripItem[] { copyPasswordToolStripMenuItem, editToolStripMenuItem, deleteToolStripMenuItem });
            listItemContextMenuStrip.Name = "contextMenuStrip1";
            listItemContextMenuStrip.Size = new Size(156, 70);
            // 
            // copyPasswordToolStripMenuItem
            // 
            copyPasswordToolStripMenuItem.Name = "copyPasswordToolStripMenuItem";
            copyPasswordToolStripMenuItem.Size = new Size(155, 22);
            copyPasswordToolStripMenuItem.Text = "Copy Password";
            copyPasswordToolStripMenuItem.Click += copyPasswordToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(155, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(155, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // addItemBtn
            // 
            addItemBtn.Location = new Point(25, 50);
            addItemBtn.Name = "addItemBtn";
            addItemBtn.Size = new Size(75, 23);
            addItemBtn.TabIndex = 1;
            addItemBtn.Text = "Add New";
            addItemBtn.UseVisualStyleBackColor = true;
            addItemBtn.Click += addItemBtn_Click;
            // 
            // importBtn
            // 
            importBtn.Location = new Point(25, 426);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(75, 23);
            importBtn.TabIndex = 2;
            importBtn.Text = "Import";
            importBtn.UseVisualStyleBackColor = true;
            importBtn.Click += importBtn_Click;
            // 
            // settingsBtn
            // 
            settingsBtn.Anchor = AnchorStyles.None;
            settingsBtn.Location = new Point(25, 455);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(75, 23);
            settingsBtn.TabIndex = 4;
            settingsBtn.Text = "Settings";
            settingsBtn.UseVisualStyleBackColor = true;
            settingsBtn.Click += settingsBtn_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Location = new Point(174, 19);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(251, 23);
            searchTextBox.TabIndex = 5;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(123, 22);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(45, 15);
            searchLabel.TabIndex = 6;
            searchLabel.Text = "Search:";
            // 
            // lockBtn
            // 
            lockBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lockBtn.ImageIndex = 0;
            lockBtn.ImageList = imageList1;
            lockBtn.Location = new Point(431, 17);
            lockBtn.Name = "lockBtn";
            lockBtn.Size = new Size(30, 27);
            lockBtn.TabIndex = 7;
            lockBtn.UseVisualStyleBackColor = true;
            lockBtn.Click += lockBtn_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "padlock.png");
            // 
            // generateBtn
            // 
            generateBtn.Location = new Point(25, 79);
            generateBtn.Name = "generateBtn";
            generateBtn.Size = new Size(75, 23);
            generateBtn.TabIndex = 8;
            generateBtn.Text = "Generate";
            generateBtn.UseVisualStyleBackColor = true;
            generateBtn.Click += generateBtn_Click;
            // 
            // VaultViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 496);
            Controls.Add(generateBtn);
            Controls.Add(lockBtn);
            Controls.Add(searchLabel);
            Controls.Add(searchTextBox);
            Controls.Add(settingsBtn);
            Controls.Add(importBtn);
            Controls.Add(addItemBtn);
            Controls.Add(vaultListView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VaultViewForm";
            Text = "Vault - PassSentinel";
            Load += VaultViewForm_Load;
            listItemContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView vaultListView;
        private ColumnHeader IDCol;
        private ColumnHeader nameCol;
        private Button addItemBtn;
        private ContextMenuStrip listItemContextMenuStrip;
        private ToolStripMenuItem copyPasswordToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button importBtn;
        private Button settingsBtn;
        private TextBox searchTextBox;
        private Label searchLabel;
        private Button lockBtn;
        private ImageList imageList1;
        private Button generateBtn;
    }
}