using Grimoire.Botting;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Tools;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;

namespace Grimoire.UI
{
    public class Loaders : Form
    {
        public enum Type
        {
            ShopItems,
            QuestIDs,
            Quests,
            InventoryItems,
            TempItems,
            BankItems,
            Monsters
        }

        private IContainer components;

        private TextBox txtLoaders;

        private ComboBox cbLoad;

        private Button btnLoad;

        private ComboBox cbGrab;

        private Button btnGrab;

        private Button btnSave;

        private Panel panel1;

        private Panel panel2;

        private SplitContainer splitContainer1;

        private Button btnLoad1;

        private Button btnForceAccept;

        private TableLayoutPanel tableLayoutPanel1;

        private TreeView treeGrabbed;

        public static Loaders Instance
        {
            get;
        } = new Loaders();

        public static Type TreeType
        {
            get;
            set;
        }

        private Loaders()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int result;
            switch (cbLoad.SelectedIndex)
            {
                case 0:
                    if (int.TryParse(txtLoaders.Text, out result))
                    {
                        Shop.LoadHairShop(result);
                    }
                    break;

                case 1:
                    if (int.TryParse(txtLoaders.Text, out result))
                    {
                        Shop.Load(result);
                    }
                    break;

                case 2:
                    if (txtLoaders.Text.Contains(","))
                    {
                        LoadQuests(txtLoaders.Text);
                    }
                    else if (int.TryParse(txtLoaders.Text, out result))
                    {
                        Player.Quests.Load(result);
                    }
                    break;

                case 3:
                    Shop.LoadArmorCustomizer();
                    break;
            }
        }

        private void LoadQuests(string str)
        {
            string[] source = str.Split(',');
            if (source.All((string s) => s.All(char.IsDigit)))
            {
                Player.Quests.Load(source.Select(int.Parse).ToList());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Save grabber data",
                CheckFileExists = false,
                Filter = "XML files|*.xml"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //using (Stream file = File.Open(openFileDialog.FileName, FileMode.Create))
                //{
                //    BinaryFormatter bf = new BinaryFormatter();
                //    bf.Serialize(file, treeGrabbed.Nodes.Cast<TreeNode>().ToList());
                //}
                XmlTextWriter textWriter = new XmlTextWriter(openFileDialog.FileName, System.Text.Encoding.ASCII)
                {
                    // set formatting style to indented
                    Formatting = Formatting.Indented
                };
                // writing the xml declaration tag
                textWriter.WriteStartDocument();
                // format it with new lines
                textWriter.WriteRaw("\r\n");
                // writing the main tag that encloses all node tags
                textWriter.WriteStartElement("TreeView");
                // save the nodes, recursive method
                SaveNodes(treeGrabbed.Nodes, textWriter);

                textWriter.WriteEndElement();

                textWriter.Close();
            }
        }

        private const string XmlNodeTag = "n";
        private const string XmlNodeTextAtt = "t";
        private const string XmlNodeTagAtt = "tg";
        private const string XmlNodeImageIndexAtt = "imageindex";

        private void SaveNodes(TreeNodeCollection nodesCollection, XmlTextWriter textWriter)
        {
            for (int i = 0; i < nodesCollection.Count; i++)
            {
                TreeNode node = nodesCollection[i];
                textWriter.WriteStartElement(XmlNodeTag);
                try
                {
                    string toadd = "";
                    for (int times = node.Text.Split(':')[0].Length; 9 > times; times++)
                        toadd += " ";
                    textWriter.WriteAttributeString(XmlNodeTextAtt, $"{node.Text.Split(':')[0]}:{toadd}{node.Text.Split(':')[1]}");
                }
                catch
                {
                    //string toadd = "";
                    //for (int times = node.Text.Split(':')[0].Length; 15 > times; times++)
                    //    toadd += "-";
                    textWriter.WriteAttributeString(XmlNodeTextAtt, $"{node.Text}");
                }
                //textWriter.WriteAttributeString(node.Text.Split(':')[0], node.Text.Split(':')[1]);
                //textWriter.WriteAttributeString(XmlNodeImageIndexAtt, node.ImageIndex.ToString());
                if (node.Tag != null)
                    textWriter.WriteAttributeString(XmlNodeTagAtt, node.Tag.ToString());
                // add other node properties to serialize here  
                if (node.Nodes.Count > 0)
                {
                    SaveNodes(node.Nodes, textWriter);
                }
                textWriter.WriteEndElement();
            }
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            treeGrabbed.BeginUpdate();
            treeGrabbed.Nodes.Clear();
            switch (cbGrab.SelectedIndex)
            {
                case 0:
                    Grabber.GrabShopItems(treeGrabbed);
                    break;

                case 1:
                    Grabber.GrabQuestIds(treeGrabbed);
                    break;

                case 2:
                    Grabber.GrabQuests(treeGrabbed);
                    break;

                case 3:
                    Grabber.GrabInventoryItems(treeGrabbed);
                    break;

                case 4:
                    Grabber.GrabTempItems(treeGrabbed);
                    break;

                case 5:
                    Grabber.GrabBankItems(treeGrabbed);
                    break;

                case 6:
                    Grabber.GrabMonsters(treeGrabbed);
                    break;
            }
            treeGrabbed.EndUpdate();
        }

        private void Loaders_FormClosing(object sender, FormClosingEventArgs e)
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Loaders));
            this.txtLoaders = new TextBox();
            this.cbLoad = new ComboBox();
            this.btnLoad = new Button();
            this.cbGrab = new ComboBox();
            this.btnGrab = new Button();
            this.btnSave = new Button();
            this.treeGrabbed = new TreeView();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.splitContainer1 = new SplitContainer();
            this.btnLoad1 = new Button();
            this.btnForceAccept = new Button();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((ISupportInitialize)this.splitContainer1).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLoaders
            // 
            this.txtLoaders.Anchor = AnchorStyles.Top | AnchorStyles.Left
            | AnchorStyles.Right;
            this.txtLoaders.Location = new Point(52, 12);
            this.txtLoaders.Name = "txtLoaders";
            this.txtLoaders.Size = new Size(136, 20);
            this.txtLoaders.TabIndex = 29;
            // 
            // cbLoad
            // 
            this.cbLoad.Anchor = AnchorStyles.Top | AnchorStyles.Left
            | AnchorStyles.Right;
            this.cbLoad.FormattingEnabled = true;
            this.cbLoad.Items.AddRange(new object[] {
            "Hair shop",
            "Shop",
            "Quest",
            "Armor customizer"});
            this.cbLoad.Location = new Point(52, 38);
            this.cbLoad.Name = "cbLoad";
            this.cbLoad.Size = new Size(136, 21);
            this.cbLoad.TabIndex = 30;
            this.cbLoad.SelectedIndexChanged += new EventHandler(this.cbLoad_SelectedIndexChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Left
            | AnchorStyles.Right;
            this.btnLoad.Location = new Point(52, 65);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new Size(136, 23);
            this.btnLoad.TabIndex = 31;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new EventHandler(this.btnLoad_Click);
            // 
            // cbGrab
            // 
            this.cbGrab.Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            | AnchorStyles.Right;
            this.cbGrab.FormattingEnabled = true;
            this.cbGrab.Items.AddRange(new object[] {
            "Shop items",
            "Quest IDs",
            "Quest items, drop rates",
            "Inventory items",
            "Temp inventory items",
            "Bank items",
            "Monsters"});
            this.cbGrab.Location = new Point(12, 301);
            this.cbGrab.Name = "cbGrab";
            this.cbGrab.Size = new Size(217, 21);
            this.cbGrab.TabIndex = 33;
            // 
            // btnGrab
            // 
            this.btnGrab.Dock = DockStyle.Fill;
            this.btnGrab.Location = new Point(0, 0);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new Size(108, 26);
            this.btnGrab.TabIndex = 34;
            this.btnGrab.Text = "Grab";
            this.btnGrab.UseVisualStyleBackColor = true;
            this.btnGrab.Click += new EventHandler(this.btnGrab_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = DockStyle.Fill;
            this.btnSave.Location = new Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(108, 26);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // treeGrabbed
            // 
            this.treeGrabbed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
            | AnchorStyles.Left
            | AnchorStyles.Right;
            this.treeGrabbed.LabelEdit = true;
            this.treeGrabbed.Location = new Point(12, 94);
            this.treeGrabbed.Name = "treeGrabbed";
            this.treeGrabbed.Size = new Size(217, 201);
            this.treeGrabbed.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(108, 26);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGrab);
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(108, 26);
            this.panel2.TabIndex = 40;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            | AnchorStyles.Right;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new Point(12, 329);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new Size(217, 26);
            this.splitContainer1.SplitterDistance = 108;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 41;
            // 
            // btnLoad1
            // 
            this.btnLoad1.Dock = DockStyle.Fill;
            this.btnLoad1.Location = new Point(0, 0);
            this.btnLoad1.Margin = new Padding(0, 0, 0, 0);
            this.btnLoad1.Name = "btnLoad1";
            this.btnLoad1.Size = new Size(108, 23);
            this.btnLoad1.TabIndex = 31;
            this.btnLoad1.Text = "Load";
            this.btnLoad1.UseVisualStyleBackColor = true;
            this.btnLoad1.Click += new EventHandler(this.btnLoad_Click);
            // 
            // btnForceAccept
            // 
            this.btnForceAccept.Dock = DockStyle.Fill;
            this.btnForceAccept.Location = new Point(108, 0);
            this.btnForceAccept.Margin = new Padding(0, 0, 0, 0);
            this.btnForceAccept.Name = "btnForceAccept";
            this.btnForceAccept.Size = new Size(108, 23);
            this.btnForceAccept.TabIndex = 31;
            this.btnForceAccept.Text = "Force Accept";
            this.btnForceAccept.UseVisualStyleBackColor = true;
            this.btnForceAccept.Click += new EventHandler(this.btnForceAccept_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left
            | AnchorStyles.Right;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnLoad1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnForceAccept, 1, 0);
            this.tableLayoutPanel1.Location = new Point(12, 62);
            this.tableLayoutPanel1.Margin = new Padding(0, 0, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new Size(216, 23);
            this.tableLayoutPanel1.TabIndex = 42;
            this.tableLayoutPanel1.Visible = false;
            // 
            // Loaders
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(241, 360);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.treeGrabbed);
            this.Controls.Add(this.cbGrab);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cbLoad);
            this.Controls.Add(this.txtLoaders);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.MinimizeBox = false;
            this.Name = "Loaders";
            this.Text = "Loaders and grabbers";
            this.TopMost = true;
            this.FormClosing += new FormClosingEventHandler(this.Loaders_FormClosing);
            this.Load += new EventHandler(this.Loaders_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)this.splitContainer1).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private readonly string font = Config.Load(Application.StartupPath + "\\config.cfg").Get("font");
        private readonly float? fontSize = float.Parse(Config.Load(Application.StartupPath + "\\config.cfg").Get("fontSize") ?? "8.25", System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

        private void Loaders_Load(object sender, EventArgs e)
        {
            this.FormClosing += this.Loaders_FormClosing;
            if (font != null && fontSize != null)
            {
                this.Font = new Font(font, (float)fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
        }

        private void cbLoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoad.SelectedIndex == cbLoad.Items.Count - 2)
            {
                btnLoad.Visible = false;
                tableLayoutPanel1.Visible = true;
            }
            else
            {
                btnLoad.Visible = true;
                tableLayoutPanel1.Visible = false;
            }
        }

        private void btnForceAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Player.Quests.Accept(int.Parse(txtLoaders.Text));
            }
            catch { }
        }
    }
}