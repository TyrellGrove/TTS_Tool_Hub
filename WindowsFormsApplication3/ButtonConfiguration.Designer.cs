namespace TTS_Tool_Hub
{
  partial class ButtonConfiguration
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonConfiguration));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.ButtonTextBox = new System.Windows.Forms.TextBox();
      this.DirectoryTextBox = new System.Windows.Forms.TextBox();
      this.Edit31 = new System.Windows.Forms.Button();
      this.CancelButton = new System.Windows.Forms.Button();
      this.OKButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(67, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Button Label";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(49, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Directory";
      // 
      // ButtonTextBox
      // 
      this.ButtonTextBox.Location = new System.Drawing.Point(86, 10);
      this.ButtonTextBox.Name = "ButtonTextBox";
      this.ButtonTextBox.Size = new System.Drawing.Size(218, 20);
      this.ButtonTextBox.TabIndex = 2;
      // 
      // DirectoryTextBox
      // 
      this.DirectoryTextBox.Location = new System.Drawing.Point(68, 44);
      this.DirectoryTextBox.Name = "DirectoryTextBox";
      this.DirectoryTextBox.Size = new System.Drawing.Size(201, 20);
      this.DirectoryTextBox.TabIndex = 3;
      // 
      // Edit31
      // 
      this.Edit31.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Edit31.BackgroundImage")));
      this.Edit31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.Edit31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Edit31.Location = new System.Drawing.Point(276, 44);
      this.Edit31.Name = "Edit31";
      this.Edit31.Size = new System.Drawing.Size(28, 20);
      this.Edit31.TabIndex = 42;
      this.Edit31.UseVisualStyleBackColor = true;
      this.Edit31.Click += new System.EventHandler(this.Edit31_Click);
      // 
      // CancelButton
      // 
      this.CancelButton.Location = new System.Drawing.Point(68, 89);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 43;
      this.CancelButton.Text = "Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(194, 89);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 44;
      this.OKButton.Text = "OK";
      this.OKButton.UseMnemonic = false;
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // ButtonConfiguration
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(323, 124);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.CancelButton);
      this.Controls.Add(this.Edit31);
      this.Controls.Add(this.DirectoryTextBox);
      this.Controls.Add(this.ButtonTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "ButtonConfiguration";
      this.Text = "ButtonConfiguration";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox ButtonTextBox;
    private System.Windows.Forms.TextBox DirectoryTextBox;
    private System.Windows.Forms.Button Edit31;
    private System.Windows.Forms.Button CancelButton;
    private System.Windows.Forms.Button OKButton;
  }
}