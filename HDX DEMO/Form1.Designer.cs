namespace HDX_DEMO
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.outputBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.GroupBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.ruteCom = new System.Windows.Forms.ComboBox();
            this.ruteLabel = new System.Windows.Forms.Label();
            this.portCom = new System.Windows.Forms.ComboBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.LanguageBox = new System.Windows.Forms.GroupBox();
            this.chsBtn = new System.Windows.Forms.RadioButton();
            this.enBtn = new System.Windows.Forms.RadioButton();
            this.functionBox = new System.Windows.Forms.GroupBox();
            this.closeAnBtn = new System.Windows.Forms.Button();
            this.ccardBtn = new System.Windows.Forms.Button();
            this.outDataBtn = new System.Windows.Forms.Button();
            this.openAnBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.myPort = new System.IO.Ports.SerialPort(this.components);
            this.numberBox = new System.Windows.Forms.GroupBox();
            this.countBtn = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.cardLabel = new System.Windows.Forms.Label();
            this.cardBtn = new System.Windows.Forms.Button();
            this.counBtn = new System.Windows.Forms.Button();
            this.counLabel = new System.Windows.Forms.Label();
            this.synBtn = new System.Windows.Forms.Button();
            this.sig2Btn = new System.Windows.Forms.Button();
            this.sig1Btn = new System.Windows.Forms.Button();
            this.synLabel = new System.Windows.Forms.Label();
            this.sig2Label = new System.Windows.Forms.Label();
            this.sig1Label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stopBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.poText = new System.Windows.Forms.TextBox();
            this.poLabel = new System.Windows.Forms.Label();
            this.ipText = new System.Windows.Forms.TextBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.proCom = new System.Windows.Forms.ComboBox();
            this.proLabel = new System.Windows.Forms.Label();
            this.Taskmenu = new System.Windows.Forms.NotifyIcon(this.components);
            this.TaskCon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tool1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool3 = new System.Windows.Forms.ToolStripMenuItem();
            this.portBox.SuspendLayout();
            this.LanguageBox.SuspendLayout();
            this.functionBox.SuspendLayout();
            this.numberBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TaskCon.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            resources.ApplyResources(this.outputBox, "outputBox");
            this.outputBox.Name = "outputBox";
            // 
            // portBox
            // 
            this.portBox.Controls.Add(this.closeBtn);
            this.portBox.Controls.Add(this.openBtn);
            this.portBox.Controls.Add(this.ruteCom);
            this.portBox.Controls.Add(this.ruteLabel);
            this.portBox.Controls.Add(this.portCom);
            this.portBox.Controls.Add(this.portLabel);
            resources.ApplyResources(this.portBox, "portBox");
            this.portBox.Name = "portBox";
            this.portBox.TabStop = false;
            // 
            // closeBtn
            // 
            resources.ApplyResources(this.closeBtn, "closeBtn");
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // openBtn
            // 
            resources.ApplyResources(this.openBtn, "openBtn");
            this.openBtn.Name = "openBtn";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // ruteCom
            // 
            this.ruteCom.FormattingEnabled = true;
            resources.ApplyResources(this.ruteCom, "ruteCom");
            this.ruteCom.Name = "ruteCom";
            // 
            // ruteLabel
            // 
            resources.ApplyResources(this.ruteLabel, "ruteLabel");
            this.ruteLabel.Name = "ruteLabel";
            // 
            // portCom
            // 
            this.portCom.FormattingEnabled = true;
            resources.ApplyResources(this.portCom, "portCom");
            this.portCom.Name = "portCom";
            // 
            // portLabel
            // 
            resources.ApplyResources(this.portLabel, "portLabel");
            this.portLabel.Name = "portLabel";
            // 
            // LanguageBox
            // 
            this.LanguageBox.Controls.Add(this.chsBtn);
            this.LanguageBox.Controls.Add(this.enBtn);
            resources.ApplyResources(this.LanguageBox, "LanguageBox");
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.TabStop = false;
            // 
            // chsBtn
            // 
            resources.ApplyResources(this.chsBtn, "chsBtn");
            this.chsBtn.Name = "chsBtn";
            this.chsBtn.TabStop = true;
            this.chsBtn.UseVisualStyleBackColor = true;
            this.chsBtn.CheckedChanged += new System.EventHandler(this.ChsBtn_CheckedChanged);
            // 
            // enBtn
            // 
            resources.ApplyResources(this.enBtn, "enBtn");
            this.enBtn.Name = "enBtn";
            this.enBtn.TabStop = true;
            this.enBtn.UseVisualStyleBackColor = true;
            this.enBtn.CheckedChanged += new System.EventHandler(this.EnBtn_CheckedChanged);
            // 
            // functionBox
            // 
            this.functionBox.Controls.Add(this.closeAnBtn);
            this.functionBox.Controls.Add(this.ccardBtn);
            this.functionBox.Controls.Add(this.outDataBtn);
            this.functionBox.Controls.Add(this.openAnBtn);
            this.functionBox.Controls.Add(this.clearBtn);
            resources.ApplyResources(this.functionBox, "functionBox");
            this.functionBox.Name = "functionBox";
            this.functionBox.TabStop = false;
            // 
            // closeAnBtn
            // 
            resources.ApplyResources(this.closeAnBtn, "closeAnBtn");
            this.closeAnBtn.Name = "closeAnBtn";
            this.closeAnBtn.UseVisualStyleBackColor = true;
            this.closeAnBtn.Click += new System.EventHandler(this.CloseAnBtn_Click);
            // 
            // ccardBtn
            // 
            resources.ApplyResources(this.ccardBtn, "ccardBtn");
            this.ccardBtn.Name = "ccardBtn";
            this.ccardBtn.UseVisualStyleBackColor = true;
            this.ccardBtn.Click += new System.EventHandler(this.CcrdBtn_Click);
            // 
            // outDataBtn
            // 
            resources.ApplyResources(this.outDataBtn, "outDataBtn");
            this.outDataBtn.Name = "outDataBtn";
            this.outDataBtn.UseVisualStyleBackColor = true;
            this.outDataBtn.Click += new System.EventHandler(this.OutDataBtn_Click);
            // 
            // openAnBtn
            // 
            resources.ApplyResources(this.openAnBtn, "openAnBtn");
            this.openAnBtn.Name = "openAnBtn";
            this.openAnBtn.UseVisualStyleBackColor = true;
            this.openAnBtn.Click += new System.EventHandler(this.OpenAnBtn_Click);
            // 
            // clearBtn
            // 
            resources.ApplyResources(this.clearBtn, "clearBtn");
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // myPort
            // 
            this.myPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MyPort_DataReceived);
            // 
            // numberBox
            // 
            this.numberBox.Controls.Add(this.countBtn);
            this.numberBox.Controls.Add(this.countLabel);
            this.numberBox.Controls.Add(this.cardLabel);
            this.numberBox.Controls.Add(this.cardBtn);
            this.numberBox.Controls.Add(this.counBtn);
            this.numberBox.Controls.Add(this.counLabel);
            this.numberBox.Controls.Add(this.synBtn);
            this.numberBox.Controls.Add(this.sig2Btn);
            this.numberBox.Controls.Add(this.sig1Btn);
            this.numberBox.Controls.Add(this.synLabel);
            this.numberBox.Controls.Add(this.sig2Label);
            this.numberBox.Controls.Add(this.sig1Label);
            resources.ApplyResources(this.numberBox, "numberBox");
            this.numberBox.Name = "numberBox";
            this.numberBox.TabStop = false;
            // 
            // countBtn
            // 
            resources.ApplyResources(this.countBtn, "countBtn");
            this.countBtn.Name = "countBtn";
            this.countBtn.UseVisualStyleBackColor = true;
            // 
            // countLabel
            // 
            resources.ApplyResources(this.countLabel, "countLabel");
            this.countLabel.Name = "countLabel";
            // 
            // cardLabel
            // 
            resources.ApplyResources(this.cardLabel, "cardLabel");
            this.cardLabel.Name = "cardLabel";
            // 
            // cardBtn
            // 
            resources.ApplyResources(this.cardBtn, "cardBtn");
            this.cardBtn.Name = "cardBtn";
            this.cardBtn.UseVisualStyleBackColor = true;
            // 
            // counBtn
            // 
            resources.ApplyResources(this.counBtn, "counBtn");
            this.counBtn.Name = "counBtn";
            this.counBtn.UseVisualStyleBackColor = true;
            // 
            // counLabel
            // 
            resources.ApplyResources(this.counLabel, "counLabel");
            this.counLabel.Name = "counLabel";
            // 
            // synBtn
            // 
            resources.ApplyResources(this.synBtn, "synBtn");
            this.synBtn.Name = "synBtn";
            this.synBtn.UseVisualStyleBackColor = true;
            // 
            // sig2Btn
            // 
            resources.ApplyResources(this.sig2Btn, "sig2Btn");
            this.sig2Btn.Name = "sig2Btn";
            this.sig2Btn.UseVisualStyleBackColor = true;
            // 
            // sig1Btn
            // 
            resources.ApplyResources(this.sig1Btn, "sig1Btn");
            this.sig1Btn.Name = "sig1Btn";
            this.sig1Btn.UseVisualStyleBackColor = true;
            // 
            // synLabel
            // 
            resources.ApplyResources(this.synLabel, "synLabel");
            this.synLabel.Name = "synLabel";
            // 
            // sig2Label
            // 
            resources.ApplyResources(this.sig2Label, "sig2Label");
            this.sig2Label.Name = "sig2Label";
            // 
            // sig1Label
            // 
            resources.ApplyResources(this.sig1Label, "sig1Label");
            this.sig1Label.Name = "sig1Label";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stopBtn);
            this.groupBox1.Controls.Add(this.startBtn);
            this.groupBox1.Controls.Add(this.poText);
            this.groupBox1.Controls.Add(this.poLabel);
            this.groupBox1.Controls.Add(this.ipText);
            this.groupBox1.Controls.Add(this.ipLabel);
            this.groupBox1.Controls.Add(this.proCom);
            this.groupBox1.Controls.Add(this.proLabel);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // stopBtn
            // 
            resources.ApplyResources(this.stopBtn, "stopBtn");
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // startBtn
            // 
            resources.ApplyResources(this.startBtn, "startBtn");
            this.startBtn.Name = "startBtn";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // poText
            // 
            resources.ApplyResources(this.poText, "poText");
            this.poText.Name = "poText";
            // 
            // poLabel
            // 
            resources.ApplyResources(this.poLabel, "poLabel");
            this.poLabel.Name = "poLabel";
            // 
            // ipText
            // 
            resources.ApplyResources(this.ipText, "ipText");
            this.ipText.Name = "ipText";
            // 
            // ipLabel
            // 
            resources.ApplyResources(this.ipLabel, "ipLabel");
            this.ipLabel.Name = "ipLabel";
            // 
            // proCom
            // 
            this.proCom.FormattingEnabled = true;
            resources.ApplyResources(this.proCom, "proCom");
            this.proCom.Name = "proCom";
            // 
            // proLabel
            // 
            resources.ApplyResources(this.proLabel, "proLabel");
            this.proLabel.Name = "proLabel";
            // 
            // Taskmenu
            // 
            this.Taskmenu.ContextMenuStrip = this.TaskCon;
            resources.ApplyResources(this.Taskmenu, "Taskmenu");
            // 
            // TaskCon
            // 
            this.TaskCon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1,
            this.tool2,
            this.tool3});
            this.TaskCon.Name = "contextMenuStrip1";
            resources.ApplyResources(this.TaskCon, "TaskCon");
            // 
            // tool1
            // 
            this.tool1.Name = "tool1";
            resources.ApplyResources(this.tool1, "tool1");
            // 
            // tool2
            // 
            this.tool2.Name = "tool2";
            resources.ApplyResources(this.tool2, "tool2");
            // 
            // tool3
            // 
            this.tool3.Name = "tool3";
            resources.ApplyResources(this.tool3, "tool3");
            this.tool3.Click += new System.EventHandler(this.Tool3_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numberBox);
            this.Controls.Add(this.functionBox);
            this.Controls.Add(this.LanguageBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.outputBox);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.portBox.ResumeLayout(false);
            this.portBox.PerformLayout();
            this.LanguageBox.ResumeLayout(false);
            this.LanguageBox.PerformLayout();
            this.functionBox.ResumeLayout(false);
            this.numberBox.ResumeLayout(false);
            this.numberBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TaskCon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.GroupBox portBox;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.ComboBox ruteCom;
        private System.Windows.Forms.Label ruteLabel;
        private System.Windows.Forms.ComboBox portCom;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.GroupBox LanguageBox;
        private System.Windows.Forms.RadioButton chsBtn;
        private System.Windows.Forms.RadioButton enBtn;
        private System.Windows.Forms.GroupBox functionBox;
        private System.IO.Ports.SerialPort myPort;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.GroupBox numberBox;
        private System.Windows.Forms.Button synBtn;
        private System.Windows.Forms.Button sig2Btn;
        private System.Windows.Forms.Button sig1Btn;
        private System.Windows.Forms.Label synLabel;
        private System.Windows.Forms.Label sig2Label;
        private System.Windows.Forms.Label sig1Label;
        private System.Windows.Forms.Label cardLabel;
        private System.Windows.Forms.Button cardBtn;
        private System.Windows.Forms.Button counBtn;
        private System.Windows.Forms.Label counLabel;
        private System.Windows.Forms.Button countBtn;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Button ccardBtn;
        private System.Windows.Forms.Button closeAnBtn;
        private System.Windows.Forms.Button outDataBtn;
        private System.Windows.Forms.Button openAnBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox poText;
        private System.Windows.Forms.Label poLabel;
        private System.Windows.Forms.TextBox ipText;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.ComboBox proCom;
        private System.Windows.Forms.Label proLabel;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.NotifyIcon Taskmenu;
        private System.Windows.Forms.ContextMenuStrip TaskCon;
        private System.Windows.Forms.ToolStripMenuItem tool1;
        private System.Windows.Forms.ToolStripMenuItem tool2;
        private System.Windows.Forms.ToolStripMenuItem tool3;
    }
}

