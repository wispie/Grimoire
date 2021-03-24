using AxShockwaveFlashObjects;
using Grimoire.Game;
using Grimoire.Networking;
using Grimoire.Properties;
using Grimoire.Tools;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Botting;
using Grimoire.Game.Data;
using System.Diagnostics;
using Unity3.Eyedropper;

namespace Grimoire.UI
{
    public class Root : Form
    {
        private IContainer components;

        private NotifyIcon nTray;

        private AxShockwaveFlash flashPlayer;

        private ComboBox cbPads;

        private ComboBox cbCells;

        private Button btnBank;

        private ProgressBar prgLoader;

        private ToolStripMenuItem botToolStripMenuItem;

        private ToolStripMenuItem toolsToolStripMenuItem;

        private ToolStripMenuItem fastTravelsToolStripMenuItem;

        private ToolStripMenuItem loadersgrabbersToolStripMenuItem;

        private ToolStripMenuItem hotkeysToolStripMenuItem;

        public MenuStrip MenuMain;

        private ToolStripMenuItem pluginManagerToolStripMenuItem;

        private NumericUpDown numFPS;

        private Button btnFPS;

        private ToolStripMenuItem packetsToolStripMenuItem;

        private ToolStripMenuItem snifferToolStripMenuItem;

        private ToolStripMenuItem spammerToolStripMenuItem;

        private ToolStripMenuItem tampererToolStripMenuItem;

        private ToolStripMenuItem logsToolStripMenuItem;

        private Button btnJump;

        private ToolStripMenuItem cosmeticsToolStripMenuItem;

        private ToolStripMenuItem bankToolStripMenuItem;

        private ToolStripMenuItem notepadToolStripMenuItem;

        private ToolStripMenuItem helpToolStripMenuItem;

        private ToolStripMenuItem discordToolStripMenuItem;

        private ToolStripMenuItem botRequestToolStripMenuItem;

        private ToolStripMenuItem browserToolStripMenuItem;

        private ToolStripMenuItem setsToolStripMenuItem;

        private ToolStripMenuItem grimoireSuggestionsToolStripMenuItem;

        private Button btnStop;

        private Button btnStart;
        private Unity3.Eyedropper.EyeDropper eyeDropper1;
        private ToolStripMenuItem eyeDropperToolStripMenuItem;
        private Button btnBankReload;

        public static Root Instance
        {
            get;
            private set;
        }

        public AxShockwaveFlash Client => flashPlayer;

        public Root()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Root_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Proxy.Instance.Start, TaskCreationOptions.LongRunning);
            Flash.flash = flashPlayer;
            flashPlayer.FlashCall += Flash.ProcessFlashCall;
            Flash.SwfLoadProgress += OnLoadProgress;
            Hotkeys.Instance.LoadHotkeys();
            InitFlashMovie();
            Config c = Config.Load(Application.StartupPath + "\\config.cfg");
        }

        private void OnLoadProgress(int progress)
        {
            if (progress < prgLoader.Maximum)
            {
                prgLoader.Value = progress;
                return;
            }
            Flash.SwfLoadProgress -= OnLoadProgress;
            flashPlayer.Visible = true;
            prgLoader.Visible = false;
        }

        private void botToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(BotManager.Instance);
        }

        private void fastTravelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Travel.Instance);
        }

        private void loadersgrabbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Loaders.Instance);
        }

        private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Hotkeys.Instance);
        }

        private void pluginManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PluginManager.Instance);
        }

        private void snifferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PacketLogger.Instance);
        }

        private void spammerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PacketSpammer.Instance);
        }

        private void tampererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PacketTamperer.Instance);
        }

        public void ShowForm(Form form)
        {
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
                form.Show();
                form.BringToFront();
                form.Focus();
                return;
            }
            else if (form.Visible)
            {
                form.Hide();
                return;
            }
            form.Show();
            form.BringToFront();
            form.Focus();
        }

        private void InitFlashMovie()
        {
            byte[] aqlitegrimoire = Resources.aqlitegrimoire;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(8 + aqlitegrimoire.Length);
                    binaryWriter.Write(1432769894);
                    binaryWriter.Write(aqlitegrimoire.Length);
                    binaryWriter.Write(aqlitegrimoire);
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    flashPlayer.OcxState = new AxHost.State(memoryStream, 1, manualUpdate: false, null);
                }
            }
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            Player.Bank.Show();
        }

        private void cbCells_Click(object sender, EventArgs e)
        {
            cbCells.Items.Clear();
            ComboBox.ObjectCollection items = cbCells.Items;
            object[] cells = World.Cells;
            object[] items2 = cells;
            items.AddRange(items2);
        }

        private void btnFPS_Click(object sender, EventArgs e)
        {
            Flash.Call("SetFPS", numFPS.Value.ToString());
        }

        private void Root_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hotkeys.InstalledHotkeys.ForEach(delegate (Hotkey h)
            {
                h.Uninstall();
            });
            KeyboardHook.Instance.Dispose();
            Proxy.Instance.Stop(appClosing: true);
            CommandColorForm.Instance.Dispose();
            nTray.Icon.Dispose();
            nTray.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Root));
            this.nTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbPads = new System.Windows.Forms.ComboBox();
            this.cbCells = new System.Windows.Forms.ComboBox();
            this.btnBank = new System.Windows.Forms.Button();
            this.btnBankReload = new System.Windows.Forms.Button();
            this.prgLoader = new System.Windows.Forms.ProgressBar();
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.botToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastTravelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadersgrabbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cosmeticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snifferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spammerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tampererToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.botRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grimoireSuggestionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numFPS = new System.Windows.Forms.NumericUpDown();
            this.btnFPS = new System.Windows.Forms.Button();
            this.flashPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.btnJump = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.eyeDropper1 = new Unity3.Eyedropper.EyeDropper();
            this.eyeDropperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // nTray
            // 
            this.nTray.Icon = ((System.Drawing.Icon)(resources.GetObject("nTray.Icon")));
            this.nTray.Text = "Grimoire";
            this.nTray.Visible = true;
            this.nTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nTray_MouseClick);
            // 
            // cbPads
            // 
            this.cbPads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPads.FormattingEnabled = true;
            this.cbPads.Items.AddRange(new object[] {
            "Center",
            "Spawn",
            "Left",
            "Right",
            "Top",
            "Bottom",
            "Up",
            "Down"});
            this.cbPads.Location = new System.Drawing.Point(786, 2);
            this.cbPads.Name = "cbPads";
            this.cbPads.Size = new System.Drawing.Size(91, 21);
            this.cbPads.TabIndex = 17;
            // 
            // cbCells
            // 
            this.cbCells.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCells.FormattingEnabled = true;
            this.cbCells.Location = new System.Drawing.Point(689, 2);
            this.cbCells.Name = "cbCells";
            this.cbCells.Size = new System.Drawing.Size(91, 21);
            this.cbCells.TabIndex = 18;
            this.cbCells.Click += new System.EventHandler(this.cbCells_Click);
            // 
            // btnBank
            // 
            this.btnBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBank.Location = new System.Drawing.Point(882, 1);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(75, 23);
            this.btnBank.TabIndex = 20;
            this.btnBank.Text = "Bank";
            this.btnBank.UseVisualStyleBackColor = true;
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // btnBankReload
            // 
            this.btnBankReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBankReload.Location = new System.Drawing.Point(957, 1);
            this.btnBankReload.Name = "btnBankReload";
            this.btnBankReload.Size = new System.Drawing.Size(5, 23);
            this.btnBankReload.TabIndex = 25;
            this.btnBankReload.UseVisualStyleBackColor = true;
            this.btnBankReload.Click += new System.EventHandler(this.btnBankReload_Click);
            // 
            // prgLoader
            // 
            this.prgLoader.Location = new System.Drawing.Point(12, 276);
            this.prgLoader.Name = "prgLoader";
            this.prgLoader.Size = new System.Drawing.Size(936, 23);
            this.prgLoader.TabIndex = 21;
            // 
            // MenuMain
            // 
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.packetsToolStripMenuItem,
            this.logsToolStripMenuItem,
            this.notepadToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(960, 24);
            this.MenuMain.TabIndex = 22;
            this.MenuMain.Text = "menuStrip";
            // 
            // botToolStripMenuItem
            // 
            this.botToolStripMenuItem.Name = "botToolStripMenuItem";
            this.botToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.botToolStripMenuItem.Text = "Bot";
            this.botToolStripMenuItem.Click += new System.EventHandler(this.botToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastTravelsToolStripMenuItem,
            this.loadersgrabbersToolStripMenuItem,
            this.hotkeysToolStripMenuItem,
            this.pluginManagerToolStripMenuItem,
            this.cosmeticsToolStripMenuItem,
            this.bankToolStripMenuItem,
            this.browserToolStripMenuItem,
            this.setsToolStripMenuItem,
            this.eyeDropperToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // fastTravelsToolStripMenuItem
            // 
            this.fastTravelsToolStripMenuItem.Name = "fastTravelsToolStripMenuItem";
            this.fastTravelsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fastTravelsToolStripMenuItem.Text = "Fast travels";
            this.fastTravelsToolStripMenuItem.Click += new System.EventHandler(this.fastTravelsToolStripMenuItem_Click);
            // 
            // loadersgrabbersToolStripMenuItem
            // 
            this.loadersgrabbersToolStripMenuItem.Name = "loadersgrabbersToolStripMenuItem";
            this.loadersgrabbersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadersgrabbersToolStripMenuItem.Text = "Loaders/grabbers";
            this.loadersgrabbersToolStripMenuItem.Click += new System.EventHandler(this.loadersgrabbersToolStripMenuItem_Click);
            // 
            // hotkeysToolStripMenuItem
            // 
            this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
            this.hotkeysToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hotkeysToolStripMenuItem.Text = "Hotkeys";
            this.hotkeysToolStripMenuItem.Click += new System.EventHandler(this.hotkeysToolStripMenuItem_Click);
            // 
            // pluginManagerToolStripMenuItem
            // 
            this.pluginManagerToolStripMenuItem.Name = "pluginManagerToolStripMenuItem";
            this.pluginManagerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pluginManagerToolStripMenuItem.Text = "Plugin manager";
            this.pluginManagerToolStripMenuItem.Click += new System.EventHandler(this.pluginManagerToolStripMenuItem_Click);
            // 
            // cosmeticsToolStripMenuItem
            // 
            this.cosmeticsToolStripMenuItem.Name = "cosmeticsToolStripMenuItem";
            this.cosmeticsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cosmeticsToolStripMenuItem.Text = "Cosmetics";
            this.cosmeticsToolStripMenuItem.Click += new System.EventHandler(this.cosmeticsToolStripMenuItem_Click);
            // 
            // bankToolStripMenuItem
            // 
            this.bankToolStripMenuItem.Name = "bankToolStripMenuItem";
            this.bankToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bankToolStripMenuItem.Text = "Bank";
            this.bankToolStripMenuItem.Click += new System.EventHandler(this.bankToolStripMenuItem_Click);
            // 
            // browserToolStripMenuItem
            // 
            this.browserToolStripMenuItem.Enabled = false;
            this.browserToolStripMenuItem.Name = "browserToolStripMenuItem";
            this.browserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.browserToolStripMenuItem.Text = "Browser";
            this.browserToolStripMenuItem.Visible = false;
            // 
            // setsToolStripMenuItem
            // 
            this.setsToolStripMenuItem.Enabled = false;
            this.setsToolStripMenuItem.Name = "setsToolStripMenuItem";
            this.setsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setsToolStripMenuItem.Text = "Sets";
            this.setsToolStripMenuItem.Click += new System.EventHandler(this.setsToolStripMenuItem_Click);
            // 
            // packetsToolStripMenuItem
            // 
            this.packetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snifferToolStripMenuItem,
            this.spammerToolStripMenuItem,
            this.tampererToolStripMenuItem});
            this.packetsToolStripMenuItem.Name = "packetsToolStripMenuItem";
            this.packetsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.packetsToolStripMenuItem.Text = "Packets";
            // 
            // snifferToolStripMenuItem
            // 
            this.snifferToolStripMenuItem.Name = "snifferToolStripMenuItem";
            this.snifferToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.snifferToolStripMenuItem.Text = "Sniffer";
            this.snifferToolStripMenuItem.Click += new System.EventHandler(this.snifferToolStripMenuItem_Click);
            // 
            // spammerToolStripMenuItem
            // 
            this.spammerToolStripMenuItem.Name = "spammerToolStripMenuItem";
            this.spammerToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.spammerToolStripMenuItem.Text = "Spammer";
            this.spammerToolStripMenuItem.Click += new System.EventHandler(this.spammerToolStripMenuItem_Click);
            // 
            // tampererToolStripMenuItem
            // 
            this.tampererToolStripMenuItem.Name = "tampererToolStripMenuItem";
            this.tampererToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.tampererToolStripMenuItem.Text = "Tamperer";
            this.tampererToolStripMenuItem.Click += new System.EventHandler(this.tampererToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.logsToolStripMenuItem.Text = "Logs";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // notepadToolStripMenuItem
            // 
            this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
            this.notepadToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.notepadToolStripMenuItem.Text = "Notepad";
            this.notepadToolStripMenuItem.Click += new System.EventHandler(this.notepadToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.discordToolStripMenuItem,
            this.botRequestToolStripMenuItem,
            this.grimoireSuggestionsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // discordToolStripMenuItem
            // 
            this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            this.discordToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.discordToolStripMenuItem.Text = "Discord";
            this.discordToolStripMenuItem.Click += new System.EventHandler(this.discordToolStripMenuItem_Click);
            // 
            // botRequestToolStripMenuItem
            // 
            this.botRequestToolStripMenuItem.Name = "botRequestToolStripMenuItem";
            this.botRequestToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.botRequestToolStripMenuItem.Text = "Bot Request";
            this.botRequestToolStripMenuItem.Click += new System.EventHandler(this.botRequestToolStripMenuItem_Click);
            // 
            // grimoireSuggestionsToolStripMenuItem
            // 
            this.grimoireSuggestionsToolStripMenuItem.Name = "grimoireSuggestionsToolStripMenuItem";
            this.grimoireSuggestionsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.grimoireSuggestionsToolStripMenuItem.Text = "Grimoire Suggestions";
            this.grimoireSuggestionsToolStripMenuItem.Click += new System.EventHandler(this.grimoireSuggestionsToolStripMenuItem_Click);
            // 
            // numFPS
            // 
            this.numFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFPS.Location = new System.Drawing.Point(586, 3);
            this.numFPS.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numFPS.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFPS.Name = "numFPS";
            this.numFPS.Size = new System.Drawing.Size(43, 20);
            this.numFPS.TabIndex = 23;
            this.numFPS.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // btnFPS
            // 
            this.btnFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFPS.Location = new System.Drawing.Point(526, 2);
            this.btnFPS.Name = "btnFPS";
            this.btnFPS.Size = new System.Drawing.Size(57, 23);
            this.btnFPS.TabIndex = 24;
            this.btnFPS.Text = "Set FPS";
            this.btnFPS.UseVisualStyleBackColor = true;
            this.btnFPS.Click += new System.EventHandler(this.btnFPS_Click);
            // 
            // flashPlayer
            // 
            this.flashPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flashPlayer.Enabled = true;
            this.flashPlayer.Location = new System.Drawing.Point(0, 25);
            this.flashPlayer.Name = "flashPlayer";
            this.flashPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flashPlayer.OcxState")));
            this.flashPlayer.Size = new System.Drawing.Size(960, 550);
            this.flashPlayer.TabIndex = 2;
            this.flashPlayer.Visible = false;
            // 
            // btnJump
            // 
            this.btnJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJump.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnJump.Location = new System.Drawing.Point(630, 1);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(53, 23);
            this.btnJump.TabIndex = 28;
            this.btnJump.Text = "Jump";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(470, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(57, 23);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_ClickAsync);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(469, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(57, 23);
            this.btnStart.TabIndex = 24;
            this.btnStart.Text = "Start bot";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // eyeDropper1
            // 
            this.eyeDropper1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eyeDropper1.Location = new System.Drawing.Point(445, 3);
            this.eyeDropper1.MaximumSize = new System.Drawing.Size(22, 22);
            this.eyeDropper1.MinimumSize = new System.Drawing.Size(22, 22);
            this.eyeDropper1.Name = "eyeDropper1";
            this.eyeDropper1.PixelPreviewSize = new System.Drawing.Size(100, 50);
            this.eyeDropper1.PixelPreviewZoom = 5F;
            this.eyeDropper1.PreviewLocation = new System.Drawing.Point(0, 0);
            this.eyeDropper1.PreviewPositionStyle = Unity3.Eyedropper.EyeDropper.ePreviewPositionStyle.Centered;
            this.eyeDropper1.SelectedColor = System.Drawing.Color.Empty;
            this.eyeDropper1.Size = new System.Drawing.Size(22, 22);
            this.eyeDropper1.TabIndex = 29;
            this.eyeDropper1.Text = "eyeDropper1";
            // 
            // eyeDropperToolStripMenuItem
            // 
            this.eyeDropperToolStripMenuItem.Name = "eyeDropperToolStripMenuItem";
            this.eyeDropperToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eyeDropperToolStripMenuItem.Text = "Eye Dropper";
            this.eyeDropperToolStripMenuItem.Click += new System.EventHandler(this.eyeDropperToolStripMenuItem_Click_1);
            // 
            // Root
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 575);
            this.Controls.Add(this.eyeDropper1);
            this.Controls.Add(this.btnJump);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnFPS);
            this.Controls.Add(this.numFPS);
            this.Controls.Add(this.prgLoader);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.btnBankReload);
            this.Controls.Add(this.cbCells);
            this.Controls.Add(this.cbPads);
            this.Controls.Add(this.flashPlayer);
            this.Controls.Add(this.MenuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Root";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grimoire 3.8+ PRO v1.7.7 t!rep @satan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Root_FormClosing);
            this.Load += new System.EventHandler(this.Root_Load);
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Instance_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnBankReload_Click(object sender, EventArgs e)
        {
            Proxy.Instance.SendToServer($"%xt%zm%loadBank%{World.RoomId}%All%");
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(LogForm.Instance);
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            string Cell = (string)this.cbCells.SelectedItem;
            string Pad = (string)this.cbPads.SelectedItem;
            Player.MoveToCell(Cell ?? Player.Cell, Pad ?? Player.Pad);
        }

        private void cosmeticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(CosmeticForm.Instance);
        }

        private void bankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(BankForm.Instance);
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Notepad.Instance);
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.com/invite/aqwbots");
        }

        private void botRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/forms/d/e/1FAIpQLSd2NSx1ezF-6bc2jRBuTniIka5z6kA2NbmC8CRCOFtpVxcRCA/viewform");
        }

        private void setsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Set.Instance);
        }

        private void grimoireSuggestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/forms/d/e/1FAIpQLSetfV9zl18G9s7w_XReJ1yJNT9aZwxB1FLzU0l1UhdmXv5rIw/viewform?usp=sf_link");
        }

        private async void btnStop_ClickAsync(object sender, EventArgs e)
        {
            if (Configuration.Instance.Items != null && Configuration.Instance.BankOnStop)
            {
                foreach (InventoryItem item in Player.Inventory.Items)
                {
                    if (!item.IsEquipped && item.IsAcItem && item.Category != "Class" && item.Name.ToLower() != "treasure potion" && Configuration.Instance.Items.Contains(item.Name))
                    {
                        Player.Bank.TransferToBank(item.Name);
                        await Task.Delay(70);
                        LogForm.Instance.AppendDebug("Transferred to Bank: " + item.Name + "\r\n");
                    }
                }
                LogForm.Instance.AppendDebug("Banked all AC Items in Items list \r\n");
            }
            btnStart.Enabled = false;
            BotManager.Instance.ActiveBotEngine.Stop();
            BotManager.Instance.MultiMode();
            await Task.Delay(2000);
            BotManager.Instance.BotStateChanged(IsRunning: false);
            this.BotStateChanged(IsRunning: false);
            btnStart.Enabled = true;
        }

        public void BotStateChanged(bool IsRunning)
        {
            if (IsRunning)
            {
                btnStart.Hide();
                btnStop.Show();
            }
            else
            {
                btnStop.Hide();
                btnStart.Show();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Player.IsAlive && Player.IsLoggedIn && BotManager.Instance.lstCommands.Items.Count > 0)
            {
                BotManager.Instance.MultiMode();
                BotManager.Instance.ActiveBotEngine.IsRunningChanged += BotManager.Instance.OnIsRunningChanged;
                BotManager.Instance.ActiveBotEngine.IndexChanged += BotManager.Instance.OnIndexChanged;
                BotManager.Instance.ActiveBotEngine.ConfigurationChanged += BotManager.Instance.OnConfigurationChanged;
                BotManager.Instance.ActiveBotEngine.Start(BotManager.Instance.GenerateConfiguration());
                BotManager.Instance.BotStateChanged(IsRunning: true);
                this.BotStateChanged(IsRunning: true);
            }
        }

        private void nTray_MouseClick(object sender, MouseEventArgs e)
        {
            ShowForm(this);
        }

        private void eyeDropperToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eyeDropperToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowForm(EyeDropper.Instance);
        }
    }
}