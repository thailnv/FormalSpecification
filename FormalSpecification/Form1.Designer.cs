namespace FormalSpecification
{
    partial class mainForm
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
            this.classNameTb = new System.Windows.Forms.TextBox();
            this.exeNameTb = new System.Windows.Forms.TextBox();
            this.inputText = new System.Windows.Forms.RichTextBox();
            this.outputText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuild = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newBtn = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openfileBtn = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitBtn = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.exitToolBtn = new System.Windows.Forms.ToolStripButton();
            this.openToolBtn = new System.Windows.Forms.ToolStripButton();
            this.newToolBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.langLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // classNameTb
            // 
            this.classNameTb.Location = new System.Drawing.Point(139, 84);
            this.classNameTb.Name = "classNameTb";
            this.classNameTb.Size = new System.Drawing.Size(141, 26);
            this.classNameTb.TabIndex = 0;
            // 
            // exeNameTb
            // 
            this.exeNameTb.Location = new System.Drawing.Point(139, 130);
            this.exeNameTb.Name = "exeNameTb";
            this.exeNameTb.Size = new System.Drawing.Size(140, 26);
            this.exeNameTb.TabIndex = 1;
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(16, 168);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(424, 491);
            this.inputText.TabIndex = 2;
            this.inputText.Text = "";
            this.inputText.TextChanged += new System.EventHandler(this.inputText_TextChanged);
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(455, 84);
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.Size = new System.Drawing.Size(508, 575);
            this.outputText.TabIndex = 3;
            this.outputText.Text = "";
            this.outputText.WordWrap = false;
            this.outputText.TextChanged += new System.EventHandler(this.outputText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Class Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Exe File Name";
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(312, 103);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(128, 31);
            this.btnBuild.TabIndex = 6;
            this.btnBuild.Text = "Build Solution";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBtn,
            this.toolStripSeparator1,
            this.openfileBtn,
            this.toolStripSeparator2,
            this.exitBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(975, 30);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newBtn
            // 
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(47, 25);
            this.newBtn.Text = "New";
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // openfileBtn
            // 
            this.openfileBtn.Name = "openfileBtn";
            this.openfileBtn.Size = new System.Drawing.Size(56, 25);
            this.openfileBtn.Text = "Open";
            this.openfileBtn.Click += new System.EventHandler(this.openfileBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // exitBtn
            // 
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(39, 25);
            this.exitBtn.Text = "Exit";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolBtn,
            this.openToolBtn,
            this.newToolBtn,
            this.toolStripSeparator3,
            this.langLabel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 30);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(975, 30);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // exitToolBtn
            // 
            this.exitToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitToolBtn.Image = global::FormalSpecification.Properties.Resources.ico28;
            this.exitToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitToolBtn.Name = "exitToolBtn";
            this.exitToolBtn.Size = new System.Drawing.Size(34, 28);
            this.exitToolBtn.Text = "Close";
            this.exitToolBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // openToolBtn
            // 
            this.openToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolBtn.Image = global::FormalSpecification.Properties.Resources.open;
            this.openToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolBtn.Name = "openToolBtn";
            this.openToolBtn.Size = new System.Drawing.Size(34, 28);
            this.openToolBtn.Text = "Open";
            this.openToolBtn.Click += new System.EventHandler(this.openfileBtn_Click);
            // 
            // newToolBtn
            // 
            this.newToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolBtn.Image = global::FormalSpecification.Properties.Resources.whitepage;
            this.newToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolBtn.Name = "newToolBtn";
            this.newToolBtn.Size = new System.Drawing.Size(34, 28);
            this.newToolBtn.Text = "New";
            this.newToolBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // langLabel
            // 
            this.langLabel.Name = "langLabel";
            this.langLabel.Size = new System.Drawing.Size(34, 28);
            this.langLabel.Text = "C#";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 671);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.exeNameTb);
            this.Controls.Add(this.classNameTb);
            this.Name = "mainForm";
            this.Text = "Formal Specification";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox classNameTb;
        private System.Windows.Forms.TextBox exeNameTb;
        private System.Windows.Forms.RichTextBox inputText;
        private System.Windows.Forms.RichTextBox outputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel newBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel openfileBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel exitBtn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton exitToolBtn;
        private System.Windows.Forms.ToolStripButton openToolBtn;
        private System.Windows.Forms.ToolStripButton newToolBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel langLabel;
    }
}

