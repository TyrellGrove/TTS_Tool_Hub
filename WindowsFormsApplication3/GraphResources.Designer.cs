namespace TTS_Tool_Hub
{
  partial class GraphResourcesFrame
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
      this.FilePath = new System.Windows.Forms.TextBox();
      this.CPULoadButton = new System.Windows.Forms.Button();
      this.CPUChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.MemoryChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.CPUBrowse = new System.Windows.Forms.Button();
      this.MemoryBrowse = new System.Windows.Forms.Button();
      this.MemoryLoadButton = new System.Windows.Forms.Button();
      this.MemoryTextBox = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.CPUChart)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MemoryChart)).BeginInit();
      this.SuspendLayout();
      // 
      // FilePath
      // 
      this.FilePath.Location = new System.Drawing.Point(69, 41);
      this.FilePath.Name = "FilePath";
      this.FilePath.Size = new System.Drawing.Size(518, 20);
      this.FilePath.TabIndex = 0;
      // 
      // CPULoadButton
      // 
      this.CPULoadButton.Location = new System.Drawing.Point(331, 12);
      this.CPULoadButton.Name = "CPULoadButton";
      this.CPULoadButton.Size = new System.Drawing.Size(75, 23);
      this.CPULoadButton.TabIndex = 1;
      this.CPULoadButton.Text = "Load File";
      this.CPULoadButton.UseVisualStyleBackColor = true;
      this.CPULoadButton.Click += new System.EventHandler(this.CPULoadButton_Click);
      // 
      // CPUChart
      // 
      chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
      chartArea3.AxisX.IsStartedFromZero = false;
      chartArea3.AxisX.LabelStyle.Format = "hh:mm:ss";
      chartArea3.AxisX.Title = "Time";
      chartArea3.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      chartArea3.AxisX2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
      chartArea3.AxisX2.IsStartedFromZero = false;
      chartArea3.AxisY.Title = "CPU Usage %";
      chartArea3.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      chartArea3.BorderWidth = 3;
      chartArea3.Name = "ChartArea1";
      this.CPUChart.ChartAreas.Add(chartArea3);
      legend3.Name = "Processes";
      legend3.Title = "Processes";
      this.CPUChart.Legends.Add(legend3);
      this.CPUChart.Location = new System.Drawing.Point(12, 67);
      this.CPUChart.Name = "CPUChart";
      series7.BorderWidth = 3;
      series7.ChartArea = "ChartArea1";
      series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series7.Legend = "Processes";
      series7.Name = "Process1";
      series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
      series8.BorderWidth = 3;
      series8.ChartArea = "ChartArea1";
      series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series8.Legend = "Processes";
      series8.Name = "Process2";
      series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
      series9.BorderWidth = 3;
      series9.ChartArea = "ChartArea1";
      series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series9.Legend = "Processes";
      series9.Name = "Process3";
      series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
      this.CPUChart.Series.Add(series7);
      this.CPUChart.Series.Add(series8);
      this.CPUChart.Series.Add(series9);
      this.CPUChart.Size = new System.Drawing.Size(720, 494);
      this.CPUChart.TabIndex = 2;
      this.CPUChart.Text = "CPU";
      title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      title3.Name = "Title1";
      title3.Text = "CPU Usage (in %)";
      this.CPUChart.Titles.Add(title3);
      // 
      // MemoryChart
      // 
      chartArea4.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
      chartArea4.AxisX.IsStartedFromZero = false;
      chartArea4.AxisX.LabelStyle.Format = "hh:mm:ss";
      chartArea4.AxisX.Title = "Time";
      chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      chartArea4.AxisX2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
      chartArea4.AxisX2.IsStartedFromZero = false;
      chartArea4.AxisY.Title = "Mbs";
      chartArea4.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      chartArea4.Name = "ChartArea1";
      this.MemoryChart.ChartAreas.Add(chartArea4);
      legend4.Name = "Legend1";
      legend4.Title = "Processes";
      this.MemoryChart.Legends.Add(legend4);
      this.MemoryChart.Location = new System.Drawing.Point(738, 67);
      this.MemoryChart.Name = "MemoryChart";
      series10.BorderWidth = 3;
      series10.ChartArea = "ChartArea1";
      series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series10.Legend = "Legend1";
      series10.Name = "Process1";
      series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
      series11.BorderWidth = 3;
      series11.ChartArea = "ChartArea1";
      series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series11.Legend = "Legend1";
      series11.Name = "Process2";
      series11.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
      series12.BorderWidth = 3;
      series12.ChartArea = "ChartArea1";
      series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series12.Legend = "Legend1";
      series12.Name = "Process3";
      series12.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
      this.MemoryChart.Series.Add(series10);
      this.MemoryChart.Series.Add(series11);
      this.MemoryChart.Series.Add(series12);
      this.MemoryChart.Size = new System.Drawing.Size(728, 494);
      this.MemoryChart.TabIndex = 7;
      this.MemoryChart.Text = "Memory";
      title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      title4.Name = "Title1";
      title4.Text = "Memory Usage (in Mbs)";
      this.MemoryChart.Titles.Add(title4);
      // 
      // CPUBrowse
      // 
      this.CPUBrowse.Location = new System.Drawing.Point(593, 38);
      this.CPUBrowse.Name = "CPUBrowse";
      this.CPUBrowse.Size = new System.Drawing.Size(75, 23);
      this.CPUBrowse.TabIndex = 8;
      this.CPUBrowse.Text = "Browse";
      this.CPUBrowse.UseVisualStyleBackColor = true;
      // 
      // MemoryBrowse
      // 
      this.MemoryBrowse.Location = new System.Drawing.Point(1326, 38);
      this.MemoryBrowse.Name = "MemoryBrowse";
      this.MemoryBrowse.Size = new System.Drawing.Size(75, 23);
      this.MemoryBrowse.TabIndex = 11;
      this.MemoryBrowse.Text = "Browse";
      this.MemoryBrowse.UseVisualStyleBackColor = true;
      // 
      // MemoryLoadButton
      // 
      this.MemoryLoadButton.Location = new System.Drawing.Point(1064, 12);
      this.MemoryLoadButton.Name = "MemoryLoadButton";
      this.MemoryLoadButton.Size = new System.Drawing.Size(75, 23);
      this.MemoryLoadButton.TabIndex = 10;
      this.MemoryLoadButton.Text = "Load File";
      this.MemoryLoadButton.UseVisualStyleBackColor = true;
      this.MemoryLoadButton.Click += new System.EventHandler(this.MemoryLoadButton_Click);
      // 
      // MemoryTextBox
      // 
      this.MemoryTextBox.Location = new System.Drawing.Point(802, 41);
      this.MemoryTextBox.Name = "MemoryTextBox";
      this.MemoryTextBox.Size = new System.Drawing.Size(518, 20);
      this.MemoryTextBox.TabIndex = 9;
      // 
      // GraphResourcesFrame
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1478, 601);
      this.Controls.Add(this.MemoryBrowse);
      this.Controls.Add(this.MemoryLoadButton);
      this.Controls.Add(this.MemoryTextBox);
      this.Controls.Add(this.CPUBrowse);
      this.Controls.Add(this.MemoryChart);
      this.Controls.Add(this.CPUChart);
      this.Controls.Add(this.CPULoadButton);
      this.Controls.Add(this.FilePath);
      this.Name = "GraphResourcesFrame";
      this.Text = "Graph Resources";
      ((System.ComponentModel.ISupportInitialize)(this.CPUChart)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MemoryChart)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox FilePath;
    private System.Windows.Forms.Button CPULoadButton;
    private System.Windows.Forms.DataVisualization.Charting.Chart CPUChart;
    private System.Windows.Forms.DataVisualization.Charting.Chart MemoryChart;
    private System.Windows.Forms.Button CPUBrowse;
    private System.Windows.Forms.Button MemoryBrowse;
    private System.Windows.Forms.Button MemoryLoadButton;
    private System.Windows.Forms.TextBox MemoryTextBox;
  }
}