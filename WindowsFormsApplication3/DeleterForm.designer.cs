namespace APhA_McCain_File_Deleter
{
  partial class DeleterForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleterForm));
      this.StartButton = new System.Windows.Forms.Button();
      this.McCainDirectoryLabel = new System.Windows.Forms.Label();
      this.McCainTimingDirectoryLabel = new System.Windows.Forms.Label();
      this.StatusDirectoryTextBox = new System.Windows.Forms.TextBox();
      this.TimingDirectoryTextBox = new System.Windows.Forms.TextBox();
      this.MessageBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // StartButton
      // 
      this.StartButton.AutoSize = true;
      this.StartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.StartButton.Location = new System.Drawing.Point(166, 133);
      this.StartButton.Name = "StartButton";
      this.StartButton.Size = new System.Drawing.Size(39, 23);
      this.StartButton.TabIndex = 0;
      this.StartButton.Text = "Start";
      this.StartButton.UseVisualStyleBackColor = true;
      this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
      // 
      // McCainDirectoryLabel
      // 
      this.McCainDirectoryLabel.AutoSize = true;
      this.McCainDirectoryLabel.Location = new System.Drawing.Point(134, 28);
      this.McCainDirectoryLabel.Name = "McCainDirectoryLabel";
      this.McCainDirectoryLabel.Size = new System.Drawing.Size(121, 13);
      this.McCainDirectoryLabel.TabIndex = 1;
      this.McCainDirectoryLabel.Text = "McCain Status Directory";
      // 
      // McCainTimingDirectoryLabel
      // 
      this.McCainTimingDirectoryLabel.AutoSize = true;
      this.McCainTimingDirectoryLabel.Location = new System.Drawing.Point(123, 80);
      this.McCainTimingDirectoryLabel.Name = "McCainTimingDirectoryLabel";
      this.McCainTimingDirectoryLabel.Size = new System.Drawing.Size(146, 13);
      this.McCainTimingDirectoryLabel.TabIndex = 2;
      this.McCainTimingDirectoryLabel.Text = "McCain Timing Plan Directory";
      // 
      // StatusDirectoryTextBox
      // 
      this.StatusDirectoryTextBox.Location = new System.Drawing.Point(16, 44);
      this.StatusDirectoryTextBox.Name = "StatusDirectoryTextBox";
      this.StatusDirectoryTextBox.Size = new System.Drawing.Size(350, 20);
      this.StatusDirectoryTextBox.TabIndex = 3;
      // 
      // TimingDirectoryTextBox
      // 
      this.TimingDirectoryTextBox.Location = new System.Drawing.Point(16, 96);
      this.TimingDirectoryTextBox.Name = "TimingDirectoryTextBox";
      this.TimingDirectoryTextBox.Size = new System.Drawing.Size(350, 20);
      this.TimingDirectoryTextBox.TabIndex = 4;
      // 
      // MessageBox
      // 
      this.MessageBox.Location = new System.Drawing.Point(16, 165);
      this.MessageBox.Multiline = true;
      this.MessageBox.Name = "MessageBox";
      this.MessageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.MessageBox.Size = new System.Drawing.Size(350, 84);
      this.MessageBox.TabIndex = 0;
      // 
      // DeleterForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(378, 261);
      this.Controls.Add(this.MessageBox);
      this.Controls.Add(this.TimingDirectoryTextBox);
      this.Controls.Add(this.StatusDirectoryTextBox);
      this.Controls.Add(this.McCainTimingDirectoryLabel);
      this.Controls.Add(this.McCainDirectoryLabel);
      this.Controls.Add(this.StartButton);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "DeleterForm";
      this.Text = "APhA_McCain_File_Deleter";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button StartButton;
    private System.Windows.Forms.Label McCainDirectoryLabel;
    private System.Windows.Forms.Label McCainTimingDirectoryLabel;
    private System.Windows.Forms.TextBox StatusDirectoryTextBox;
    private System.Windows.Forms.TextBox TimingDirectoryTextBox;
    private System.Windows.Forms.TextBox MessageBox;
  }
}

