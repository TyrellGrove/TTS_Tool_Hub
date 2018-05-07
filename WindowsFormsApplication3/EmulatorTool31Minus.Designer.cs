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
    public void InitializeComponent()
    {
      this.ResultTextBox = new System.Windows.Forms.TextBox();
      this.RunButton = new System.Windows.Forms.Button();
      this.DoneButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.SchemaComboBox1 = new System.Windows.Forms.ComboBox();
      this.SchemaComboBox2 = new System.Windows.Forms.ComboBox();
      this.TableTextBox1 = new System.Windows.Forms.TextBox();
      this.TableTextBox2 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.SCNRTextBox = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // ResultTextBox
      // 
      this.ResultTextBox.Location = new System.Drawing.Point(13, 279);
      this.ResultTextBox.Multiline = true;
      this.ResultTextBox.Name = "ResultTextBox";
      this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.ResultTextBox.Size = new System.Drawing.Size(538, 171);
      this.ResultTextBox.TabIndex = 0;
      // 
      // RunButton
      // 
      this.RunButton.Location = new System.Drawing.Point(245, 221);
      this.RunButton.Name = "RunButton";
      this.RunButton.Size = new System.Drawing.Size(75, 23);
      this.RunButton.TabIndex = 1;
      this.RunButton.Text = "Run";
      this.RunButton.UseVisualStyleBackColor = true;
      this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
      // 
      // DoneButton
      // 
      this.DoneButton.Enabled = false;
      this.DoneButton.Location = new System.Drawing.Point(245, 250);
      this.DoneButton.Name = "DoneButton";
      this.DoneButton.Size = new System.Drawing.Size(75, 23);
      this.DoneButton.TabIndex = 2;
      this.DoneButton.Text = "Done";
      this.DoneButton.UseVisualStyleBackColor = true;
      this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 67);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Schema 1";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 125);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Today\'s Schema ";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 94);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(43, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Table 1";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 153);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(74, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Today\'s Table";
      // 
      // SchemaComboBox1
      // 
      this.SchemaComboBox1.FormattingEnabled = true;
      this.SchemaComboBox1.Items.AddRange(new object[] {
            "",
            "apha",
            "apha_alerts",
            "apha_fieldtest",
            "apha_live",
            "apha_logic",
            "apha_predictions",
            "apha_status",
            "apha_timingdrift",
            "apha_timingplaninfo",
            "apha_topology",
            "apha_users"});
      this.SchemaComboBox1.Location = new System.Drawing.Point(73, 64);
      this.SchemaComboBox1.Name = "SchemaComboBox1";
      this.SchemaComboBox1.Size = new System.Drawing.Size(200, 21);
      this.SchemaComboBox1.TabIndex = 7;
      // 
      // SchemaComboBox2
      // 
      this.SchemaComboBox2.FormattingEnabled = true;
      this.SchemaComboBox2.Items.AddRange(new object[] {
            "",
            "apha",
            "apha_alerts",
            "apha_fieldtest",
            "apha_live",
            "apha_logic",
            "apha_predictions",
            "apha_status",
            "apha_timingdrift",
            "apha_timingplaninfo",
            "apha_topology",
            "apha_users"});
      this.SchemaComboBox2.Location = new System.Drawing.Point(107, 122);
      this.SchemaComboBox2.Name = "SchemaComboBox2";
      this.SchemaComboBox2.Size = new System.Drawing.Size(200, 21);
      this.SchemaComboBox2.TabIndex = 8;
      // 
      // TableTextBox1
      // 
      this.TableTextBox1.Location = new System.Drawing.Point(73, 91);
      this.TableTextBox1.Name = "TableTextBox1";
      this.TableTextBox1.Size = new System.Drawing.Size(200, 20);
      this.TableTextBox1.TabIndex = 9;
      // 
      // TableTextBox2
      // 
      this.TableTextBox2.Location = new System.Drawing.Point(107, 153);
      this.TableTextBox2.Name = "TableTextBox2";
      this.TableTextBox2.Size = new System.Drawing.Size(200, 20);
      this.TableTextBox2.TabIndex = 10;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 189);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(37, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "SCNR";
      // 
      // SCNRTextBox
      // 
      this.SCNRTextBox.Location = new System.Drawing.Point(73, 186);
      this.SCNRTextBox.Name = "SCNRTextBox";
      this.SCNRTextBox.Size = new System.Drawing.Size(100, 20);
      this.SCNRTextBox.TabIndex = 12;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(144, 9);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(278, 20);
      this.label6.TabIndex = 13;
      this.label6.Text = "Emulator Tool for APhA 1.0 to 3.1";
      // 
      // EmulatorTool31Minus
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(563, 462);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.SCNRTextBox);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.TableTextBox2);
      this.Controls.Add(this.TableTextBox1);
      this.Controls.Add(this.SchemaComboBox2);
      this.Controls.Add(this.SchemaComboBox1);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.DoneButton);
      this.Controls.Add(this.RunButton);
      this.Controls.Add(this.ResultTextBox);
      this.Name = "EmulatorTool31Minus";
      this.Text = "Emulator Tool 3.1 Minus";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button RunButton;
    private System.Windows.Forms.Button DoneButton;
    public System.Windows.Forms.TextBox ResultTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox SchemaComboBox1;
    private System.Windows.Forms.ComboBox SchemaComboBox2;
    private System.Windows.Forms.TextBox TableTextBox1;
    private System.Windows.Forms.TextBox TableTextBox2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox SCNRTextBox;
    private System.Windows.Forms.Label label6;
  }
}