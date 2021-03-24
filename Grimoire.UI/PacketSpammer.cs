using Grimoire.Networking;
using Grimoire.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Grimoire.UI
{
    public class PacketSpammer : Form
    {
        private IContainer components;

        private ListBox lstPackets;

        private TextBox txtPacket;

        private Button btnAdd;

        private Button btnClear;

        private Button btnLoad;

        private Button btnSave;

        private Button btnStart;

        private Button btnStop;

        private NumericUpDown numDelay;

        private Button btnSend;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnRemove;

        public static PacketSpammer Instance
        {
            get;
        } = new PacketSpammer();

        private PacketSpammer()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstPackets.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPacket.Text.Length > 0)
            {
                lstPackets.Items.Add(txtPacket.Text);
                txtPacket.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstPackets.Items.Count > 0)
            {
                SaveConfig();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lstPackets.Items.Clear();
            LoadConfig();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Spammer.Instance.Stop();
            Spammer.Instance.IndexChanged -= IndexChanged;
            SetButtonsEnabled(enabled: true);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lstPackets.Items.Count > 0)
            {
                SetButtonsEnabled(enabled: false);
                List<string> packets = lstPackets.Items.Cast<string>().ToList();
                int delay = (int)numDelay.Value;
                Spammer.Instance.IndexChanged += IndexChanged;
                Spammer.Instance.Start(packets, delay);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (txtPacket.TextLength > 0)
            {
                btnSend.Enabled = false;
                await Proxy.Instance.SendToServer(txtPacket.Text);
                btnSend.Enabled = true;
            }
        }

        private void PacketSpammer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void SaveConfig()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Save spammer file";
                openFileDialog.Filter = "XML files|*.xml";
                openFileDialog.CheckFileExists = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(openFileDialog.FileName))
                    {
                        xmlWriter.WriteStartElement("autoer");
                        foreach (string item in lstPackets.Items)
                        {
                            xmlWriter.WriteElementString("packet", item);
                        }
                        xmlWriter.WriteElementString("author", "Author");
                        xmlWriter.WriteElementString("spamspeed", numDelay.Value.ToString());
                        xmlWriter.WriteEndElement();
                    }
                }
            }
        }

        private void LoadConfig()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Load spammer file";
                openFileDialog.Filter = "XML files|*.xml";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (XElement item in XElement.Load(openFileDialog.FileName).Nodes())
                    {
                        if (item.Name == "packet")
                        {
                            lstPackets.Items.Add(item.Value);
                        }
                        else if (item.Name == "spamspeed")
                        {
                            string text = item.Name.ToString();
                            numDelay.Value = text.All(char.IsDigit) ? int.Parse(text) : 2000;
                        }
                    }
                }
            }
        }

        private void SetButtonsEnabled(bool enabled)
        {
            btnStart.Enabled = enabled;
            btnAdd.Enabled = enabled;
            btnClear.Enabled = enabled;
            btnLoad.Enabled = enabled;
        }

        private void IndexChanged(int index)
        {
            lstPackets.Invoke((Action)delegate
            {
                lstPackets.SelectedIndex = index;
            });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstPackets.SelectedIndex;
            if (selectedIndex > -1)
            {
                lstPackets.Items.RemoveAt(selectedIndex);
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(PacketSpammer));
            this.lstPackets = new ListBox();
            this.txtPacket = new TextBox();
            this.btnAdd = new Button();
            this.btnClear = new Button();
            this.btnLoad = new Button();
            this.btnSave = new Button();
            this.btnStart = new Button();
            this.btnStop = new Button();
            this.numDelay = new NumericUpDown();
            this.btnSend = new Button();
            this.btnRemove = new Button();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            ((ISupportInitialize)this.numDelay).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPackets
            // 
            this.lstPackets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
            | AnchorStyles.Left
            | AnchorStyles.Right;
            this.lstPackets.BorderStyle = BorderStyle.FixedSingle;
            this.lstPackets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.lstPackets.FormattingEnabled = true;
            this.lstPackets.Location = new System.Drawing.Point(12, 12);
            this.lstPackets.Name = "lstPackets";
            this.lstPackets.Size = new System.Drawing.Size(276, 93);
            this.lstPackets.TabIndex = 0;
            // 
            // txtPacket
            // 
            this.txtPacket.Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            | AnchorStyles.Right;
            this.txtPacket.Location = new System.Drawing.Point(12, 111);
            this.txtPacket.Name = "txtPacket";
            this.txtPacket.Size = new System.Drawing.Size(276, 20);
            this.txtPacket.TabIndex = 27;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(208, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 23);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(140, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(62, 23);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = DockStyle.Fill;
            this.btnLoad.Location = new System.Drawing.Point(140, 32);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(62, 23);
            this.btnLoad.TabIndex = 30;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(208, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(208, 61);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(64, 25);
            this.btnStart.TabIndex = 32;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(140, 61);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(62, 25);
            this.btnStop.TabIndex = 33;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new EventHandler(this.btnStop_Click);
            // 
            // numDelay
            // 
            this.numDelay.Dock = DockStyle.Fill;
            this.numDelay.Location = new System.Drawing.Point(3, 3);
            this.numDelay.Maximum = new decimal(new int[] {
            61000,
            0,
            0,
            0});
            this.numDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(68, 20);
            this.numDelay.TabIndex = 34;
            this.numDelay.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // btnSend
            // 
            this.btnSend.Dock = DockStyle.Fill;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSend.Location = new System.Drawing.Point(3, 61);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(68, 25);
            this.btnSend.TabIndex = 35;
            this.btnSend.Text = "Send once";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new EventHandler(this.btnSend_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = DockStyle.Fill;
            this.btnRemove.Location = new System.Drawing.Point(77, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(57, 23);
            this.btnRemove.TabIndex = 36;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            | AnchorStyles.Right;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRemove, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.numDelay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoad, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSend, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 137);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(275, 89);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // PacketSpammer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 228);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtPacket);
            this.Controls.Add(this.lstPackets);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = "PacketSpammer";
            this.Text = "Packet spammer";
            this.TopMost = true;
            this.FormClosing += new FormClosingEventHandler(this.PacketSpammer_FormClosing);
            ((ISupportInitialize)this.numDelay).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}