namespace OrviboController.UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonExit = new System.Windows.Forms.Button();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.buttonFindDevices = new System.Windows.Forms.Button();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.textBoxMACAddress = new System.Windows.Forms.TextBox();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelMACAddress = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.buttonOn = new System.Windows.Forms.Button();
            this.buttonOff = new System.Windows.Forms.Button();
            this.checkBoxManual = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxCycle = new System.Windows.Forms.GroupBox();
            this.labelCurrentCycle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCycleCount = new System.Windows.Forms.TextBox();
            this.labelCycleCount = new System.Windows.Forms.Label();
            this.buttonStopCycling = new System.Windows.Forms.Button();
            this.buttonStartCycling = new System.Windows.Forms.Button();
            this.textBoxOffTimeS = new System.Windows.Forms.TextBox();
            this.textBoxOnTimeS = new System.Windows.Forms.TextBox();
            this.labelOffTime = new System.Windows.Forms.Label();
            this.labelOnTime = new System.Windows.Forms.Label();
            this.checkBoxCycle = new System.Windows.Forms.CheckBox();
            this.timerCycle = new System.Windows.Forms.Timer(this.components);
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.groupBoxManual.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBoxCycle.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(448, 434);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExitClick);
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(267, 27);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(256, 21);
            this.comboBoxDevices.TabIndex = 1;
            // 
            // buttonFindDevices
            // 
            this.buttonFindDevices.Location = new System.Drawing.Point(34, 27);
            this.buttonFindDevices.Name = "buttonFindDevices";
            this.buttonFindDevices.Size = new System.Drawing.Size(196, 23);
            this.buttonFindDevices.TabIndex = 2;
            this.buttonFindDevices.Text = "Find Devices";
            this.buttonFindDevices.UseVisualStyleBackColor = true;
            this.buttonFindDevices.Click += new System.EventHandler(this.ButtonFindDevicesClick);
            // 
            // groupBoxManual
            // 
            this.groupBoxManual.Controls.Add(this.textBoxMACAddress);
            this.groupBoxManual.Controls.Add(this.textBoxIPAddress);
            this.groupBoxManual.Controls.Add(this.labelMACAddress);
            this.groupBoxManual.Controls.Add(this.labelIPAddress);
            this.groupBoxManual.Location = new System.Drawing.Point(34, 88);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(489, 100);
            this.groupBoxManual.TabIndex = 3;
            this.groupBoxManual.TabStop = false;
            // 
            // textBoxMACAddress
            // 
            this.textBoxMACAddress.Location = new System.Drawing.Point(262, 57);
            this.textBoxMACAddress.Name = "textBoxMACAddress";
            this.textBoxMACAddress.Size = new System.Drawing.Size(221, 20);
            this.textBoxMACAddress.TabIndex = 3;
            this.textBoxMACAddress.Text = "AC-CF-23-8D-63-1C";
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(262, 24);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(221, 20);
            this.textBoxIPAddress.TabIndex = 2;
            this.textBoxIPAddress.Text = "10.221.15.230";
            // 
            // labelMACAddress
            // 
            this.labelMACAddress.AutoSize = true;
            this.labelMACAddress.Location = new System.Drawing.Point(161, 60);
            this.labelMACAddress.Name = "labelMACAddress";
            this.labelMACAddress.Size = new System.Drawing.Size(71, 13);
            this.labelMACAddress.TabIndex = 1;
            this.labelMACAddress.Text = "MAC Address";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(161, 27);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(58, 13);
            this.labelIPAddress.TabIndex = 0;
            this.labelIPAddress.Text = "IP Address";
            // 
            // buttonOn
            // 
            this.buttonOn.Location = new System.Drawing.Point(123, 434);
            this.buttonOn.Name = "buttonOn";
            this.buttonOn.Size = new System.Drawing.Size(75, 23);
            this.buttonOn.TabIndex = 4;
            this.buttonOn.Text = "ON";
            this.buttonOn.UseVisualStyleBackColor = true;
            this.buttonOn.Click += new System.EventHandler(this.ButtonOnClick);
            // 
            // buttonOff
            // 
            this.buttonOff.Location = new System.Drawing.Point(218, 434);
            this.buttonOff.Name = "buttonOff";
            this.buttonOff.Size = new System.Drawing.Size(75, 23);
            this.buttonOff.TabIndex = 5;
            this.buttonOff.Text = "OFF";
            this.buttonOff.UseVisualStyleBackColor = true;
            this.buttonOff.Click += new System.EventHandler(this.ButtonOffClick);
            // 
            // checkBoxManual
            // 
            this.checkBoxManual.AutoSize = true;
            this.checkBoxManual.Location = new System.Drawing.Point(34, 65);
            this.checkBoxManual.Name = "checkBoxManual";
            this.checkBoxManual.Size = new System.Drawing.Size(97, 17);
            this.checkBoxManual.TabIndex = 6;
            this.checkBoxManual.Text = "Manual Control";
            this.checkBoxManual.UseVisualStyleBackColor = true;
            this.checkBoxManual.CheckedChanged += new System.EventHandler(this.CheckBoxManualCheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(550, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBoxCycle
            // 
            this.groupBoxCycle.Controls.Add(this.labelCurrentCycle);
            this.groupBoxCycle.Controls.Add(this.label1);
            this.groupBoxCycle.Controls.Add(this.textBoxCycleCount);
            this.groupBoxCycle.Controls.Add(this.labelCycleCount);
            this.groupBoxCycle.Controls.Add(this.buttonStopCycling);
            this.groupBoxCycle.Controls.Add(this.buttonStartCycling);
            this.groupBoxCycle.Controls.Add(this.textBoxOffTimeS);
            this.groupBoxCycle.Controls.Add(this.textBoxOnTimeS);
            this.groupBoxCycle.Controls.Add(this.labelOffTime);
            this.groupBoxCycle.Controls.Add(this.labelOnTime);
            this.groupBoxCycle.Location = new System.Drawing.Point(34, 217);
            this.groupBoxCycle.Name = "groupBoxCycle";
            this.groupBoxCycle.Size = new System.Drawing.Size(489, 201);
            this.groupBoxCycle.TabIndex = 8;
            this.groupBoxCycle.TabStop = false;
            // 
            // labelCurrentCycle
            // 
            this.labelCurrentCycle.AutoSize = true;
            this.labelCurrentCycle.Location = new System.Drawing.Point(259, 135);
            this.labelCurrentCycle.Name = "labelCurrentCycle";
            this.labelCurrentCycle.Size = new System.Drawing.Size(0, 13);
            this.labelCurrentCycle.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Remaining Cycles";
            // 
            // textBoxCycleCount
            // 
            this.textBoxCycleCount.Location = new System.Drawing.Point(262, 93);
            this.textBoxCycleCount.Name = "textBoxCycleCount";
            this.textBoxCycleCount.Size = new System.Drawing.Size(221, 20);
            this.textBoxCycleCount.TabIndex = 11;
            this.textBoxCycleCount.Text = "2";
            // 
            // labelCycleCount
            // 
            this.labelCycleCount.AutoSize = true;
            this.labelCycleCount.Location = new System.Drawing.Point(132, 100);
            this.labelCycleCount.Name = "labelCycleCount";
            this.labelCycleCount.Size = new System.Drawing.Size(112, 13);
            this.labelCycleCount.TabIndex = 10;
            this.labelCycleCount.Text = "Max Cycles (0=infinite)";
            // 
            // buttonStopCycling
            // 
            this.buttonStopCycling.Location = new System.Drawing.Point(376, 165);
            this.buttonStopCycling.Name = "buttonStopCycling";
            this.buttonStopCycling.Size = new System.Drawing.Size(75, 23);
            this.buttonStopCycling.TabIndex = 9;
            this.buttonStopCycling.Text = "Stop";
            this.buttonStopCycling.UseVisualStyleBackColor = true;
            this.buttonStopCycling.Click += new System.EventHandler(this.ButtonStopCyclingClick);
            // 
            // buttonStartCycling
            // 
            this.buttonStartCycling.Location = new System.Drawing.Point(285, 165);
            this.buttonStartCycling.Name = "buttonStartCycling";
            this.buttonStartCycling.Size = new System.Drawing.Size(75, 23);
            this.buttonStartCycling.TabIndex = 8;
            this.buttonStartCycling.Text = "Start";
            this.buttonStartCycling.UseVisualStyleBackColor = true;
            this.buttonStartCycling.Click += new System.EventHandler(this.ButtonStartCyclingClick);
            // 
            // textBoxOffTimeS
            // 
            this.textBoxOffTimeS.Location = new System.Drawing.Point(262, 55);
            this.textBoxOffTimeS.Name = "textBoxOffTimeS";
            this.textBoxOffTimeS.Size = new System.Drawing.Size(221, 20);
            this.textBoxOffTimeS.TabIndex = 7;
            this.textBoxOffTimeS.Text = "2";
            // 
            // textBoxOnTimeS
            // 
            this.textBoxOnTimeS.Location = new System.Drawing.Point(262, 22);
            this.textBoxOnTimeS.Name = "textBoxOnTimeS";
            this.textBoxOnTimeS.Size = new System.Drawing.Size(221, 20);
            this.textBoxOnTimeS.TabIndex = 6;
            this.textBoxOnTimeS.Text = "2";
            // 
            // labelOffTime
            // 
            this.labelOffTime.AutoSize = true;
            this.labelOffTime.Location = new System.Drawing.Point(161, 58);
            this.labelOffTime.Name = "labelOffTime";
            this.labelOffTime.Size = new System.Drawing.Size(80, 13);
            this.labelOffTime.TabIndex = 5;
            this.labelOffTime.Text = "Off Time (Secs)";
            // 
            // labelOnTime
            // 
            this.labelOnTime.AutoSize = true;
            this.labelOnTime.Location = new System.Drawing.Point(161, 25);
            this.labelOnTime.Name = "labelOnTime";
            this.labelOnTime.Size = new System.Drawing.Size(80, 13);
            this.labelOnTime.TabIndex = 4;
            this.labelOnTime.Text = "On Time (Secs)";
            // 
            // checkBoxCycle
            // 
            this.checkBoxCycle.AutoSize = true;
            this.checkBoxCycle.Location = new System.Drawing.Point(34, 194);
            this.checkBoxCycle.Name = "checkBoxCycle";
            this.checkBoxCycle.Size = new System.Drawing.Size(88, 17);
            this.checkBoxCycle.TabIndex = 9;
            this.checkBoxCycle.Text = "Cycle On/Off";
            this.checkBoxCycle.UseVisualStyleBackColor = true;
            this.checkBoxCycle.CheckedChanged += new System.EventHandler(this.CheckBoxCycleCheckedChanged);
            // 
            // timerCycle
            // 
            this.timerCycle.Interval = 1000;
            this.timerCycle.Tick += new System.EventHandler(this.TimerCycleTick);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(275, 66);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(89, 13);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Status: Unknown";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(32, 434);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 11;
            this.buttonQuery.Text = "Query";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.ButtonQueryClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 496);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.checkBoxCycle);
            this.Controls.Add(this.groupBoxCycle);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBoxManual);
            this.Controls.Add(this.buttonOff);
            this.Controls.Add(this.buttonOn);
            this.Controls.Add(this.groupBoxManual);
            this.Controls.Add(this.buttonFindDevices);
            this.Controls.Add(this.comboBoxDevices);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Orvibo Controller";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxCycle.ResumeLayout(false);
            this.groupBoxCycle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.Button buttonFindDevices;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.TextBox textBoxMACAddress;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Label labelMACAddress;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.Button buttonOn;
        private System.Windows.Forms.Button buttonOff;
        private System.Windows.Forms.CheckBox checkBoxManual;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBoxCycle;
        private System.Windows.Forms.TextBox textBoxOffTimeS;
        private System.Windows.Forms.TextBox textBoxOnTimeS;
        private System.Windows.Forms.Label labelOffTime;
        private System.Windows.Forms.Label labelOnTime;
        private System.Windows.Forms.CheckBox checkBoxCycle;
        private System.Windows.Forms.Button buttonStopCycling;
        private System.Windows.Forms.Button buttonStartCycling;
        private System.Windows.Forms.Timer timerCycle;
        private System.Windows.Forms.TextBox textBoxCycleCount;
        private System.Windows.Forms.Label labelCycleCount;
        private System.Windows.Forms.Label labelCurrentCycle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonQuery;
    }
}

