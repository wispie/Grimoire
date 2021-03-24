using Grimoire.Botting;
using Grimoire.Botting.Commands;
using Grimoire.Botting.Commands.Combat;
using Grimoire.Botting.Commands.Item;
using Grimoire.Botting.Commands.Map;
using Grimoire.Botting.Commands.Misc;
using Grimoire.Botting.Commands.Misc.Statements;
using Grimoire.Botting.Commands.Quest;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Networking;
using Grimoire.Properties;
using Grimoire.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Grimoire.UI;
using System.Drawing.Drawing2D;

namespace Grimoire.UI
{
    public class BotManager : Form
    {
        private IBotEngine _activeBotEngine = new Bot();

        private List<StatementCommand> _statementCommands;

        private Dictionary<string, string> _defaultControlText;

        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All
        };

        #region Definitions
        private IContainer components;
        private Panel[] _panels;
        public ListBox lstCommands;
        private ListBox lstSkills;
        private ListBox lstQuests;
        private ListBox lstDrops;
        private ListBox lstBoosts;
        public static LogForm Log;
        private string _customName;
        private string _customGuild;
        private ListBox lstItems;
        private TabControl tabControl1;
        private TabPage tabCombat;
        private Panel pnlCombat;
        private Button btnUseSkillSet;
        private Button btnAddSkillSet;
        private TextBox txtSkillSet;
        private CheckBox chkSafeMp;
        private Label label17;
        private Label label16;
        private Button btnRest;
        private Button btnRestF;
        private CheckBox chkSkillCD;
        private Label label12;
        private Label label11;
        private Label label10;
        private Button btnKill;
        private Label label13;
        private CheckBox chkExistQuest;
        private NumericUpDown numRestMP;
        private CheckBox chkMP;
        private NumericUpDown numRest;
        private CheckBox chkHP;
        private CheckBox chkPacket;
        private NumericUpDown numSkillD;
        private Label label2;
        private NumericUpDown numSafe;
        private Button btnAddSafe;
        private Button btnAddSkill;
        private NumericUpDown numSkill;
        private CheckBox chkExitRest;
        private CheckBox chkAllSkillsCD;
        private TextBox txtKillFQ;
        private TextBox txtKillFItem;
        private TextBox txtKillFMon;
        private RadioButton rbTemp;
        private RadioButton rbItems;
        private Button btnKillF;
        private TextBox txtMonster;
        private Panel pnlItem;
        private TextBox txtShopItem;
        private NumericUpDown numShopId;
        private Label label15;
        private Button btnBuy;
        private Button btnBuyFast;
        private Button btnLoadShop;
        private Button btnBoost;
        private ComboBox cbBoosts;
        private NumericUpDown numMapItem;
        private Button btnMapItem;
        private Button btnSwap;
        private TextBox txtSwapInv;
        private TextBox txtSwapBank;
        private CheckBox chkPickup;
        private Button btnBoth;
        private TextBox txtWhitelist;
        private Button btnItem;
        private Button btnUnbanklst;
        private TextBox txtItem;
        private ComboBox cbItemCmds;
        private TabPage tabMap;
        private Panel pnlMap;
        private Button btnWalkCur;
        private Button btnWalk;
        private NumericUpDown numWalkY;
        private NumericUpDown numWalkX;
        private Button btnCellSwap;
        private Button btnJump;
        private Button btnCurrCell;
        private TextBox txtPad;
        private TextBox txtCell;
        private Button btnJoin;
        private TextBox txtJoinPad;
        private TextBox txtJoinCell;
        private TextBox txtJoin;
        private TabPage tabQuest;
        private Panel pnlQuest;
        private Button btnQuestAccept;
        private Button btnQuestComplete;
        private Button btnQuestAdd;
        private NumericUpDown numQuestItem;
        private CheckBox chkQuestItem;
        private NumericUpDown numQuestID;
        private Label label4;
        private TabPage tabMisc;
        private Panel pnlMisc;
        private CheckBox chkRestartDeath;
        private CheckBox chkMerge;
        private Button btnLogout;
        private TextBox txtLabel;
        private Button btnGotoLabel;
        private Button btnAddLabel;
        private TextBox txtDescription;
        private TextBox txtAuthor;
        private Button btnSave;
        private Button btnDelay;
        private NumericUpDown numDelay;
        private Label label3;
        private NumericUpDown numBotDelay;
        private Button btnBotDelay;
        private TextBox txtPlayer;
        private Button btnGoto;
        private Button btnLoad;
        private Button btnRestart;
        private Button btnStop;
        private Button btnLoadCmd;
        private CheckBox chkSkip;
        private Button btnStatementAdd;
        private TextBox txtStatement2;
        private TextBox txtStatement1;
        private ComboBox cbStatement;
        private ComboBox cbCategories;
        private TextBox txtPacket;
        private Button btnPacket;
        private TabPage tabOptions;
        private Panel pnlOptions;
        private CheckBox chkEnableSettings;
        private CheckBox chkDisableAnims;
        private TextBox txtSoundItem;
        private Button btnSoundAdd;
        private Button btnSoundDelete;
        private Button btnSoundTest;
        private ListBox lstSoundItems;
        private Label label9;
        private NumericUpDown numWalkSpeed;
        private Label label8;
        private CheckBox chkSkipCutscenes;
        private CheckBox chkHidePlayers;
        private CheckBox chkLag;
        private CheckBox chkMagnet;
        private CheckBox chkProvoke;
        private CheckBox chkInfiniteRange;
        private GroupBox grpLogin;
        private ComboBox cbServers;
        private CheckBox chkRelogRetry;
        private CheckBox chkRelog;
        private NumericUpDown numRelogDelay;
        private Label label7;
        private TextBox txtUsername;
        private TextBox txtGuild;
        private Button btnchangeName;
        private Button btnchangeGuild;
        private CheckBox chkGender;
        private TabPage tabBots;
        private Panel pnlSaved;
        private Label lblBoosts;
        private Label lblDrops;
        private Label lblQuests;
        private Label lblSkills;
        private Label lblCommands;
        private Label lblItems;
        private TextBox txtSavedDesc;
        private TextBox txtSavedAuthor;
        private Label lblBots;
        private TreeView treeBots;
        private TextBox txtSavedAdd;
        private Button btnSavedAdd;
        private TextBox txtSaved;
        private CheckBox chkBankOnStop;
        private Label labelProvoke;
        private Button btnProvoke;
        private Button btnProvokeOn;
        private Button btnProvokeOff;
        private Button btnYulgar;
        private ListBox lstLogText;
        private Button btnLogDebug;
        private Button btnLog;
        private TextBox txtLog;
        private CheckBox chkUntarget;
        private Label label5;
        private NumericUpDown numOptionsTimer;
        private Label label6;
        private CheckBox chkEnsureComplete;
        private Label label14;
        private NumericUpDown numEnsureTries;
        private Button btnWalkRdm;
        private Button btnBlank;
        private CheckBox chkRejectAll;
        private CheckBox chkPickupAll;
        private CheckBox chkReject;
        private CheckBox chkBuff;
        private CheckBox chkAFK;
        private SplitContainer splitContainer1;
        private ComboBox cbLists;
        private CheckBox chkAll;
        private Button btnClear;
        private Button btnDown;
        private Button btnRemove;
        private Button btnUp;
        private Button btnBotStop;
        private Button btnBotStart;
        private Panel panel1;
        private SplitContainer splitContainer2;
        private Button button2;
        private Button btnCurrBlank;
        private Button btnSetSpawn;
        private Button btnBeep;
        private NumericUpDown numBeepTimes;
        private Panel panel3;
        private Panel panel2;
        private Button btnWhitelist;
        private Button btnSkillCmd;
        private TabPage tabItem;
        private CheckBox checkBox1;
        private CheckBox chkBuffup;
        private TabPage tabOptions2;
        private Button btnSetUndecided;
        private Button btnSetChaos;
        private Button btnSetEvil;
        private Button btnSetGood;
        private GroupBox grpAlignment;
        private GroupBox grpAccessLevel;
        private Button btnSetMem;
        private Button btnSetModerator;
        private Button btnSetNonMem;
        private CheckBox chkToggleMute;
        private ContextMenuStrip BotManagerMenuStrip;
        private ToolStripMenuItem changeFontsToolStripMenuItem;
        private Label label1;
        private NumericUpDown numDropDelay;
        private Label label18;
        private Button btnGoDownIndex;
        private Button btnGoUpIndex;
        private Button btnGotoIndex;
        private NumericUpDown numIndexCmd;
        private ToolStripMenuItem multilineToggleToolStripMenuItem;
        private ToolStripMenuItem toggleTabpagesToolStripMenuItem;
        private ToolStripMenuItem commandColorsToolStripMenuItem;
        private Button btnChangeNameCmd;
        private Button btnChangeGuildCmd;
        private CheckBox chkAntiAfk;
        private CheckBox chkChangeRoomTag;
        private CheckBox chkChangeChat;
        private NumericUpDown numSetLevel;
        private CheckBox chkSetJoinLevel;
        private Button btnClientPacket;
        private CheckBox chkHideYulgarPlayers;
        private NumericUpDown numSetInt;
        private TextBox txtSetInt;
        private Button btnSetInt;
        private Label label19;
        private Button btnDecreaseInt;
        private Button btnIncreaseInt;
        private Button btnAttack;
        #endregion

        public static BotManager Instance
        {
            get;
        }

        public IBotEngine ActiveBotEngine
        {
            get
            {
                return _activeBotEngine;
            }
            set
            {
                if (_activeBotEngine.IsRunning)
                {
                    throw new InvalidOperationException("Cannot set a new bot engine while the current one is running");
                }

                _activeBotEngine = value ?? throw new ArgumentNullException("value");
            }
        }

        private ListBox SelectedList
        {
            get
            {
                switch (cbLists.SelectedIndex)
                {
                    case 1:
                        return lstSkills;

                    case 2:
                        return lstQuests;

                    case 3:
                        return lstDrops;

                    case 4:
                        return lstBoosts;

                    case 5:
                        return lstItems;

                    default:
                        return lstCommands;
                }
            }
        }

        public string CustomName
        {
            get => _customName;

            set
            {
                _customName = value;
                Flash.Call("ChangeName", _customName);
            }
        }

        public string CustomGuild
        {
            get => _customGuild;
            set
            {
                _customGuild = value;
                Flash.Call("ChangeGuild", txtGuild.Text);
            }
        }

        public static int SliderValue
        {
            get;
            set;
        }

        private BotManager()
        {
            InitializeComponent();
        }

        private void BotManager_Load(object sender, EventArgs e)
        {
            _panels = new Panel[7]
            {
                pnlCombat,
                pnlMap,
                pnlQuest,
                pnlItem,
                pnlMisc,
                pnlOptions,
                pnlSaved
            };
            pnlCombat.Size = new Size(442, 315);
            pnlMap.Size = new Size(442, 315);
            pnlQuest.Size = new Size(442, 315);
            pnlItem.Size = new Size(442, 315);
            pnlMisc.Size = new Size(442, 315);
            pnlOptions.Size = new Size(442, 315);
            pnlSaved.Size = new Size(442, 315);
            lstBoosts.DisplayMember = "Text";
            lstQuests.DisplayMember = "Text";
            lstSkills.DisplayMember = "Text";
            cbBoosts.DisplayMember = "Name";
            cbServers.DisplayMember = "Name";
            lstItems.DisplayMember = "Text";
            cbStatement.DisplayMember = "Text";
            cbLists.SelectedIndex = 0;
            _statementCommands = JsonConvert.DeserializeObject<List<StatementCommand>>(Resources.statementcmds, _serializerSettings);
            _defaultControlText = JsonConvert.DeserializeObject<Dictionary<string, string>>(Resources.defaulttext, _serializerSettings);
            OptionsManager.StateChanged += OnOptionsStateChanged;
            Config c = Config.Load(Application.StartupPath + "\\config.cfg");
            string font = c.Get("font");
            //float fontSize = float.Parse(Config.Load(Application.StartupPath + "\\config.cfg").Get("fontSize") ?? "8.25", System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            if (font != null)
                this.Font = new Font(font, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstCommands.ItemHeight = int.Parse(c.Get("CommandsSize") ?? "60");
            //MessageBox.Show("" + lstCommands.ItemHeight);
            lstCommands.Font = new Font(font, lstCommands.ItemHeight / 4 - (float)6.5, FontStyle.Regular, GraphicsUnit.Point, 0);
            //MessageBox.Show("" + lstCommands.Font.Size);
            lstCommands.ItemHeight = lstCommands.ItemHeight / 4;
            //MessageBox.Show("" + lstCommands.ItemHeight);
        }

        private void TextboxEnter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Clear();
        }

        private void TextboxLeave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text) && _defaultControlText.TryGetValue(textBox.Name, out string value))
            {
                textBox.Text = value;
            }
        }

        public void OnServersLoaded(Server[] servers)
        {
            if (servers != null && servers.Length != 0 && cbServers.Items.Count <= 1)
            {
                cbServers.Items.AddRange(servers);
                cbServers.SelectedIndex = 0;
            }
        }

        private void MoveListItem(int direction)
        {
            if (SelectedList.SelectedItem != null && SelectedList.SelectedIndex >= 0)
            {
                int num = SelectedList.SelectedIndex + direction;
                if (num >= 0 && num < SelectedList.Items.Count)
                {
                    object selectedItem = SelectedList.SelectedItem;
                    SelectedList.Items.Remove(selectedItem);
                    SelectedList.Items.Insert(num, selectedItem);
                    SelectedList.SetSelected(num, value: true);
                }
            }
        }

        private void MoveListItemByKey(int direction)
        {
            if (SelectedList.SelectedItem == null || SelectedList.SelectedIndex < 0)
            {
                return;
            }
            int num = SelectedList.SelectedIndex + direction;
            if (num >= 0 && num < SelectedList.Items.Count)
            {
                object selectedItem = SelectedList.SelectedItem;
                SelectedList.Items.Remove(selectedItem);
                SelectedList.Items.Insert(num, selectedItem);
                if (direction == 1)
                {
                    SelectedList.SetSelected(num - 1, value: true);
                }
            }
        }

        public Configuration GenerateConfiguration()
        {
            return new Configuration
            {
                Author = txtAuthor.Text,
                Description = txtDescription.Text,
                Commands = lstCommands.Items.Cast<IBotCommand>().ToList(),
                Skills = lstSkills.Items.Cast<Skill>().ToList(),
                Quests = lstQuests.Items.Cast<Quest>().ToList(),
                Boosts = lstBoosts.Items.Cast<InventoryItem>().ToList(),
                Drops = lstDrops.Items.Cast<string>().ToList(),
                Items = lstItems.Items.Cast<string>().ToList(),
                SkillDelay = (int)numSkillD.Value,
                ExitCombatBeforeRest = chkExitRest.Checked,
                ExitCombatBeforeQuest = chkExistQuest.Checked,
                Server = (Server)cbServers.SelectedItem,
                AutoRelogin = chkRelog.Checked,
                RelogDelay = (int)numRelogDelay.Value,
                RelogRetryUponFailure = chkRelogRetry.Checked,
                BotDelay = (int)numBotDelay.Value,
                EnablePickup = chkPickup.Checked,
                EnableRejection = chkReject.Checked,
                EnablePickupAll = chkPickupAll.Checked,
                EnableRejectAll = chkRejectAll.Checked,
                WaitForAllSkills = chkAllSkillsCD.Checked,
                WaitForSkill = chkSkillCD.Checked,
                SkipDelayIndexIf = chkSkip.Checked,
                InfiniteAttackRange = chkInfiniteRange.Checked,
                ProvokeMonsters = chkProvoke.Checked,
                EnemyMagnet = chkMagnet.Checked,
                LagKiller = chkLag.Checked,
                HidePlayers = chkHidePlayers.Checked,
                SkipCutscenes = chkSkipCutscenes.Checked,
                WalkSpeed = (int)numWalkSpeed.Value,
                NotifyUponDrop = lstSoundItems.Items.Cast<string>().ToList(),
                RestIfMp = chkMP.Checked,
                RestIfHp = chkHP.Checked,
                EnsureTries = (int)numEnsureTries.Value,
                Untarget = chkUntarget.Checked,
                BankOnStop = chkBankOnStop.Checked,
                RestMp = (int)numRestMP.Value,
                RestHp = (int)numRest.Value,
                RestartUponDeath = chkRestartDeath.Checked,
                EnsureComplete = chkEnsureComplete.Checked,
                AFK = chkAFK.Checked,
                DropDelay = (int)numDropDelay.Value
            };
        }

        public void ApplyConfiguration(Configuration config)
        {
            if (config != null)
            {
                if (!chkMerge.Checked || ActiveBotEngine.IsRunning)
                {
                    lstCommands.Items.Clear();
                    lstBoosts.Items.Clear();
                    lstDrops.Items.Clear();
                    lstQuests.Items.Clear();
                    lstSkills.Items.Clear();
                    lstItems.Items.Clear();
                    lstSoundItems.Items.Clear();
                }
                txtSavedAuthor.Text = config.Author ?? "Author";
                txtSavedDesc.Text = config.Description ?? "Description";
                List<IBotCommand> commands = config.Commands;
                if (commands != null && commands.Count > 0)
                {
                    ListBox.ObjectCollection items = lstCommands.Items;
                    object[] array = config.Commands.ToArray();
                    items.AddRange(array);
                }
                List<Skill> skills = config.Skills;
                if (skills != null && skills.Count > 0)
                {
                    ListBox.ObjectCollection items = lstSkills.Items;
                    object[] array = config.Skills.ToArray();
                    items.AddRange(array);
                }
                List<Quest> quests = config.Quests;
                if (quests != null && quests.Count > 0)
                {
                    ListBox.ObjectCollection items = lstQuests.Items;
                    object[] array = config.Quests.ToArray();
                    items.AddRange(array);
                }
                List<InventoryItem> boosts = config.Boosts;
                if (boosts != null && boosts.Count > 0)
                {
                    ListBox.ObjectCollection items = lstBoosts.Items;
                    object[] array = config.Boosts.ToArray();
                    items.AddRange(array);
                }
                List<string> drops = config.Drops;
                if (drops != null && drops.Count > 0)
                {
                    ListBox.ObjectCollection items = lstDrops.Items;
                    object[] array = config.Drops.ToArray();
                    items.AddRange(array);
                }
                List<string> item = config.Items;
                if (item != null && item.Count > 0)
                {
                    ListBox.ObjectCollection items = lstItems.Items;
                    object[] array = config.Items.ToArray();
                    items.AddRange(array);
                }
                numSkillD.Value = config.SkillDelay;
                chkExitRest.Checked = config.ExitCombatBeforeRest;
                chkExistQuest.Checked = config.ExitCombatBeforeQuest;
                if (config.Server != null)
                {
                    cbServers.SelectedIndex = cbServers.Items.Cast<Server>().ToList().FindIndex((Server s) => s.Name == config.Server.Name);
                }
                chkRelog.Checked = config.AutoRelogin;
                numRelogDelay.Value = config.RelogDelay;
                chkRelogRetry.Checked = config.RelogRetryUponFailure;
                numBotDelay.Value = config.BotDelay;
                chkPickup.Checked = config.EnablePickup;
                chkReject.Checked = config.EnableRejection;
                chkPickupAll.Checked = config.EnablePickupAll;
                chkRejectAll.Checked = config.EnableRejectAll;
                chkAllSkillsCD.Checked = config.WaitForAllSkills;
                chkSkillCD.Checked = config.WaitForSkill;
                chkSkip.Checked = config.SkipDelayIndexIf;
                chkInfiniteRange.Checked = config.InfiniteAttackRange;
                chkProvoke.Checked = config.ProvokeMonsters;
                chkLag.Checked = config.LagKiller;
                chkMagnet.Checked = config.EnemyMagnet;
                chkHidePlayers.Checked = config.HidePlayers;
                chkSkipCutscenes.Checked = config.SkipCutscenes;
                numWalkSpeed.Value = (config.WalkSpeed <= 0) ? 8 : config.WalkSpeed;
                List<string> notifyUponDrop = config.NotifyUponDrop;
                if (notifyUponDrop != null && notifyUponDrop.Count > 0)
                {
                    ListBox.ObjectCollection items14 = lstSoundItems.Items;
                    object[] array = config.NotifyUponDrop.ToArray();
                    object[] items15 = array;
                    items14.AddRange(items15);
                }
                numRestMP.Value = config.RestMp;
                numRest.Value = config.RestHp;
                chkMP.Checked = config.RestIfMp;
                chkHP.Checked = config.RestIfHp;
                numEnsureTries.Value = (config.EnsureTries <= 0) ? 20 : config.EnsureTries;
                chkUntarget.Checked = config.Untarget;
                chkBankOnStop.Checked = config.BankOnStop;
                chkRestartDeath.Checked = config.RestartUponDeath;
                chkEnsureComplete.Checked = config.EnsureComplete;
                chkAFK.Checked = config.AFK;
                numDropDelay.Value = config.DropDelay <= 0 ? 1000 : config.DropDelay;
            }
        }

        public void OnConfigurationChanged(Configuration config)
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate
                {
                    ApplyConfiguration(config);
                });
            }
            else
            {
                ApplyConfiguration(config);
            }
        }

        public void OnIndexChanged(int index)
        {
            if (index > -1)
            {
                if (InvokeRequired)
                {
                    Invoke((Action)delegate
                    {
                        lstCommands.SelectedIndex = index;
                    });
                }
                else
                {
                    lstCommands.SelectedIndex = index;
                }
            }
        }

        public void OnSkillIndexChanged(int index)
        {
            if (index > -1 && index < lstSkills.Items.Count)
            {
                Invoke((Action)delegate
                {
                    lstSkills.SelectedIndex = index;
                });
            }
        }

        public void OnIsRunningChanged(bool IsRunning)
        {
            Invoke((Action)delegate
            {
                if (!IsRunning)
                {
                    ActiveBotEngine.IsRunningChanged -= OnIsRunningChanged;
                    ActiveBotEngine.IndexChanged -= OnIndexChanged;
                    ActiveBotEngine.ConfigurationChanged -= OnConfigurationChanged;
                }
                BotStateChanged(IsRunning);
            });
        }

        private void lstCommands_DoubleClick(object sender, EventArgs e)
        {
            if (lstCommands.Items.Count <= 0)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Load bot";
                    openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Bots");
                    openFileDialog.Filter = "Grimoire bots|*.gbot";
                    openFileDialog.DefaultExt = ".gbot";
                    if (openFileDialog.ShowDialog() == DialogResult.OK && TryDeserialize(File.ReadAllText(openFileDialog.FileName), out Configuration config))
                    {
                        ApplyConfiguration(config);
                    }
                }
            }
            else if (lstCommands.SelectedIndex > -1)
            {
                int selectedIndex = lstCommands.SelectedIndex;
                object obj = lstCommands.Items[selectedIndex];
                string text = RawCommandEditor.Show(JsonConvert.SerializeObject(obj, Formatting.Indented, _serializerSettings));
                if (text != null)
                {
                    try
                    {
                        IBotCommand item = (IBotCommand)JsonConvert.DeserializeObject(text, obj.GetType());
                        lstCommands.Items.Remove(obj);
                        lstCommands.Items.Insert(selectedIndex, item);
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (SelectedList.SelectedItem != null)
            {
                int selectedIndex = SelectedList.SelectedIndex;
                if (selectedIndex > -1)
                {
                    _RemoveListBoxItem();
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            _MoveListBoxDown();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            _MoveListBoxUp();
        }

        private void _RemoveListBoxItem()
        {
            SelectedList.BeginUpdate();
            for (int x = SelectedList.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = SelectedList.SelectedIndices[x];
                SelectedList.Items.RemoveAt(idx);
            }
            SelectedList.EndUpdate();
        }

        private void _MoveListBoxUp()
        {
            //MoveListItem(-1);
            SelectedList.BeginUpdate();
            int numberOfSelectedItems = SelectedList.SelectedItems.Count;
            for (int i = 0; i < numberOfSelectedItems; i++)
            {
                // only if it's not the first item
                if (SelectedList.SelectedIndices[i] > 0)
                {
                    // the index of the item above the item that we wanna move up
                    int indexToInsertIn = SelectedList.SelectedIndices[i] - 1;
                    // insert UP the item that we want to move up
                    SelectedList.Items.Insert(indexToInsertIn, SelectedList.SelectedItems[i]);
                    // removing it from its old place
                    SelectedList.Items.RemoveAt(indexToInsertIn + 2);
                    // highlighting it in its new place
                    SelectedList.SelectedItem = SelectedList.Items[indexToInsertIn];
                }
            }
            SelectedList.EndUpdate();
        }

        private void _MoveListBoxDown()
        {
            //MoveListItem(1);
            SelectedList.BeginUpdate();
            int numberOfSelectedItems = SelectedList.SelectedItems.Count;
            // when going down, instead of moving through the selected items from top to bottom
            // we'll go from bottom to top, it's easier to handle this way.
            for (int i = numberOfSelectedItems - 1; i >= 0; i--)
            {
                // only if it's not the last item
                if (SelectedList.SelectedIndices[i] < SelectedList.Items.Count - 1)
                {
                    // the index of the item that is currently below the selected item
                    int indexToInsertIn = SelectedList.SelectedIndices[i] + 2;
                    // insert DOWN the item that we want to move down
                    SelectedList.Items.Insert(indexToInsertIn, SelectedList.SelectedItems[i]);
                    // removing it from its old place
                    SelectedList.Items.RemoveAt(indexToInsertIn - 2);
                    // highlighting it in its new place
                    SelectedList.SelectedItem = SelectedList.Items[indexToInsertIn - 1];
                }
            }
            SelectedList.EndUpdate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                lstBoosts.Items.Clear();
                lstCommands.Items.Clear();
                lstDrops.Items.Clear();
                lstItems.Items.Clear();
                lstQuests.Items.Clear();
                lstSkills.Items.Clear();
            }
            else
            {
                SelectedList.Items.Clear();
            }
        }

        private void cbLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBoosts.Visible = SelectedList == lstBoosts;
            lstCommands.Visible = SelectedList == lstCommands;
            lstDrops.Visible = SelectedList == lstDrops;
            lstItems.Visible = SelectedList == lstItems;
            lstQuests.Visible = SelectedList == lstQuests;
            lstSkills.Visible = SelectedList == lstSkills;
        }

        private void BotManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            string monster = string.IsNullOrEmpty(txtMonster.Text) ? "*" : txtMonster.Text;
            if (txtMonster.Text == "Monster (*  = random)")
            {
                monster = "*";
            }
            AddCommand(new CmdKill
            {
                Monster = monster
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnKillF_Click(object sender, EventArgs e)
        {
            if (txtKillFItem.Text.Length > 0 && txtKillFQ.Text.Length > 0)
            {
                string monster = string.IsNullOrEmpty(txtKillFMon.Text) ? "*" : txtKillFMon.Text;
                string text = txtKillFItem.Text;
                string text2 = txtKillFQ.Text;
                AddCommand(new CmdKillFor
                {
                    ItemType = (!rbItems.Checked) ? ItemType.TempItems : ItemType.Items,
                    Monster = monster,
                    ItemName = text,
                    Quantity = text2
                }, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            string text = numSkill.Text;
            AddSkill(new Skill
            {
                Text = text + ": " + Skill.GetSkillName(text),
                Index = text,
                Type = Skill.SkillType.Normal
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnAddSafe_Click(object sender, EventArgs e)
        {
            string text = numSkill.Text;
            int safeHealth = (int)numSafe.Value;
            AddSkill(new Skill
            {
                Text = "[S] " + text + ": " + Skill.GetSkillName(text),
                Index = text,
                SafeHealth = safeHealth,
                Type = Skill.SkillType.Safe,
                SafeMp = chkSafeMp.Checked
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdRest(), (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnRestF_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdRest
            {
                Full = true
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            string text = txtJoin.Text;
            string cell = string.IsNullOrEmpty(txtJoinCell.Text) ? "Enter" : txtJoinCell.Text;
            string pad = string.IsNullOrEmpty(txtJoinPad.Text) ? "Spawn" : txtJoinPad.Text;
            if (text.Length > 0)
            {
                AddCommand(new CmdJoin
                {
                    Map = text,
                    Cell = cell,
                    Pad = pad
                }, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnCellSwap_Click(object sender, EventArgs e)
        {
            Button s = sender as Button;
            if (s.Text == "<")
            {
                txtJoin.Text = Player.Map + "-" + Flash.Call<string>("RoomNumber", new object[0]);
                txtJoinCell.Text = txtCell.Text;
                txtJoinPad.Text = txtPad.Text;
            }
            else if (s.Text == ">")
            {
                txtCell.Text = txtJoinCell.Text;
                txtPad.Text = txtJoinPad.Text;
            }
        }

        private void btnCurrCell_Click(object sender, EventArgs e)
        {
            txtCell.Text = Player.Cell;
            txtPad.Text = Player.Pad;
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            string cell = string.IsNullOrEmpty(txtCell.Text) ? "Enter" : txtCell.Text;
            string pad = string.IsNullOrEmpty(txtPad.Text) ? "Spawn" : txtPad.Text;
            AddCommand(new CmdMoveToCell
            {
                Cell = cell,
                Pad = pad
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnWalk_Click(object sender, EventArgs e)
        {
            string x = numWalkX.Value.ToString();
            string y = numWalkY.Value.ToString();
            AddCommand(new CmdWalk
            {
                X = x,
                Y = y
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnWalkCur_Click(object sender, EventArgs e)
        {
            float[] position = Player.Position;
            numWalkX.Value = (decimal)position[0];
            numWalkY.Value = (decimal)position[1];
        }

        private void btnWalkRdm_Click(object sender, EventArgs e)
        {
            string x = numWalkX.Value.ToString();
            string y = numWalkY.Value.ToString();
            AddCommand(new CmdWalk
            {
                Type = "Random",
                X = x,
                Y = y
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            string text = txtItem.Text;
            if (text.Length > 0 && cbItemCmds.SelectedIndex > -1)
            {
                IBotCommand cmd;
                switch (cbItemCmds.SelectedIndex)
                {
                    case 0:
                        cmd = new CmdGetDrop
                        {
                            ItemName = text
                        };
                        break;

                    case 1:
                        cmd = new CmdSell
                        {
                            ItemName = text
                        };
                        break;

                    case 2:
                        cmd = new CmdEquip
                        {
                            ItemName = text
                        };
                        break;

                    case 3:
                        cmd = new CmdBankTransfer
                        {
                            ItemName = text,
                            TransferFromBank = false
                        };
                        break;

                    case 4:
                        cmd = new CmdBankTransfer
                        {
                            ItemName = text,
                            TransferFromBank = true
                        };
                        break;

                    default:
                        cmd = new CmdEquipSet
                        {
                            ItemName = text
                        };
                        break;
                }
                AddCommand(cmd, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnMapItem_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdMapItem
            {
                ItemId = (int)numMapItem.Value
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnBoth_Click(object sender, EventArgs e)
        {
            string text = txtWhitelist.Text;
            if (text.Length > 0)
            {
                AddDrop(text);
                AddItem(text);
            }
        }

        private void btnWhitelist_Click(object sender, EventArgs e)
        {
            string text = txtWhitelist.Text;
            if (text.Length > 0)
            {
                AddDrop(text);
            }
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string text = txtSwapBank.Text;
            string text2 = txtSwapInv.Text;
            if (text.Length > 0 && text2.Length > 0)
            {
                AddCommand(new CmdBankSwap
                {
                    InventoryItemName = text2,
                    BankItemName = text
                }, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnBoost_Click(object sender, EventArgs e)
        {
            if (cbBoosts.SelectedIndex > -1)
            {
                lstBoosts.Items.Add(cbBoosts.SelectedItem);
            }
        }

        private void cbBoosts_Click(object sender, EventArgs e)
        {
            cbBoosts.Items.Clear();
            ComboBox.ObjectCollection items = cbBoosts.Items;
            object[] array = Player.Inventory.Items.Where((InventoryItem i) => i.Category == "ServerUse").ToArray();
            object[] items2 = array;
            items.AddRange(items2);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (txtShopItem.TextLength > 0)
            {
                AddCommand(new CmdBuy
                {
                    ItemName = txtShopItem.Text,
                    ShopId = (int)numShopId.Value
                }, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnQuestAdd_Click(object sender, EventArgs e)
        {
            AddQuest((int)numQuestID.Value, chkQuestItem.Checked ? numQuestItem.Value.ToString() : null);
        }

        private void btnQuestComplete_Click(object sender, EventArgs e)
        {
            Quest quest = new Quest();
            CmdCompleteQuest cmdCompleteQuest = new CmdCompleteQuest();
            quest.Id = (int)numQuestID.Value;
            if (chkQuestItem.Checked)
            {
                quest.ItemId = numQuestItem.Value.ToString();
            }
            cmdCompleteQuest.Quest = quest;
            AddCommand(cmdCompleteQuest, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnQuestAccept_Click(object sender, EventArgs e)
        {
            Quest quest = new Quest
            {
                Id = (int)numQuestID.Value
            };
            AddCommand(new CmdAcceptQuest
            {
                Quest = quest
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void chkQuestItem_CheckedChanged(object sender, EventArgs e)
        {
            numQuestItem.Enabled = chkQuestItem.Checked;
        }

        private void btnPacket_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdPacket
            {
                Packet = txtPacket.Text
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            int delay = (int)numDelay.Value;
            AddCommand(new CmdDelay
            {
                Delay = delay
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            string text = txtPlayer.Text;
            if (text.Length > 0)
            {
                AddCommand(new CmdGotoPlayer
                {
                    PlayerName = text
                }, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnBotDelay_Click(object sender, EventArgs e)
        {
            int delay = (int)numBotDelay.Value;
            AddCommand(new CmdBotDelay
            {
                Delay = delay
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdStop(), (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdRestart(), (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Load bot";
                openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Bots");
                openFileDialog.Filter = "Grimoire bots|*.gbot";
                openFileDialog.DefaultExt = ".gbot";
                if (openFileDialog.ShowDialog() == DialogResult.OK && TryDeserialize(File.ReadAllText(openFileDialog.FileName), out Configuration config))
                {
                    ApplyConfiguration(config);
                }
            }
        }

        private bool TryDeserialize(string json, out Configuration config)
        {
            try
            {
                config = JsonConvert.DeserializeObject<Configuration>(json, _serializerSettings);
                return true;
            }
            catch
            {

            }
            config = null;
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save bot";
                saveFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Bots");
                saveFileDialog.DefaultExt = ".gbot";
                saveFileDialog.Filter = "Grimoire bots|*.gbot";
                saveFileDialog.CheckFileExists = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Configuration value = GenerateConfiguration();
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(value, Formatting.Indented, _serializerSettings));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to save bot: " + ex.Message);
                    }
                }
            }
        }

        private void btnLoadCmd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string initialDirectory = Path.Combine(Application.StartupPath, "Bots");
                openFileDialog.Title = "Select bot to load";
                openFileDialog.Filter = "Grimoire bots|*.gbot";
                openFileDialog.InitialDirectory = initialDirectory;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AddCommand(new CmdLoadBot
                    {
                        BotFilePath = Extensions.MakeRelativePathFrom(Application.StartupPath, openFileDialog.FileName), // Path.GetFullPath(openFileDialog.FileName)
                        BotFileName = Path.GetFileName(openFileDialog.FileName)

                    }, (ModifierKeys & Keys.Control) == Keys.Control);
                }
            }
        }

        private void cbStatement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategories.SelectedIndex > -1 && cbStatement.SelectedIndex > -1)
            {
                StatementCommand statementCommand = (StatementCommand)cbStatement.SelectedItem;
                txtStatement1.Enabled = statementCommand.Description1 != null;
                txtStatement2.Enabled = statementCommand.Description2 != null;
                txtStatement1.Text = statementCommand.Description1;
                txtStatement2.Text = statementCommand.Description2;
            }
        }

        private void btnStatementAdd_Click(object sender, EventArgs e)
        {
            if (cbCategories.SelectedIndex > -1 && cbStatement.SelectedIndex > -1)
            {
                string text = txtStatement1.Text;
                string text2 = txtStatement2.Text;
                StatementCommand statementCommand = (StatementCommand)Activator.CreateInstance(cbStatement.SelectedItem.GetType());
                statementCommand.Value1 = text;
                statementCommand.Value2 = text2;
                AddCommand((IBotCommand)statementCommand, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategories.SelectedIndex > -1)
            {
                cbStatement.Items.Clear();
                string text = cbCategories.SelectedItem.ToString();
                ComboBox.ObjectCollection items = cbStatement.Items;
                object[] array = _statementCommands.Where((StatementCommand s) => s.Tag == text).ToArray();
                object[] items2 = array;
                items.AddRange(items2);
            }
        }

        private void btnGotoLabel_Click(object sender, EventArgs e)
        {
            if (txtLabel.TextLength > 0)
            {
                AddCommand(new CmdGotoLabel
                {
                    Label = txtLabel.Text
                }, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnAddLabel_Click(object sender, EventArgs e)
        {
            if (txtLabel.TextLength > 0)
            {
                AddCommand(new CmdLabel
                {
                    Name = txtLabel.Text
                }, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdLogout(), (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void UpdateTree()
        {
            if (!string.IsNullOrEmpty(txtSaved.Text) && Directory.Exists(txtSaved.Text))
            {
                lblBots.Text = string.Format("Number of Bots: {0}", Directory.EnumerateFiles(txtSaved.Text, "*.gbot", SearchOption.AllDirectories).Count());
                treeBots.Nodes.Clear();
                AddTreeNodes(treeBots, txtSaved.Text);
            }
        }

        private void treeBots_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = Path.Combine(txtSaved.Text, e.Node.FullPath);
            if (File.Exists(path))
            {
                if (!TryDeserialize(File.ReadAllText(path), out Configuration config))
                {
                    return;
                }
                ApplyConfiguration(config);
            }
            lblCommands.Text = $"Number of{Environment.NewLine}Commands: {lstCommands.Items.Count}";
            lblSkills.Text = $"Skills: {lstSkills.Items.Count}";
            lblQuests.Text = $"Quests: {lstQuests.Items.Count}";
            lblDrops.Text = $"Drops: {lstDrops.Items.Count}";
            lblBoosts.Text = $"Boosts: {lstBoosts.Items.Count}";
            lblItems.Text = $"Items: {lstItems.Items.Count}";
        }

        private void treeBots_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string path = Path.Combine(txtSaved.Text, e.Node.FullPath);
            if (Directory.Exists(path))
            {
                AddTreeNodes(e.Node, path);
                if (e.Node.Nodes.Count > 0 && e.Node.Nodes[0].Text == "Loading...")
                {
                    e.Node.Nodes.RemoveAt(0);
                }
            }
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
            foreach (string item2 in Directory.EnumerateFiles(path, "*.gbot", SearchOption.TopDirectoryOnly))
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
            foreach (string item2 in Directory.EnumerateFiles(path, "*.gbot", SearchOption.TopDirectoryOnly))
            {
                string add2 = Path.GetFileName(item2);
                if (tree.Nodes.Cast<TreeNode>().ToList().All((TreeNode n) => n.Text != add2))
                {
                    tree.Nodes.Add(add2);
                }
            }
        }

        private void btnSavedAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSaved.Text))
            {
                string path = Path.Combine(txtSaved.Text, txtSavedAdd.Text);
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to create directory: " + ex.Message, "Grimoire", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                UpdateTree();
            }
        }

        private void btnSoundAdd_Click(object sender, EventArgs e)
        {
            if (txtSoundItem.TextLength > 0)
            {
                lstSoundItems.Items.Add(txtSoundItem.Text);
            }
        }

        private void btnSoundDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstSoundItems.SelectedIndex;
            if (selectedIndex > -1)
            {
                lstSoundItems.Items.RemoveAt(selectedIndex);
            }
        }

        private void btnSoundClear_Click(object sender, EventArgs e)
        {
            lstSoundItems.Items.Clear();
        }

        private void btnSoundTest_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Beep();
            }
        }

        private void chkInfiniteRange_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.InfiniteRange = chkInfiniteRange.Checked;
        }

        private void chkProvoke_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.ProvokeMonsters = chkProvoke.Checked;
        }

        private void chkMagnet_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.EnemyMagnet = chkMagnet.Checked;
        }

        private void chkLag_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.LagKiller = chkLag.Checked;
        }

        private void chkHidePlayers_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.HidePlayers = chkHidePlayers.Checked;
        }

        private void chkSkipCutscenes_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.SkipCutscenes = chkSkipCutscenes.Checked;
        }

        private void numWalkSpeed_ValueChanged(object sender, EventArgs e)
        {
            OptionsManager.WalkSpeed = (int)numWalkSpeed.Value;
        }

        private void chkDisableAnims_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.DisableAnimations = chkDisableAnims.Checked;
        }

        private void OnOptionsStateChanged(bool state)
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate
                {
                    chkEnableSettings.Checked = state;
                });
            }
            else
            {
                chkEnableSettings.Checked = state;
            }
        }

        private void chkEnableSettings_Click(object sender, EventArgs e)
        {
            if (chkEnableSettings.Checked)
                OptionsManager.Start();
            else
                OptionsManager.Stop();
        }
        
        private void lstBoxs_KeyPress(object sender, KeyEventArgs e)
        {
            if      (ModifierKeys == Keys.Control && e.KeyCode == Keys.Up)
            {
                _MoveListBoxUp();
                e.Handled = true;
            }
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Down)
            {
                _MoveListBoxDown();
                e.Handled = true;
            }
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Delete)
            {
                btnRemove.PerformClick();
                e.Handled = true;
            }
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.D && SelectedList.SelectedIndex > -1)
            {
                var selectedItems = SelectedList.SelectedItems;
                for (int i = 0; selectedItems.Count > i; i++)
                {
                    SelectedList.Items.Insert(SelectedList.SelectedIndex + selectedItems.Count + i, selectedItems[i]);
                }
                e.Handled = true;
            }
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.C && SelectedList.SelectedIndex > -1)
            {
                Clipboard.Clear();
                Configuration items = new Configuration {
                    Commands = lstCommands.SelectedItems.Cast<IBotCommand>().ToList(),
                    Skills = lstSkills.SelectedItems.Cast<Skill>().ToList(),
                    Quests = lstQuests.SelectedItems.Cast<Quest>().ToList(),
                    Boosts = lstBoosts.SelectedItems.Cast<InventoryItem>().ToList(),
                    Drops = lstDrops.SelectedItems.Cast<string>().ToList(),
                    Items = lstItems.SelectedItems.Cast<string>().ToList()
                };
                Clipboard.SetText(JsonConvert.SerializeObject(items, Formatting.Indented, _serializerSettings));
                e.Handled = true;
            }
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.V)
            {
                TryDeserialize(Clipboard.GetText(), out Configuration config);
                List<IBotCommand> commands = config.Commands;
                if (commands != null && commands.Count > 0)
                {
                    ListBox.ObjectCollection items = lstCommands.Items;
                    object[] array = config.Commands.ToArray();
                    int selectedIndex = lstCommands.SelectedIndex;
                    lstCommands.SelectedIndex = -1;
                    for (int i = 0; array.Count() > i; i++)
                    {
                        items.Insert(selectedIndex + i + 1, array[i]);
                        lstCommands.SelectedIndex = selectedIndex + i + 1;
                    }
                }
                List<Skill> skills = config.Skills;
                if (skills != null && skills.Count > 0)
                {
                    ListBox.ObjectCollection items = lstSkills.Items;
                    object[] array = config.Skills.ToArray();
                    items.AddRange(array);
                }
                List<Quest> quests = config.Quests;
                if (quests != null && quests.Count > 0)
                {
                    ListBox.ObjectCollection items = lstQuests.Items;
                    object[] array = config.Quests.ToArray();
                    items.AddRange(array);
                }
                List<InventoryItem> boosts = config.Boosts;
                if (boosts != null && boosts.Count > 0)
                {
                    ListBox.ObjectCollection items = lstBoosts.Items;
                    object[] array = config.Boosts.ToArray();
                    items.AddRange(array);
                }
                List<string> drops = config.Drops;
                if (drops != null && drops.Count > 0)
                {
                    ListBox.ObjectCollection items = lstDrops.Items;
                    object[] array = config.Drops.ToArray();
                    items.AddRange(array);
                }
                List<string> item = config.Items;
                if (item != null && item.Count > 0)
                {
                    ListBox.ObjectCollection items = lstItems.Items;
                    object[] array = config.Items.ToArray();
                    items.AddRange(array);
                }
                e.Handled = true;
            }
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.S)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Save bot";
                    saveFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Bots");
                    saveFileDialog.DefaultExt = ".gbot";
                    saveFileDialog.Filter = "Grimoire bots|*.gbot";
                    saveFileDialog.CheckFileExists = false;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Configuration value = GenerateConfiguration();
                        try
                        {
                            File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(value, Formatting.Indented, _serializerSettings));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Unable to save bot: " + ex.Message);
                        }
                    }
                }
                e.Handled = true;
            }
        }

        private void AddCommand(IBotCommand cmd, bool Insert)
        {
            if (Insert)
            {
                lstCommands.Items.Insert((lstCommands.SelectedIndex > -1) ? lstCommands.SelectedIndex : lstCommands.Items.Count, cmd);
            }
            else
            {
                lstCommands.Items.Add(cmd);
            }
        }

        private void AddSkill(Skill skill, bool Insert)
        {
            if (Insert)
            {
                lstSkills.Items.Insert((lstSkills.SelectedIndex > -1) ? lstSkills.SelectedIndex : lstSkills.Items.Count, skill);
            }
            else
            {
                lstSkills.Items.Add(skill);
            }
        }

        public void btnBotStart_ClickAsync(object sender, EventArgs e)
        {
            if (Player.IsAlive && Player.IsLoggedIn && lstCommands.Items.Count > 0)
            {
                this.lstCommands.SelectionMode = SelectionMode.One;
                this.lstItems.SelectionMode = SelectionMode.One;
                this.lstSkills.SelectionMode = SelectionMode.One;
                this.lstQuests.SelectionMode = SelectionMode.One;
                this.lstDrops.SelectionMode = SelectionMode.One;
                this.lstBoosts.SelectionMode = SelectionMode.One;
                ActiveBotEngine.IsRunningChanged += OnIsRunningChanged;
                ActiveBotEngine.IndexChanged += OnIndexChanged;
                ActiveBotEngine.ConfigurationChanged += OnConfigurationChanged;
                ActiveBotEngine.Start(GenerateConfiguration());
                BotStateChanged(IsRunning: true);
                Root.Instance.BotStateChanged(IsRunning: true);
            }
        }

        public async void btnBotStop_Click(object sender, EventArgs e)
        {
            if (lstItems != null && this.chkBankOnStop.Checked)
            {
                foreach (InventoryItem item in Player.Inventory.Items)
                {
                    if (!item.IsEquipped && item.IsAcItem && item.Category != "Class" && item.Name.ToLower() != "treasure potion" && lstItems.Items.Contains(item.Name))
                    {
                        Player.Bank.TransferToBank(item.Name);
                        await Task.Delay(70);
                        LogForm.Instance.AppendDebug("Transferred to Bank: " + item.Name + "\r\n");
                    }
                }
                LogForm.Instance.AppendDebug("Banked all AC Items in Items list \r\n");
            }
            btnBotStart.Enabled = false;
            ActiveBotEngine.Stop();
            this.lstCommands.SelectionMode = SelectionMode.MultiExtended;
            this.lstItems.SelectionMode = SelectionMode.MultiExtended;
            this.lstSkills.SelectionMode = SelectionMode.MultiExtended;
            this.lstQuests.SelectionMode = SelectionMode.MultiExtended;
            this.lstDrops.SelectionMode = SelectionMode.MultiExtended;
            this.lstBoosts.SelectionMode = SelectionMode.MultiExtended;
            await Task.Delay(2000);
            BotStateChanged(IsRunning: false);
            Root.Instance.BotStateChanged(IsRunning: false);
            btnBotStart.Enabled = true;
        }

        public void BotStateChanged(bool IsRunning)
        {
            if (IsRunning)
            {
                btnBotStart.Hide();
                btnBotStop.Show();
            }
            else
            {
                btnBotStop.Hide();
                btnBotStart.Show();
            }
            btnUp.Enabled = !IsRunning;
            btnDown.Enabled = !IsRunning;
            btnClear.Enabled = !IsRunning;
            btnRemove.Enabled = !IsRunning;
        }

        public void AddCommand(IBotCommand cmd)
        {
            lstCommands.Items.Add(cmd);
        }

        public void AddQuest(int QuestID, string ItemID = null)
        {
            Quest quest = new Quest
            {
                Id = QuestID,
                ItemId = ItemID
            };
            quest.Text = (quest.ItemId != null) ? $"{quest.Id}:{quest.ItemId}" : quest.Id.ToString();
            if (!lstQuests.Items.Contains(quest))
            {
                lstQuests.Items.Add(quest);
            }
        }

        public void AddDrop(string Name)
        {
            if (!lstDrops.Items.Contains(Name))
            {
                lstDrops.Items.Add(Name);
            }
        }

        private void btnAddSkillSet_Click(object sender, EventArgs e)
        {
            if (txtSkillSet.TextLength > 0)
            {
                AddSkill(new Skill
                {
                    Text = "[" + txtSkillSet.Text.ToUpper() + "]",
                    Type = Skill.SkillType.Label
                }, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnUseSkillSet_Click(object sender, EventArgs e)
        {
            if (txtSkillSet.TextLength > 0)
            {
                AddCommand(new CmdSkillSet
                {
                    Name = txtSkillSet.Text.ToUpper()
                }, (ModifierKeys & Keys.Control) == Keys.Control);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotManager));
            this.lstCommands = new System.Windows.Forms.ListBox();
            this.lstBoosts = new System.Windows.Forms.ListBox();
            this.lstDrops = new System.Windows.Forms.ListBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.lstQuests = new System.Windows.Forms.ListBox();
            this.lstSkills = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCombat = new System.Windows.Forms.TabPage();
            this.pnlCombat = new System.Windows.Forms.Panel();
            this.btnUseSkillSet = new System.Windows.Forms.Button();
            this.btnAddSkillSet = new System.Windows.Forms.Button();
            this.txtSkillSet = new System.Windows.Forms.TextBox();
            this.chkSafeMp = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnRest = new System.Windows.Forms.Button();
            this.btnRestF = new System.Windows.Forms.Button();
            this.chkSkillCD = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.chkExistQuest = new System.Windows.Forms.CheckBox();
            this.numRestMP = new System.Windows.Forms.NumericUpDown();
            this.chkMP = new System.Windows.Forms.CheckBox();
            this.numRest = new System.Windows.Forms.NumericUpDown();
            this.chkHP = new System.Windows.Forms.CheckBox();
            this.chkPacket = new System.Windows.Forms.CheckBox();
            this.numSkillD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numSafe = new System.Windows.Forms.NumericUpDown();
            this.btnAddSafe = new System.Windows.Forms.Button();
            this.btnSkillCmd = new System.Windows.Forms.Button();
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.numSkill = new System.Windows.Forms.NumericUpDown();
            this.chkExitRest = new System.Windows.Forms.CheckBox();
            this.chkAllSkillsCD = new System.Windows.Forms.CheckBox();
            this.txtKillFQ = new System.Windows.Forms.TextBox();
            this.txtKillFItem = new System.Windows.Forms.TextBox();
            this.txtKillFMon = new System.Windows.Forms.TextBox();
            this.rbTemp = new System.Windows.Forms.RadioButton();
            this.rbItems = new System.Windows.Forms.RadioButton();
            this.btnKillF = new System.Windows.Forms.Button();
            this.txtMonster = new System.Windows.Forms.TextBox();
            this.tabItem = new System.Windows.Forms.TabPage();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numDropDelay = new System.Windows.Forms.NumericUpDown();
            this.chkRejectAll = new System.Windows.Forms.CheckBox();
            this.chkPickupAll = new System.Windows.Forms.CheckBox();
            this.chkBankOnStop = new System.Windows.Forms.CheckBox();
            this.txtShopItem = new System.Windows.Forms.TextBox();
            this.numShopId = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnBuyFast = new System.Windows.Forms.Button();
            this.btnLoadShop = new System.Windows.Forms.Button();
            this.btnBoost = new System.Windows.Forms.Button();
            this.cbBoosts = new System.Windows.Forms.ComboBox();
            this.numMapItem = new System.Windows.Forms.NumericUpDown();
            this.btnMapItem = new System.Windows.Forms.Button();
            this.btnSwap = new System.Windows.Forms.Button();
            this.txtSwapInv = new System.Windows.Forms.TextBox();
            this.txtSwapBank = new System.Windows.Forms.TextBox();
            this.chkReject = new System.Windows.Forms.CheckBox();
            this.chkPickup = new System.Windows.Forms.CheckBox();
            this.btnWhitelist = new System.Windows.Forms.Button();
            this.btnBoth = new System.Windows.Forms.Button();
            this.txtWhitelist = new System.Windows.Forms.TextBox();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnUnbanklst = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.cbItemCmds = new System.Windows.Forms.ComboBox();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.btnCurrBlank = new System.Windows.Forms.Button();
            this.btnSetSpawn = new System.Windows.Forms.Button();
            this.btnWalkRdm = new System.Windows.Forms.Button();
            this.btnYulgar = new System.Windows.Forms.Button();
            this.btnWalkCur = new System.Windows.Forms.Button();
            this.btnWalk = new System.Windows.Forms.Button();
            this.numWalkY = new System.Windows.Forms.NumericUpDown();
            this.numWalkX = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCellSwap = new System.Windows.Forms.Button();
            this.btnJump = new System.Windows.Forms.Button();
            this.btnCurrCell = new System.Windows.Forms.Button();
            this.txtPad = new System.Windows.Forms.TextBox();
            this.txtCell = new System.Windows.Forms.TextBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.txtJoinPad = new System.Windows.Forms.TextBox();
            this.txtJoinCell = new System.Windows.Forms.TextBox();
            this.txtJoin = new System.Windows.Forms.TextBox();
            this.tabQuest = new System.Windows.Forms.TabPage();
            this.pnlQuest = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.numEnsureTries = new System.Windows.Forms.NumericUpDown();
            this.chkEnsureComplete = new System.Windows.Forms.CheckBox();
            this.btnQuestAccept = new System.Windows.Forms.Button();
            this.btnQuestComplete = new System.Windows.Forms.Button();
            this.btnQuestAdd = new System.Windows.Forms.Button();
            this.numQuestItem = new System.Windows.Forms.NumericUpDown();
            this.chkQuestItem = new System.Windows.Forms.CheckBox();
            this.numQuestID = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.pnlMisc = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.btnDecreaseInt = new System.Windows.Forms.Button();
            this.btnIncreaseInt = new System.Windows.Forms.Button();
            this.numSetInt = new System.Windows.Forms.NumericUpDown();
            this.txtSetInt = new System.Windows.Forms.TextBox();
            this.btnSetInt = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnGoDownIndex = new System.Windows.Forms.Button();
            this.btnGoUpIndex = new System.Windows.Forms.Button();
            this.btnGotoIndex = new System.Windows.Forms.Button();
            this.numIndexCmd = new System.Windows.Forms.NumericUpDown();
            this.btnBlank = new System.Windows.Forms.Button();
            this.btnProvokeOff = new System.Windows.Forms.Button();
            this.btnProvokeOn = new System.Windows.Forms.Button();
            this.btnProvoke = new System.Windows.Forms.Button();
            this.labelProvoke = new System.Windows.Forms.Label();
            this.chkRestartDeath = new System.Windows.Forms.CheckBox();
            this.chkMerge = new System.Windows.Forms.CheckBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.btnGotoLabel = new System.Windows.Forms.Button();
            this.btnAddLabel = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBeep = new System.Windows.Forms.Button();
            this.numBeepTimes = new System.Windows.Forms.NumericUpDown();
            this.btnDelay = new System.Windows.Forms.Button();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numBotDelay = new System.Windows.Forms.NumericUpDown();
            this.btnBotDelay = new System.Windows.Forms.Button();
            this.txtPlayer = new System.Windows.Forms.TextBox();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLoadCmd = new System.Windows.Forms.Button();
            this.chkSkip = new System.Windows.Forms.CheckBox();
            this.btnStatementAdd = new System.Windows.Forms.Button();
            this.txtStatement2 = new System.Windows.Forms.TextBox();
            this.txtStatement1 = new System.Windows.Forms.TextBox();
            this.cbStatement = new System.Windows.Forms.ComboBox();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.txtPacket = new System.Windows.Forms.TextBox();
            this.btnClientPacket = new System.Windows.Forms.Button();
            this.btnPacket = new System.Windows.Forms.Button();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.chkBuff = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numOptionsTimer = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkUntarget = new System.Windows.Forms.CheckBox();
            this.lstLogText = new System.Windows.Forms.ListBox();
            this.btnLogDebug = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.chkEnableSettings = new System.Windows.Forms.CheckBox();
            this.chkDisableAnims = new System.Windows.Forms.CheckBox();
            this.txtSoundItem = new System.Windows.Forms.TextBox();
            this.btnSoundAdd = new System.Windows.Forms.Button();
            this.btnSoundDelete = new System.Windows.Forms.Button();
            this.btnSoundTest = new System.Windows.Forms.Button();
            this.lstSoundItems = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numWalkSpeed = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.chkSkipCutscenes = new System.Windows.Forms.CheckBox();
            this.chkHidePlayers = new System.Windows.Forms.CheckBox();
            this.chkLag = new System.Windows.Forms.CheckBox();
            this.chkMagnet = new System.Windows.Forms.CheckBox();
            this.chkProvoke = new System.Windows.Forms.CheckBox();
            this.chkInfiniteRange = new System.Windows.Forms.CheckBox();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.chkAFK = new System.Windows.Forms.CheckBox();
            this.cbServers = new System.Windows.Forms.ComboBox();
            this.chkRelogRetry = new System.Windows.Forms.CheckBox();
            this.chkRelog = new System.Windows.Forms.CheckBox();
            this.numRelogDelay = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.chkGender = new System.Windows.Forms.CheckBox();
            this.tabOptions2 = new System.Windows.Forms.TabPage();
            this.numSetLevel = new System.Windows.Forms.NumericUpDown();
            this.chkChangeRoomTag = new System.Windows.Forms.CheckBox();
            this.chkChangeChat = new System.Windows.Forms.CheckBox();
            this.chkSetJoinLevel = new System.Windows.Forms.CheckBox();
            this.chkHideYulgarPlayers = new System.Windows.Forms.CheckBox();
            this.chkAntiAfk = new System.Windows.Forms.CheckBox();
            this.grpAccessLevel = new System.Windows.Forms.GroupBox();
            this.chkToggleMute = new System.Windows.Forms.CheckBox();
            this.btnSetMem = new System.Windows.Forms.Button();
            this.btnSetModerator = new System.Windows.Forms.Button();
            this.btnSetNonMem = new System.Windows.Forms.Button();
            this.grpAlignment = new System.Windows.Forms.GroupBox();
            this.btnSetChaos = new System.Windows.Forms.Button();
            this.btnSetUndecided = new System.Windows.Forms.Button();
            this.btnSetGood = new System.Windows.Forms.Button();
            this.btnSetEvil = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnChangeNameCmd = new System.Windows.Forms.Button();
            this.btnchangeName = new System.Windows.Forms.Button();
            this.btnChangeGuildCmd = new System.Windows.Forms.Button();
            this.btnchangeGuild = new System.Windows.Forms.Button();
            this.txtGuild = new System.Windows.Forms.TextBox();
            this.tabBots = new System.Windows.Forms.TabPage();
            this.pnlSaved = new System.Windows.Forms.Panel();
            this.lblBoosts = new System.Windows.Forms.Label();
            this.lblDrops = new System.Windows.Forms.Label();
            this.lblQuests = new System.Windows.Forms.Label();
            this.lblSkills = new System.Windows.Forms.Label();
            this.lblCommands = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.txtSavedDesc = new System.Windows.Forms.TextBox();
            this.txtSavedAuthor = new System.Windows.Forms.TextBox();
            this.lblBots = new System.Windows.Forms.Label();
            this.treeBots = new System.Windows.Forms.TreeView();
            this.txtSavedAdd = new System.Windows.Forms.TextBox();
            this.btnSavedAdd = new System.Windows.Forms.Button();
            this.txtSaved = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.cbLists = new System.Windows.Forms.ComboBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnBotStop = new System.Windows.Forms.Button();
            this.btnBotStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkBuffup = new System.Windows.Forms.CheckBox();
            this.BotManagerMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeFontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multilineToggleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleTabpagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabCombat.SuspendLayout();
            this.pnlCombat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRestMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkillD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).BeginInit();
            this.tabItem.SuspendLayout();
            this.pnlItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDropDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShopId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapItem)).BeginInit();
            this.tabMap.SuspendLayout();
            this.pnlMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkX)).BeginInit();
            this.tabQuest.SuspendLayout();
            this.pnlQuest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEnsureTries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestID)).BeginInit();
            this.tabMisc.SuspendLayout();
            this.pnlMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIndexCmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeepTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBotDelay)).BeginInit();
            this.tabOptions.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOptionsTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeed)).BeginInit();
            this.grpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRelogDelay)).BeginInit();
            this.tabOptions2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetLevel)).BeginInit();
            this.grpAccessLevel.SuspendLayout();
            this.grpAlignment.SuspendLayout();
            this.tabBots.SuspendLayout();
            this.pnlSaved.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.BotManagerMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCommands
            // 
            this.lstCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCommands.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstCommands.FormattingEnabled = true;
            this.lstCommands.HorizontalScrollbar = true;
            this.lstCommands.IntegralHeight = false;
            this.lstCommands.ItemHeight = 15;
            this.lstCommands.Location = new System.Drawing.Point(0, 0);
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstCommands.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCommands.Size = new System.Drawing.Size(238, 251);
            this.lstCommands.TabIndex = 1;
            this.lstCommands.Click += new System.EventHandler(this.lstCommands_Click);
            this.lstCommands.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstCommands_DrawItem);
            this.lstCommands.DoubleClick += new System.EventHandler(this.lstCommands_DoubleClick);
            this.lstCommands.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstBoxs_KeyPress);
            this.lstCommands.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstCommands_KeyPress);
            this.lstCommands.MouseEnter += new System.EventHandler(this.lstCommands_MouseEnter);
            this.lstCommands.MouseLeave += new System.EventHandler(this.lstCommands_MouseLeave);
            // 
            // lstBoosts
            // 
            this.lstBoosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoosts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lstBoosts.FormattingEnabled = true;
            this.lstBoosts.HorizontalScrollbar = true;
            this.lstBoosts.Location = new System.Drawing.Point(0, 0);
            this.lstBoosts.Name = "lstBoosts";
            this.lstBoosts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoosts.Size = new System.Drawing.Size(238, 251);
            this.lstBoosts.TabIndex = 25;
            this.lstBoosts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstBoxs_KeyPress);
            // 
            // lstDrops
            // 
            this.lstDrops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDrops.FormattingEnabled = true;
            this.lstDrops.HorizontalScrollbar = true;
            this.lstDrops.Location = new System.Drawing.Point(0, 0);
            this.lstDrops.Name = "lstDrops";
            this.lstDrops.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstDrops.Size = new System.Drawing.Size(238, 251);
            this.lstDrops.TabIndex = 26;
            this.lstDrops.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstBoxs_KeyPress);
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.HorizontalScrollbar = true;
            this.lstItems.Location = new System.Drawing.Point(0, 0);
            this.lstItems.Name = "lstItems";
            this.lstItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstItems.Size = new System.Drawing.Size(238, 251);
            this.lstItems.TabIndex = 145;
            this.lstItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstBoxs_KeyPress);
            // 
            // lstQuests
            // 
            this.lstQuests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstQuests.FormattingEnabled = true;
            this.lstQuests.HorizontalScrollbar = true;
            this.lstQuests.Location = new System.Drawing.Point(0, 0);
            this.lstQuests.Name = "lstQuests";
            this.lstQuests.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstQuests.Size = new System.Drawing.Size(238, 251);
            this.lstQuests.TabIndex = 27;
            this.lstQuests.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstBoxs_KeyPress);
            // 
            // lstSkills
            // 
            this.lstSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSkills.FormattingEnabled = true;
            this.lstSkills.HorizontalScrollbar = true;
            this.lstSkills.Location = new System.Drawing.Point(0, 0);
            this.lstSkills.Name = "lstSkills";
            this.lstSkills.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSkills.Size = new System.Drawing.Size(238, 251);
            this.lstSkills.TabIndex = 28;
            this.lstSkills.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstBoxs_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCombat);
            this.tabControl1.Controls.Add(this.tabItem);
            this.tabControl1.Controls.Add(this.tabMap);
            this.tabControl1.Controls.Add(this.tabQuest);
            this.tabControl1.Controls.Add(this.tabMisc);
            this.tabControl1.Controls.Add(this.tabOptions);
            this.tabControl1.Controls.Add(this.tabOptions2);
            this.tabControl1.Controls.Add(this.tabBots);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 325);
            this.tabControl1.TabIndex = 146;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabCombat
            // 
            this.tabCombat.Controls.Add(this.pnlCombat);
            this.tabCombat.Location = new System.Drawing.Point(4, 22);
            this.tabCombat.Name = "tabCombat";
            this.tabCombat.Padding = new System.Windows.Forms.Padding(3);
            this.tabCombat.Size = new System.Drawing.Size(444, 299);
            this.tabCombat.TabIndex = 0;
            this.tabCombat.Text = "Combat";
            this.tabCombat.UseVisualStyleBackColor = true;
            // 
            // pnlCombat
            // 
            this.pnlCombat.Controls.Add(this.btnUseSkillSet);
            this.pnlCombat.Controls.Add(this.btnAddSkillSet);
            this.pnlCombat.Controls.Add(this.txtSkillSet);
            this.pnlCombat.Controls.Add(this.chkSafeMp);
            this.pnlCombat.Controls.Add(this.label17);
            this.pnlCombat.Controls.Add(this.label16);
            this.pnlCombat.Controls.Add(this.btnRest);
            this.pnlCombat.Controls.Add(this.btnRestF);
            this.pnlCombat.Controls.Add(this.chkSkillCD);
            this.pnlCombat.Controls.Add(this.label12);
            this.pnlCombat.Controls.Add(this.label11);
            this.pnlCombat.Controls.Add(this.label10);
            this.pnlCombat.Controls.Add(this.btnAttack);
            this.pnlCombat.Controls.Add(this.btnKill);
            this.pnlCombat.Controls.Add(this.label13);
            this.pnlCombat.Controls.Add(this.chkExistQuest);
            this.pnlCombat.Controls.Add(this.numRestMP);
            this.pnlCombat.Controls.Add(this.chkMP);
            this.pnlCombat.Controls.Add(this.numRest);
            this.pnlCombat.Controls.Add(this.chkHP);
            this.pnlCombat.Controls.Add(this.chkPacket);
            this.pnlCombat.Controls.Add(this.numSkillD);
            this.pnlCombat.Controls.Add(this.label2);
            this.pnlCombat.Controls.Add(this.numSafe);
            this.pnlCombat.Controls.Add(this.btnAddSafe);
            this.pnlCombat.Controls.Add(this.btnSkillCmd);
            this.pnlCombat.Controls.Add(this.btnAddSkill);
            this.pnlCombat.Controls.Add(this.numSkill);
            this.pnlCombat.Controls.Add(this.chkExitRest);
            this.pnlCombat.Controls.Add(this.chkAllSkillsCD);
            this.pnlCombat.Controls.Add(this.txtKillFQ);
            this.pnlCombat.Controls.Add(this.txtKillFItem);
            this.pnlCombat.Controls.Add(this.txtKillFMon);
            this.pnlCombat.Controls.Add(this.rbTemp);
            this.pnlCombat.Controls.Add(this.rbItems);
            this.pnlCombat.Controls.Add(this.btnKillF);
            this.pnlCombat.Controls.Add(this.txtMonster);
            this.pnlCombat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCombat.Location = new System.Drawing.Point(3, 3);
            this.pnlCombat.Name = "pnlCombat";
            this.pnlCombat.Size = new System.Drawing.Size(438, 293);
            this.pnlCombat.TabIndex = 103;
            // 
            // btnUseSkillSet
            // 
            this.btnUseSkillSet.Location = new System.Drawing.Point(220, 53);
            this.btnUseSkillSet.Name = "btnUseSkillSet";
            this.btnUseSkillSet.Size = new System.Drawing.Size(115, 22);
            this.btnUseSkillSet.TabIndex = 65;
            this.btnUseSkillSet.Text = "Use Skill Set";
            this.btnUseSkillSet.UseVisualStyleBackColor = true;
            this.btnUseSkillSet.Click += new System.EventHandler(this.btnUseSkillSet_Click);
            // 
            // btnAddSkillSet
            // 
            this.btnAddSkillSet.Location = new System.Drawing.Point(220, 29);
            this.btnAddSkillSet.Name = "btnAddSkillSet";
            this.btnAddSkillSet.Size = new System.Drawing.Size(115, 22);
            this.btnAddSkillSet.TabIndex = 64;
            this.btnAddSkillSet.Text = "Add Skill Set";
            this.btnAddSkillSet.UseVisualStyleBackColor = true;
            this.btnAddSkillSet.Click += new System.EventHandler(this.btnAddSkillSet_Click);
            // 
            // txtSkillSet
            // 
            this.txtSkillSet.Location = new System.Drawing.Point(220, 7);
            this.txtSkillSet.Name = "txtSkillSet";
            this.txtSkillSet.Size = new System.Drawing.Size(115, 20);
            this.txtSkillSet.TabIndex = 63;
            this.txtSkillSet.Text = "Skill Set Name";
            this.txtSkillSet.Click += new System.EventHandler(this.TextboxEnter);
            this.txtSkillSet.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtSkillSet.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // chkSafeMp
            // 
            this.chkSafeMp.AutoSize = true;
            this.chkSafeMp.Location = new System.Drawing.Point(170, 84);
            this.chkSafeMp.Name = "chkSafeMp";
            this.chkSafeMp.Size = new System.Drawing.Size(42, 17);
            this.chkSafeMp.TabIndex = 58;
            this.chkSafeMp.Text = "MP";
            this.chkSafeMp.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(137, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 62;
            this.label17.Text = "HP or";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(137, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 61;
            this.label16.Text = "is less than";
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(220, 101);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(44, 22);
            this.btnRest.TabIndex = 43;
            this.btnRest.Text = "Rest";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // btnRestF
            // 
            this.btnRestF.Location = new System.Drawing.Point(264, 101);
            this.btnRestF.Name = "btnRestF";
            this.btnRestF.Size = new System.Drawing.Size(71, 22);
            this.btnRestF.TabIndex = 44;
            this.btnRestF.Text = "Rest fully";
            this.btnRestF.UseVisualStyleBackColor = true;
            this.btnRestF.Click += new System.EventHandler(this.btnRestF_Click);
            // 
            // chkSkillCD
            // 
            this.chkSkillCD.AutoSize = true;
            this.chkSkillCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkSkillCD.Location = new System.Drawing.Point(172, 202);
            this.chkSkillCD.Name = "chkSkillCD";
            this.chkSkillCD.Size = new System.Drawing.Size(144, 17);
            this.chkSkillCD.TabIndex = 60;
            this.chkSkillCD.Text = "Wait for skill to cooldown";
            this.chkSkillCD.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(219, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "Rest if";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(320, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "%";
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(66, 29);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(62, 22);
            this.btnAttack.TabIndex = 54;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(4, 29);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(62, 22);
            this.btnKill.TabIndex = 54;
            this.btnKill.Text = "Kill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(134, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Skill delay";
            // 
            // chkExistQuest
            // 
            this.chkExistQuest.AutoSize = true;
            this.chkExistQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkExistQuest.Location = new System.Drawing.Point(172, 227);
            this.chkExistQuest.Name = "chkExistQuest";
            this.chkExistQuest.Size = new System.Drawing.Size(197, 17);
            this.chkExistQuest.TabIndex = 51;
            this.chkExistQuest.Text = "Exit combat before completing quest";
            this.chkExistQuest.UseVisualStyleBackColor = true;
            // 
            // numRestMP
            // 
            this.numRestMP.Location = new System.Drawing.Point(284, 154);
            this.numRestMP.Name = "numRestMP";
            this.numRestMP.Size = new System.Drawing.Size(34, 20);
            this.numRestMP.TabIndex = 50;
            this.numRestMP.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // chkMP
            // 
            this.chkMP.AutoSize = true;
            this.chkMP.Location = new System.Drawing.Point(222, 157);
            this.chkMP.Name = "chkMP";
            this.chkMP.Size = new System.Drawing.Size(57, 17);
            this.chkMP.TabIndex = 49;
            this.chkMP.Text = "MP <=";
            this.chkMP.UseVisualStyleBackColor = true;
            // 
            // numRest
            // 
            this.numRest.Location = new System.Drawing.Point(284, 135);
            this.numRest.Name = "numRest";
            this.numRest.Size = new System.Drawing.Size(34, 20);
            this.numRest.TabIndex = 48;
            this.numRest.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // chkHP
            // 
            this.chkHP.AutoSize = true;
            this.chkHP.Location = new System.Drawing.Point(222, 140);
            this.chkHP.Name = "chkHP";
            this.chkHP.Size = new System.Drawing.Size(56, 17);
            this.chkHP.TabIndex = 47;
            this.chkHP.Text = "HP <=";
            this.chkHP.UseVisualStyleBackColor = true;
            // 
            // chkPacket
            // 
            this.chkPacket.AutoSize = true;
            this.chkPacket.Location = new System.Drawing.Point(222, 80);
            this.chkPacket.Name = "chkPacket";
            this.chkPacket.Size = new System.Drawing.Size(109, 17);
            this.chkPacket.TabIndex = 47;
            this.chkPacket.Text = "Use Skill Packets";
            this.chkPacket.UseVisualStyleBackColor = true;
            this.chkPacket.CheckStateChanged += new System.EventHandler(this.chkPacket_CheckChanged);
            // 
            // numSkillD
            // 
            this.numSkillD.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSkillD.Location = new System.Drawing.Point(135, 153);
            this.numSkillD.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.numSkillD.Name = "numSkillD";
            this.numSkillD.Size = new System.Drawing.Size(81, 20);
            this.numSkillD.TabIndex = 45;
            this.numSkillD.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "%";
            // 
            // numSafe
            // 
            this.numSafe.Location = new System.Drawing.Point(135, 117);
            this.numSafe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSafe.Name = "numSafe";
            this.numSafe.Size = new System.Drawing.Size(44, 20);
            this.numSafe.TabIndex = 41;
            this.numSafe.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnAddSafe
            // 
            this.btnAddSafe.Location = new System.Drawing.Point(135, 54);
            this.btnAddSafe.Name = "btnAddSafe";
            this.btnAddSafe.Size = new System.Drawing.Size(81, 22);
            this.btnAddSafe.TabIndex = 39;
            this.btnAddSafe.Text = "Safe skill";
            this.btnAddSafe.UseVisualStyleBackColor = true;
            this.btnAddSafe.Click += new System.EventHandler(this.btnAddSafe_Click);
            // 
            // btnSkillCmd
            // 
            this.btnSkillCmd.Location = new System.Drawing.Point(135, 29);
            this.btnSkillCmd.Name = "btnSkillCmd";
            this.btnSkillCmd.Size = new System.Drawing.Size(81, 21);
            this.btnSkillCmd.TabIndex = 38;
            this.btnSkillCmd.Text = "Add (cmd)";
            this.btnSkillCmd.UseVisualStyleBackColor = true;
            this.btnSkillCmd.Click += new System.EventHandler(this.btnAddSkillCmd_Click);
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Location = new System.Drawing.Point(165, 4);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(51, 21);
            this.btnAddSkill.TabIndex = 38;
            this.btnAddSkill.Text = "Add skill";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.btnAddSkill_Click);
            // 
            // numSkill
            // 
            this.numSkill.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numSkill.Location = new System.Drawing.Point(135, 5);
            this.numSkill.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSkill.Name = "numSkill";
            this.numSkill.Size = new System.Drawing.Size(29, 20);
            this.numSkill.TabIndex = 37;
            this.numSkill.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkExitRest
            // 
            this.chkExitRest.AutoSize = true;
            this.chkExitRest.Checked = true;
            this.chkExitRest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExitRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkExitRest.Location = new System.Drawing.Point(4, 227);
            this.chkExitRest.Name = "chkExitRest";
            this.chkExitRest.Size = new System.Drawing.Size(148, 17);
            this.chkExitRest.TabIndex = 36;
            this.chkExitRest.Text = "Exit combat before resting";
            this.chkExitRest.UseVisualStyleBackColor = true;
            // 
            // chkAllSkillsCD
            // 
            this.chkAllSkillsCD.AutoSize = true;
            this.chkAllSkillsCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkAllSkillsCD.Location = new System.Drawing.Point(4, 195);
            this.chkAllSkillsCD.Name = "chkAllSkillsCD";
            this.chkAllSkillsCD.Size = new System.Drawing.Size(165, 30);
            this.chkAllSkillsCD.TabIndex = 35;
            this.chkAllSkillsCD.Text = "Wait for all skills to cool down\r\nbefore attacking";
            this.chkAllSkillsCD.UseVisualStyleBackColor = true;
            // 
            // txtKillFQ
            // 
            this.txtKillFQ.Location = new System.Drawing.Point(4, 153);
            this.txtKillFQ.Name = "txtKillFQ";
            this.txtKillFQ.Size = new System.Drawing.Size(124, 20);
            this.txtKillFQ.TabIndex = 34;
            this.txtKillFQ.Text = "Quantity (* = any)";
            this.txtKillFQ.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtKillFQ.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtKillFItem
            // 
            this.txtKillFItem.Location = new System.Drawing.Point(4, 129);
            this.txtKillFItem.Name = "txtKillFItem";
            this.txtKillFItem.Size = new System.Drawing.Size(124, 20);
            this.txtKillFItem.TabIndex = 33;
            this.txtKillFItem.Text = "Item name";
            this.txtKillFItem.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtKillFItem.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtKillFMon
            // 
            this.txtKillFMon.Location = new System.Drawing.Point(4, 105);
            this.txtKillFMon.Name = "txtKillFMon";
            this.txtKillFMon.Size = new System.Drawing.Size(124, 20);
            this.txtKillFMon.TabIndex = 32;
            this.txtKillFMon.Text = "Monster (* = random)";
            this.txtKillFMon.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtKillFMon.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // rbTemp
            // 
            this.rbTemp.AutoSize = true;
            this.rbTemp.Location = new System.Drawing.Point(52, 81);
            this.rbTemp.Name = "rbTemp";
            this.rbTemp.Size = new System.Drawing.Size(79, 17);
            this.rbTemp.TabIndex = 31;
            this.rbTemp.Text = "Temp items";
            this.rbTemp.UseVisualStyleBackColor = true;
            // 
            // rbItems
            // 
            this.rbItems.AutoSize = true;
            this.rbItems.Checked = true;
            this.rbItems.Location = new System.Drawing.Point(4, 81);
            this.rbItems.Name = "rbItems";
            this.rbItems.Size = new System.Drawing.Size(50, 17);
            this.rbItems.TabIndex = 30;
            this.rbItems.TabStop = true;
            this.rbItems.Text = "Items";
            this.rbItems.UseVisualStyleBackColor = true;
            // 
            // btnKillF
            // 
            this.btnKillF.Location = new System.Drawing.Point(4, 54);
            this.btnKillF.Name = "btnKillF";
            this.btnKillF.Size = new System.Drawing.Size(123, 22);
            this.btnKillF.TabIndex = 29;
            this.btnKillF.Text = "Kill for...";
            this.btnKillF.UseVisualStyleBackColor = true;
            this.btnKillF.Click += new System.EventHandler(this.btnKillF_Click);
            // 
            // txtMonster
            // 
            this.txtMonster.Location = new System.Drawing.Point(4, 4);
            this.txtMonster.Name = "txtMonster";
            this.txtMonster.Size = new System.Drawing.Size(124, 20);
            this.txtMonster.TabIndex = 27;
            this.txtMonster.Text = "Monster (*  = random)";
            this.txtMonster.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtMonster.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // tabItem
            // 
            this.tabItem.Controls.Add(this.pnlItem);
            this.tabItem.Location = new System.Drawing.Point(4, 22);
            this.tabItem.Name = "tabItem";
            this.tabItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabItem.Size = new System.Drawing.Size(444, 299);
            this.tabItem.TabIndex = 1;
            this.tabItem.Text = "Item";
            this.tabItem.UseVisualStyleBackColor = true;
            // 
            // pnlItem
            // 
            this.pnlItem.Controls.Add(this.label1);
            this.pnlItem.Controls.Add(this.numDropDelay);
            this.pnlItem.Controls.Add(this.chkRejectAll);
            this.pnlItem.Controls.Add(this.chkPickupAll);
            this.pnlItem.Controls.Add(this.chkBankOnStop);
            this.pnlItem.Controls.Add(this.txtShopItem);
            this.pnlItem.Controls.Add(this.numShopId);
            this.pnlItem.Controls.Add(this.label15);
            this.pnlItem.Controls.Add(this.btnBuy);
            this.pnlItem.Controls.Add(this.btnBuyFast);
            this.pnlItem.Controls.Add(this.btnLoadShop);
            this.pnlItem.Controls.Add(this.btnBoost);
            this.pnlItem.Controls.Add(this.cbBoosts);
            this.pnlItem.Controls.Add(this.numMapItem);
            this.pnlItem.Controls.Add(this.btnMapItem);
            this.pnlItem.Controls.Add(this.btnSwap);
            this.pnlItem.Controls.Add(this.txtSwapInv);
            this.pnlItem.Controls.Add(this.txtSwapBank);
            this.pnlItem.Controls.Add(this.chkReject);
            this.pnlItem.Controls.Add(this.chkPickup);
            this.pnlItem.Controls.Add(this.btnWhitelist);
            this.pnlItem.Controls.Add(this.btnBoth);
            this.pnlItem.Controls.Add(this.txtWhitelist);
            this.pnlItem.Controls.Add(this.btnItem);
            this.pnlItem.Controls.Add(this.btnUnbanklst);
            this.pnlItem.Controls.Add(this.txtItem);
            this.pnlItem.Controls.Add(this.cbItemCmds);
            this.pnlItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItem.Location = new System.Drawing.Point(3, 3);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(438, 293);
            this.pnlItem.TabIndex = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 152;
            this.label1.Text = "Drop Delay";
            // 
            // numDropDelay
            // 
            this.numDropDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDropDelay.Location = new System.Drawing.Point(147, 217);
            this.numDropDelay.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numDropDelay.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDropDelay.Name = "numDropDelay";
            this.numDropDelay.Size = new System.Drawing.Size(65, 20);
            this.numDropDelay.TabIndex = 151;
            this.numDropDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDropDelay.ValueChanged += new System.EventHandler(this.numDropDelay_ValueChanged);
            // 
            // chkRejectAll
            // 
            this.chkRejectAll.AutoSize = true;
            this.chkRejectAll.Enabled = false;
            this.chkRejectAll.Location = new System.Drawing.Point(296, 84);
            this.chkRejectAll.Name = "chkRejectAll";
            this.chkRejectAll.Size = new System.Drawing.Size(97, 17);
            this.chkRejectAll.TabIndex = 150;
            this.chkRejectAll.Text = "Reject all items";
            this.chkRejectAll.UseVisualStyleBackColor = true;
            this.chkRejectAll.Visible = false;
            // 
            // chkPickupAll
            // 
            this.chkPickupAll.AutoSize = true;
            this.chkPickupAll.Location = new System.Drawing.Point(296, 4);
            this.chkPickupAll.Name = "chkPickupAll";
            this.chkPickupAll.Size = new System.Drawing.Size(102, 17);
            this.chkPickupAll.TabIndex = 149;
            this.chkPickupAll.Text = "Pick up all items";
            this.chkPickupAll.UseVisualStyleBackColor = true;
            // 
            // chkBankOnStop
            // 
            this.chkBankOnStop.AutoSize = true;
            this.chkBankOnStop.Location = new System.Drawing.Point(296, 64);
            this.chkBankOnStop.Name = "chkBankOnStop";
            this.chkBankOnStop.Size = new System.Drawing.Size(94, 17);
            this.chkBankOnStop.TabIndex = 148;
            this.chkBankOnStop.Text = "Bank on Stop ";
            this.chkBankOnStop.UseVisualStyleBackColor = true;
            this.chkBankOnStop.CheckedChanged += new System.EventHandler(this.chkBankOnStop_CheckedChanged);
            // 
            // txtShopItem
            // 
            this.txtShopItem.Location = new System.Drawing.Point(5, 193);
            this.txtShopItem.Name = "txtShopItem";
            this.txtShopItem.Size = new System.Drawing.Size(137, 20);
            this.txtShopItem.TabIndex = 41;
            this.txtShopItem.Text = "Shop Item";
            this.txtShopItem.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtShopItem.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // numShopId
            // 
            this.numShopId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numShopId.Location = new System.Drawing.Point(5, 169);
            this.numShopId.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numShopId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShopId.Name = "numShopId";
            this.numShopId.Size = new System.Drawing.Size(65, 20);
            this.numShopId.TabIndex = 40;
            this.numShopId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 156);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Shop ID";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(4, 215);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(68, 22);
            this.btnBuy.TabIndex = 38;
            this.btnBuy.Text = "Buy item";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnBuyFast
            // 
            this.btnBuyFast.Location = new System.Drawing.Point(74, 215);
            this.btnBuyFast.Name = "btnBuyFast";
            this.btnBuyFast.Size = new System.Drawing.Size(69, 22);
            this.btnBuyFast.TabIndex = 133;
            this.btnBuyFast.Text = "Buy fast";
            this.btnBuyFast.UseVisualStyleBackColor = true;
            this.btnBuyFast.Click += new System.EventHandler(this.btnBuyFast_Click);
            // 
            // btnLoadShop
            // 
            this.btnLoadShop.Location = new System.Drawing.Point(76, 168);
            this.btnLoadShop.Name = "btnLoadShop";
            this.btnLoadShop.Size = new System.Drawing.Size(66, 22);
            this.btnLoadShop.TabIndex = 134;
            this.btnLoadShop.Text = "Load Shop";
            this.btnLoadShop.UseVisualStyleBackColor = true;
            this.btnLoadShop.Click += new System.EventHandler(this.btnLoadShop_Click);
            // 
            // btnBoost
            // 
            this.btnBoost.Location = new System.Drawing.Point(146, 128);
            this.btnBoost.Name = "btnBoost";
            this.btnBoost.Size = new System.Drawing.Size(134, 22);
            this.btnBoost.TabIndex = 37;
            this.btnBoost.Text = "Add boost";
            this.btnBoost.UseVisualStyleBackColor = true;
            this.btnBoost.Click += new System.EventHandler(this.btnBoost_Click);
            // 
            // cbBoosts
            // 
            this.cbBoosts.FormattingEnabled = true;
            this.cbBoosts.Location = new System.Drawing.Point(147, 104);
            this.cbBoosts.Name = "cbBoosts";
            this.cbBoosts.Size = new System.Drawing.Size(132, 21);
            this.cbBoosts.TabIndex = 36;
            this.cbBoosts.Click += new System.EventHandler(this.cbBoosts_Click);
            // 
            // numMapItem
            // 
            this.numMapItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numMapItem.Location = new System.Drawing.Point(148, 170);
            this.numMapItem.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMapItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMapItem.Name = "numMapItem";
            this.numMapItem.Size = new System.Drawing.Size(132, 20);
            this.numMapItem.TabIndex = 30;
            this.numMapItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnMapItem
            // 
            this.btnMapItem.Location = new System.Drawing.Point(147, 193);
            this.btnMapItem.Name = "btnMapItem";
            this.btnMapItem.Size = new System.Drawing.Size(134, 22);
            this.btnMapItem.TabIndex = 29;
            this.btnMapItem.Text = "Get map item";
            this.btnMapItem.UseVisualStyleBackColor = true;
            this.btnMapItem.Click += new System.EventHandler(this.btnMapItem_Click);
            // 
            // btnSwap
            // 
            this.btnSwap.Location = new System.Drawing.Point(3, 129);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(141, 22);
            this.btnSwap.TabIndex = 28;
            this.btnSwap.Text = "Bank swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // txtSwapInv
            // 
            this.txtSwapInv.Location = new System.Drawing.Point(4, 105);
            this.txtSwapInv.Name = "txtSwapInv";
            this.txtSwapInv.Size = new System.Drawing.Size(139, 20);
            this.txtSwapInv.TabIndex = 27;
            this.txtSwapInv.Text = "Inventory item name";
            // 
            // txtSwapBank
            // 
            this.txtSwapBank.Location = new System.Drawing.Point(4, 80);
            this.txtSwapBank.Name = "txtSwapBank";
            this.txtSwapBank.Size = new System.Drawing.Size(139, 20);
            this.txtSwapBank.TabIndex = 26;
            this.txtSwapBank.Text = "Bank item name";
            // 
            // chkReject
            // 
            this.chkReject.AutoSize = true;
            this.chkReject.Location = new System.Drawing.Point(296, 44);
            this.chkReject.Name = "chkReject";
            this.chkReject.Size = new System.Drawing.Size(130, 17);
            this.chkReject.TabIndex = 25;
            this.chkReject.Text = "Reject non-whitelisted";
            this.chkReject.UseVisualStyleBackColor = true;
            // 
            // chkPickup
            // 
            this.chkPickup.AutoSize = true;
            this.chkPickup.Checked = true;
            this.chkPickup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPickup.Location = new System.Drawing.Point(296, 24);
            this.chkPickup.Name = "chkPickup";
            this.chkPickup.Size = new System.Drawing.Size(114, 17);
            this.chkPickup.TabIndex = 24;
            this.chkPickup.Text = "Pick up whitelisted";
            this.chkPickup.UseVisualStyleBackColor = true;
            // 
            // btnWhitelist
            // 
            this.btnWhitelist.Location = new System.Drawing.Point(146, 54);
            this.btnWhitelist.Name = "btnWhitelist";
            this.btnWhitelist.Size = new System.Drawing.Size(132, 22);
            this.btnWhitelist.TabIndex = 23;
            this.btnWhitelist.Text = "Add to whitelist";
            this.btnWhitelist.UseVisualStyleBackColor = true;
            this.btnWhitelist.Click += new System.EventHandler(this.btnWhitelist_Click);
            // 
            // btnBoth
            // 
            this.btnBoth.Location = new System.Drawing.Point(146, 29);
            this.btnBoth.Name = "btnBoth";
            this.btnBoth.Size = new System.Drawing.Size(132, 22);
            this.btnBoth.TabIndex = 23;
            this.btnBoth.Text = "Add to both";
            this.btnBoth.UseVisualStyleBackColor = true;
            this.btnBoth.Click += new System.EventHandler(this.btnBoth_Click);
            // 
            // txtWhitelist
            // 
            this.txtWhitelist.Location = new System.Drawing.Point(148, 4);
            this.txtWhitelist.Name = "txtWhitelist";
            this.txtWhitelist.Size = new System.Drawing.Size(132, 20);
            this.txtWhitelist.TabIndex = 22;
            this.txtWhitelist.Text = "Item name";
            this.txtWhitelist.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtWhitelist.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnItem
            // 
            this.btnItem.Location = new System.Drawing.Point(3, 54);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(141, 22);
            this.btnItem.TabIndex = 21;
            this.btnItem.Text = "Add command";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // btnUnbanklst
            // 
            this.btnUnbanklst.Location = new System.Drawing.Point(146, 79);
            this.btnUnbanklst.Name = "btnUnbanklst";
            this.btnUnbanklst.Size = new System.Drawing.Size(132, 22);
            this.btnUnbanklst.TabIndex = 147;
            this.btnUnbanklst.Text = "Unbank";
            this.btnUnbanklst.UseVisualStyleBackColor = true;
            this.btnUnbanklst.Click += new System.EventHandler(this.btnUnbanklst_Click);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(4, 29);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(139, 20);
            this.txtItem.TabIndex = 20;
            this.txtItem.Text = "Item name";
            this.txtItem.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtItem.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // cbItemCmds
            // 
            this.cbItemCmds.FormattingEnabled = true;
            this.cbItemCmds.Items.AddRange(new object[] {
            "Get drop",
            "Sell",
            "Equip",
            "To bank from inv",
            "To inv from bank",
            "Equip Set"});
            this.cbItemCmds.Location = new System.Drawing.Point(4, 4);
            this.cbItemCmds.Name = "cbItemCmds";
            this.cbItemCmds.Size = new System.Drawing.Size(139, 21);
            this.cbItemCmds.TabIndex = 19;
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.pnlMap);
            this.tabMap.Location = new System.Drawing.Point(4, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabMap.Size = new System.Drawing.Size(444, 299);
            this.tabMap.TabIndex = 2;
            this.tabMap.Text = "Map";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // pnlMap
            // 
            this.pnlMap.Controls.Add(this.btnCurrBlank);
            this.pnlMap.Controls.Add(this.btnSetSpawn);
            this.pnlMap.Controls.Add(this.btnWalkRdm);
            this.pnlMap.Controls.Add(this.btnYulgar);
            this.pnlMap.Controls.Add(this.btnWalkCur);
            this.pnlMap.Controls.Add(this.btnWalk);
            this.pnlMap.Controls.Add(this.numWalkY);
            this.pnlMap.Controls.Add(this.numWalkX);
            this.pnlMap.Controls.Add(this.button2);
            this.pnlMap.Controls.Add(this.btnCellSwap);
            this.pnlMap.Controls.Add(this.btnJump);
            this.pnlMap.Controls.Add(this.btnCurrCell);
            this.pnlMap.Controls.Add(this.txtPad);
            this.pnlMap.Controls.Add(this.txtCell);
            this.pnlMap.Controls.Add(this.btnJoin);
            this.pnlMap.Controls.Add(this.txtJoinPad);
            this.pnlMap.Controls.Add(this.txtJoinCell);
            this.pnlMap.Controls.Add(this.txtJoin);
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(3, 3);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(438, 293);
            this.pnlMap.TabIndex = 104;
            // 
            // btnCurrBlank
            // 
            this.btnCurrBlank.Location = new System.Drawing.Point(128, 29);
            this.btnCurrBlank.Name = "btnCurrBlank";
            this.btnCurrBlank.Size = new System.Drawing.Size(56, 23);
            this.btnCurrBlank.TabIndex = 143;
            this.btnCurrBlank.Text = "Blank";
            this.btnCurrBlank.UseVisualStyleBackColor = true;
            this.btnCurrBlank.Click += new System.EventHandler(this.btnCurrBlank_Click);
            // 
            // btnSetSpawn
            // 
            this.btnSetSpawn.Location = new System.Drawing.Point(3, 200);
            this.btnSetSpawn.MaximumSize = new System.Drawing.Size(114, 22);
            this.btnSetSpawn.MinimumSize = new System.Drawing.Size(114, 22);
            this.btnSetSpawn.Name = "btnSetSpawn";
            this.btnSetSpawn.Size = new System.Drawing.Size(114, 22);
            this.btnSetSpawn.TabIndex = 142;
            this.btnSetSpawn.Text = "Set Spawnpoint";
            this.btnSetSpawn.UseVisualStyleBackColor = true;
            this.btnSetSpawn.Click += new System.EventHandler(this.btnSetSpawn_Click);
            // 
            // btnWalkRdm
            // 
            this.btnWalkRdm.Location = new System.Drawing.Point(4, 172);
            this.btnWalkRdm.MaximumSize = new System.Drawing.Size(114, 22);
            this.btnWalkRdm.MinimumSize = new System.Drawing.Size(114, 22);
            this.btnWalkRdm.Name = "btnWalkRdm";
            this.btnWalkRdm.Size = new System.Drawing.Size(114, 22);
            this.btnWalkRdm.TabIndex = 142;
            this.btnWalkRdm.Text = "Walk Randomly";
            this.btnWalkRdm.UseVisualStyleBackColor = true;
            this.btnWalkRdm.Click += new System.EventHandler(this.btnWalkRdm_Click);
            // 
            // btnYulgar
            // 
            this.btnYulgar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYulgar.FlatAppearance.BorderSize = 0;
            this.btnYulgar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYulgar.ForeColor = System.Drawing.Color.Transparent;
            this.btnYulgar.Location = new System.Drawing.Point(192, 82);
            this.btnYulgar.Name = "btnYulgar";
            this.btnYulgar.Size = new System.Drawing.Size(111, 28);
            this.btnYulgar.TabIndex = 141;
            this.btnYulgar.Text = "Yulgar?";
            this.btnYulgar.UseVisualStyleBackColor = true;
            this.btnYulgar.Click += new System.EventHandler(this.btnYulgar_Click);
            // 
            // btnWalkCur
            // 
            this.btnWalkCur.Location = new System.Drawing.Point(3, 144);
            this.btnWalkCur.MaximumSize = new System.Drawing.Size(114, 22);
            this.btnWalkCur.MinimumSize = new System.Drawing.Size(114, 22);
            this.btnWalkCur.Name = "btnWalkCur";
            this.btnWalkCur.Size = new System.Drawing.Size(114, 22);
            this.btnWalkCur.TabIndex = 38;
            this.btnWalkCur.Text = "Current position";
            this.btnWalkCur.UseVisualStyleBackColor = true;
            this.btnWalkCur.Click += new System.EventHandler(this.btnWalkCur_Click);
            // 
            // btnWalk
            // 
            this.btnWalk.Location = new System.Drawing.Point(3, 116);
            this.btnWalk.Name = "btnWalk";
            this.btnWalk.Size = new System.Drawing.Size(115, 22);
            this.btnWalk.TabIndex = 37;
            this.btnWalk.Text = "Walk to";
            this.btnWalk.UseVisualStyleBackColor = true;
            this.btnWalk.Click += new System.EventHandler(this.btnWalk_Click);
            // 
            // numWalkY
            // 
            this.numWalkY.Location = new System.Drawing.Point(65, 90);
            this.numWalkY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numWalkY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWalkY.Name = "numWalkY";
            this.numWalkY.Size = new System.Drawing.Size(52, 20);
            this.numWalkY.TabIndex = 36;
            this.numWalkY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numWalkX
            // 
            this.numWalkX.Location = new System.Drawing.Point(6, 90);
            this.numWalkX.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numWalkX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWalkX.Name = "numWalkX";
            this.numWalkX.Size = new System.Drawing.Size(54, 20);
            this.numWalkX.TabIndex = 35;
            this.numWalkX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 22);
            this.button2.TabIndex = 34;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCellSwap_Click);
            // 
            // btnCellSwap
            // 
            this.btnCellSwap.Location = new System.Drawing.Point(144, 53);
            this.btnCellSwap.Name = "btnCellSwap";
            this.btnCellSwap.Size = new System.Drawing.Size(21, 22);
            this.btnCellSwap.TabIndex = 34;
            this.btnCellSwap.Text = "<";
            this.btnCellSwap.UseVisualStyleBackColor = true;
            this.btnCellSwap.Click += new System.EventHandler(this.btnCellSwap_Click);
            // 
            // btnJump
            // 
            this.btnJump.AutoSize = true;
            this.btnJump.Location = new System.Drawing.Point(192, 53);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(111, 23);
            this.btnJump.TabIndex = 33;
            this.btnJump.Text = "Jump";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnCurrCell
            // 
            this.btnCurrCell.AutoSize = true;
            this.btnCurrCell.Location = new System.Drawing.Point(192, 29);
            this.btnCurrCell.Name = "btnCurrCell";
            this.btnCurrCell.Size = new System.Drawing.Size(111, 23);
            this.btnCurrCell.TabIndex = 32;
            this.btnCurrCell.Text = "Get current cell";
            this.btnCurrCell.UseVisualStyleBackColor = true;
            this.btnCurrCell.Click += new System.EventHandler(this.btnCurrCell_Click);
            // 
            // txtPad
            // 
            this.txtPad.Location = new System.Drawing.Point(250, 4);
            this.txtPad.Name = "txtPad";
            this.txtPad.Size = new System.Drawing.Size(54, 20);
            this.txtPad.TabIndex = 31;
            this.txtPad.Text = "Pad";
            this.txtPad.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtPad.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtCell
            // 
            this.txtCell.Location = new System.Drawing.Point(192, 4);
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(54, 20);
            this.txtCell.TabIndex = 30;
            this.txtCell.Text = "Cell";
            this.txtCell.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtCell.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(6, 53);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(111, 22);
            this.btnJoin.TabIndex = 29;
            this.btnJoin.Text = "Join map";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // txtJoinPad
            // 
            this.txtJoinPad.Location = new System.Drawing.Point(64, 29);
            this.txtJoinPad.Name = "txtJoinPad";
            this.txtJoinPad.Size = new System.Drawing.Size(54, 20);
            this.txtJoinPad.TabIndex = 28;
            this.txtJoinPad.Text = "Spawn";
            // 
            // txtJoinCell
            // 
            this.txtJoinCell.Location = new System.Drawing.Point(6, 29);
            this.txtJoinCell.Name = "txtJoinCell";
            this.txtJoinCell.Size = new System.Drawing.Size(54, 20);
            this.txtJoinCell.TabIndex = 27;
            this.txtJoinCell.Text = "Enter";
            // 
            // txtJoin
            // 
            this.txtJoin.Location = new System.Drawing.Point(6, 4);
            this.txtJoin.Name = "txtJoin";
            this.txtJoin.Size = new System.Drawing.Size(112, 20);
            this.txtJoin.TabIndex = 26;
            this.txtJoin.Text = "battleon-1e99";
            // 
            // tabQuest
            // 
            this.tabQuest.Controls.Add(this.pnlQuest);
            this.tabQuest.Location = new System.Drawing.Point(4, 22);
            this.tabQuest.Name = "tabQuest";
            this.tabQuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuest.Size = new System.Drawing.Size(444, 299);
            this.tabQuest.TabIndex = 3;
            this.tabQuest.Text = "Quest";
            this.tabQuest.UseVisualStyleBackColor = true;
            // 
            // pnlQuest
            // 
            this.pnlQuest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlQuest.Controls.Add(this.label14);
            this.pnlQuest.Controls.Add(this.numEnsureTries);
            this.pnlQuest.Controls.Add(this.chkEnsureComplete);
            this.pnlQuest.Controls.Add(this.btnQuestAccept);
            this.pnlQuest.Controls.Add(this.btnQuestComplete);
            this.pnlQuest.Controls.Add(this.btnQuestAdd);
            this.pnlQuest.Controls.Add(this.numQuestItem);
            this.pnlQuest.Controls.Add(this.chkQuestItem);
            this.pnlQuest.Controls.Add(this.numQuestID);
            this.pnlQuest.Controls.Add(this.label4);
            this.pnlQuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuest.Location = new System.Drawing.Point(3, 3);
            this.pnlQuest.Name = "pnlQuest";
            this.pnlQuest.Size = new System.Drawing.Size(438, 293);
            this.pnlQuest.TabIndex = 106;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(189, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Tries";
            this.label14.Visible = false;
            // 
            // numEnsureTries
            // 
            this.numEnsureTries.Enabled = false;
            this.numEnsureTries.Location = new System.Drawing.Point(143, 92);
            this.numEnsureTries.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEnsureTries.Name = "numEnsureTries";
            this.numEnsureTries.Size = new System.Drawing.Size(42, 20);
            this.numEnsureTries.TabIndex = 15;
            this.numEnsureTries.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numEnsureTries.Visible = false;
            // 
            // chkEnsureComplete
            // 
            this.chkEnsureComplete.AutoSize = true;
            this.chkEnsureComplete.Location = new System.Drawing.Point(143, 75);
            this.chkEnsureComplete.Name = "chkEnsureComplete";
            this.chkEnsureComplete.Size = new System.Drawing.Size(59, 17);
            this.chkEnsureComplete.TabIndex = 14;
            this.chkEnsureComplete.Text = "Ensure";
            this.chkEnsureComplete.UseVisualStyleBackColor = true;
            this.chkEnsureComplete.Visible = false;
            this.chkEnsureComplete.CheckedChanged += new System.EventHandler(this.chkEnsureComplete_CheckedChanged);
            // 
            // btnQuestAccept
            // 
            this.btnQuestAccept.Location = new System.Drawing.Point(8, 99);
            this.btnQuestAccept.Name = "btnQuestAccept";
            this.btnQuestAccept.Size = new System.Drawing.Size(129, 22);
            this.btnQuestAccept.TabIndex = 13;
            this.btnQuestAccept.Text = "Accept command";
            this.btnQuestAccept.UseVisualStyleBackColor = true;
            this.btnQuestAccept.Click += new System.EventHandler(this.btnQuestAccept_Click);
            // 
            // btnQuestComplete
            // 
            this.btnQuestComplete.Location = new System.Drawing.Point(8, 72);
            this.btnQuestComplete.Name = "btnQuestComplete";
            this.btnQuestComplete.Size = new System.Drawing.Size(129, 22);
            this.btnQuestComplete.TabIndex = 12;
            this.btnQuestComplete.Text = "Complete command";
            this.btnQuestComplete.UseVisualStyleBackColor = true;
            this.btnQuestComplete.Click += new System.EventHandler(this.btnQuestComplete_Click);
            // 
            // btnQuestAdd
            // 
            this.btnQuestAdd.Location = new System.Drawing.Point(8, 45);
            this.btnQuestAdd.Name = "btnQuestAdd";
            this.btnQuestAdd.Size = new System.Drawing.Size(129, 22);
            this.btnQuestAdd.TabIndex = 11;
            this.btnQuestAdd.Text = "Add to quest list";
            this.btnQuestAdd.UseVisualStyleBackColor = true;
            this.btnQuestAdd.Click += new System.EventHandler(this.btnQuestAdd_Click);
            // 
            // numQuestItem
            // 
            this.numQuestItem.Enabled = false;
            this.numQuestItem.Location = new System.Drawing.Point(143, 21);
            this.numQuestItem.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQuestItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuestItem.Name = "numQuestItem";
            this.numQuestItem.Size = new System.Drawing.Size(76, 20);
            this.numQuestItem.TabIndex = 10;
            this.numQuestItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkQuestItem
            // 
            this.chkQuestItem.AutoSize = true;
            this.chkQuestItem.Location = new System.Drawing.Point(143, 5);
            this.chkQuestItem.Name = "chkQuestItem";
            this.chkQuestItem.Size = new System.Drawing.Size(60, 17);
            this.chkQuestItem.TabIndex = 9;
            this.chkQuestItem.Text = "Item ID";
            this.chkQuestItem.UseVisualStyleBackColor = true;
            this.chkQuestItem.CheckedChanged += new System.EventHandler(this.chkQuestItem_CheckedChanged);
            // 
            // numQuestID
            // 
            this.numQuestID.Location = new System.Drawing.Point(8, 21);
            this.numQuestID.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQuestID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuestID.Name = "numQuestID";
            this.numQuestID.Size = new System.Drawing.Size(129, 20);
            this.numQuestID.TabIndex = 8;
            this.numQuestID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quest ID";
            // 
            // tabMisc
            // 
            this.tabMisc.Controls.Add(this.pnlMisc);
            this.tabMisc.Location = new System.Drawing.Point(4, 22);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tabMisc.Size = new System.Drawing.Size(444, 299);
            this.tabMisc.TabIndex = 4;
            this.tabMisc.Text = "Misc";
            this.tabMisc.UseVisualStyleBackColor = true;
            // 
            // pnlMisc
            // 
            this.pnlMisc.Controls.Add(this.label19);
            this.pnlMisc.Controls.Add(this.btnDecreaseInt);
            this.pnlMisc.Controls.Add(this.btnIncreaseInt);
            this.pnlMisc.Controls.Add(this.numSetInt);
            this.pnlMisc.Controls.Add(this.txtSetInt);
            this.pnlMisc.Controls.Add(this.btnSetInt);
            this.pnlMisc.Controls.Add(this.label18);
            this.pnlMisc.Controls.Add(this.btnGoDownIndex);
            this.pnlMisc.Controls.Add(this.btnGoUpIndex);
            this.pnlMisc.Controls.Add(this.btnGotoIndex);
            this.pnlMisc.Controls.Add(this.numIndexCmd);
            this.pnlMisc.Controls.Add(this.btnBlank);
            this.pnlMisc.Controls.Add(this.btnProvokeOff);
            this.pnlMisc.Controls.Add(this.btnProvokeOn);
            this.pnlMisc.Controls.Add(this.btnProvoke);
            this.pnlMisc.Controls.Add(this.labelProvoke);
            this.pnlMisc.Controls.Add(this.chkRestartDeath);
            this.pnlMisc.Controls.Add(this.chkMerge);
            this.pnlMisc.Controls.Add(this.btnLogout);
            this.pnlMisc.Controls.Add(this.txtLabel);
            this.pnlMisc.Controls.Add(this.btnGotoLabel);
            this.pnlMisc.Controls.Add(this.btnAddLabel);
            this.pnlMisc.Controls.Add(this.txtDescription);
            this.pnlMisc.Controls.Add(this.txtAuthor);
            this.pnlMisc.Controls.Add(this.btnSave);
            this.pnlMisc.Controls.Add(this.btnBeep);
            this.pnlMisc.Controls.Add(this.numBeepTimes);
            this.pnlMisc.Controls.Add(this.btnDelay);
            this.pnlMisc.Controls.Add(this.numDelay);
            this.pnlMisc.Controls.Add(this.label3);
            this.pnlMisc.Controls.Add(this.numBotDelay);
            this.pnlMisc.Controls.Add(this.btnBotDelay);
            this.pnlMisc.Controls.Add(this.txtPlayer);
            this.pnlMisc.Controls.Add(this.btnGoto);
            this.pnlMisc.Controls.Add(this.btnLoad);
            this.pnlMisc.Controls.Add(this.btnRestart);
            this.pnlMisc.Controls.Add(this.btnStop);
            this.pnlMisc.Controls.Add(this.btnLoadCmd);
            this.pnlMisc.Controls.Add(this.chkSkip);
            this.pnlMisc.Controls.Add(this.btnStatementAdd);
            this.pnlMisc.Controls.Add(this.txtStatement2);
            this.pnlMisc.Controls.Add(this.txtStatement1);
            this.pnlMisc.Controls.Add(this.cbStatement);
            this.pnlMisc.Controls.Add(this.cbCategories);
            this.pnlMisc.Controls.Add(this.txtPacket);
            this.pnlMisc.Controls.Add(this.btnClientPacket);
            this.pnlMisc.Controls.Add(this.btnPacket);
            this.pnlMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMisc.Location = new System.Drawing.Point(3, 3);
            this.pnlMisc.Name = "pnlMisc";
            this.pnlMisc.Size = new System.Drawing.Size(438, 293);
            this.pnlMisc.TabIndex = 107;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(42, 221);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 13);
            this.label19.TabIndex = 159;
            this.label19.Text = "Temporary Integers";
            // 
            // btnDecreaseInt
            // 
            this.btnDecreaseInt.Location = new System.Drawing.Point(94, 262);
            this.btnDecreaseInt.Name = "btnDecreaseInt";
            this.btnDecreaseInt.Size = new System.Drawing.Size(78, 23);
            this.btnDecreaseInt.TabIndex = 158;
            this.btnDecreaseInt.Text = "Decrease";
            this.btnDecreaseInt.UseVisualStyleBackColor = true;
            this.btnDecreaseInt.Click += new System.EventHandler(this.btnDecreaseInt_Click);
            // 
            // btnIncreaseInt
            // 
            this.btnIncreaseInt.Location = new System.Drawing.Point(7, 262);
            this.btnIncreaseInt.Name = "btnIncreaseInt";
            this.btnIncreaseInt.Size = new System.Drawing.Size(81, 23);
            this.btnIncreaseInt.TabIndex = 158;
            this.btnIncreaseInt.Text = "Increase";
            this.btnIncreaseInt.UseVisualStyleBackColor = true;
            this.btnIncreaseInt.Click += new System.EventHandler(this.btnIncreaseInt_Click);
            // 
            // numSetInt
            // 
            this.numSetInt.Location = new System.Drawing.Point(70, 240);
            this.numSetInt.Name = "numSetInt";
            this.numSetInt.Size = new System.Drawing.Size(30, 20);
            this.numSetInt.TabIndex = 157;
            // 
            // txtSetInt
            // 
            this.txtSetInt.Location = new System.Drawing.Point(7, 240);
            this.txtSetInt.Name = "txtSetInt";
            this.txtSetInt.Size = new System.Drawing.Size(57, 20);
            this.txtSetInt.TabIndex = 156;
            // 
            // btnSetInt
            // 
            this.btnSetInt.Location = new System.Drawing.Point(104, 238);
            this.btnSetInt.Name = "btnSetInt";
            this.btnSetInt.Size = new System.Drawing.Size(68, 23);
            this.btnSetInt.TabIndex = 155;
            this.btnSetInt.Text = "Set";
            this.btnSetInt.UseVisualStyleBackColor = true;
            this.btnSetInt.Click += new System.EventHandler(this.btnSetInt_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(352, 201);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 154;
            this.label18.Text = "Index";
            // 
            // btnGoDownIndex
            // 
            this.btnGoDownIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoDownIndex.Location = new System.Drawing.Point(371, 239);
            this.btnGoDownIndex.Name = "btnGoDownIndex";
            this.btnGoDownIndex.Size = new System.Drawing.Size(57, 23);
            this.btnGoDownIndex.TabIndex = 153;
            this.btnGoDownIndex.Text = "Down--";
            this.btnGoDownIndex.UseVisualStyleBackColor = true;
            this.btnGoDownIndex.Click += new System.EventHandler(this.btnGotoIndex_Click);
            // 
            // btnGoUpIndex
            // 
            this.btnGoUpIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoUpIndex.Location = new System.Drawing.Point(311, 239);
            this.btnGoUpIndex.Name = "btnGoUpIndex";
            this.btnGoUpIndex.Size = new System.Drawing.Size(57, 23);
            this.btnGoUpIndex.TabIndex = 153;
            this.btnGoUpIndex.Text = "Up++";
            this.btnGoUpIndex.UseVisualStyleBackColor = true;
            this.btnGoUpIndex.Click += new System.EventHandler(this.btnGotoIndex_Click);
            // 
            // btnGotoIndex
            // 
            this.btnGotoIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGotoIndex.Location = new System.Drawing.Point(371, 216);
            this.btnGotoIndex.Name = "btnGotoIndex";
            this.btnGotoIndex.Size = new System.Drawing.Size(57, 23);
            this.btnGotoIndex.TabIndex = 153;
            this.btnGotoIndex.Text = "Goto Index";
            this.btnGotoIndex.UseVisualStyleBackColor = true;
            this.btnGotoIndex.Click += new System.EventHandler(this.btnGotoIndex_Click);
            // 
            // numIndexCmd
            // 
            this.numIndexCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numIndexCmd.Location = new System.Drawing.Point(311, 217);
            this.numIndexCmd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numIndexCmd.Name = "numIndexCmd";
            this.numIndexCmd.Size = new System.Drawing.Size(57, 20);
            this.numIndexCmd.TabIndex = 152;
            // 
            // btnBlank
            // 
            this.btnBlank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlank.Location = new System.Drawing.Point(177, 153);
            this.btnBlank.Name = "btnBlank";
            this.btnBlank.Size = new System.Drawing.Size(128, 22);
            this.btnBlank.TabIndex = 151;
            this.btnBlank.Text = "Blank Command";
            this.btnBlank.UseVisualStyleBackColor = true;
            this.btnBlank.Click += new System.EventHandler(this.btnBlank_Click);
            // 
            // btnProvokeOff
            // 
            this.btnProvokeOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProvokeOff.AutoSize = true;
            this.btnProvokeOff.Location = new System.Drawing.Point(240, 239);
            this.btnProvokeOff.Name = "btnProvokeOff";
            this.btnProvokeOff.Size = new System.Drawing.Size(64, 23);
            this.btnProvokeOff.TabIndex = 150;
            this.btnProvokeOff.Text = "Off";
            this.btnProvokeOff.UseVisualStyleBackColor = true;
            this.btnProvokeOff.Click += new System.EventHandler(this.btnProvokeOff_Click);
            // 
            // btnProvokeOn
            // 
            this.btnProvokeOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProvokeOn.AutoSize = true;
            this.btnProvokeOn.Location = new System.Drawing.Point(177, 239);
            this.btnProvokeOn.Name = "btnProvokeOn";
            this.btnProvokeOn.Size = new System.Drawing.Size(64, 23);
            this.btnProvokeOn.TabIndex = 149;
            this.btnProvokeOn.Text = "On";
            this.btnProvokeOn.UseVisualStyleBackColor = true;
            this.btnProvokeOn.Click += new System.EventHandler(this.btnProvokeOn_Click);
            // 
            // btnProvoke
            // 
            this.btnProvoke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProvoke.AutoSize = true;
            this.btnProvoke.Location = new System.Drawing.Point(177, 216);
            this.btnProvoke.Name = "btnProvoke";
            this.btnProvoke.Size = new System.Drawing.Size(127, 23);
            this.btnProvoke.TabIndex = 148;
            this.btnProvoke.Text = "Toggle";
            this.btnProvoke.UseVisualStyleBackColor = true;
            this.btnProvoke.Click += new System.EventHandler(this.btnProvoke_Click);
            // 
            // labelProvoke
            // 
            this.labelProvoke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProvoke.Location = new System.Drawing.Point(182, 202);
            this.labelProvoke.Name = "labelProvoke";
            this.labelProvoke.Size = new System.Drawing.Size(115, 13);
            this.labelProvoke.TabIndex = 147;
            this.labelProvoke.Text = "Provoke";
            this.labelProvoke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkRestartDeath
            // 
            this.chkRestartDeath.AutoSize = true;
            this.chkRestartDeath.Checked = true;
            this.chkRestartDeath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRestartDeath.Location = new System.Drawing.Point(7, 198);
            this.chkRestartDeath.Name = "chkRestartDeath";
            this.chkRestartDeath.Size = new System.Drawing.Size(133, 17);
            this.chkRestartDeath.TabIndex = 116;
            this.chkRestartDeath.Text = "Restart bot upon dying";
            this.chkRestartDeath.UseVisualStyleBackColor = true;
            // 
            // chkMerge
            // 
            this.chkMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMerge.AutoSize = true;
            this.chkMerge.Location = new System.Drawing.Point(376, 57);
            this.chkMerge.Name = "chkMerge";
            this.chkMerge.Size = new System.Drawing.Size(56, 17);
            this.chkMerge.TabIndex = 115;
            this.chkMerge.Text = "Merge";
            this.chkMerge.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(311, 54);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(58, 22);
            this.btnLogout.TabIndex = 114;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtLabel
            // 
            this.txtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLabel.Location = new System.Drawing.Point(311, 153);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(117, 20);
            this.txtLabel.TabIndex = 113;
            this.txtLabel.Text = "Label name";
            // 
            // btnGotoLabel
            // 
            this.btnGotoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGotoLabel.Location = new System.Drawing.Point(310, 175);
            this.btnGotoLabel.Name = "btnGotoLabel";
            this.btnGotoLabel.Size = new System.Drawing.Size(58, 22);
            this.btnGotoLabel.TabIndex = 112;
            this.btnGotoLabel.Text = "Goto";
            this.btnGotoLabel.UseVisualStyleBackColor = true;
            this.btnGotoLabel.Click += new System.EventHandler(this.btnGotoLabel_Click);
            // 
            // btnAddLabel
            // 
            this.btnAddLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLabel.Location = new System.Drawing.Point(371, 175);
            this.btnAddLabel.Name = "btnAddLabel";
            this.btnAddLabel.Size = new System.Drawing.Size(57, 22);
            this.btnAddLabel.TabIndex = 111;
            this.btnAddLabel.Text = "Add";
            this.btnAddLabel.UseVisualStyleBackColor = true;
            this.btnAddLabel.Click += new System.EventHandler(this.btnAddLabel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(311, 103);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(117, 48);
            this.txtDescription.TabIndex = 109;
            this.txtDescription.Text = "Description";
            this.txtDescription.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtDescription.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(311, 80);
            this.txtAuthor.Multiline = true;
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(117, 20);
            this.txtAuthor.TabIndex = 110;
            this.txtAuthor.Text = "Author";
            this.txtAuthor.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtAuthor.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(311, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(58, 22);
            this.btnSave.TabIndex = 75;
            this.btnSave.Text = "Save bot";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBeep
            // 
            this.btnBeep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeep.Location = new System.Drawing.Point(177, 177);
            this.btnBeep.Name = "btnBeep";
            this.btnBeep.Size = new System.Drawing.Size(75, 22);
            this.btnBeep.TabIndex = 74;
            this.btnBeep.Text = "Play Sound";
            this.btnBeep.UseVisualStyleBackColor = true;
            this.btnBeep.Click += new System.EventHandler(this.btnBeep_Click);
            // 
            // numBeepTimes
            // 
            this.numBeepTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numBeepTimes.Location = new System.Drawing.Point(253, 178);
            this.numBeepTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBeepTimes.Name = "numBeepTimes";
            this.numBeepTimes.Size = new System.Drawing.Size(52, 20);
            this.numBeepTimes.TabIndex = 73;
            this.numBeepTimes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnDelay
            // 
            this.btnDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelay.Location = new System.Drawing.Point(177, 78);
            this.btnDelay.Name = "btnDelay";
            this.btnDelay.Size = new System.Drawing.Size(75, 22);
            this.btnDelay.TabIndex = 74;
            this.btnDelay.Text = "Delay";
            this.btnDelay.UseVisualStyleBackColor = true;
            this.btnDelay.Click += new System.EventHandler(this.btnDelay_Click);
            // 
            // numDelay
            // 
            this.numDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numDelay.Location = new System.Drawing.Point(253, 79);
            this.numDelay.Maximum = new decimal(new int[] {
            71000,
            0,
            0,
            0});
            this.numDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(52, 20);
            this.numDelay.TabIndex = 73;
            this.numDelay.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Bot delay";
            // 
            // numBotDelay
            // 
            this.numBotDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBotDelay.Location = new System.Drawing.Point(53, 156);
            this.numBotDelay.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.numBotDelay.Name = "numBotDelay";
            this.numBotDelay.Size = new System.Drawing.Size(48, 20);
            this.numBotDelay.TabIndex = 71;
            this.numBotDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnBotDelay
            // 
            this.btnBotDelay.Location = new System.Drawing.Point(102, 155);
            this.btnBotDelay.Name = "btnBotDelay";
            this.btnBotDelay.Size = new System.Drawing.Size(70, 23);
            this.btnBotDelay.TabIndex = 70;
            this.btnBotDelay.Text = "Set delay";
            this.btnBotDelay.UseVisualStyleBackColor = true;
            this.btnBotDelay.Click += new System.EventHandler(this.btnBotDelay_Click);
            // 
            // txtPlayer
            // 
            this.txtPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayer.Location = new System.Drawing.Point(178, 104);
            this.txtPlayer.Name = "txtPlayer";
            this.txtPlayer.Size = new System.Drawing.Size(127, 20);
            this.txtPlayer.TabIndex = 69;
            this.txtPlayer.Text = "Player name";
            this.txtPlayer.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtPlayer.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnGoto
            // 
            this.btnGoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoto.Location = new System.Drawing.Point(177, 129);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(128, 22);
            this.btnGoto.TabIndex = 68;
            this.btnGoto.Text = "Goto Command";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(370, 28);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(59, 22);
            this.btnLoad.TabIndex = 67;
            this.btnLoad.Text = "Load bot";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.Location = new System.Drawing.Point(370, 3);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(59, 22);
            this.btnRestart.TabIndex = 66;
            this.btnRestart.Text = "Restart bot";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(311, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(58, 22);
            this.btnStop.TabIndex = 65;
            this.btnStop.Text = "Stop bot";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnLoadCmd
            // 
            this.btnLoadCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadCmd.Location = new System.Drawing.Point(177, 53);
            this.btnLoadCmd.Name = "btnLoadCmd";
            this.btnLoadCmd.Size = new System.Drawing.Size(129, 22);
            this.btnLoadCmd.TabIndex = 63;
            this.btnLoadCmd.Text = "Load bot (command)";
            this.btnLoadCmd.UseVisualStyleBackColor = true;
            this.btnLoadCmd.Click += new System.EventHandler(this.btnLoadCmd_Click);
            // 
            // chkSkip
            // 
            this.chkSkip.AutoSize = true;
            this.chkSkip.Checked = true;
            this.chkSkip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSkip.Location = new System.Drawing.Point(7, 179);
            this.chkSkip.Name = "chkSkip";
            this.chkSkip.Size = new System.Drawing.Size(174, 17);
            this.chkSkip.TabIndex = 62;
            this.chkSkip.Text = "Skip bot delay for index/if cmds";
            this.chkSkip.UseVisualStyleBackColor = true;
            // 
            // btnStatementAdd
            // 
            this.btnStatementAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatementAdd.Location = new System.Drawing.Point(5, 129);
            this.btnStatementAdd.MaximumSize = new System.Drawing.Size(197, 20);
            this.btnStatementAdd.MinimumSize = new System.Drawing.Size(167, 20);
            this.btnStatementAdd.Name = "btnStatementAdd";
            this.btnStatementAdd.Size = new System.Drawing.Size(167, 20);
            this.btnStatementAdd.TabIndex = 61;
            this.btnStatementAdd.Text = "Add statement";
            this.btnStatementAdd.UseVisualStyleBackColor = true;
            this.btnStatementAdd.Click += new System.EventHandler(this.btnStatementAdd_Click);
            // 
            // txtStatement2
            // 
            this.txtStatement2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatement2.Location = new System.Drawing.Point(5, 105);
            this.txtStatement2.MaximumSize = new System.Drawing.Size(197, 20);
            this.txtStatement2.MinimumSize = new System.Drawing.Size(167, 20);
            this.txtStatement2.Name = "txtStatement2";
            this.txtStatement2.Size = new System.Drawing.Size(167, 20);
            this.txtStatement2.TabIndex = 60;
            // 
            // txtStatement1
            // 
            this.txtStatement1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatement1.Location = new System.Drawing.Point(5, 80);
            this.txtStatement1.MaximumSize = new System.Drawing.Size(197, 20);
            this.txtStatement1.MinimumSize = new System.Drawing.Size(167, 20);
            this.txtStatement1.Name = "txtStatement1";
            this.txtStatement1.Size = new System.Drawing.Size(167, 20);
            this.txtStatement1.TabIndex = 59;
            // 
            // cbStatement
            // 
            this.cbStatement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatement.FormattingEnabled = true;
            this.cbStatement.Location = new System.Drawing.Point(5, 55);
            this.cbStatement.MaximumSize = new System.Drawing.Size(197, 0);
            this.cbStatement.MinimumSize = new System.Drawing.Size(167, 0);
            this.cbStatement.Name = "cbStatement";
            this.cbStatement.Size = new System.Drawing.Size(167, 21);
            this.cbStatement.TabIndex = 58;
            this.cbStatement.SelectedIndexChanged += new System.EventHandler(this.cbStatement_SelectedIndexChanged);
            // 
            // cbCategories
            // 
            this.cbCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Items.AddRange(new object[] {
            "Item",
            "This player",
            "Player",
            "Map",
            "Monster",
            "Quest",
            "Misc"});
            this.cbCategories.Location = new System.Drawing.Point(5, 30);
            this.cbCategories.MaximumSize = new System.Drawing.Size(197, 0);
            this.cbCategories.MinimumSize = new System.Drawing.Size(167, 0);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(167, 21);
            this.cbCategories.TabIndex = 57;
            this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            // 
            // txtPacket
            // 
            this.txtPacket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPacket.Location = new System.Drawing.Point(4, 4);
            this.txtPacket.Name = "txtPacket";
            this.txtPacket.Size = new System.Drawing.Size(248, 20);
            this.txtPacket.TabIndex = 53;
            this.txtPacket.Text = "%xt%zm%cmd%1%tfer%PLAYERNAME%MAP-1e99%";
            // 
            // btnClientPacket
            // 
            this.btnClientPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientPacket.Location = new System.Drawing.Point(178, 28);
            this.btnClientPacket.Name = "btnClientPacket";
            this.btnClientPacket.Size = new System.Drawing.Size(127, 22);
            this.btnClientPacket.TabIndex = 52;
            this.btnClientPacket.Text = "Client Packet";
            this.btnClientPacket.UseVisualStyleBackColor = true;
            this.btnClientPacket.Click += new System.EventHandler(this.btnClientPacket_Click);
            // 
            // btnPacket
            // 
            this.btnPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPacket.Location = new System.Drawing.Point(253, 3);
            this.btnPacket.Name = "btnPacket";
            this.btnPacket.Size = new System.Drawing.Size(52, 22);
            this.btnPacket.TabIndex = 52;
            this.btnPacket.Text = "Packet";
            this.btnPacket.UseVisualStyleBackColor = true;
            this.btnPacket.Click += new System.EventHandler(this.btnPacket_Click);
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.pnlOptions);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(444, 299);
            this.tabOptions.TabIndex = 5;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.chkBuff);
            this.pnlOptions.Controls.Add(this.label6);
            this.pnlOptions.Controls.Add(this.numOptionsTimer);
            this.pnlOptions.Controls.Add(this.label5);
            this.pnlOptions.Controls.Add(this.chkUntarget);
            this.pnlOptions.Controls.Add(this.lstLogText);
            this.pnlOptions.Controls.Add(this.btnLogDebug);
            this.pnlOptions.Controls.Add(this.btnLog);
            this.pnlOptions.Controls.Add(this.txtLog);
            this.pnlOptions.Controls.Add(this.chkEnableSettings);
            this.pnlOptions.Controls.Add(this.chkDisableAnims);
            this.pnlOptions.Controls.Add(this.txtSoundItem);
            this.pnlOptions.Controls.Add(this.btnSoundAdd);
            this.pnlOptions.Controls.Add(this.btnSoundDelete);
            this.pnlOptions.Controls.Add(this.btnSoundTest);
            this.pnlOptions.Controls.Add(this.lstSoundItems);
            this.pnlOptions.Controls.Add(this.label9);
            this.pnlOptions.Controls.Add(this.numWalkSpeed);
            this.pnlOptions.Controls.Add(this.label8);
            this.pnlOptions.Controls.Add(this.chkSkipCutscenes);
            this.pnlOptions.Controls.Add(this.chkHidePlayers);
            this.pnlOptions.Controls.Add(this.chkLag);
            this.pnlOptions.Controls.Add(this.chkMagnet);
            this.pnlOptions.Controls.Add(this.chkProvoke);
            this.pnlOptions.Controls.Add(this.chkInfiniteRange);
            this.pnlOptions.Controls.Add(this.grpLogin);
            this.pnlOptions.Controls.Add(this.chkGender);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptions.Location = new System.Drawing.Point(3, 3);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(438, 293);
            this.pnlOptions.TabIndex = 108;
            // 
            // chkBuff
            // 
            this.chkBuff.AutoSize = true;
            this.chkBuff.Location = new System.Drawing.Point(150, 184);
            this.chkBuff.Name = "chkBuff";
            this.chkBuff.Size = new System.Drawing.Size(60, 17);
            this.chkBuff.TabIndex = 158;
            this.chkBuff.Text = "Buff up";
            this.chkBuff.UseVisualStyleBackColor = true;
            this.chkBuff.CheckedChanged += new System.EventHandler(this.chkBuffup_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 157;
            this.label6.Text = "Options Timer";
            // 
            // numOptionsTimer
            // 
            this.numOptionsTimer.Location = new System.Drawing.Point(150, 251);
            this.numOptionsTimer.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numOptionsTimer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOptionsTimer.Name = "numOptionsTimer";
            this.numOptionsTimer.Size = new System.Drawing.Size(42, 20);
            this.numOptionsTimer.TabIndex = 156;
            this.numOptionsTimer.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numOptionsTimer.ValueChanged += new System.EventHandler(this.numOptionsTimer_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 155;
            this.label5.Text = "Viable Log References";
            // 
            // chkUntarget
            // 
            this.chkUntarget.AutoSize = true;
            this.chkUntarget.Location = new System.Drawing.Point(150, 165);
            this.chkUntarget.Name = "chkUntarget";
            this.chkUntarget.Size = new System.Drawing.Size(86, 17);
            this.chkUntarget.TabIndex = 154;
            this.chkUntarget.Text = "Untarget self";
            this.chkUntarget.UseVisualStyleBackColor = true;
            this.chkUntarget.CheckedChanged += new System.EventHandler(this.chkUntarget_CheckedChanged);
            // 
            // lstLogText
            // 
            this.lstLogText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLogText.FormattingEnabled = true;
            this.lstLogText.Items.AddRange(new object[] {
            "{USERNAME}",
            "{MAP}",
            "{GOLD}",
            "{LEVEL}",
            "{CELL}",
            "{HEALTH}",
            "{TIME: 12}",
            "{TIME: 24}",
            "{CLEAR}",
            "{ITEM: item name}",
            "{ITEM MAX: item name}",
            "{REP XP: faction}",
            "{REP RANK: faction}",
            "{REP TOTAL: faction}",
            "{REP REMAINING: faction}",
            "{REP REQUIRED: faction}",
            "{REP CURRENT: faction}",
            "{INT VALUE: int}"});
            this.lstLogText.Location = new System.Drawing.Point(281, 123);
            this.lstLogText.Name = "lstLogText";
            this.lstLogText.Size = new System.Drawing.Size(141, 147);
            this.lstLogText.TabIndex = 153;
            this.lstLogText.DoubleClick += new System.EventHandler(this.lstLogText_DoubleClick);
            this.lstLogText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLogText_KeyDown);
            // 
            // btnLogDebug
            // 
            this.btnLogDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogDebug.AutoSize = true;
            this.btnLogDebug.Location = new System.Drawing.Point(348, 86);
            this.btnLogDebug.Name = "btnLogDebug";
            this.btnLogDebug.Size = new System.Drawing.Size(74, 23);
            this.btnLogDebug.TabIndex = 152;
            this.btnLogDebug.Text = "Log Debug";
            this.btnLogDebug.UseVisualStyleBackColor = true;
            this.btnLogDebug.Click += new System.EventHandler(this.logDebug);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLog.AutoSize = true;
            this.btnLog.Location = new System.Drawing.Point(280, 86);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(68, 23);
            this.btnLog.TabIndex = 148;
            this.btnLog.Text = "Log Script";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.logScript);
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.AcceptsTab = true;
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.AutoCompleteCustomSource.AddRange(new string[] {
            "{USERNAME}",
            "{MAP}",
            "{GOLD}",
            "{LEVEL}",
            "{CELL}",
            "{HEALTH}",
            "{TIME: 12}",
            "{TIME: 24}",
            "{CLEAR}",
            "{ITEM: item name}",
            "{ITEM MAX: item name}",
            "{REP XP: faction}",
            "{REP RANK: faction}",
            "{REP TOTAL: faction}",
            "{REP REMAINING: faction}",
            "{REP REQUIRED: faction}",
            "{REP CURRENT: faction}"});
            this.txtLog.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtLog.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLog.Location = new System.Drawing.Point(281, 5);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(141, 79);
            this.txtLog.TabIndex = 147;
            this.txtLog.Text = "Logs";
            // 
            // chkEnableSettings
            // 
            this.chkEnableSettings.AutoSize = true;
            this.chkEnableSettings.Location = new System.Drawing.Point(151, 221);
            this.chkEnableSettings.Name = "chkEnableSettings";
            this.chkEnableSettings.Size = new System.Drawing.Size(97, 30);
            this.chkEnableSettings.TabIndex = 132;
            this.chkEnableSettings.Text = "Enable options\r\nwithout starting";
            this.chkEnableSettings.UseVisualStyleBackColor = true;
            this.chkEnableSettings.Click += new System.EventHandler(this.chkEnableSettings_Click);
            // 
            // chkDisableAnims
            // 
            this.chkDisableAnims.AutoSize = true;
            this.chkDisableAnims.Location = new System.Drawing.Point(150, 127);
            this.chkDisableAnims.Name = "chkDisableAnims";
            this.chkDisableAnims.Size = new System.Drawing.Size(122, 17);
            this.chkDisableAnims.TabIndex = 131;
            this.chkDisableAnims.Text = "Disable player anims";
            this.chkDisableAnims.UseVisualStyleBackColor = true;
            this.chkDisableAnims.CheckedChanged += new System.EventHandler(this.chkDisableAnims_CheckedChanged);
            // 
            // txtSoundItem
            // 
            this.txtSoundItem.Location = new System.Drawing.Point(6, 228);
            this.txtSoundItem.Name = "txtSoundItem";
            this.txtSoundItem.Size = new System.Drawing.Size(139, 20);
            this.txtSoundItem.TabIndex = 130;
            this.txtSoundItem.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtSoundItem.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnSoundAdd
            // 
            this.btnSoundAdd.Location = new System.Drawing.Point(51, 250);
            this.btnSoundAdd.Name = "btnSoundAdd";
            this.btnSoundAdd.Size = new System.Drawing.Size(43, 22);
            this.btnSoundAdd.TabIndex = 129;
            this.btnSoundAdd.Text = "Add";
            this.btnSoundAdd.UseVisualStyleBackColor = true;
            this.btnSoundAdd.Click += new System.EventHandler(this.btnSoundAdd_Click);
            // 
            // btnSoundDelete
            // 
            this.btnSoundDelete.Location = new System.Drawing.Point(96, 250);
            this.btnSoundDelete.Name = "btnSoundDelete";
            this.btnSoundDelete.Size = new System.Drawing.Size(50, 22);
            this.btnSoundDelete.TabIndex = 128;
            this.btnSoundDelete.Text = "Delete";
            this.btnSoundDelete.UseVisualStyleBackColor = true;
            this.btnSoundDelete.Click += new System.EventHandler(this.btnSoundDelete_Click);
            // 
            // btnSoundTest
            // 
            this.btnSoundTest.Location = new System.Drawing.Point(5, 250);
            this.btnSoundTest.Name = "btnSoundTest";
            this.btnSoundTest.Size = new System.Drawing.Size(43, 22);
            this.btnSoundTest.TabIndex = 126;
            this.btnSoundTest.Text = "Test";
            this.btnSoundTest.UseVisualStyleBackColor = true;
            this.btnSoundTest.Click += new System.EventHandler(this.btnSoundTest_Click);
            // 
            // lstSoundItems
            // 
            this.lstSoundItems.FormattingEnabled = true;
            this.lstSoundItems.Location = new System.Drawing.Point(6, 168);
            this.lstSoundItems.Name = "lstSoundItems";
            this.lstSoundItems.Size = new System.Drawing.Size(139, 56);
            this.lstSoundItems.TabIndex = 125;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 26);
            this.label9.TabIndex = 124;
            this.label9.Text = "If any of the following items\r\nare dropped, play a sound";
            // 
            // numWalkSpeed
            // 
            this.numWalkSpeed.Location = new System.Drawing.Point(214, 201);
            this.numWalkSpeed.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numWalkSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWalkSpeed.Name = "numWalkSpeed";
            this.numWalkSpeed.Size = new System.Drawing.Size(28, 20);
            this.numWalkSpeed.TabIndex = 123;
            this.numWalkSpeed.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numWalkSpeed.ValueChanged += new System.EventHandler(this.numWalkSpeed_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 122;
            this.label8.Text = "Walk speed";
            // 
            // chkSkipCutscenes
            // 
            this.chkSkipCutscenes.AutoSize = true;
            this.chkSkipCutscenes.Location = new System.Drawing.Point(150, 107);
            this.chkSkipCutscenes.Name = "chkSkipCutscenes";
            this.chkSkipCutscenes.Size = new System.Drawing.Size(99, 17);
            this.chkSkipCutscenes.TabIndex = 121;
            this.chkSkipCutscenes.Text = "Skip cutscenes";
            this.chkSkipCutscenes.UseVisualStyleBackColor = true;
            this.chkSkipCutscenes.CheckedChanged += new System.EventHandler(this.chkSkipCutscenes_CheckedChanged);
            // 
            // chkHidePlayers
            // 
            this.chkHidePlayers.AutoSize = true;
            this.chkHidePlayers.Location = new System.Drawing.Point(150, 87);
            this.chkHidePlayers.Name = "chkHidePlayers";
            this.chkHidePlayers.Size = new System.Drawing.Size(84, 17);
            this.chkHidePlayers.TabIndex = 120;
            this.chkHidePlayers.Text = "Hide players";
            this.chkHidePlayers.UseVisualStyleBackColor = true;
            this.chkHidePlayers.CheckedChanged += new System.EventHandler(this.chkHidePlayers_CheckedChanged);
            // 
            // chkLag
            // 
            this.chkLag.AutoSize = true;
            this.chkLag.Location = new System.Drawing.Point(150, 66);
            this.chkLag.Name = "chkLag";
            this.chkLag.Size = new System.Drawing.Size(68, 17);
            this.chkLag.TabIndex = 119;
            this.chkLag.Text = "Lag killer";
            this.chkLag.UseVisualStyleBackColor = true;
            this.chkLag.CheckedChanged += new System.EventHandler(this.chkLag_CheckedChanged);
            // 
            // chkMagnet
            // 
            this.chkMagnet.AutoSize = true;
            this.chkMagnet.Location = new System.Drawing.Point(150, 46);
            this.chkMagnet.Name = "chkMagnet";
            this.chkMagnet.Size = new System.Drawing.Size(96, 17);
            this.chkMagnet.TabIndex = 118;
            this.chkMagnet.Text = "Enemy magnet";
            this.chkMagnet.UseVisualStyleBackColor = true;
            this.chkMagnet.CheckedChanged += new System.EventHandler(this.chkMagnet_CheckedChanged);
            // 
            // chkProvoke
            // 
            this.chkProvoke.AutoSize = true;
            this.chkProvoke.Location = new System.Drawing.Point(150, 25);
            this.chkProvoke.Name = "chkProvoke";
            this.chkProvoke.Size = new System.Drawing.Size(111, 17);
            this.chkProvoke.TabIndex = 117;
            this.chkProvoke.Text = "Provoke monsters";
            this.chkProvoke.UseVisualStyleBackColor = true;
            this.chkProvoke.CheckedChanged += new System.EventHandler(this.chkProvoke_CheckedChanged);
            // 
            // chkInfiniteRange
            // 
            this.chkInfiniteRange.AutoSize = true;
            this.chkInfiniteRange.Location = new System.Drawing.Point(150, 4);
            this.chkInfiniteRange.Name = "chkInfiniteRange";
            this.chkInfiniteRange.Size = new System.Drawing.Size(120, 17);
            this.chkInfiniteRange.TabIndex = 116;
            this.chkInfiniteRange.Text = "Infinite attack range";
            this.chkInfiniteRange.UseVisualStyleBackColor = true;
            this.chkInfiniteRange.CheckedChanged += new System.EventHandler(this.chkInfiniteRange_CheckedChanged);
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.chkAFK);
            this.grpLogin.Controls.Add(this.cbServers);
            this.grpLogin.Controls.Add(this.chkRelogRetry);
            this.grpLogin.Controls.Add(this.chkRelog);
            this.grpLogin.Controls.Add(this.numRelogDelay);
            this.grpLogin.Controls.Add(this.label7);
            this.grpLogin.Location = new System.Drawing.Point(4, 3);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(141, 138);
            this.grpLogin.TabIndex = 115;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Auto relogin";
            // 
            // chkAFK
            // 
            this.chkAFK.AutoSize = true;
            this.chkAFK.Enabled = false;
            this.chkAFK.Location = new System.Drawing.Point(4, 62);
            this.chkAFK.Name = "chkAFK";
            this.chkAFK.Size = new System.Drawing.Size(100, 17);
            this.chkAFK.TabIndex = 159;
            this.chkAFK.Text = "Relogin on AFK";
            this.chkAFK.UseVisualStyleBackColor = true;
            this.chkAFK.CheckedChanged += new System.EventHandler(this.chkAFK_CheckedChanged);
            // 
            // cbServers
            // 
            this.cbServers.FormattingEnabled = true;
            this.cbServers.Location = new System.Drawing.Point(4, 17);
            this.cbServers.Name = "cbServers";
            this.cbServers.Size = new System.Drawing.Size(123, 21);
            this.cbServers.TabIndex = 0;
            // 
            // chkRelogRetry
            // 
            this.chkRelogRetry.AutoSize = true;
            this.chkRelogRetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkRelogRetry.Location = new System.Drawing.Point(3, 120);
            this.chkRelogRetry.Name = "chkRelogRetry";
            this.chkRelogRetry.Size = new System.Drawing.Size(143, 17);
            this.chkRelogRetry.TabIndex = 88;
            this.chkRelogRetry.Text = "Relog again if in battleon";
            this.chkRelogRetry.UseVisualStyleBackColor = true;
            // 
            // chkRelog
            // 
            this.chkRelog.AutoSize = true;
            this.chkRelog.Location = new System.Drawing.Point(4, 43);
            this.chkRelog.Name = "chkRelog";
            this.chkRelog.Size = new System.Drawing.Size(82, 17);
            this.chkRelog.TabIndex = 1;
            this.chkRelog.Text = "Auto relogin";
            this.chkRelog.UseVisualStyleBackColor = true;
            this.chkRelog.CheckedChanged += new System.EventHandler(this.chkRelog_CheckedChanged);
            // 
            // numRelogDelay
            // 
            this.numRelogDelay.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRelogDelay.Location = new System.Drawing.Point(3, 98);
            this.numRelogDelay.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numRelogDelay.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRelogDelay.Name = "numRelogDelay";
            this.numRelogDelay.Size = new System.Drawing.Size(46, 20);
            this.numRelogDelay.TabIndex = 86;
            this.numRelogDelay.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label7.Location = new System.Drawing.Point(0, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Delay before starting the bot";
            // 
            // chkGender
            // 
            this.chkGender.AutoSize = true;
            this.chkGender.Location = new System.Drawing.Point(150, 146);
            this.chkGender.Name = "chkGender";
            this.chkGender.Size = new System.Drawing.Size(89, 17);
            this.chkGender.TabIndex = 137;
            this.chkGender.Text = "Gender swap";
            this.chkGender.UseVisualStyleBackColor = true;
            this.chkGender.CheckedChanged += new System.EventHandler(this.changeGenderAsync);
            // 
            // tabOptions2
            // 
            this.tabOptions2.Controls.Add(this.numSetLevel);
            this.tabOptions2.Controls.Add(this.chkChangeRoomTag);
            this.tabOptions2.Controls.Add(this.chkChangeChat);
            this.tabOptions2.Controls.Add(this.chkSetJoinLevel);
            this.tabOptions2.Controls.Add(this.chkHideYulgarPlayers);
            this.tabOptions2.Controls.Add(this.chkAntiAfk);
            this.tabOptions2.Controls.Add(this.grpAccessLevel);
            this.tabOptions2.Controls.Add(this.grpAlignment);
            this.tabOptions2.Controls.Add(this.txtUsername);
            this.tabOptions2.Controls.Add(this.btnChangeNameCmd);
            this.tabOptions2.Controls.Add(this.btnchangeName);
            this.tabOptions2.Controls.Add(this.btnChangeGuildCmd);
            this.tabOptions2.Controls.Add(this.btnchangeGuild);
            this.tabOptions2.Controls.Add(this.txtGuild);
            this.tabOptions2.Location = new System.Drawing.Point(4, 22);
            this.tabOptions2.Name = "tabOptions2";
            this.tabOptions2.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions2.Size = new System.Drawing.Size(444, 299);
            this.tabOptions2.TabIndex = 7;
            this.tabOptions2.Text = "Client";
            this.tabOptions2.UseVisualStyleBackColor = true;
            // 
            // numSetLevel
            // 
            this.numSetLevel.Enabled = false;
            this.numSetLevel.Location = new System.Drawing.Point(12, 195);
            this.numSetLevel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSetLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSetLevel.Name = "numSetLevel";
            this.numSetLevel.Size = new System.Drawing.Size(51, 20);
            this.numSetLevel.TabIndex = 145;
            this.numSetLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkChangeRoomTag
            // 
            this.chkChangeRoomTag.AutoSize = true;
            this.chkChangeRoomTag.Location = new System.Drawing.Point(12, 221);
            this.chkChangeRoomTag.Name = "chkChangeRoomTag";
            this.chkChangeRoomTag.Size = new System.Drawing.Size(107, 17);
            this.chkChangeRoomTag.TabIndex = 144;
            this.chkChangeRoomTag.Text = "Anonymous room";
            this.chkChangeRoomTag.UseVisualStyleBackColor = true;
            this.chkChangeRoomTag.CheckedChanged += new System.EventHandler(this.chkChangeRoomTag_CheckedChanged);
            // 
            // chkChangeChat
            // 
            this.chkChangeChat.AutoSize = true;
            this.chkChangeChat.Location = new System.Drawing.Point(12, 243);
            this.chkChangeChat.Name = "chkChangeChat";
            this.chkChangeChat.Size = new System.Drawing.Size(105, 17);
            this.chkChangeChat.TabIndex = 144;
            this.chkChangeChat.Text = "Anonymous chat";
            this.chkChangeChat.UseVisualStyleBackColor = true;
            this.chkChangeChat.CheckedChanged += new System.EventHandler(this.chkChangeChat_CheckedChanged);
            // 
            // chkSetJoinLevel
            // 
            this.chkSetJoinLevel.AutoSize = true;
            this.chkSetJoinLevel.Enabled = false;
            this.chkSetJoinLevel.Location = new System.Drawing.Point(69, 197);
            this.chkSetJoinLevel.Name = "chkSetJoinLevel";
            this.chkSetJoinLevel.Size = new System.Drawing.Size(110, 17);
            this.chkSetJoinLevel.TabIndex = 144;
            this.chkSetJoinLevel.Text = "Toggle Join Level";
            this.chkSetJoinLevel.UseVisualStyleBackColor = true;
            this.chkSetJoinLevel.CheckedChanged += new System.EventHandler(this.chkSetJoinLevel_CheckedChanged);
            // 
            // chkHideYulgarPlayers
            // 
            this.chkHideYulgarPlayers.AutoSize = true;
            this.chkHideYulgarPlayers.Location = new System.Drawing.Point(12, 266);
            this.chkHideYulgarPlayers.Name = "chkHideYulgarPlayers";
            this.chkHideYulgarPlayers.Size = new System.Drawing.Size(126, 17);
            this.chkHideYulgarPlayers.TabIndex = 144;
            this.chkHideYulgarPlayers.Text = "Hide Players Upstairs";
            this.chkHideYulgarPlayers.UseVisualStyleBackColor = true;
            this.chkHideYulgarPlayers.CheckedChanged += new System.EventHandler(this.chkHideYulgarPlayers_CheckedChanged);
            // 
            // chkAntiAfk
            // 
            this.chkAntiAfk.AutoSize = true;
            this.chkAntiAfk.Location = new System.Drawing.Point(121, 221);
            this.chkAntiAfk.Name = "chkAntiAfk";
            this.chkAntiAfk.Size = new System.Drawing.Size(67, 17);
            this.chkAntiAfk.TabIndex = 144;
            this.chkAntiAfk.Text = "Anti-AFK";
            this.chkAntiAfk.UseVisualStyleBackColor = true;
            this.chkAntiAfk.CheckedChanged += new System.EventHandler(this.chkAntiAfk_CheckedChanged);
            // 
            // grpAccessLevel
            // 
            this.grpAccessLevel.Controls.Add(this.chkToggleMute);
            this.grpAccessLevel.Controls.Add(this.btnSetMem);
            this.grpAccessLevel.Controls.Add(this.btnSetModerator);
            this.grpAccessLevel.Controls.Add(this.btnSetNonMem);
            this.grpAccessLevel.Location = new System.Drawing.Point(98, 6);
            this.grpAccessLevel.Name = "grpAccessLevel";
            this.grpAccessLevel.Size = new System.Drawing.Size(86, 131);
            this.grpAccessLevel.TabIndex = 6;
            this.grpAccessLevel.TabStop = false;
            this.grpAccessLevel.Text = "Access";
            // 
            // chkToggleMute
            // 
            this.chkToggleMute.AutoSize = true;
            this.chkToggleMute.Location = new System.Drawing.Point(4, 107);
            this.chkToggleMute.Name = "chkToggleMute";
            this.chkToggleMute.Size = new System.Drawing.Size(86, 17);
            this.chkToggleMute.TabIndex = 6;
            this.chkToggleMute.Text = "Toggle Mute";
            this.chkToggleMute.UseVisualStyleBackColor = true;
            this.chkToggleMute.CheckedChanged += new System.EventHandler(this.chkToggleMute_CheckedChanged);
            // 
            // btnSetMem
            // 
            this.btnSetMem.Location = new System.Drawing.Point(6, 19);
            this.btnSetMem.Name = "btnSetMem";
            this.btnSetMem.Size = new System.Drawing.Size(75, 23);
            this.btnSetMem.TabIndex = 3;
            this.btnSetMem.Text = "Member";
            this.btnSetMem.UseVisualStyleBackColor = true;
            this.btnSetMem.Click += new System.EventHandler(this.btnSetHero_Click);
            // 
            // btnSetModerator
            // 
            this.btnSetModerator.Location = new System.Drawing.Point(6, 77);
            this.btnSetModerator.Name = "btnSetModerator";
            this.btnSetModerator.Size = new System.Drawing.Size(75, 23);
            this.btnSetModerator.TabIndex = 5;
            this.btnSetModerator.Text = "Moderator";
            this.btnSetModerator.UseVisualStyleBackColor = true;
            this.btnSetModerator.Click += new System.EventHandler(this.btnSetHero_Click);
            // 
            // btnSetNonMem
            // 
            this.btnSetNonMem.Location = new System.Drawing.Point(6, 48);
            this.btnSetNonMem.Name = "btnSetNonMem";
            this.btnSetNonMem.Size = new System.Drawing.Size(75, 23);
            this.btnSetNonMem.TabIndex = 4;
            this.btnSetNonMem.Text = "Non-Mem";
            this.btnSetNonMem.UseVisualStyleBackColor = true;
            this.btnSetNonMem.Click += new System.EventHandler(this.btnSetHero_Click);
            // 
            // grpAlignment
            // 
            this.grpAlignment.Controls.Add(this.btnSetChaos);
            this.grpAlignment.Controls.Add(this.btnSetUndecided);
            this.grpAlignment.Controls.Add(this.btnSetGood);
            this.grpAlignment.Controls.Add(this.btnSetEvil);
            this.grpAlignment.Location = new System.Drawing.Point(6, 6);
            this.grpAlignment.Name = "grpAlignment";
            this.grpAlignment.Size = new System.Drawing.Size(86, 131);
            this.grpAlignment.TabIndex = 1;
            this.grpAlignment.TabStop = false;
            this.grpAlignment.Text = "Alignment";
            // 
            // btnSetChaos
            // 
            this.btnSetChaos.Location = new System.Drawing.Point(6, 74);
            this.btnSetChaos.Name = "btnSetChaos";
            this.btnSetChaos.Size = new System.Drawing.Size(75, 23);
            this.btnSetChaos.TabIndex = 0;
            this.btnSetChaos.Text = "Chaos";
            this.btnSetChaos.UseVisualStyleBackColor = true;
            this.btnSetChaos.Click += new System.EventHandler(this.btnSetHero_Click);
            // 
            // btnSetUndecided
            // 
            this.btnSetUndecided.Location = new System.Drawing.Point(6, 103);
            this.btnSetUndecided.Name = "btnSetUndecided";
            this.btnSetUndecided.Size = new System.Drawing.Size(75, 23);
            this.btnSetUndecided.TabIndex = 0;
            this.btnSetUndecided.Text = "Undecided";
            this.btnSetUndecided.UseVisualStyleBackColor = true;
            this.btnSetUndecided.Click += new System.EventHandler(this.btnSetHero_Click);
            // 
            // btnSetGood
            // 
            this.btnSetGood.Location = new System.Drawing.Point(6, 16);
            this.btnSetGood.Name = "btnSetGood";
            this.btnSetGood.Size = new System.Drawing.Size(75, 23);
            this.btnSetGood.TabIndex = 0;
            this.btnSetGood.Text = "Good";
            this.btnSetGood.UseVisualStyleBackColor = true;
            this.btnSetGood.Click += new System.EventHandler(this.btnSetHero_Click);
            // 
            // btnSetEvil
            // 
            this.btnSetEvil.Location = new System.Drawing.Point(6, 45);
            this.btnSetEvil.Name = "btnSetEvil";
            this.btnSetEvil.Size = new System.Drawing.Size(75, 23);
            this.btnSetEvil.TabIndex = 0;
            this.btnSetEvil.Text = "Evil";
            this.btnSetEvil.UseVisualStyleBackColor = true;
            this.btnSetEvil.Click += new System.EventHandler(this.btnSetHero_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(10, 146);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(78, 20);
            this.txtUsername.TabIndex = 135;
            this.txtUsername.Text = "Username";
            // 
            // btnChangeNameCmd
            // 
            this.btnChangeNameCmd.AutoSize = true;
            this.btnChangeNameCmd.Location = new System.Drawing.Point(136, 145);
            this.btnChangeNameCmd.Name = "btnChangeNameCmd";
            this.btnChangeNameCmd.Size = new System.Drawing.Size(45, 23);
            this.btnChangeNameCmd.TabIndex = 142;
            this.btnChangeNameCmd.Text = "(cmd)";
            this.btnChangeNameCmd.Click += new System.EventHandler(this.btnChangeCmd_Click);
            // 
            // btnchangeName
            // 
            this.btnchangeName.AutoSize = true;
            this.btnchangeName.Location = new System.Drawing.Point(90, 145);
            this.btnchangeName.Name = "btnchangeName";
            this.btnchangeName.Size = new System.Drawing.Size(45, 23);
            this.btnchangeName.TabIndex = 142;
            this.btnchangeName.Text = "Set";
            this.btnchangeName.Click += new System.EventHandler(this.btnchangeName_Click);
            // 
            // btnChangeGuildCmd
            // 
            this.btnChangeGuildCmd.AutoSize = true;
            this.btnChangeGuildCmd.Location = new System.Drawing.Point(136, 168);
            this.btnChangeGuildCmd.Name = "btnChangeGuildCmd";
            this.btnChangeGuildCmd.Size = new System.Drawing.Size(45, 23);
            this.btnChangeGuildCmd.TabIndex = 143;
            this.btnChangeGuildCmd.Text = "(cmd)";
            this.btnChangeGuildCmd.Click += new System.EventHandler(this.btnChangeCmd_Click);
            // 
            // btnchangeGuild
            // 
            this.btnchangeGuild.AutoSize = true;
            this.btnchangeGuild.Location = new System.Drawing.Point(90, 168);
            this.btnchangeGuild.Name = "btnchangeGuild";
            this.btnchangeGuild.Size = new System.Drawing.Size(45, 23);
            this.btnchangeGuild.TabIndex = 143;
            this.btnchangeGuild.Text = "Set";
            this.btnchangeGuild.Click += new System.EventHandler(this.btnchangeGuild_Click);
            // 
            // txtGuild
            // 
            this.txtGuild.Location = new System.Drawing.Point(10, 169);
            this.txtGuild.Name = "txtGuild";
            this.txtGuild.Size = new System.Drawing.Size(78, 20);
            this.txtGuild.TabIndex = 136;
            this.txtGuild.Text = "Guild";
            // 
            // tabBots
            // 
            this.tabBots.Controls.Add(this.pnlSaved);
            this.tabBots.Location = new System.Drawing.Point(4, 22);
            this.tabBots.Name = "tabBots";
            this.tabBots.Padding = new System.Windows.Forms.Padding(3);
            this.tabBots.Size = new System.Drawing.Size(444, 299);
            this.tabBots.TabIndex = 6;
            this.tabBots.Text = "Bots";
            this.tabBots.UseVisualStyleBackColor = true;
            // 
            // pnlSaved
            // 
            this.pnlSaved.Controls.Add(this.lblBoosts);
            this.pnlSaved.Controls.Add(this.lblDrops);
            this.pnlSaved.Controls.Add(this.lblQuests);
            this.pnlSaved.Controls.Add(this.lblSkills);
            this.pnlSaved.Controls.Add(this.lblCommands);
            this.pnlSaved.Controls.Add(this.lblItems);
            this.pnlSaved.Controls.Add(this.txtSavedDesc);
            this.pnlSaved.Controls.Add(this.txtSavedAuthor);
            this.pnlSaved.Controls.Add(this.lblBots);
            this.pnlSaved.Controls.Add(this.treeBots);
            this.pnlSaved.Controls.Add(this.txtSavedAdd);
            this.pnlSaved.Controls.Add(this.btnSavedAdd);
            this.pnlSaved.Controls.Add(this.txtSaved);
            this.pnlSaved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSaved.Location = new System.Drawing.Point(3, 3);
            this.pnlSaved.Name = "pnlSaved";
            this.pnlSaved.Size = new System.Drawing.Size(438, 293);
            this.pnlSaved.TabIndex = 109;
            // 
            // lblBoosts
            // 
            this.lblBoosts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblBoosts.AutoSize = true;
            this.lblBoosts.Location = new System.Drawing.Point(251, 260);
            this.lblBoosts.Name = "lblBoosts";
            this.lblBoosts.Size = new System.Drawing.Size(42, 13);
            this.lblBoosts.TabIndex = 25;
            this.lblBoosts.Text = "Boosts:";
            this.lblBoosts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblDrops
            // 
            this.lblDrops.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDrops.AutoSize = true;
            this.lblDrops.Location = new System.Drawing.Point(195, 260);
            this.lblDrops.Name = "lblDrops";
            this.lblDrops.Size = new System.Drawing.Size(38, 13);
            this.lblDrops.TabIndex = 24;
            this.lblDrops.Text = "Drops:";
            this.lblDrops.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblQuests
            // 
            this.lblQuests.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblQuests.AutoSize = true;
            this.lblQuests.Location = new System.Drawing.Point(137, 260);
            this.lblQuests.Name = "lblQuests";
            this.lblQuests.Size = new System.Drawing.Size(43, 13);
            this.lblQuests.TabIndex = 23;
            this.lblQuests.Text = "Quests:";
            this.lblQuests.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblSkills
            // 
            this.lblSkills.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSkills.AutoSize = true;
            this.lblSkills.Location = new System.Drawing.Point(87, 260);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(34, 13);
            this.lblSkills.TabIndex = 22;
            this.lblSkills.Text = "Skills:";
            this.lblSkills.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCommands
            // 
            this.lblCommands.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCommands.AutoSize = true;
            this.lblCommands.Location = new System.Drawing.Point(6, 247);
            this.lblCommands.Name = "lblCommands";
            this.lblCommands.Size = new System.Drawing.Size(62, 26);
            this.lblCommands.TabIndex = 21;
            this.lblCommands.Text = "Number of\r\nCommands:";
            this.lblCommands.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblItems
            // 
            this.lblItems.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(313, 260);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(35, 13);
            this.lblItems.TabIndex = 146;
            this.lblItems.Text = "Items:";
            this.lblItems.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtSavedDesc
            // 
            this.txtSavedDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavedDesc.Location = new System.Drawing.Point(247, 85);
            this.txtSavedDesc.Multiline = true;
            this.txtSavedDesc.Name = "txtSavedDesc";
            this.txtSavedDesc.Size = new System.Drawing.Size(188, 157);
            this.txtSavedDesc.TabIndex = 20;
            this.txtSavedDesc.Text = "Description";
            // 
            // txtSavedAuthor
            // 
            this.txtSavedAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavedAuthor.Location = new System.Drawing.Point(247, 64);
            this.txtSavedAuthor.Name = "txtSavedAuthor";
            this.txtSavedAuthor.Size = new System.Drawing.Size(188, 20);
            this.txtSavedAuthor.TabIndex = 19;
            this.txtSavedAuthor.Text = "Author";
            // 
            // lblBots
            // 
            this.lblBots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBots.AutoSize = true;
            this.lblBots.Location = new System.Drawing.Point(242, 50);
            this.lblBots.Name = "lblBots";
            this.lblBots.Size = new System.Drawing.Size(83, 13);
            this.lblBots.TabIndex = 18;
            this.lblBots.Text = "Number of Bots:";
            // 
            // treeBots
            // 
            this.treeBots.AllowDrop = true;
            this.treeBots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeBots.Location = new System.Drawing.Point(4, 27);
            this.treeBots.Name = "treeBots";
            this.treeBots.Size = new System.Drawing.Size(237, 215);
            this.treeBots.TabIndex = 17;
            this.treeBots.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeBots_AfterExpand);
            this.treeBots.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeBots_AfterSelect);
            // 
            // txtSavedAdd
            // 
            this.txtSavedAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavedAdd.Location = new System.Drawing.Point(247, 27);
            this.txtSavedAdd.Name = "txtSavedAdd";
            this.txtSavedAdd.Size = new System.Drawing.Size(121, 20);
            this.txtSavedAdd.TabIndex = 16;
            // 
            // btnSavedAdd
            // 
            this.btnSavedAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavedAdd.Location = new System.Drawing.Point(371, 27);
            this.btnSavedAdd.Name = "btnSavedAdd";
            this.btnSavedAdd.Size = new System.Drawing.Size(64, 22);
            this.btnSavedAdd.TabIndex = 15;
            this.btnSavedAdd.Text = "Add folder";
            this.btnSavedAdd.UseVisualStyleBackColor = true;
            this.btnSavedAdd.Click += new System.EventHandler(this.btnSavedAdd_Click);
            // 
            // txtSaved
            // 
            this.txtSaved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaved.Location = new System.Drawing.Point(4, 4);
            this.txtSaved.Name = "txtSaved";
            this.txtSaved.Size = new System.Drawing.Size(431, 20);
            this.txtSaved.TabIndex = 13;
            this.txtSaved.TextChanged += new System.EventHandler(this.txtSaved_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 252);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.cbLists);
            this.splitContainer1.Panel1.Controls.Add(this.chkAll);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemove);
            this.splitContainer1.Panel2.Controls.Add(this.btnBotStop);
            this.splitContainer1.Panel2.Controls.Add(this.btnBotStart);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(238, 75);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 149;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnDown);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(116, 22);
            this.panel3.TabIndex = 148;
            // 
            // btnDown
            // 
            this.btnDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(0, 0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(116, 22);
            this.btnDown.TabIndex = 166;
            this.btnDown.Text = "▼";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // cbLists
            // 
            this.cbLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLists.FormattingEnabled = true;
            this.cbLists.Items.AddRange(new object[] {
            "Commands",
            "Skills",
            "Quests",
            "Drops",
            "Boosts",
            "Items"});
            this.cbLists.Location = new System.Drawing.Point(1, 51);
            this.cbLists.Name = "cbLists";
            this.cbLists.Size = new System.Drawing.Size(115, 21);
            this.cbLists.TabIndex = 169;
            this.cbLists.SelectedIndexChanged += new System.EventHandler(this.cbLists_SelectedIndexChanged);
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(79, 29);
            this.chkAll.Name = "chkAll";
            this.chkAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAll.Size = new System.Drawing.Size(36, 17);
            this.chkAll.TabIndex = 168;
            this.chkAll.Text = "all";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(0, 26);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 22);
            this.btnClear.TabIndex = 167;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 22);
            this.panel2.TabIndex = 147;
            // 
            // btnUp
            // 
            this.btnUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(0, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(116, 22);
            this.btnUp.TabIndex = 165;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemove.Location = new System.Drawing.Point(1, 25);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(115, 22);
            this.btnRemove.TabIndex = 166;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnBotStop
            // 
            this.btnBotStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBotStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBotStop.Location = new System.Drawing.Point(1, 50);
            this.btnBotStop.Name = "btnBotStop";
            this.btnBotStop.Size = new System.Drawing.Size(115, 22);
            this.btnBotStop.TabIndex = 168;
            this.btnBotStop.Text = "Stop";
            this.btnBotStop.UseVisualStyleBackColor = true;
            this.btnBotStop.Visible = false;
            this.btnBotStop.Click += new System.EventHandler(this.btnBotStop_Click);
            // 
            // btnBotStart
            // 
            this.btnBotStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBotStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBotStart.Location = new System.Drawing.Point(1, 50);
            this.btnBotStart.Name = "btnBotStart";
            this.btnBotStart.Size = new System.Drawing.Size(115, 22);
            this.btnBotStart.TabIndex = 167;
            this.btnBotStart.Text = "Start";
            this.btnBotStart.UseVisualStyleBackColor = true;
            this.btnBotStart.Click += new System.EventHandler(this.btnBotStart_ClickAsync);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.lstCommands);
            this.panel1.Controls.Add(this.lstDrops);
            this.panel1.Controls.Add(this.lstBoosts);
            this.panel1.Controls.Add(this.lstQuests);
            this.panel1.Controls.Add(this.lstSkills);
            this.panel1.Controls.Add(this.lstItems);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 325);
            this.panel1.TabIndex = 150;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(7, 7);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1MinSize = 30;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(694, 325);
            this.splitContainer2.SplitterDistance = 238;
            this.splitContainer2.TabIndex = 150;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(150, 184);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 158;
            this.checkBox1.Text = "Placeholder";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkBuffup
            // 
            this.chkBuffup.Location = new System.Drawing.Point(0, 0);
            this.chkBuffup.Name = "chkBuffup";
            this.chkBuffup.Size = new System.Drawing.Size(104, 24);
            this.chkBuffup.TabIndex = 0;
            // 
            // BotManagerMenuStrip
            // 
            this.BotManagerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeFontsToolStripMenuItem,
            this.multilineToggleToolStripMenuItem,
            this.toggleTabpagesToolStripMenuItem,
            this.commandColorsToolStripMenuItem});
            this.BotManagerMenuStrip.Name = "contextMenuStrip1";
            this.BotManagerMenuStrip.Size = new System.Drawing.Size(195, 92);
            // 
            // changeFontsToolStripMenuItem
            // 
            this.changeFontsToolStripMenuItem.Name = "changeFontsToolStripMenuItem";
            this.changeFontsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.changeFontsToolStripMenuItem.Text = "Change Fonts";
            this.changeFontsToolStripMenuItem.Click += new System.EventHandler(this.changeFontsToolStripMenuItem_Click);
            // 
            // multilineToggleToolStripMenuItem
            // 
            this.multilineToggleToolStripMenuItem.Name = "multilineToggleToolStripMenuItem";
            this.multilineToggleToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.multilineToggleToolStripMenuItem.Text = "Multiline Toggle";
            this.multilineToggleToolStripMenuItem.Click += new System.EventHandler(this.multilineToggleToolStripMenuItem_Click);
            // 
            // toggleTabpagesToolStripMenuItem
            // 
            this.toggleTabpagesToolStripMenuItem.Name = "toggleTabpagesToolStripMenuItem";
            this.toggleTabpagesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.toggleTabpagesToolStripMenuItem.Text = "Toggle Tabpages";
            this.toggleTabpagesToolStripMenuItem.Click += new System.EventHandler(this.toggleTabpagesToolStripMenuItem_Click);
            // 
            // commandColorsToolStripMenuItem
            // 
            this.commandColorsToolStripMenuItem.Name = "commandColorsToolStripMenuItem";
            this.commandColorsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.commandColorsToolStripMenuItem.Text = "Command Customizer";
            this.commandColorsToolStripMenuItem.Click += new System.EventHandler(this.commandColorsToolStripMenuItem_Click);
            // 
            // BotManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(708, 339);
            this.ContextMenuStrip = this.BotManagerMenuStrip;
            this.Controls.Add(this.splitContainer2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BotManager";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Bot";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BotManager_FormClosing);
            this.Load += new System.EventHandler(this.BotManager_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabCombat.ResumeLayout(false);
            this.pnlCombat.ResumeLayout(false);
            this.pnlCombat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRestMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkillD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).EndInit();
            this.tabItem.ResumeLayout(false);
            this.pnlItem.ResumeLayout(false);
            this.pnlItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDropDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShopId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapItem)).EndInit();
            this.tabMap.ResumeLayout(false);
            this.pnlMap.ResumeLayout(false);
            this.pnlMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkX)).EndInit();
            this.tabQuest.ResumeLayout(false);
            this.pnlQuest.ResumeLayout(false);
            this.pnlQuest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEnsureTries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestID)).EndInit();
            this.tabMisc.ResumeLayout(false);
            this.pnlMisc.ResumeLayout(false);
            this.pnlMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetInt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIndexCmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeepTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBotDelay)).EndInit();
            this.tabOptions.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOptionsTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeed)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRelogDelay)).EndInit();
            this.tabOptions2.ResumeLayout(false);
            this.tabOptions2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetLevel)).EndInit();
            this.grpAccessLevel.ResumeLayout(false);
            this.grpAccessLevel.PerformLayout();
            this.grpAlignment.ResumeLayout(false);
            this.tabBots.ResumeLayout(false);
            this.pnlSaved.ResumeLayout(false);
            this.pnlSaved.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.BotManagerMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        static BotManager()
        {
            Instance = new BotManager();
            Log = new LogForm();
        }

        private void btnBuyFast_Click(object sender, EventArgs e)
        {
            if (txtShopItem.TextLength > 0)
            {
                AddCommand(new CmdBuyFast
                {
                    ItemName = txtShopItem.Text
                }, (ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnLoadShop_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdLoad
            {
                ShopId = (int)numShopId.Value
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        public void changeGenderAsync(object sender, EventArgs e)
        {
            int num = Flash.Call<int>("UserID", new string[0]);
            string text = Flash.Call<string>("Gender", new string[0]);
            text = (!text.Contains("M")) ? "M" : "F";
            string data = $"{{\"t\":\"xt\",\"b\":{{\"r\":-1,\"o\":{{\"cmd\":\"genderSwap\",\"bitSuccess\":1,\"gender\":\"{text}\",\"intCoins\":0,\"uid\":\"{num}\",\"strHairFileName\":\"\",\"HairID\":\"\",\"strHairName\":\"\"}}}}}}";
            Proxy.Instance.SendToClient(data);
        }

        private void logScript(object sender, EventArgs e)
        {
            AddCommand(new CmdLog
            {
                Text = txtLog.Text
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void logDebug(object sender, EventArgs e)
        {
            AddCommand(new CmdLog
            {
                Text = txtLog.Text,
                Debug = true
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogForm.Instance.Show();
            LogForm.Instance.BringToFront();
        }

        private void btnYulgar_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdYulgar(), (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnProvoke_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdToggleProvoke
            {
                Type = 2
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnchangeName_Click(object sender, EventArgs e)
        {
            foreach (string n in Configuration.BlockedPlayers)
            {
                if (txtUsername.Text.ToLower() == n)
                {
                    Environment.Exit(0);
                }
            }
            CustomName = txtUsername.Text;
        }

        private void btnchangeGuild_Click(object sender, EventArgs e)
        {
            foreach (string n in Configuration.BlockedPlayers)
            {
                if (txtUsername.Text.ToLower() == n)
                {
                    Environment.Exit(0);
                }
            }
            CustomGuild = txtGuild.Text;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Join Discord", "discord.gg/aqwbots", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnProvokeOn_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdToggleProvoke
            {
                Type = 1
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnProvokeOff_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdToggleProvoke
            {
                Type = 0
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        public void AddItem(string Name)
        {
            if (!lstItems.Items.Contains(Name))
            {
                lstItems.Items.Add(Name);
            }
        }

        private void btnUnbanklst_Click(object sender, EventArgs e)
        {
            string text = txtWhitelist.Text;
            if (text.Length > 0)
            {
                AddItem(text);
            }
        }

        private void chkPacket_CheckChanged(object sender, EventArgs e)
        {
            OptionsManager.Packet = chkPacket.Checked;
        }

        private void lstLogText_KeyDown(object sender, KeyEventArgs e)
        {
            bool flag = e.Control && e.KeyCode == Keys.C;
            if (flag)
            {
                string data = this.lstLogText.SelectedItem.ToString();
                Clipboard.SetData(DataFormats.StringFormat, data);
            }
        }

        private void numOptionsTimer_ValueChanged(object sender, EventArgs e)
        {
            OptionsManager.Timer = (int)numOptionsTimer.Value;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabBots)
            {
                this.txtSaved.Text = Path.Combine(Application.StartupPath, "Bots");
                UpdateTree();
            }
        }

        private void txtSaved_TextChanged(object sender, EventArgs e)
        {
            UpdateTree();
        }

        private void chkEnsureComplete_CheckedChanged(object sender, EventArgs e)
        {
            bool chk = chkEnsureComplete.Checked;
            numEnsureTries.Enabled = chk;
        }

        private void lstLogText_DoubleClick(object sender, EventArgs e)
        {
            string data = this.txtLog.Text == "Logs" ? "" : txtLog.Text + " ";
            string data2 = this.lstLogText.SelectedItem.ToString();
            this.txtLog.Text = $"{data}{data2}";
        }

        public void MultiMode()
        {
            if (this.lstCommands.SelectionMode != SelectionMode.MultiExtended)
            {
                this.lstCommands.SelectionMode = SelectionMode.MultiExtended;
                this.lstItems.SelectionMode = SelectionMode.MultiExtended;
                this.lstSkills.SelectionMode = SelectionMode.MultiExtended;
                this.lstQuests.SelectionMode = SelectionMode.MultiExtended;
                this.lstDrops.SelectionMode = SelectionMode.MultiExtended;
                this.lstBoosts.SelectionMode = SelectionMode.MultiExtended;
            }
            else
            {
                this.lstCommands.SelectionMode = SelectionMode.One;
                this.lstItems.SelectionMode = SelectionMode.One;
                this.lstSkills.SelectionMode = SelectionMode.One;
                this.lstQuests.SelectionMode = SelectionMode.One;
                this.lstDrops.SelectionMode = SelectionMode.One;
                this.lstBoosts.SelectionMode = SelectionMode.One;
            }
        }

        private void chkUntarget_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.Untarget = chkUntarget.Checked;
        }

        private void lstCommands_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void lstCommands_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lstCommands_Click(object sender, EventArgs e)
        {
            
        }

        private void lstCommands_MouseEnter(object sender, EventArgs e)
        {
            if (lstCommands.Items.Count <= 0)
            {
                Color c1 = lstCommands.BackColor;
                Color c2 = Color.FromArgb(c1.A, (int)(c1.R * 0.8), (int)(c1.G * 0.8), (int)(c1.B * 0.8));
                lstCommands.BackColor = c2;
            }
        }

        private void lstCommands_MouseLeave(object sender, EventArgs e)
        {
            lstCommands.BackColor = DefaultBackColor;
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdBlank2 { Text = " " }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void chkAFK_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.AFK = chkAFK.Checked;
        }

        private void chkRelog_CheckedChanged(object sender, EventArgs e)
        {
            this.chkAFK.Enabled = chkRelog.Checked;
        }

        private void btnCurrBlank_Click(object sender, EventArgs e)
        {
            this.txtJoinCell.Text = "Blank";
            this.txtJoinPad.Text = "Satan";
            this.txtCell.Text = "Blank";
            this.txtPad.Text = "Satan";
        }
        private void btnSetSpawn_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdSetSpawn(), (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnBeep_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdBeep
            {
                Times = (int)numBeepTimes.Value
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnAddSkillCmd_Click(object sender, EventArgs e)
        {
            string text = numSkill.Text;
            AddCommand(new CmdUseSkill
            {
                Index = text,
                SafeHp = (int)this.numSafe.Value,
                SafeMp = (int)this.numSafe.Value,
                Wait = this.chkSkillCD.Checked,
                Skill = text + ": " + Skill.GetSkillName(text)
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void chkBuffup_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.Buff = chkBuffup.Checked;
        }

        private void btnSetHero_Click(object sender, EventArgs e)
        {
#pragma warning disable CS4014 // Because this call is not awaited
            Button s = (Button)sender;
            switch(s.Name)
            {
                case "btnSetGood":
                    Proxy.Instance.SendToServer("%xt%zm%updateQuest%218701%41%1%");
                    break;
                case "btnSetEvil":
                    Proxy.Instance.SendToServer("%xt%zm%updateQuest%218701%41%2%");
                    break;
                case "btnSetChaos":
                    Proxy.Instance.SendToServer("%xt%zm%updateQuest%218701%41%3%");
                    break;
                case "btnSetUndecided":
                    Proxy.Instance.SendToServer("%xt%zm%updateQuest%218701%41%5%");
                    break;
                case "btnSetMem":
                    Player.ChangeAccessLevel("Member");
                    break;
                case "btnSetNonMem":
                    Player.ChangeAccessLevel("Non Member");
                    break;
                case "btnSetModerator":
                    Player.ChangeAccessLevel("Moderator");
                    break;
            } 
#pragma warning restore CS4014 // Because this call is not awaited
        }

        private void chkToggleMute_CheckedChanged(object sender, EventArgs e)
        {
            Player.ToggleMute(chkToggleMute.Checked);
        }

        private void changeFontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fdlg = new FontDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                this.Font = new Font(fdlg.Font.FontFamily, fdlg.Font.Size, FontStyle.Regular, GraphicsUnit.Point, 0);
                foreach (Control control in this.Controls)
                {
                    control.Font = new Font(fdlg.Font.FontFamily, fdlg.Font.Size, FontStyle.Regular, GraphicsUnit.Point, 0);
                }
                var selectedOption = MessageBox.Show("Would you like to Save style and have it load on the next startup?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (selectedOption == DialogResult.Yes)
                {
                    Config c = Config.Load(Application.StartupPath + "\\config.cfg");
                    c.Set("font", fdlg.Font.FontFamily.Name.ToString());
                    c.Set("fontSize", fdlg.Font.Size.ToString());
                    c.Save();
                }
            }
        }

        private void numDropDelay_ValueChanged(object sender, EventArgs e)
        {
            Bot.Instance.DropDelay = (int)numDropDelay.Value;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            string monster = string.IsNullOrEmpty(txtMonster.Text) ? "*" : txtMonster.Text;
            AddCommand(new CmdAttack
            {
                Monster = txtMonster.Text == "Monster (*  = random)" ? "*" : txtMonster.Text
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void chkBankOnStop_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Instance.BankOnStop = chkBankOnStop.Checked;
        }

        private void btnGotoIndex_Click(object sender, EventArgs e)
        {
            IBotCommand cmd;
            switch (((Button)sender).Text)
            {
                case "Up++":
                    cmd = new CmdIndex
                    {
                        Type = CmdIndex.IndexCommand.Up,
                        Index = (int)numIndexCmd.Value
                    };
                    break;
                case "Down--":
                    cmd = new CmdIndex
                    {
                        Type = CmdIndex.IndexCommand.Down,
                        Index = (int)numIndexCmd.Value
                    };
                    break;
                default:
                    cmd = new CmdIndex
                    {
                        Type = CmdIndex.IndexCommand.Goto,
                        Index = (int)numIndexCmd.Value
                    };
                    break;
            }
            AddCommand(cmd, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void TogglePages()
        {
            Size p1 = splitContainer2.Panel1.ClientSize;
            int p1w = splitContainer2.Panel1.ClientSize.Width;
            Size p2 = splitContainer2.Panel2.ClientSize;
            int p2w = splitContainer2.Panel2.ClientSize.Width;
            if (tabControl1.Visible)
            {
                this.ClientSize = new Size(p1w, ClientSize.Height);
                tabControl1.Visible = false;
                splitContainer2.Panel2Collapsed = true;
            }
            else
            {
                this.ClientSize = new Size(p1w + 500, ClientSize.Height);
                splitContainer2.Panel2Collapsed = false;
                tabControl1.Visible = true;
            }
        }

        private void lstCommands_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (!(e.Index > -1))
                return;
            e.DrawBackground();

            #region Settings
            IBotCommand cmd = (IBotCommand)lstCommands.Items[e.Index];
            string[] count = cmd.GetType().ToString().Split('.');
            string scmd = count[count.Count() - 1].Replace("Cmd", "");
            string WindowText = SystemColors.WindowText.ToArgb().ToString();
            SolidBrush color = new SolidBrush(Color.FromArgb(GetColor(scmd)));
            SolidBrush indexcolor = new SolidBrush(Color.FromArgb(GetColor(name: "Index")));
            RectangleF region = e.Bounds;
            Font font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Regular);
            StringFormat centered = new StringFormat()
            {
                    Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            #endregion

            string[] LabelLess = new string[]
            {
                "Label",
                "GotoLabel",
                "Blank",
                "Blank2",
                "StatementCommand",
                "Index",
                "SkillSet"
            };

            if (cmd is CmdBlank || cmd is CmdBlank2)
            {
                string txt = lstCommands.Items[e.Index].ToString();
                Font b2 = new Font("Arial", e.Font.Size + (float)6.5, FontStyle.Bold, GraphicsUnit.Pixel);
                if (cmd is CmdBlank2 && txt.Contains("[RGB]"))
                    using (Font the_font = new Font("Times New Roman", e.Font.Size + (float)6.5, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        var font_info = new FontInfo(e.Graphics, the_font);
                        SizeF text_size = e.Graphics.MeasureString(txt, the_font);
                        int x0 = (int)((this.ClientSize.Width - text_size.Width) / 2);
                        int y0 = (int)((this.ClientSize.Height - text_size.Height) / 2);
                        int brush_y0 = (int)(y0 + font_info.InternalLeadingPixels) + (int)font_info.InternalLeadingPixels;
                        int brush_y1 = (int)(y0 + font_info.AscentPixels) + 5;
                        using (LinearGradientBrush rainbowbrush = new LinearGradientBrush(new Point(x0, brush_y0), new Point(x0, brush_y1), Color.Red, Color.Violet))
                        {
                            Color[] colors = new Color[]
                            {
                                Color.FromArgb(255, 0, 0),
                                Color.FromArgb(255, 0, 0),
                                Color.FromArgb(255, 128, 0),
                                Color.FromArgb(255, 255, 0),
                                Color.FromArgb(0, 255, 0),
                                Color.FromArgb(0, 255, 128),
                                Color.FromArgb(0, 255, 255),
                                Color.FromArgb(0, 128, 255),
                                Color.FromArgb(0, 0, 255),
                                Color.FromArgb(0, 0, 255),
                            };
                            int num_colors = colors.Length;
                            float[] blend_positions = new float[num_colors];
                            for (int i = 0; i < num_colors; i++)
                                blend_positions[i] = i / (num_colors - 1f);
                            ColorBlend color_blend = new ColorBlend
                            {
                                Colors = colors,
                                Positions = blend_positions
                            };
                            rainbowbrush.InterpolationColors = color_blend;

                            // Draw the text.
                            txt = txt.Replace("[RGB]", "");
                            e.Graphics.DrawString(txt, the_font, rainbowbrush, e.Bounds, centered);
                        }
                    }
                else if(cmd is CmdBlank2 && txt.StartsWith("["))
                {
                    try
                    {
                        string[] rgbarray = txt.Replace("[", "").Split(']')[0].Split(',');
                        SolidBrush b2b = new SolidBrush(Color.FromArgb(int.Parse(rgbarray[0]), int.Parse(rgbarray[1]), int.Parse(rgbarray[2])));
                        txt = Regex.Replace(txt, @"\[.*?\]", "");
                        if (txt.Contains("(TROLL)"))
                        {
                            e.Graphics.DrawString(txt.Replace("(TROLL)", ""), e.Font, b2b, e.Bounds, StringFormat.GenericDefault);
                        }
                        else
                        {
                            e.Graphics.DrawString(txt, b2, b2b, e.Bounds, centered);
                        }
                    }catch{}
                }
                else if (txt.Contains("(TROLL)"))
                {
                    e.Graphics.DrawString(txt.Replace("(TROLL)", ""), e.Font, new SolidBrush(Color.White), e.Bounds, StringFormat.GenericDefault);
                }
                return;
            }

            if (!LabelLess.Contains(scmd))
            {
                //Draw Index
                //Region first = DrawString(e.Graphics, $"[{e.Index.ToString()}] ", this.Font, indexcolor, region, new StringFormat(StringFormatFlags.DirectionRightToLeft));
                Region first = DrawString(e.Graphics, $"[{e.Index.ToString()}] ", font, indexcolor, region, StringFormat.GenericDefault);
                // Adjust the region we wish to print with a +3 offset.
                region = new RectangleF(region.X + first.GetBounds(e.Graphics).Width + 3, region.Y, region.Width, region.Height);
            }

            if (GetBoolCentered(scmd))
            {
                e.Graphics.DrawString(lstCommands.Items[e.Index].ToString(), font, color, e.Bounds, centered);
                return;
            }

            // Draw the second string (rest of the string, in this case Command text).
            DrawString(e.Graphics, lstCommands.Items[e.Index].ToString(), font, color, region, StringFormat.GenericDefault);
        }

        private int GetColor(string name)
        {
            Config c = Config.Load(Application.StartupPath + "\\config.cfg");
            string WindowText = SystemColors.WindowText.ToArgb().ToString("X");
            return int.Parse(c.Get(name + "Color") ?? WindowText, System.Globalization.NumberStyles.HexNumber);
        }

        private bool GetBoolCentered(string name)
        {
            Config c = Config.Load(Application.StartupPath + "\\config.cfg");
            return bool.Parse(c.Get(name + "Centered") ?? "false");
        }

        private Region DrawString(Graphics g, string s, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format)
        {
            format.SetMeasurableCharacterRanges(new[] { new CharacterRange(0, s.Length) });
            format.Alignment = StringAlignment.Near;
            g.DrawString(s, font, brush, layoutRectangle, format);
            return g.MeasureCharacterRanges(s, font, layoutRectangle, format)[0];
        }

        private Region DrawRTLString(Graphics g, string s, Font font, Brush brush, RectangleF layoutRectangle)
        {
            var format = new StringFormat()
            {
                Alignment = StringAlignment.Near,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };
            format.SetMeasurableCharacterRanges(new[] { new CharacterRange(0, s.Length) });
            //g.DrawString(s, font, brush, layoutRectangle, format);
            Region length = g.MeasureCharacterRanges(s, font, layoutRectangle, format)[0];
            layoutRectangle = new RectangleF(layoutRectangle.Width, layoutRectangle.Y, length.GetBounds(g).Width, layoutRectangle.Height);
            DrawString(g, s, font, brush, layoutRectangle, format);
            return length;
        }

        private void multilineToggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiMode();
        }

        private void toggleTabpagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePages();
        }

        private void commandColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Root.Instance.ShowForm(CommandColorForm.Instance);
        }

        private void btnChangeCmd_Click(object sender, EventArgs e)
        {
            IBotCommand cmd;
            switch(((Button)sender).Name)
            {
                case "btnChangeGuildCmd":
                    cmd = new CmdChange
                    {
                        Guild = true,
                        Text = txtGuild.Text
                    };
                    break;
                default:
                    cmd = new CmdChange
                    {
                        Guild = false,
                        Text = txtUsername.Text
                    };
                    break;
            }
            AddCommand(cmd, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void chkAntiAfk_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.AFK2 = chkAntiAfk.Checked;
        }

        private void treeBots_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void chkChangeRoomTag_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.HideRoom = chkChangeRoomTag.Checked;
        }

        private void chkChangeChat_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.ChangeChat = chkChangeChat.Checked;
        }

        private void chkSetJoinLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetJoinLevel.Checked)
                OptionsManager.SetLevelOnJoin = (int)numSetLevel.Value;
            else
                OptionsManager.SetLevelOnJoin = null;
        }

        private void btnClientPacket_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdPacket
            {
                Packet = txtPacket.Text,
                Client = true
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void chkHideYulgarPlayers_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.HideYulgar = chkHideYulgarPlayers.Checked;
        }

        private void btnSetInt_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdInt
            {
                Int = txtSetInt.Text,
                Value = (int)numSetInt.Value,
                type = CmdInt.Types.Set
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnIncreaseInt_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdInt
            {
                Int = txtSetInt.Text,
                Value = (int)numSetInt.Value,
                type = CmdInt.Types.Upper
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnDecreaseInt_Click(object sender, EventArgs e)
        {
            AddCommand(new CmdInt
            {
                Int = txtSetInt.Text,
                Value = (int)numSetInt.Value,
                type = CmdInt.Types.Lower
            }, (ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void lstCommands_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}