namespace DTAutoDirectory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.createDirectoryButton = new System.Windows.Forms.Button();
            this.useCaseSelectionBox = new System.Windows.Forms.ComboBox();
            this.projectNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.responseLabel = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.issueNumberBox = new System.Windows.Forms.TextBox();
            this.issueLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // createDirectoryButton
            // 
            this.createDirectoryButton.Location = new System.Drawing.Point(247, 95);
            this.createDirectoryButton.Name = "createDirectoryButton";
            this.createDirectoryButton.Size = new System.Drawing.Size(297, 49);
            this.createDirectoryButton.TabIndex = 0;
            this.createDirectoryButton.Text = "Create Project";
            this.createDirectoryButton.UseVisualStyleBackColor = true;
            this.createDirectoryButton.Click += new System.EventHandler(this.createDirectoryButton_Click);
            // 
            // useCaseSelectionBox
            // 
            this.useCaseSelectionBox.FormattingEnabled = true;
            this.useCaseSelectionBox.Items.AddRange(new object[] {
            "Use Case 1: Longitudinal statistical data",
            "Use Case 2: KML/Shape of evolving geographic extents",
            "Use Case 3: Inundations",
            "Use Case 4: Time coded cumulative feature sets",
            "Use Case 5: Historic track data",
            "Use Case 10: Eras"});
            this.useCaseSelectionBox.Location = new System.Drawing.Point(318, 12);
            this.useCaseSelectionBox.Name = "useCaseSelectionBox";
            this.useCaseSelectionBox.Size = new System.Drawing.Size(391, 24);
            this.useCaseSelectionBox.TabIndex = 2;
            this.useCaseSelectionBox.Text = "Choose a Use Case";
            this.useCaseSelectionBox.SelectedIndexChanged += new System.EventHandler(this.useCaseSelectionBox_SelectedIndexChanged);
            // 
            // projectNameBox
            // 
            this.projectNameBox.Location = new System.Drawing.Point(153, 12);
            this.projectNameBox.Name = "projectNameBox";
            this.projectNameBox.Size = new System.Drawing.Size(159, 22);
            this.projectNameBox.TabIndex = 3;
            this.projectNameBox.TextChanged += new System.EventHandler(this.projectNameBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Project Name:";
            // 
            // responseLabel
            // 
            this.responseLabel.AutoSize = true;
            this.responseLabel.Location = new System.Drawing.Point(663, 37);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(46, 17);
            this.responseLabel.TabIndex = 5;
            this.responseLabel.Text = "label2";
            this.responseLabel.Visible = false;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(472, 72);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(72, 17);
            this.linkLabel.TabIndex = 6;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "linkLabel1";
            this.linkLabel.Visible = false;
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter Issue Number:";
            // 
            // issueNumberBox
            // 
            this.issueNumberBox.Location = new System.Drawing.Point(153, 40);
            this.issueNumberBox.Name = "issueNumberBox";
            this.issueNumberBox.Size = new System.Drawing.Size(100, 22);
            this.issueNumberBox.TabIndex = 8;
            this.issueNumberBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // issueLinkLabel
            // 
            this.issueLinkLabel.AutoSize = true;
            this.issueLinkLabel.Location = new System.Drawing.Point(12, 72);
            this.issueLinkLabel.Name = "issueLinkLabel";
            this.issueLinkLabel.Size = new System.Drawing.Size(72, 17);
            this.issueLinkLabel.TabIndex = 9;
            this.issueLinkLabel.TabStop = true;
            this.issueLinkLabel.Text = "linkLabel1";
            this.issueLinkLabel.Visible = false;
            this.issueLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.issueLinkLabel_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 156);
            this.Controls.Add(this.issueLinkLabel);
            this.Controls.Add(this.issueNumberBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.responseLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectNameBox);
            this.Controls.Add(this.useCaseSelectionBox);
            this.Controls.Add(this.createDirectoryButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DTAutoDirectory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createDirectoryButton;
        private System.Windows.Forms.ComboBox useCaseSelectionBox;
        private System.Windows.Forms.TextBox projectNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label responseLabel;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox issueNumberBox;
        private System.Windows.Forms.LinkLabel issueLinkLabel;

    }
}

