using Grimoire.Botting;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Grimoire.UI
{
    public class LogForm : Form
    {
        public class DebugLogger : TraceListener
        {
            private LogForm log;

            public DebugLogger(LogForm log)
            {
                this.log = log;
            }

            public override void Write(string message)
            {
                log.AppendDebug(message);
            }

            public override void WriteLine(string message)
            {
                log.AppendDebug(message + "\r\n");
            }
        }

        public static DebugLogger logRec;

        private IContainer components;

        public TextBox iable;

        private Button btnClear;

        private Button btnSave;

        private TabControl tabLogs;

        private TabPage tabLogDebug;

        private TabPage tabLogScript;

        public TextBox txtLogDebug;

        public TextBox txtLogScript;

        private TabPage tabLogDrops;

        private TabPage tabLogChat;

        private TextBox txtLogDrops;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem changeFontToolStripMenuItem;

        private ToolStripMenuItem changeColorToolStripMenuItem;

        private ColorDialog colorDialog1;

        private TextBox txtLogChat;

        public TextBox SelectedLog
        {
            get
            {
                if (tabLogs.SelectedIndex == 0)
                {
                    return txtLogDebug;
                }
                else if (tabLogs.SelectedIndex == 1)
                {
                    return txtLogScript;
                }
                else if (tabLogs.SelectedIndex == 2)
                {
                    return txtLogDrops;
                }
                else //(tabLogs.SelectedIndex == 3)
                {
                    return txtLogChat;
                }
            }
        }

        public static LogForm Instance
        {
            get;
        }

        public LogForm()
        {
            InitializeComponent();
            logRec = new DebugLogger(this);
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            FormClosing += LogForm_FormClosing;
            string font = Config.Load(Application.StartupPath + "\\config.cfg").Get("font");
            float? fontSize = float.Parse(Config.Load(Application.StartupPath + "\\config.cfg").Get("fontSize") ?? "8.25", System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            if (font != null && fontSize != null)
            {
                this.Font = new Font(font, (float)fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        //
        // Append Debug
        //
        public void AppendDebug(string text)
        {
            if (Visible)
            {
                if (text.Contains("{CLEAR}"))
                    txtLogDebug.Clear();
                if (txtLogDebug.InvokeRequired)
                {
                    txtLogDebug.Invoke((Action)delegate
                    {
                        txtLogDebug.AppendText(text);
                    });
                }
                else
                    txtLogDebug.AppendText(text);
            }
        }

        //
        // Append Drops
        //
        public void AppendDrops(string text)
        {
            if (Visible)
            {
               if (text.Contains("{CLEAR}"))
                    txtLogDrops.Clear();
               if (txtLogDrops.InvokeRequired)
               {
                    txtLogDrops.Invoke((Action)delegate
                    {
                        txtLogDrops.AppendText(text);
                    });
               }
               else
                    txtLogDrops.AppendText(text);
            }
        }

        //
        // Append Chat
        //
        public void AppendChat(string text)
        {
            if (Visible)
            {
                if (text.Contains("{CLEAR}"))
                    txtLogChat.Clear();
                if (txtLogChat.InvokeRequired)
                {
                    txtLogChat.Invoke((Action)delegate
                    {
                        txtLogChat.AppendText(text);
                    });
                }
                else
                    txtLogChat.AppendText(text);
            }
        }
        //
        // Append Script
        //
        public void AppendScript(string text, bool ignoreInvoke = false)
        {
            if (Visible)
            {
                if (text.Contains("{CLEAR}"))
                    txtLogScript.Clear();
                if (txtLogScript.InvokeRequired)
                {
                    txtLogScript.Invoke((Action)delegate
                    {
                        txtLogScript.AppendText(text);
                    });
                }
                else
                    txtLogScript.AppendText(text);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SelectedLog.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, SelectedLog.Text);
                }
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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(LogForm));
            this.txtLogDebug = new TextBox();
            this.btnClear = new Button();
            this.btnSave = new Button();
            this.tabLogs = new TabControl();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.changeFontToolStripMenuItem = new ToolStripMenuItem();
            this.changeColorToolStripMenuItem = new ToolStripMenuItem();
            this.tabLogDebug = new TabPage();
            this.tabLogScript = new TabPage();
            this.txtLogScript = new TextBox();
            this.tabLogDrops = new TabPage();
            this.txtLogDrops = new TextBox();
            this.tabLogChat = new TabPage();
            this.txtLogChat = new TextBox();
            this.colorDialog1 = new ColorDialog();
            this.tabLogs.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabLogDebug.SuspendLayout();
            this.tabLogScript.SuspendLayout();
            this.tabLogDrops.SuspendLayout();
            this.tabLogChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogDebug
            // 
            this.txtLogDebug.Dock = DockStyle.Fill;
            this.txtLogDebug.Location = new Point(3, 3);
            this.txtLogDebug.Multiline = true;
            this.txtLogDebug.Name = "txtLogDebug";
            this.txtLogDebug.ReadOnly = true;
            this.txtLogDebug.ScrollBars = ScrollBars.Vertical;
            this.txtLogDebug.Size = new Size(414, 211);
            this.txtLogDebug.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnClear.Location = new Point(12, 249);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(199, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnSave.Location = new Point(217, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(199, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // tabLogs
            // 
            this.tabLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
            | AnchorStyles.Left
            | AnchorStyles.Right;
            this.tabLogs.ContextMenuStrip = this.contextMenuStrip1;
            this.tabLogs.Controls.Add(this.tabLogDebug);
            this.tabLogs.Controls.Add(this.tabLogScript);
            this.tabLogs.Controls.Add(this.tabLogDrops);
            this.tabLogs.Controls.Add(this.tabLogChat);
            this.tabLogs.Location = new Point(0, 0);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.SelectedIndex = 0;
            this.tabLogs.Size = new Size(428, 243);
            this.tabLogs.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
            this.changeFontToolStripMenuItem,
            this.changeColorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(148, 48);
            // 
            // changeFontToolStripMenuItem
            // 
            this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
            this.changeFontToolStripMenuItem.Size = new Size(147, 22);
            this.changeFontToolStripMenuItem.Text = "Change Font";
            this.changeFontToolStripMenuItem.Click += new EventHandler(this.changeFontToolStripMenuItem_Click);
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new Size(147, 22);
            this.changeColorToolStripMenuItem.Text = "Change Color";
            this.changeColorToolStripMenuItem.Click += new EventHandler(this.changeColorToolStripMenuItem_Click);
            // 
            // tabLogDebug
            // 
            this.tabLogDebug.Controls.Add(this.txtLogDebug);
            this.tabLogDebug.Location = new Point(4, 22);
            this.tabLogDebug.Name = "tabLogDebug";
            this.tabLogDebug.Padding = new Padding(3);
            this.tabLogDebug.Size = new Size(420, 217);
            this.tabLogDebug.TabIndex = 0;
            this.tabLogDebug.Text = "Debug";
            this.tabLogDebug.UseVisualStyleBackColor = true;
            // 
            // tabLogScript
            // 
            this.tabLogScript.Controls.Add(this.txtLogScript);
            this.tabLogScript.Location = new Point(4, 22);
            this.tabLogScript.Name = "tabLogScript";
            this.tabLogScript.Padding = new Padding(3);
            this.tabLogScript.Size = new Size(420, 217);
            this.tabLogScript.TabIndex = 1;
            this.tabLogScript.Text = "Script";
            this.tabLogScript.UseVisualStyleBackColor = true;
            // 
            // txtLogScript
            // 
            this.txtLogScript.Dock = DockStyle.Fill;
            this.txtLogScript.ForeColor = SystemColors.WindowText;
            this.txtLogScript.Location = new Point(3, 3);
            this.txtLogScript.Multiline = true;
            this.txtLogScript.Name = "txtLogScript";
            this.txtLogScript.ReadOnly = true;
            this.txtLogScript.ScrollBars = ScrollBars.Vertical;
            this.txtLogScript.Size = new Size(414, 211);
            this.txtLogScript.TabIndex = 1;
            // 
            // tabLogDrops
            // 
            this.tabLogDrops.Controls.Add(this.txtLogDrops);
            this.tabLogDrops.Location = new Point(4, 22);
            this.tabLogDrops.Name = "tabLogDrops";
            this.tabLogDrops.Padding = new Padding(3);
            this.tabLogDrops.Size = new Size(420, 217);
            this.tabLogDrops.TabIndex = 2;
            this.tabLogDrops.Text = "Drops";
            this.tabLogDrops.UseVisualStyleBackColor = true;
            // 
            // txtLogDrops
            // 
            this.txtLogDrops.Dock = DockStyle.Fill;
            this.txtLogDrops.Location = new Point(3, 3);
            this.txtLogDrops.Multiline = true;
            this.txtLogDrops.Name = "txtLogDrops";
            this.txtLogDrops.ReadOnly = true;
            this.txtLogDrops.ScrollBars = ScrollBars.Vertical;
            this.txtLogDrops.Size = new Size(414, 211);
            this.txtLogDrops.TabIndex = 2;
            // 
            // tabLogChat
            // 
            this.tabLogChat.Controls.Add(this.txtLogChat);
            this.tabLogChat.Location = new Point(4, 22);
            this.tabLogChat.Name = "tabLogChat";
            this.tabLogChat.Padding = new Padding(3);
            this.tabLogChat.Size = new Size(420, 217);
            this.tabLogChat.TabIndex = 3;
            this.tabLogChat.Text = "Chat";
            this.tabLogChat.UseVisualStyleBackColor = true;
            // 
            // txtLogChat
            // 
            this.txtLogChat.Dock = DockStyle.Fill;
            this.txtLogChat.Location = new Point(3, 3);
            this.txtLogChat.Multiline = true;
            this.txtLogChat.Name = "txtLogChat";
            this.txtLogChat.ReadOnly = true;
            this.txtLogChat.ScrollBars = ScrollBars.Vertical;
            this.txtLogChat.Size = new Size(414, 211);
            this.txtLogChat.TabIndex = 2;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(428, 284);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tabLogs);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Name = "LogForm";
            this.Text = "Debug Log";
            this.TopMost = true;
            this.Load += new EventHandler(this.LogForm_Load);
            this.tabLogs.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabLogDebug.ResumeLayout(false);
            this.tabLogDebug.PerformLayout();
            this.tabLogScript.ResumeLayout(false);
            this.tabLogScript.PerformLayout();
            this.tabLogDrops.ResumeLayout(false);
            this.tabLogDrops.PerformLayout();
            this.tabLogChat.ResumeLayout(false);
            this.tabLogChat.PerformLayout();
            this.ResumeLayout(false);

        }

        static LogForm()
        {
            Instance = new LogForm();
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cdlg = new ColorDialog();
            cdlg.ShowDialog();
            this.ForeColor = cdlg.Color;
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fdlg = new FontDialog();
            fdlg.ShowDialog();
            this.Font = fdlg.Font;
        }
    }
}