using Grimoire.Networking;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Grimoire.UI
{
    public class PacketLogger : Form
    {
        private IContainer components;

        private TextBox txtPackets;

        private Button btnStart;

        private Button btnStop;

        private Button btnCopy;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnClear;

        public static PacketLogger Instance
        {
            get;
        } = new PacketLogger();

        private PacketLogger()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPackets.Clear();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtPackets.Text.Length > 0)
            {
                Clipboard.SetText(txtPackets.Text);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Proxy.Instance.ReceivedFromClient -= PacketCaptured;
            btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            Proxy.Instance.ReceivedFromClient += PacketCaptured;
        }

        private void PacketCaptured(Networking.Message msg)
        {
            if (msg.RawContent != null && msg.RawContent.Contains("%xt%zm%"))
            {
                txtPackets.Invoke((Action)delegate
                {
                    txtPackets.AppendText(msg.RawContent + Environment.NewLine);
                });
            }
        }

        private void PacketLogger_FormClosing(object sender, FormClosingEventArgs e)
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(PacketLogger));
            this.txtPackets = new TextBox();
            this.btnStart = new Button();
            this.btnStop = new Button();
            this.btnCopy = new Button();
            this.btnClear = new Button();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPackets
            // 
            this.txtPackets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
            | AnchorStyles.Left
            | AnchorStyles.Right;
            this.txtPackets.Location = new System.Drawing.Point(12, 12);
            this.txtPackets.Multiline = true;
            this.txtPackets.Name = "txtPackets";
            this.txtPackets.Size = new System.Drawing.Size(420, 160);
            this.txtPackets.TabIndex = 15;
            // 
            // btnStart
            // 
            this.btnStart.Dock = DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(318, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 24);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(213, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(99, 24);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new EventHandler(this.btnStop_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Dock = DockStyle.Fill;
            this.btnCopy.Location = new System.Drawing.Point(108, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(99, 24);
            this.btnCopy.TabIndex = 18;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new EventHandler(this.btnCopy_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(3, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 24);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            | AnchorStyles.Right;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy, 1, 0);
            this.tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 175);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 30);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // PacketLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 207);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtPackets);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MinimizeBox = false;
            this.Name = "PacketLogger";
            this.Text = "Packet logger";
            this.TopMost = true;
            this.FormClosing += new FormClosingEventHandler(this.PacketLogger_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}