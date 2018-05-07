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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.CPULoadButton.Location = new System.Drawing.Point(326, 12);
            this.CPULoadButton.Name = "CPULoadButton";
            this.CPULoadButton.Size = new System.Drawing.Size(75, 23);
            this.CPULoadButton.TabIndex = 1;
            this.CPULoadButton.Text = "Load File";
            this.CPULoadButton.UseVisualStyleBackColor = true;
            this.CPULoadButton.Click += new System.EventHandler(this.CPULoadButton_Click);
            // 
            // CPUChart
            // 
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Format = "hh:mm:ss";
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX2.IsStartedFromZero = false;
            chartArea1.AxisY.Title = "CPU Usage %";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BorderWidth = 3;
            chartArea1.Name = "ChartArea1";
            this.CPUChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Processes";
            legend1.Title = "Processes";
            this.CPUChart.Legends.Add(legend1);
            this.CPUChart.Location = new System.Drawing.Point(12, 67);
            this.CPUChart.Name = "CPUChart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Processes";
            series1.Name = "Process1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Processes";
            series2.Name = "Process2";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Processes";
            series3.Name = "Process3";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.CPUChart.Series.Add(series1);
            this.CPUChart.Series.Add(series2);
            this.CPUChart.Series.Add(series3);
            this.CPUChart.Size = new System.Drawing.Size(720, 494);
            this.CPUChart.TabIndex = 2;
            this.CPUChart.Text = "CPU";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "CPU Usage (in %)";
            this.CPUChart.Titles.Add(title1);
            // 
            // MemoryChart
            // 
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea2.AxisX.IsStartedFromZero = false;
            chartArea2.AxisX.LabelStyle.Format = "hh:mm:ss";
            chartArea2.AxisX.Title = "Time";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea2.AxisX2.IsStartedFromZero = false;
            chartArea2.AxisY.Title = "Mbs";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartArea1";
            this.MemoryChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            legend2.Title = "Processes";
            this.MemoryChart.Legends.Add(legend2);
            this.MemoryChart.Location = new System.Drawing.Point(738, 67);
            this.MemoryChart.Name = "MemoryChart";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Process1";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Process2";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Process3";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.MemoryChart.Series.Add(series4);
            this.MemoryChart.Series.Add(series5);
            this.MemoryChart.Series.Add(series6);
            this.MemoryChart.Size = new System.Drawing.Size(728, 494);
            this.MemoryChart.TabIndex = 7;
            this.MemoryChart.Text = "Memory";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Memory Usage (in Mbs)";
            this.MemoryChart.Titles.Add(title2);
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