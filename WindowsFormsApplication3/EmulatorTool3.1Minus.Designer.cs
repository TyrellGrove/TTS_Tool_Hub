namespace TTS_Tool_Hub
{
  partial class EmulatorTool31Minus
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
      if (disposing && (components != null)) {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmulatorTool31Minus));
      this.WindowBox = new System.Windows.Forms.TextBox();
      this.OriginalCheckBox = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.QuitButton = new System.Windows.Forms.Button();
      this.RunButton = new System.Windows.Forms.Button();
      this.StopButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // WindowBox
      // 
      this.WindowBox.Location = new System.Drawing.Point(12, 105);
      this.WindowBox.MinimumSize = new System.Drawing.Size(260, 100);
      this.WindowBox.Multiline = true;
      this.WindowBox.Name = "WindowBox";
      this.WindowBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.WindowBox.Size = new System.Drawing.Size(260, 144);
      this.WindowBox.TabIndex = 0;
      // 
      // OriginalCheckBox
      // 
      this.OriginalCheckBox.AutoSize = true;
      this.OriginalCheckBox.Location = new System.Drawing.Point(12, 13);
      this.OriginalCheckBox.Name = "OriginalCheckBox";
      this.OriginalCheckBox.Size = new System.Drawing.Size(93, 17);
      this.OriginalCheckBox.TabIndex = 1;
      this.OriginalCheckBox.Text = "Original Data?";
      this.OriginalCheckBox.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 37);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Current Table:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Old Table:";
      // 
      // QuitButton
      // 
      this.QuitButton.Location = new System.Drawing.Point(12, 76);
      this.QuitButton.Name = "QuitButton";
      this.QuitButton.Size = new System.Drawing.Size(75, 23);
      this.QuitButton.TabIndex = 4;
      this.QuitButton.Text = "Quit";
      this.QuitButton.UseVisualStyleBackColor = true;
      // 
      // RunButton
      // 
      this.RunButton.Location = new System.Drawing.Point(104, 76);
      this.RunButton.Name = "RunButton";
      this.RunButton.Size = new System.Drawing.Size(75, 23);
      this.RunButton.TabIndex = 5;
      this.RunButton.Text = "Run";
      this.RunButton.UseVisualStyleBackColor = true;
      // 
      // StopButton
      // 
      this.StopButton.Enabled = false;
      this.StopButton.Location = new System.Drawing.Point(197, 76);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(75, 23);
      this.StopButton.TabIndex = 6;
      this.StopButton.Text = "Stop";
      this.StopButton.UseVisualStyleBackColor = true;
      // 
      // EmulatorTool31Minus
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.StopButton);
      this.Controls.Add(this.RunButton);
      this.Controls.Add(this.QuitButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.OriginalCheckBox);
      this.Controls.Add(this.WindowBox);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "EmulatorTool31Minus";
      this.Text = "Emulator Tool 3.1-";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox WindowBox;
    private System.Windows.Forms.CheckBox OriginalCheckBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button QuitButton;
    private System.Windows.Forms.Button RunButton;
    private System.Windows.Forms.Button StopButton;
  }
}