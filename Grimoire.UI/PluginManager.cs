using Grimoire.Tools.Plugins;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Grimoire.UI
{
    public class PluginManager : Form
    {
        private IContainer components;

        public GroupBox gbLoaded;

        public Button btnUnload;

        public TextBox txtDesc;

        public Label lblAuthor;

        public ListBox lstLoaded;

        public GroupBox gbLoad;

        public Button btnBrowse;

        public Button btnLoad;
        private TreeView treePlugins;
        public TextBox txtPlugin;

        public static PluginManager Instance
        {
            get;
        } = new PluginManager();

        public PluginManager()
        {
            InitializeComponent();
        }

        private string path = Application.StartupPath + "\\Plugins";

        private void PluginManager_Load(object sender, EventArgs e)
        {
            lstLoaded.DisplayMember = "Name";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            UpdateTree();
        }

        private void AddTreeNodes(TreeNode node, string path)
        {
            foreach (string item in Directory.EnumerateDirectories(path, "*", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(item);
                if (node.Nodes.Cast<TreeNode>().ToList().All((TreeNode n) => n.Text != add))
                {
                    node.Nodes.Add(add).Nodes.Add("Loading...");
                }
            }
            foreach (string item2 in Directory.EnumerateFiles(path, "*.dll", SearchOption.TopDirectoryOnly))
            {
                string add2 = Path.GetFileName(item2);
                if (node.Nodes.Cast<TreeNode>().ToList().All((TreeNode n) => n.Text != add2))
                {
                    node.Nodes.Add(add2);
                }
            }
        }

        private void AddTreeNodes(TreeView tree, string path)
        {
            foreach (string item in Directory.EnumerateDirectories(path, "*", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(item);
                if (tree.Nodes.Cast<TreeNode>().ToList().All((TreeNode n) => n.Text != add))
                {
                    tree.Nodes.Add(add).Nodes.Add("Loading...");
                }
            }
            foreach (string item2 in Directory.EnumerateFiles(path, "*.dll", SearchOption.TopDirectoryOnly))
            {
                string add2 = Path.GetFileName(item2);
                if (tree.Nodes.Cast<TreeNode>().ToList().All((TreeNode n) => n.Text != add2))
                {
                    tree.Nodes.Add(add2);
                }
            }
        }

        private void UpdateTree()
        {
            treePlugins.Nodes.Clear();
            AddTreeNodes(treePlugins, path);
        }

        private void treePlugins_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string text;
            if (File.Exists(text = Path.Combine(path, e.Node.FullPath)))
            {
                GrimoirePlugin grimoirePlugin = new GrimoirePlugin(text);
                if (grimoirePlugin.Load())
                {
                    txtPlugin.Clear();
                    lstLoaded.Items.Clear();
                    ListBox.ObjectCollection items = lstLoaded.Items;
                    object[] items2 = GrimoirePlugin.LoadedPlugins.ToArray();
                    items.AddRange(items2);
                    lstLoaded.SelectedItem = grimoirePlugin;
                }
                else
                {
                    MessageBox.Show(grimoirePlugin.LastError, "Grimoire", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void treePlugins_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string text;
            if (Directory.Exists(text = Path.Combine(path, e.Node.FullPath)))
            {
                AddTreeNodes(e.Node, text);
                if (e.Node.Nodes.Count > 0 && e.Node.Nodes[0].Text == "Loading...")
                {
                    e.Node.Nodes.RemoveAt(0);
                }
            }
        }

        private string Plugintext;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Load Grimoire plugin";
                openFileDialog.Filter = "Dynamic Link Library|*.dll";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPlugin.Text = openFileDialog.SafeFileName;
                    Plugintext = openFileDialog.FileName;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string text;
            if (File.Exists(text = Plugintext))
            {
                GrimoirePlugin grimoirePlugin = new GrimoirePlugin(text);
                if (grimoirePlugin.Load())
                {
                    txtPlugin.Clear();
                    lstLoaded.Items.Clear();
                    ListBox.ObjectCollection items = lstLoaded.Items;
                    object[] items2 = GrimoirePlugin.LoadedPlugins.ToArray();
                    items.AddRange(items2);
                    lstLoaded.SelectedItem = grimoirePlugin;
                }
                else
                {
                    MessageBox.Show(grimoirePlugin.LastError, "Grimoire", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            int selectedIndex;
            if ((selectedIndex = lstLoaded.SelectedIndex) > -1)
            {
                GrimoirePlugin grimoirePlugin = GrimoirePlugin.LoadedPlugins[selectedIndex];
                if (grimoirePlugin.Unload())
                {
                    lstLoaded.Items.RemoveAt(selectedIndex);
                    lblAuthor.Text = "Plugin created by:";
                    txtDesc.Clear();
                }
                else
                {
                    MessageBox.Show(grimoirePlugin.LastError, "Grimoire", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void lstLoaded_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex;
            if ((selectedIndex = lstLoaded.SelectedIndex) > -1)
            {
                GrimoirePlugin grimoirePlugin = GrimoirePlugin.LoadedPlugins[selectedIndex];
                lblAuthor.Text = "Plugin created by: " + grimoirePlugin.Author;
                txtDesc.Text = grimoirePlugin.Description;
            }
        }

        private void PluginManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(PluginManager));
            this.gbLoaded = new GroupBox();
            this.btnUnload = new Button();
            this.txtDesc = new TextBox();
            this.lblAuthor = new Label();
            this.lstLoaded = new ListBox();
            this.gbLoad = new GroupBox();
            this.btnBrowse = new Button();
            this.btnLoad = new Button();
            this.txtPlugin = new TextBox();
            this.treePlugins = new TreeView();
            this.gbLoaded.SuspendLayout();
            this.gbLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLoaded
            // 
            this.gbLoaded.Controls.Add(this.btnUnload);
            this.gbLoaded.Controls.Add(this.txtDesc);
            this.gbLoaded.Controls.Add(this.lblAuthor);
            this.gbLoaded.Controls.Add(this.lstLoaded);
            this.gbLoaded.Location = new System.Drawing.Point(12, 213);
            this.gbLoaded.Name = "gbLoaded";
            this.gbLoaded.Size = new System.Drawing.Size(292, 267);
            this.gbLoaded.TabIndex = 12;
            this.gbLoaded.TabStop = false;
            this.gbLoaded.Text = "Loaded plugins";
            // 
            // btnUnload
            // 
            this.btnUnload.Location = new System.Drawing.Point(155, 238);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(128, 23);
            this.btnUnload.TabIndex = 3;
            this.btnUnload.Text = "Unload selected plugin";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new EventHandler(this.btnUnload_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(6, 120);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = ScrollBars.Both;
            this.txtDesc.Size = new System.Drawing.Size(277, 112);
            this.txtDesc.TabIndex = 2;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(6, 104);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(92, 13);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Plugin created by:";
            // 
            // lstLoaded
            // 
            this.lstLoaded.FormattingEnabled = true;
            this.lstLoaded.Location = new System.Drawing.Point(6, 19);
            this.lstLoaded.Name = "lstLoaded";
            this.lstLoaded.ScrollAlwaysVisible = true;
            this.lstLoaded.Size = new System.Drawing.Size(277, 82);
            this.lstLoaded.TabIndex = 0;
            this.lstLoaded.SelectedIndexChanged += new EventHandler(this.lstLoaded_SelectedIndexChanged);
            // 
            // gbLoad
            // 
            this.gbLoad.Controls.Add(this.btnBrowse);
            this.gbLoad.Controls.Add(this.btnLoad);
            this.gbLoad.Controls.Add(this.txtPlugin);
            this.gbLoad.Location = new System.Drawing.Point(12, 12);
            this.gbLoad.Name = "gbLoad";
            this.gbLoad.Size = new System.Drawing.Size(292, 51);
            this.gbLoad.TabIndex = 11;
            this.gbLoad.TabStop = false;
            this.gbLoad.Text = "Load plugin";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(200, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new EventHandler(this.btnBrowse_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(231, 17);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(55, 23);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new EventHandler(this.btnLoad_Click);
            // 
            // txtPlugin
            // 
            this.txtPlugin.Location = new System.Drawing.Point(6, 19);
            this.txtPlugin.Name = "txtPlugin";
            this.txtPlugin.Size = new System.Drawing.Size(188, 20);
            this.txtPlugin.TabIndex = 4;
            // 
            // treePlugins
            // 
            this.treePlugins.Location = new System.Drawing.Point(12, 70);
            this.treePlugins.Name = "treePlugins";
            this.treePlugins.Size = new System.Drawing.Size(292, 136);
            this.treePlugins.TabIndex = 13;
            this.treePlugins.AfterExpand += new TreeViewEventHandler(this.treePlugins_AfterExpand);
            this.treePlugins.AfterSelect += new TreeViewEventHandler(this.treePlugins_AfterSelect);
            // 
            // PluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 485);
            this.Controls.Add(this.treePlugins);
            this.Controls.Add(this.gbLoaded);
            this.Controls.Add(this.gbLoad);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = "PluginManager";
            this.Text = "Plugin Manager";
            this.TopMost = true;
            this.FormClosing += new FormClosingEventHandler(this.PluginManager_FormClosing);
            this.Load += new EventHandler(this.PluginManager_Load);
            this.gbLoaded.ResumeLayout(false);
            this.gbLoaded.PerformLayout();
            this.gbLoad.ResumeLayout(false);
            this.gbLoad.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}