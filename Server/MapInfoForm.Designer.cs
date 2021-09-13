using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Server
{
    partial class MapInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.MapTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.BigMapTextBox = new System.Windows.Forms.TextBox();
            this.LightsComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MapIndexTextBox = new System.Windows.Forms.TextBox();
            this.MiniMapTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MapNameTextBox = new System.Windows.Forms.TextBox();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RemoveSZButton = new System.Windows.Forms.Button();
            this.AddSZButton = new System.Windows.Forms.Button();
            this.SafeZoneInfoPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.SZYTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.SZXTextBox = new System.Windows.Forms.TextBox();
            this.StartPointCheckBox = new System.Windows.Forms.CheckBox();
            this.SafeZoneInfoListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RPasteButton = new System.Windows.Forms.Button();
            this.RCopyButton = new System.Windows.Forms.Button();
            this.RemoveRButton = new System.Windows.Forms.Button();
            this.AddRButton = new System.Windows.Forms.Button();
            this.RespawnInfoListBox = new System.Windows.Forms.ListBox();
            this.RespawnInfoPanel = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.DirectionTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DelayTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MonsterInfoComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SpreadTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RYTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CountTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RXTextBox = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.RemoveMButton = new System.Windows.Forms.Button();
            this.AddMButton = new System.Windows.Forms.Button();
            this.MovementInfoPanel = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.DestMapComboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.DestYTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.DestXTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SourceYTextBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.SourceXTextBox = new System.Windows.Forms.TextBox();
            this.MovementInfoListBox = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.RemoveNButton = new System.Windows.Forms.Button();
            this.AddNButton = new System.Windows.Forms.Button();
            this.NPCInfoPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.NFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.NRateTextBox = new System.Windows.Forms.TextBox();
            this.ClearHButton = new System.Windows.Forms.Button();
            this.NNameTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.NImageTextBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.NYTextBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.NXTextBox = new System.Windows.Forms.TextBox();
            this.NPCInfoListBox = new System.Windows.Forms.ListBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.MapInfoListBox = new System.Windows.Forms.ListBox();
            this.PasteMapButton = new System.Windows.Forms.Button();
            this.CopyMapButton = new System.Windows.Forms.Button();
            this.MapTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SafeZoneInfoPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.RespawnInfoPanel.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.MovementInfoPanel.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.NPCInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapTabs
            // 
            this.MapTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapTabs.Controls.Add(this.tabPage1);
            this.MapTabs.Controls.Add(this.tabPage3);
            this.MapTabs.Controls.Add(this.tabPage2);
            this.MapTabs.Controls.Add(this.tabPage4);
            this.MapTabs.Controls.Add(this.tabPage5);
            this.MapTabs.Location = new System.Drawing.Point(207, 41);
            this.MapTabs.Name = "MapTabs";
            this.MapTabs.SelectedIndex = 0;
            this.MapTabs.Size = new System.Drawing.Size(524, 201);
            this.MapTabs.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.BigMapTextBox);
            this.tabPage1.Controls.Add(this.LightsComboBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.MapIndexTextBox);
            this.tabPage1.Controls.Add(this.MiniMapTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.MapNameTextBox);
            this.tabPage1.Controls.Add(this.FileNameTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(516, 175);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(129, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Big Map:";
            // 
            // BigMapTextBox
            // 
            this.BigMapTextBox.Location = new System.Drawing.Point(184, 96);
            this.BigMapTextBox.MaxLength = 5;
            this.BigMapTextBox.Name = "BigMapTextBox";
            this.BigMapTextBox.Size = new System.Drawing.Size(37, 20);
            this.BigMapTextBox.TabIndex = 13;
            this.BigMapTextBox.TextChanged += new System.EventHandler(this.BigMapTextBox_TextChanged);
            // 
            // LightsComboBox
            // 
            this.LightsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LightsComboBox.FormattingEnabled = true;
            this.LightsComboBox.Location = new System.Drawing.Point(82, 122);
            this.LightsComboBox.Name = "LightsComboBox";
            this.LightsComboBox.Size = new System.Drawing.Size(92, 21);
            this.LightsComboBox.TabIndex = 11;
            this.LightsComboBox.SelectedIndexChanged += new System.EventHandler(this.LightsComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Lights:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Map Index:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mini Map:";
            // 
            // MapIndexTextBox
            // 
            this.MapIndexTextBox.Location = new System.Drawing.Point(82, 15);
            this.MapIndexTextBox.Name = "MapIndexTextBox";
            this.MapIndexTextBox.ReadOnly = true;
            this.MapIndexTextBox.Size = new System.Drawing.Size(47, 20);
            this.MapIndexTextBox.TabIndex = 0;
            // 
            // MiniMapTextBox
            // 
            this.MiniMapTextBox.Location = new System.Drawing.Point(82, 96);
            this.MiniMapTextBox.MaxLength = 5;
            this.MiniMapTextBox.Name = "MiniMapTextBox";
            this.MiniMapTextBox.Size = new System.Drawing.Size(37, 20);
            this.MiniMapTextBox.TabIndex = 9;
            this.MiniMapTextBox.TextChanged += new System.EventHandler(this.MiniMapTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "File Name:";
            // 
            // MapNameTextBox
            // 
            this.MapNameTextBox.Location = new System.Drawing.Point(82, 70);
            this.MapNameTextBox.Name = "MapNameTextBox";
            this.MapNameTextBox.Size = new System.Drawing.Size(92, 20);
            this.MapNameTextBox.TabIndex = 2;
            this.MapNameTextBox.TextChanged += new System.EventHandler(this.MapNameTextBox_TextChanged);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(82, 44);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(47, 20);
            this.FileNameTextBox.TabIndex = 1;
            this.FileNameTextBox.TextChanged += new System.EventHandler(this.FileNameTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Map Name:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RemoveSZButton);
            this.tabPage3.Controls.Add(this.AddSZButton);
            this.tabPage3.Controls.Add(this.SafeZoneInfoPanel);
            this.tabPage3.Controls.Add(this.SafeZoneInfoListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(516, 175);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Safe Zones";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RemoveSZButton
            // 
            this.RemoveSZButton.Location = new System.Drawing.Point(108, 6);
            this.RemoveSZButton.Name = "RemoveSZButton";
            this.RemoveSZButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveSZButton.TabIndex = 8;
            this.RemoveSZButton.Text = "Remove";
            this.RemoveSZButton.UseVisualStyleBackColor = true;
            this.RemoveSZButton.Click += new System.EventHandler(this.RemoveSZButton_Click);
            // 
            // AddSZButton
            // 
            this.AddSZButton.Location = new System.Drawing.Point(6, 6);
            this.AddSZButton.Name = "AddSZButton";
            this.AddSZButton.Size = new System.Drawing.Size(75, 23);
            this.AddSZButton.TabIndex = 7;
            this.AddSZButton.Text = "Add";
            this.AddSZButton.UseVisualStyleBackColor = true;
            this.AddSZButton.Click += new System.EventHandler(this.AddSZButton_Click);
            // 
            // SafeZoneInfoPanel
            // 
            this.SafeZoneInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SafeZoneInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SafeZoneInfoPanel.Controls.Add(this.label12);
            this.SafeZoneInfoPanel.Controls.Add(this.SZYTextBox);
            this.SafeZoneInfoPanel.Controls.Add(this.label14);
            this.SafeZoneInfoPanel.Controls.Add(this.SizeTextBox);
            this.SafeZoneInfoPanel.Controls.Add(this.label17);
            this.SafeZoneInfoPanel.Controls.Add(this.SZXTextBox);
            this.SafeZoneInfoPanel.Controls.Add(this.StartPointCheckBox);
            this.SafeZoneInfoPanel.Enabled = false;
            this.SafeZoneInfoPanel.Location = new System.Drawing.Point(189, 35);
            this.SafeZoneInfoPanel.Name = "SafeZoneInfoPanel";
            this.SafeZoneInfoPanel.Size = new System.Drawing.Size(212, 134);
            this.SafeZoneInfoPanel.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Y:";
            // 
            // SZYTextBox
            // 
            this.SZYTextBox.Location = new System.Drawing.Point(147, 22);
            this.SZYTextBox.MaxLength = 5;
            this.SZYTextBox.Name = "SZYTextBox";
            this.SZYTextBox.Size = new System.Drawing.Size(37, 20);
            this.SZYTextBox.TabIndex = 3;
            this.SZYTextBox.TextChanged += new System.EventHandler(this.SZYTextBox_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Size:";
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Location = new System.Drawing.Point(61, 48);
            this.SizeTextBox.MaxLength = 5;
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(37, 20);
            this.SizeTextBox.TabIndex = 4;
            this.SizeTextBox.TextChanged += new System.EventHandler(this.SizeTextBox_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(38, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "X:";
            // 
            // SZXTextBox
            // 
            this.SZXTextBox.Location = new System.Drawing.Point(61, 22);
            this.SZXTextBox.MaxLength = 5;
            this.SZXTextBox.Name = "SZXTextBox";
            this.SZXTextBox.Size = new System.Drawing.Size(37, 20);
            this.SZXTextBox.TabIndex = 2;
            this.SZXTextBox.TextChanged += new System.EventHandler(this.SZXTextBox_TextChanged);
            // 
            // StartPointCheckBox
            // 
            this.StartPointCheckBox.AutoSize = true;
            this.StartPointCheckBox.Location = new System.Drawing.Point(61, 89);
            this.StartPointCheckBox.Name = "StartPointCheckBox";
            this.StartPointCheckBox.Size = new System.Drawing.Size(75, 17);
            this.StartPointCheckBox.TabIndex = 5;
            this.StartPointCheckBox.Text = "Start Point";
            this.StartPointCheckBox.UseVisualStyleBackColor = true;
            this.StartPointCheckBox.CheckedChanged += new System.EventHandler(this.StartPointCheckBox_CheckedChanged);
            // 
            // SafeZoneInfoListBox
            // 
            this.SafeZoneInfoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SafeZoneInfoListBox.FormattingEnabled = true;
            this.SafeZoneInfoListBox.Location = new System.Drawing.Point(6, 35);
            this.SafeZoneInfoListBox.Name = "SafeZoneInfoListBox";
            this.SafeZoneInfoListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SafeZoneInfoListBox.Size = new System.Drawing.Size(177, 134);
            this.SafeZoneInfoListBox.TabIndex = 9;
            this.SafeZoneInfoListBox.SelectedIndexChanged += new System.EventHandler(this.SafeZoneInfoListBox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RPasteButton);
            this.tabPage2.Controls.Add(this.RCopyButton);
            this.tabPage2.Controls.Add(this.RemoveRButton);
            this.tabPage2.Controls.Add(this.AddRButton);
            this.tabPage2.Controls.Add(this.RespawnInfoListBox);
            this.tabPage2.Controls.Add(this.RespawnInfoPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(516, 175);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Respawns";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RPasteButton
            // 
            this.RPasteButton.Location = new System.Drawing.Point(270, 6);
            this.RPasteButton.Name = "RPasteButton";
            this.RPasteButton.Size = new System.Drawing.Size(75, 23);
            this.RPasteButton.TabIndex = 22;
            this.RPasteButton.Text = "Paste";
            this.RPasteButton.UseVisualStyleBackColor = true;
            this.RPasteButton.Click += new System.EventHandler(this.RPasteButton_Click);
            // 
            // RCopyButton
            // 
            this.RCopyButton.Location = new System.Drawing.Point(189, 6);
            this.RCopyButton.Name = "RCopyButton";
            this.RCopyButton.Size = new System.Drawing.Size(75, 23);
            this.RCopyButton.TabIndex = 21;
            this.RCopyButton.Text = "Copy";
            this.RCopyButton.UseVisualStyleBackColor = true;
            // 
            // RemoveRButton
            // 
            this.RemoveRButton.Location = new System.Drawing.Point(108, 6);
            this.RemoveRButton.Name = "RemoveRButton";
            this.RemoveRButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveRButton.TabIndex = 16;
            this.RemoveRButton.Text = "Remove";
            this.RemoveRButton.UseVisualStyleBackColor = true;
            this.RemoveRButton.Click += new System.EventHandler(this.RemoveRButton_Click);
            // 
            // AddRButton
            // 
            this.AddRButton.Location = new System.Drawing.Point(6, 6);
            this.AddRButton.Name = "AddRButton";
            this.AddRButton.Size = new System.Drawing.Size(75, 23);
            this.AddRButton.TabIndex = 15;
            this.AddRButton.Text = "Add";
            this.AddRButton.UseVisualStyleBackColor = true;
            this.AddRButton.Click += new System.EventHandler(this.AddRButton_Click);
            // 
            // RespawnInfoListBox
            // 
            this.RespawnInfoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RespawnInfoListBox.FormattingEnabled = true;
            this.RespawnInfoListBox.Location = new System.Drawing.Point(6, 35);
            this.RespawnInfoListBox.Name = "RespawnInfoListBox";
            this.RespawnInfoListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.RespawnInfoListBox.Size = new System.Drawing.Size(260, 134);
            this.RespawnInfoListBox.TabIndex = 14;
            this.RespawnInfoListBox.SelectedIndexChanged += new System.EventHandler(this.RespawnInfoListBox_SelectedIndexChanged);
            // 
            // RespawnInfoPanel
            // 
            this.RespawnInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RespawnInfoPanel.Controls.Add(this.label24);
            this.RespawnInfoPanel.Controls.Add(this.DirectionTextBox);
            this.RespawnInfoPanel.Controls.Add(this.label8);
            this.RespawnInfoPanel.Controls.Add(this.DelayTextBox);
            this.RespawnInfoPanel.Controls.Add(this.label7);
            this.RespawnInfoPanel.Controls.Add(this.MonsterInfoComboBox);
            this.RespawnInfoPanel.Controls.Add(this.label6);
            this.RespawnInfoPanel.Controls.Add(this.SpreadTextBox);
            this.RespawnInfoPanel.Controls.Add(this.label9);
            this.RespawnInfoPanel.Controls.Add(this.RYTextBox);
            this.RespawnInfoPanel.Controls.Add(this.label10);
            this.RespawnInfoPanel.Controls.Add(this.CountTextBox);
            this.RespawnInfoPanel.Controls.Add(this.label13);
            this.RespawnInfoPanel.Controls.Add(this.RXTextBox);
            this.RespawnInfoPanel.Enabled = false;
            this.RespawnInfoPanel.Location = new System.Drawing.Point(272, 35);
            this.RespawnInfoPanel.Name = "RespawnInfoPanel";
            this.RespawnInfoPanel.Size = new System.Drawing.Size(238, 134);
            this.RespawnInfoPanel.TabIndex = 11;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(134, 95);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(18, 13);
            this.label24.TabIndex = 18;
            this.label24.Text = "D:";
            // 
            // DirectionTextBox
            // 
            this.DirectionTextBox.Location = new System.Drawing.Point(158, 92);
            this.DirectionTextBox.MaxLength = 5;
            this.DirectionTextBox.Name = "DirectionTextBox";
            this.DirectionTextBox.Size = new System.Drawing.Size(37, 20);
            this.DirectionTextBox.TabIndex = 17;
            this.DirectionTextBox.TextChanged += new System.EventHandler(this.DirectionTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Delay:";
            // 
            // DelayTextBox
            // 
            this.DelayTextBox.Location = new System.Drawing.Point(65, 92);
            this.DelayTextBox.MaxLength = 10;
            this.DelayTextBox.Multiline = true;
            this.DelayTextBox.Name = "DelayTextBox";
            this.DelayTextBox.Size = new System.Drawing.Size(62, 20);
            this.DelayTextBox.TabIndex = 15;
            this.DelayTextBox.TextChanged += new System.EventHandler(this.DelayTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Monster:";
            // 
            // MonsterInfoComboBox
            // 
            this.MonsterInfoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonsterInfoComboBox.FormattingEnabled = true;
            this.MonsterInfoComboBox.Location = new System.Drawing.Point(65, 13);
            this.MonsterInfoComboBox.Name = "MonsterInfoComboBox";
            this.MonsterInfoComboBox.Size = new System.Drawing.Size(130, 21);
            this.MonsterInfoComboBox.TabIndex = 13;
            this.MonsterInfoComboBox.SelectedIndexChanged += new System.EventHandler(this.MonsterInfoComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Spread:";
            // 
            // SpreadTextBox
            // 
            this.SpreadTextBox.Location = new System.Drawing.Point(158, 66);
            this.SpreadTextBox.MaxLength = 5;
            this.SpreadTextBox.Name = "SpreadTextBox";
            this.SpreadTextBox.Size = new System.Drawing.Size(37, 20);
            this.SpreadTextBox.TabIndex = 11;
            this.SpreadTextBox.TextChanged += new System.EventHandler(this.SpreadTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Y:";
            // 
            // RYTextBox
            // 
            this.RYTextBox.Location = new System.Drawing.Point(158, 40);
            this.RYTextBox.MaxLength = 5;
            this.RYTextBox.Name = "RYTextBox";
            this.RYTextBox.Size = new System.Drawing.Size(37, 20);
            this.RYTextBox.TabIndex = 3;
            this.RYTextBox.TextChanged += new System.EventHandler(this.RYTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Count:";
            // 
            // CountTextBox
            // 
            this.CountTextBox.Location = new System.Drawing.Point(65, 66);
            this.CountTextBox.MaxLength = 5;
            this.CountTextBox.Name = "CountTextBox";
            this.CountTextBox.Size = new System.Drawing.Size(37, 20);
            this.CountTextBox.TabIndex = 4;
            this.CountTextBox.TextChanged += new System.EventHandler(this.CountTextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "X:";
            // 
            // RXTextBox
            // 
            this.RXTextBox.Location = new System.Drawing.Point(65, 40);
            this.RXTextBox.MaxLength = 5;
            this.RXTextBox.Name = "RXTextBox";
            this.RXTextBox.Size = new System.Drawing.Size(37, 20);
            this.RXTextBox.TabIndex = 2;
            this.RXTextBox.TextChanged += new System.EventHandler(this.RXTextBox_TextChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.RemoveMButton);
            this.tabPage4.Controls.Add(this.AddMButton);
            this.tabPage4.Controls.Add(this.MovementInfoPanel);
            this.tabPage4.Controls.Add(this.MovementInfoListBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(516, 175);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Movements";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // RemoveMButton
            // 
            this.RemoveMButton.Location = new System.Drawing.Point(108, 6);
            this.RemoveMButton.Name = "RemoveMButton";
            this.RemoveMButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveMButton.TabIndex = 12;
            this.RemoveMButton.Text = "Remove";
            this.RemoveMButton.UseVisualStyleBackColor = true;
            this.RemoveMButton.Click += new System.EventHandler(this.RemoveMButton_Click);
            // 
            // AddMButton
            // 
            this.AddMButton.Location = new System.Drawing.Point(6, 6);
            this.AddMButton.Name = "AddMButton";
            this.AddMButton.Size = new System.Drawing.Size(75, 23);
            this.AddMButton.TabIndex = 11;
            this.AddMButton.Text = "Add";
            this.AddMButton.UseVisualStyleBackColor = true;
            this.AddMButton.Click += new System.EventHandler(this.AddMButton_Click);
            // 
            // MovementInfoPanel
            // 
            this.MovementInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MovementInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MovementInfoPanel.Controls.Add(this.label22);
            this.MovementInfoPanel.Controls.Add(this.DestMapComboBox);
            this.MovementInfoPanel.Controls.Add(this.label18);
            this.MovementInfoPanel.Controls.Add(this.DestYTextBox);
            this.MovementInfoPanel.Controls.Add(this.label21);
            this.MovementInfoPanel.Controls.Add(this.DestXTextBox);
            this.MovementInfoPanel.Controls.Add(this.label16);
            this.MovementInfoPanel.Controls.Add(this.SourceYTextBox);
            this.MovementInfoPanel.Controls.Add(this.label20);
            this.MovementInfoPanel.Controls.Add(this.SourceXTextBox);
            this.MovementInfoPanel.Enabled = false;
            this.MovementInfoPanel.Location = new System.Drawing.Point(239, 35);
            this.MovementInfoPanel.Name = "MovementInfoPanel";
            this.MovementInfoPanel.Size = new System.Drawing.Size(271, 134);
            this.MovementInfoPanel.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 58);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 16;
            this.label22.Text = "To Map:";
            // 
            // DestMapComboBox
            // 
            this.DestMapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DestMapComboBox.FormattingEnabled = true;
            this.DestMapComboBox.Location = new System.Drawing.Point(64, 55);
            this.DestMapComboBox.Name = "DestMapComboBox";
            this.DestMapComboBox.Size = new System.Drawing.Size(182, 21);
            this.DestMapComboBox.TabIndex = 15;
            this.DestMapComboBox.SelectedIndexChanged += new System.EventHandler(this.DestMapComboBox_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(118, 85);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 14;
            this.label18.Text = "To Y:";
            // 
            // DestYTextBox
            // 
            this.DestYTextBox.Location = new System.Drawing.Point(157, 82);
            this.DestYTextBox.MaxLength = 5;
            this.DestYTextBox.Name = "DestYTextBox";
            this.DestYTextBox.Size = new System.Drawing.Size(37, 20);
            this.DestYTextBox.TabIndex = 12;
            this.DestYTextBox.TextChanged += new System.EventHandler(this.DestYTextBox_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.label21.Location = new System.Drawing.Point(23, 85);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 13);
            this.label21.TabIndex = 13;
            this.label21.Text = "To X:";
            // 
            // DestXTextBox
            // 
            this.DestXTextBox.Location = new System.Drawing.Point(62, 82);
            this.DestXTextBox.MaxLength = 5;
            this.DestXTextBox.Name = "DestXTextBox";
            this.DestXTextBox.Size = new System.Drawing.Size(37, 20);
            this.DestXTextBox.TabIndex = 11;
            this.DestXTextBox.TextChanged += new System.EventHandler(this.DestXTextBox_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(108, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "From Y:";
            // 
            // SourceYTextBox
            // 
            this.SourceYTextBox.Location = new System.Drawing.Point(157, 29);
            this.SourceYTextBox.MaxLength = 5;
            this.SourceYTextBox.Name = "SourceYTextBox";
            this.SourceYTextBox.Size = new System.Drawing.Size(37, 20);
            this.SourceYTextBox.TabIndex = 3;
            this.SourceYTextBox.TextChanged += new System.EventHandler(this.SourceYTextBox_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "From X:";
            // 
            // SourceXTextBox
            // 
            this.SourceXTextBox.Location = new System.Drawing.Point(62, 29);
            this.SourceXTextBox.MaxLength = 5;
            this.SourceXTextBox.Name = "SourceXTextBox";
            this.SourceXTextBox.Size = new System.Drawing.Size(37, 20);
            this.SourceXTextBox.TabIndex = 2;
            this.SourceXTextBox.TextChanged += new System.EventHandler(this.SourceXTextBox_TextChanged);
            // 
            // MovementInfoListBox
            // 
            this.MovementInfoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MovementInfoListBox.FormattingEnabled = true;
            this.MovementInfoListBox.Location = new System.Drawing.Point(6, 35);
            this.MovementInfoListBox.Name = "MovementInfoListBox";
            this.MovementInfoListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.MovementInfoListBox.Size = new System.Drawing.Size(227, 134);
            this.MovementInfoListBox.TabIndex = 13;
            this.MovementInfoListBox.SelectedIndexChanged += new System.EventHandler(this.MovementInfoListBox_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.RemoveNButton);
            this.tabPage5.Controls.Add(this.AddNButton);
            this.tabPage5.Controls.Add(this.NPCInfoPanel);
            this.tabPage5.Controls.Add(this.NPCInfoListBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(516, 175);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "NPCs";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // RemoveNButton
            // 
            this.RemoveNButton.Location = new System.Drawing.Point(108, 6);
            this.RemoveNButton.Name = "RemoveNButton";
            this.RemoveNButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveNButton.TabIndex = 16;
            this.RemoveNButton.Text = "Remove";
            this.RemoveNButton.UseVisualStyleBackColor = true;
            this.RemoveNButton.Click += new System.EventHandler(this.RemoveNButton_Click);
            // 
            // AddNButton
            // 
            this.AddNButton.Location = new System.Drawing.Point(6, 6);
            this.AddNButton.Name = "AddNButton";
            this.AddNButton.Size = new System.Drawing.Size(75, 23);
            this.AddNButton.TabIndex = 15;
            this.AddNButton.Text = "Add";
            this.AddNButton.UseVisualStyleBackColor = true;
            this.AddNButton.Click += new System.EventHandler(this.AddNButton_Click);
            // 
            // NPCInfoPanel
            // 
            this.NPCInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NPCInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NPCInfoPanel.Controls.Add(this.label11);
            this.NPCInfoPanel.Controls.Add(this.NFileNameTextBox);
            this.NPCInfoPanel.Controls.Add(this.label29);
            this.NPCInfoPanel.Controls.Add(this.NRateTextBox);
            this.NPCInfoPanel.Controls.Add(this.ClearHButton);
            this.NPCInfoPanel.Controls.Add(this.NNameTextBox);
            this.NPCInfoPanel.Controls.Add(this.label23);
            this.NPCInfoPanel.Controls.Add(this.label25);
            this.NPCInfoPanel.Controls.Add(this.NImageTextBox);
            this.NPCInfoPanel.Controls.Add(this.label26);
            this.NPCInfoPanel.Controls.Add(this.NYTextBox);
            this.NPCInfoPanel.Controls.Add(this.label28);
            this.NPCInfoPanel.Controls.Add(this.NXTextBox);
            this.NPCInfoPanel.Enabled = false;
            this.NPCInfoPanel.Location = new System.Drawing.Point(239, 35);
            this.NPCInfoPanel.Name = "NPCInfoPanel";
            this.NPCInfoPanel.Size = new System.Drawing.Size(223, 134);
            this.NPCInfoPanel.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "File Name:";
            // 
            // NFileNameTextBox
            // 
            this.NFileNameTextBox.Location = new System.Drawing.Point(71, 3);
            this.NFileNameTextBox.MaxLength = 20;
            this.NFileNameTextBox.Name = "NFileNameTextBox";
            this.NFileNameTextBox.Size = new System.Drawing.Size(92, 20);
            this.NFileNameTextBox.TabIndex = 22;
            this.NFileNameTextBox.TextChanged += new System.EventHandler(this.NFileNameTextBox_TextChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Cursor = System.Windows.Forms.Cursors.Default;
            this.label29.Location = new System.Drawing.Point(127, 85);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(33, 13);
            this.label29.TabIndex = 21;
            this.label29.Text = "Rate:";
            // 
            // NRateTextBox
            // 
            this.NRateTextBox.Location = new System.Drawing.Point(166, 80);
            this.NRateTextBox.MaxLength = 3;
            this.NRateTextBox.Name = "NRateTextBox";
            this.NRateTextBox.Size = new System.Drawing.Size(37, 20);
            this.NRateTextBox.TabIndex = 20;
            this.NRateTextBox.TextChanged += new System.EventHandler(this.NRateTextBox_TextChanged);
            // 
            // ClearHButton
            // 
            this.ClearHButton.Location = new System.Drawing.Point(139, 106);
            this.ClearHButton.Name = "ClearHButton";
            this.ClearHButton.Size = new System.Drawing.Size(75, 23);
            this.ClearHButton.TabIndex = 19;
            this.ClearHButton.Text = "Clear History";
            this.ClearHButton.UseVisualStyleBackColor = true;
            // 
            // NNameTextBox
            // 
            this.NNameTextBox.Location = new System.Drawing.Point(71, 29);
            this.NNameTextBox.Name = "NNameTextBox";
            this.NNameTextBox.Size = new System.Drawing.Size(92, 20);
            this.NNameTextBox.TabIndex = 14;
            this.NNameTextBox.TextChanged += new System.EventHandler(this.NNameTextBox_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(27, 32);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(38, 13);
            this.label23.TabIndex = 15;
            this.label23.Text = "Name:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Cursor = System.Windows.Forms.Cursors.Default;
            this.label25.Location = new System.Drawing.Point(26, 85);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 13);
            this.label25.TabIndex = 13;
            this.label25.Text = "Image:";
            // 
            // NImageTextBox
            // 
            this.NImageTextBox.Location = new System.Drawing.Point(71, 81);
            this.NImageTextBox.MaxLength = 3;
            this.NImageTextBox.Name = "NImageTextBox";
            this.NImageTextBox.Size = new System.Drawing.Size(28, 20);
            this.NImageTextBox.TabIndex = 11;
            this.NImageTextBox.TextChanged += new System.EventHandler(this.NImageTextBox_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(117, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 13);
            this.label26.TabIndex = 10;
            this.label26.Text = "From Y:";
            // 
            // NYTextBox
            // 
            this.NYTextBox.Location = new System.Drawing.Point(166, 55);
            this.NYTextBox.MaxLength = 5;
            this.NYTextBox.Name = "NYTextBox";
            this.NYTextBox.Size = new System.Drawing.Size(37, 20);
            this.NYTextBox.TabIndex = 3;
            this.NYTextBox.TextChanged += new System.EventHandler(this.NYTextBox_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(22, 58);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(43, 13);
            this.label28.TabIndex = 3;
            this.label28.Text = "From X:";
            // 
            // NXTextBox
            // 
            this.NXTextBox.Location = new System.Drawing.Point(71, 55);
            this.NXTextBox.MaxLength = 5;
            this.NXTextBox.Name = "NXTextBox";
            this.NXTextBox.Size = new System.Drawing.Size(37, 20);
            this.NXTextBox.TabIndex = 2;
            this.NXTextBox.TextChanged += new System.EventHandler(this.NXTextBox_TextChanged);
            // 
            // NPCInfoListBox
            // 
            this.NPCInfoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NPCInfoListBox.FormattingEnabled = true;
            this.NPCInfoListBox.Location = new System.Drawing.Point(6, 35);
            this.NPCInfoListBox.Name = "NPCInfoListBox";
            this.NPCInfoListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.NPCInfoListBox.Size = new System.Drawing.Size(227, 134);
            this.NPCInfoListBox.TabIndex = 17;
            this.NPCInfoListBox.SelectedIndexChanged += new System.EventHandler(this.NPCInfoListBox_SelectedIndexChanged);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(126, 12);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 6;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // MapInfoListBox
            // 
            this.MapInfoListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MapInfoListBox.FormattingEnabled = true;
            this.MapInfoListBox.Location = new System.Drawing.Point(12, 41);
            this.MapInfoListBox.Name = "MapInfoListBox";
            this.MapInfoListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.MapInfoListBox.Size = new System.Drawing.Size(189, 199);
            this.MapInfoListBox.TabIndex = 7;
            this.MapInfoListBox.SelectedIndexChanged += new System.EventHandler(this.MapInfoListBox_SelectedIndexChanged);
            // 
            // PasteMapButton
            // 
            this.PasteMapButton.Location = new System.Drawing.Point(288, 12);
            this.PasteMapButton.Name = "PasteMapButton";
            this.PasteMapButton.Size = new System.Drawing.Size(75, 23);
            this.PasteMapButton.TabIndex = 24;
            this.PasteMapButton.Text = "Paste";
            this.PasteMapButton.UseVisualStyleBackColor = true;
            this.PasteMapButton.Click += new System.EventHandler(this.PasteMapButton_Click);
            // 
            // CopyMapButton
            // 
            this.CopyMapButton.Location = new System.Drawing.Point(207, 12);
            this.CopyMapButton.Name = "CopyMapButton";
            this.CopyMapButton.Size = new System.Drawing.Size(75, 23);
            this.CopyMapButton.TabIndex = 23;
            this.CopyMapButton.Text = "Copy";
            this.CopyMapButton.UseVisualStyleBackColor = true;
            // 
            // MapInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 254);
            this.Controls.Add(this.PasteMapButton);
            this.Controls.Add(this.CopyMapButton);
            this.Controls.Add(this.MapTabs);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.MapInfoListBox);
            this.Name = "MapInfoForm";
            this.Text = "Map Info";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapInfoForm_FormClosed);
            this.MapTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.SafeZoneInfoPanel.ResumeLayout(false);
            this.SafeZoneInfoPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.RespawnInfoPanel.ResumeLayout(false);
            this.RespawnInfoPanel.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.MovementInfoPanel.ResumeLayout(false);
            this.MovementInfoPanel.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.NPCInfoPanel.ResumeLayout(false);
            this.NPCInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl MapTabs;
        private TabPage tabPage1;
        private ComboBox LightsComboBox;
        private Label label5;
        private Label label4;
        private TextBox MiniMapTextBox;
        private TextBox MapNameTextBox;
        private Label label3;
        private TextBox FileNameTextBox;
        private Label label2;
        private TextBox MapIndexTextBox;
        private Label label1;
        private TabPage tabPage3;
        private Button RemoveSZButton;
        private Button AddSZButton;
        private Panel SafeZoneInfoPanel;
        private Label label12;
        private TextBox SZYTextBox;
        private Label label14;
        private TextBox SizeTextBox;
        private Label label17;
        private TextBox SZXTextBox;
        private CheckBox StartPointCheckBox;
        private ListBox SafeZoneInfoListBox;
        private TabPage tabPage2;
        private Button RPasteButton;
        private Button RCopyButton;
        private Button RemoveRButton;
        private Button AddRButton;
        private ListBox RespawnInfoListBox;
        private Panel RespawnInfoPanel;
        private Label label24;
        private TextBox DirectionTextBox;
        private Label label8;
        private TextBox DelayTextBox;
        private Label label7;
        private ComboBox MonsterInfoComboBox;
        private Label label6;
        private TextBox SpreadTextBox;
        private Label label9;
        private TextBox RYTextBox;
        private Label label10;
        private TextBox CountTextBox;
        private Label label13;
        private TextBox RXTextBox;
        private TabPage tabPage4;
        private Button RemoveMButton;
        private Button AddMButton;
        private Panel MovementInfoPanel;
        private Label label22;
        private ComboBox DestMapComboBox;
        private Label label18;
        private TextBox DestYTextBox;
        private Label label21;
        private TextBox DestXTextBox;
        private Label label16;
        private TextBox SourceYTextBox;
        private Label label20;
        private TextBox SourceXTextBox;
        private ListBox MovementInfoListBox;
        private TabPage tabPage5;
        private Button RemoveNButton;
        private Button AddNButton;
        private Panel NPCInfoPanel;
        private Label label29;
        private TextBox NRateTextBox;
        private Button ClearHButton;
        private TextBox NNameTextBox;
        private Label label23;
        private Label label25;
        private TextBox NImageTextBox;
        private Label label26;
        private TextBox NYTextBox;
        private Label label28;
        private TextBox NXTextBox;
        private ListBox NPCInfoListBox;
        private Button RemoveButton;
        private Button AddButton;
        private ListBox MapInfoListBox;
        private Label label11;
        private TextBox NFileNameTextBox;
        private Button PasteMapButton;
        private Button CopyMapButton;
        private Label label15;
        private TextBox BigMapTextBox;

    }
}