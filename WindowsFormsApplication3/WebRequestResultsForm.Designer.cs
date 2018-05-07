namespace TTS_Tool_Hub
{
  partial class WebRequestResultsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebRequestResultsForm));
      this.ResultBox = new System.Windows.Forms.TextBox();
      this.CloseButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ResultBox
      // 
      this.ResultBox.BackColor = System.Drawing.SystemColors.Window;
      this.ResultBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ResultBox.Location = new System.Drawing.Point(12, 12);
      this.ResultBox.MaxLength = 1000000;
      this.ResultBox.Multiline = true;
      this.ResultBox.Name = "ResultBox";
      this.ResultBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.ResultBox.Size = new System.Drawing.Size(1478, 444);
      this.ResultBox.TabIndex = 1;
      // 
      // CloseButton
      // 
      this.CloseButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CloseButton.Location = new System.Drawing.Point(710, 472);
      this.CloseButton.Name = "CloseButton";
      this.CloseButton.Size = new System.Drawing.Size(75, 23);
      this.CloseButton.TabIndex = 2;
      this.CloseButton.Text = "Close";
      this.CloseButton.UseVisualStyleBackColor = true;
      this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // WebRequestResultsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1502, 516);
      this.Controls.Add(this.CloseButton);
      this.Controls.Add(this.ResultBox);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "WebRequestResultsForm";
      this.Text = "Web Request Results";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox ResultBox;
    private System.Windows.Forms.Button CloseButton;
  }
}