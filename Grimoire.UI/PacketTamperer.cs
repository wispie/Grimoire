using Grimoire.Networking;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Grimoire.UI
{
    public class PacketTamperer : Form
    {
        private IContainer components;

        private RichTextBox txtSend;

        private RichTextBox txtReceive;

        private Button btnToServer;

        private CheckBox chkFromClient;

        private CheckBox chkFromServer;
        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnToClient;

        public static PacketTamperer Instance
        {
            get;
        } = new PacketTamperer();

        private PacketTamperer()
        {
            InitializeComponent();
        }

        private void PacketTamperer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void chkFromServer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFromServer.Checked)
            {
                Proxy.Instance.ReceivedFromServer += ReceivedFromServer;
            }
            else
            {
                Proxy.Instance.ReceivedFromServer -= ReceivedFromServer;
            }
        }

        private void chkFromClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFromClient.Checked)
            {
                Proxy.Instance.ReceivedFromClient += ReceivedFromClient;
            }
            else
            {
                Proxy.Instance.ReceivedFromClient -= ReceivedFromClient;
            }
        }

        private async void btnToClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSend.Text))
            {
                btnToClient.Enabled = false;
                await Proxy.Instance.SendToClient(txtSend.Text);
                btnToClient.Enabled = true;
            }
        }

        private async void btnToServer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSend.Text))
            {
                btnToServer.Enabled = false;
                await Proxy.Instance.SendToServer(txtSend.Text);
                btnToServer.Enabled = true;
            }
        }

        private void ReceivedFromClient(Networking.Message message)
        {
            txtSend.Invoke((Action)delegate
            {
                Append("From client: " + message.RawContent);
            });
        }

        private void ReceivedFromServer(Networking.Message message)
        {
            txtSend.Invoke((Action)delegate
            {
                Append("From server: " + message.RawContent);
            });
        }

        private void Append(string text)
        {
            txtReceive.AppendText(text + Environment.NewLine + Environment.NewLine);
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(PacketTamperer));
            this.txtSend = new RichTextBox();
            this.txtReceive = new RichTextBox();
            this.btnToServer = new Button();
            this.chkFromClient = new CheckBox();
            this.chkFromServer = new CheckBox();
            this.btnToClient = new Button();
            this.splitContainer1 = new SplitContainer();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            ((ISupportInitialize)this.splitContainer1).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Dock = DockStyle.Fill;
            this.txtSend.Location = new System.Drawing.Point(0, 0);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(536, 99);
            this.txtSend.TabIndex = 0;
            this.txtSend.Text = "";
            // 
            // txtReceive
            // 
            this.txtReceive.Dock = DockStyle.Fill;
            this.txtReceive.Location = new System.Drawing.Point(0, 0);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(536, 212);
            this.txtReceive.TabIndex = 1;
            this.txtReceive.Text = "";
            // 
            // btnToServer
            // 
            this.btnToServer.Dock = DockStyle.Fill;
            this.btnToServer.Location = new System.Drawing.Point(448, 3);
            this.btnToServer.Name = "btnToServer";
            this.btnToServer.Size = new System.Drawing.Size(85, 23);
            this.btnToServer.TabIndex = 3;
            this.btnToServer.Text = "Send to server";
            this.btnToServer.UseVisualStyleBackColor = true;
            this.btnToServer.Click += new EventHandler(this.btnToServer_Click);
            // 
            // chkFromClient
            // 
            this.chkFromClient.AutoSize = true;
            this.chkFromClient.Dock = DockStyle.Fill;
            this.chkFromClient.Location = new System.Drawing.Point(127, 3);
            this.chkFromClient.Name = "chkFromClient";
            this.chkFromClient.Size = new System.Drawing.Size(120, 23);
            this.chkFromClient.TabIndex = 4;
            this.chkFromClient.Text = "Capture from client";
            this.chkFromClient.UseVisualStyleBackColor = true;
            this.chkFromClient.CheckedChanged += new EventHandler(this.chkFromClient_CheckedChanged);
            // 
            // chkFromServer
            // 
            this.chkFromServer.AutoSize = true;
            this.chkFromServer.Dock = DockStyle.Fill;
            this.chkFromServer.Location = new System.Drawing.Point(0, 0);
            this.chkFromServer.Name = "chkFromServer";
            this.chkFromServer.Size = new System.Drawing.Size(118, 23);
            this.chkFromServer.TabIndex = 5;
            this.chkFromServer.Text = "Capture from server";
            this.chkFromServer.UseVisualStyleBackColor = true;
            this.chkFromServer.CheckedChanged += new EventHandler(this.chkFromServer_CheckedChanged);
            // 
            // btnToClient
            // 
            this.btnToClient.Dock = DockStyle.Fill;
            this.btnToClient.Location = new System.Drawing.Point(358, 3);
            this.btnToClient.Name = "btnToClient";
            this.btnToClient.Size = new System.Drawing.Size(84, 23);
            this.btnToClient.TabIndex = 6;
            this.btnToClient.Text = "Send to client";
            this.btnToClient.UseVisualStyleBackColor = true;
            this.btnToClient.Click += new EventHandler(this.btnToClient_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
            | AnchorStyles.Left
            | AnchorStyles.Right;
            this.splitContainer1.Location = new System.Drawing.Point(16, 41);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSend);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtReceive);
            this.splitContainer1.Size = new System.Drawing.Size(536, 315);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkFromServer);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 23);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(253, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(99, 23);
            this.panel2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left
            | AnchorStyles.Right;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.btnToClient, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnToServer, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkFromClient, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 29);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // PacketTamperer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 368);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Name = "PacketTamperer";
            this.Text = "Packet Tamperer";
            this.TopMost = true;
            this.FormClosing += new FormClosingEventHandler(this.PacketTamperer_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)this.splitContainer1).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}