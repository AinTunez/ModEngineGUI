namespace ModEngineGUI
{
    partial class Configure
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
            this.skipLogosBox = new System.Windows.Forms.CheckBox();
            this.loadUxmBox = new System.Windows.Forms.CheckBox();
            this.useModOverrideBox = new System.Windows.Forms.CheckBox();
            this.cacheFilePathBox = new System.Windows.Forms.CheckBox();
            this.showDebugLogBox = new System.Windows.Forms.CheckBox();
            this.modFolderBox = new System.Windows.Forms.TextBox();
            this.selectDirBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.chainBtn = new System.Windows.Forms.Button();
            this.chainDllBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // skipLogosBox
            // 
            this.skipLogosBox.AutoSize = true;
            this.skipLogosBox.BackColor = System.Drawing.SystemColors.Control;
            this.skipLogosBox.Location = new System.Drawing.Point(13, 13);
            this.skipLogosBox.Name = "skipLogosBox";
            this.skipLogosBox.Size = new System.Drawing.Size(75, 17);
            this.skipLogosBox.TabIndex = 0;
            this.skipLogosBox.Text = "Skip logos";
            this.skipLogosBox.UseVisualStyleBackColor = false;
            // 
            // loadUxmBox
            // 
            this.loadUxmBox.AutoSize = true;
            this.loadUxmBox.BackColor = System.Drawing.SystemColors.Control;
            this.loadUxmBox.Location = new System.Drawing.Point(12, 65);
            this.loadUxmBox.Name = "loadUxmBox";
            this.loadUxmBox.Size = new System.Drawing.Size(98, 17);
            this.loadUxmBox.TabIndex = 1;
            this.loadUxmBox.Text = "Load UXM files";
            this.loadUxmBox.UseVisualStyleBackColor = false;
            // 
            // useModOverrideBox
            // 
            this.useModOverrideBox.AutoSize = true;
            this.useModOverrideBox.BackColor = System.Drawing.SystemColors.Control;
            this.useModOverrideBox.Location = new System.Drawing.Point(12, 88);
            this.useModOverrideBox.Name = "useModOverrideBox";
            this.useModOverrideBox.Size = new System.Drawing.Size(152, 17);
            this.useModOverrideBox.TabIndex = 2;
            this.useModOverrideBox.Text = "Use mod override directory";
            this.useModOverrideBox.UseVisualStyleBackColor = false;
            // 
            // cacheFilePathBox
            // 
            this.cacheFilePathBox.AutoSize = true;
            this.cacheFilePathBox.BackColor = System.Drawing.SystemColors.Control;
            this.cacheFilePathBox.Location = new System.Drawing.Point(12, 140);
            this.cacheFilePathBox.Name = "cacheFilePathBox";
            this.cacheFilePathBox.Size = new System.Drawing.Size(102, 17);
            this.cacheFilePathBox.TabIndex = 3;
            this.cacheFilePathBox.Text = "Cache file paths";
            this.cacheFilePathBox.UseVisualStyleBackColor = false;
            // 
            // showDebugLogBox
            // 
            this.showDebugLogBox.AutoSize = true;
            this.showDebugLogBox.BackColor = System.Drawing.SystemColors.Control;
            this.showDebugLogBox.Location = new System.Drawing.Point(12, 163);
            this.showDebugLogBox.Name = "showDebugLogBox";
            this.showDebugLogBox.Size = new System.Drawing.Size(103, 17);
            this.showDebugLogBox.TabIndex = 4;
            this.showDebugLogBox.Text = "Show debug log";
            this.showDebugLogBox.UseVisualStyleBackColor = false;
            // 
            // overrideDirBox
            // 
            this.modFolderBox.Location = new System.Drawing.Point(157, 113);
            this.modFolderBox.Name = "overrideDirBox";
            this.modFolderBox.Size = new System.Drawing.Size(249, 20);
            this.modFolderBox.TabIndex = 0;
            this.modFolderBox.TabStop = false;
            // 
            // selectDirBtn
            // 
            this.selectDirBtn.Location = new System.Drawing.Point(12, 111);
            this.selectDirBtn.Name = "selectDirBtn";
            this.selectDirBtn.Size = new System.Drawing.Size(139, 23);
            this.selectDirBtn.TabIndex = 5;
            this.selectDirBtn.Text = "Select Override Directory";
            this.selectDirBtn.UseVisualStyleBackColor = true;
            this.selectDirBtn.Click += new System.EventHandler(this.selectDirBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(332, 224);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 8;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(251, 224);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // chainBtn
            // 
            this.chainBtn.Location = new System.Drawing.Point(12, 36);
            this.chainBtn.Name = "chainBtn";
            this.chainBtn.Size = new System.Drawing.Size(139, 23);
            this.chainBtn.TabIndex = 11;
            this.chainBtn.Text = "Chain dinput8.dll";
            this.chainBtn.UseVisualStyleBackColor = true;
            this.chainBtn.Click += new System.EventHandler(this.chainBtn_Click);
            // 
            // chainDllBox
            // 
            this.chainDllBox.Location = new System.Drawing.Point(157, 38);
            this.chainDllBox.Name = "chainDllBox";
            this.chainDllBox.Size = new System.Drawing.Size(249, 20);
            this.chainDllBox.TabIndex = 10;
            this.chainDllBox.TabStop = false;
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 262);
            this.Controls.Add(this.chainBtn);
            this.Controls.Add(this.chainDllBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.selectDirBtn);
            this.Controls.Add(this.modFolderBox);
            this.Controls.Add(this.showDebugLogBox);
            this.Controls.Add(this.cacheFilePathBox);
            this.Controls.Add(this.useModOverrideBox);
            this.Controls.Add(this.loadUxmBox);
            this.Controls.Add(this.skipLogosBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Configure";
            this.Text = "Configure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox skipLogosBox;
        private System.Windows.Forms.CheckBox loadUxmBox;
        private System.Windows.Forms.CheckBox useModOverrideBox;
        private System.Windows.Forms.CheckBox cacheFilePathBox;
        private System.Windows.Forms.CheckBox showDebugLogBox;
        private System.Windows.Forms.TextBox modFolderBox;
        private System.Windows.Forms.Button selectDirBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button chainBtn;
        private System.Windows.Forms.TextBox chainDllBox;
    }
}