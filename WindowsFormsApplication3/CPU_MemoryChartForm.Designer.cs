namespace CPU_MemoryChart
{
  partial class RecourceMonitorForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecourceMonitorForm));
      this.CPUChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.StartButton = new System.Windows.Forms.Button();
      this.ProcessOneDropDown = new System.Windows.Forms.ComboBox();
      this.ProcessTwoDropDown = new System.Windows.Forms.ComboBox();
      this.ProcessThreeDropDown = new System.Windows.Forms.ComboBox();
      this.LabelForProcesses = new System.Windows.Forms.Label();
      this.MemoryChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.IncludeCPUReportCheckBox = new System.Windows.Forms.CheckBox();
      this.IncludeMemoryReportCheckBox = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.TimmerBox = new System.Windows.Forms.ComboBox();
      this.StartTimeLabel = new System.Windows.Forms.Label();
      this.TotalcheckBox = new System.Windows.Forms.CheckBox();
      this.SchedulerButton = new System.Windows.Forms.Button();
      this.DateTimeTextBox = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.CPUChart)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MemoryChart)).BeginInit();
      this.SuspendLayout();
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
      this.CPUChart.Location = new System.Drawing.Point(12, 134);
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
      this.CPUChart.Size = new System.Drawing.Size(716, 494);
      this.CPUChart.TabIndex = 0;
      this.CPUChart.Text = "CPU";
      title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      title1.Name = "Title1";
      title1.Text = "CPU Usage (in %)";
      this.CPUChart.Titles.Add(title1);
      // 
      // StartButton
      // 
      this.StartButton.Location = new System.Drawing.Point(683, 12);
      this.StartButton.Name = "StartButton";
      this.StartButton.Size = new System.Drawing.Size(92, 23);
      this.StartButton.TabIndex = 1;
      this.StartButton.Text = "Start Monitoring";
      this.StartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.StartButton.UseVisualStyleBackColor = true;
      this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
      // 
      // ProcessOneDropDown
      // 
      this.ProcessOneDropDown.FormattingEnabled = true;
      this.ProcessOneDropDown.Location = new System.Drawing.Point(333, 42);
      this.ProcessOneDropDown.Name = "ProcessOneDropDown";
      this.ProcessOneDropDown.Size = new System.Drawing.Size(271, 21);
      this.ProcessOneDropDown.TabIndex = 2;
      this.ProcessOneDropDown.SelectedIndexChanged += new System.EventHandler(this.ProcessOneDropDown_SelectedIndexChanged);
      this.ProcessOneDropDown.Click += new System.EventHandler(this.ProcessOneDropDown_Click);
      // 
      // ProcessTwoDropDown
      // 
      this.ProcessTwoDropDown.FormattingEnabled = true;
      this.ProcessTwoDropDown.Location = new System.Drawing.Point(610, 42);
      this.ProcessTwoDropDown.Name = "ProcessTwoDropDown";
      this.ProcessTwoDropDown.Size = new System.Drawing.Size(303, 21);
      this.ProcessTwoDropDown.TabIndex = 3;
      this.ProcessTwoDropDown.SelectedIndexChanged += new System.EventHandler(this.ProcessTwoDropDown_SelectedIndexChanged);
      this.ProcessTwoDropDown.Click += new System.EventHandler(this.ProcessTwoDropDown_Click);
      // 
      // ProcessThreeDropDown
      // 
      this.ProcessThreeDropDown.FormattingEnabled = true;
      this.ProcessThreeDropDown.Location = new System.Drawing.Point(919, 42);
      this.ProcessThreeDropDown.Name = "ProcessThreeDropDown";
      this.ProcessThreeDropDown.Size = new System.Drawing.Size(312, 21);
      this.ProcessThreeDropDown.TabIndex = 4;
      this.ProcessThreeDropDown.SelectedIndexChanged += new System.EventHandler(this.ProcessThreeDropDown_SelectedIndexChanged);
      this.ProcessThreeDropDown.Click += new System.EventHandler(this.ProcessThreeDropDown_Click);
      // 
      // LabelForProcesses
      // 
      this.LabelForProcesses.AutoSize = true;
      this.LabelForProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabelForProcesses.Location = new System.Drawing.Point(202, 45);
      this.LabelForProcesses.Name = "LabelForProcesses";
      this.LabelForProcesses.Size = new System.Drawing.Size(125, 13);
      this.LabelForProcesses.TabIndex = 5;
      this.LabelForProcesses.Text = "Processes Monitored";
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
      this.MemoryChart.Location = new System.Drawing.Point(734, 134);
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
      this.MemoryChart.Size = new System.Drawing.Size(727, 494);
      this.MemoryChart.TabIndex = 6;
      this.MemoryChart.Text = "Memory";
      title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      title2.Name = "Title1";
      title2.Text = "Memory Usage (in Mbs)";
      this.MemoryChart.Titles.Add(title2);
      // 
      // IncludeCPUReportCheckBox
      // 
      this.IncludeCPUReportCheckBox.AutoSize = true;
      this.IncludeCPUReportCheckBox.Checked = true;
      this.IncludeCPUReportCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.IncludeCPUReportCheckBox.Location = new System.Drawing.Point(12, 111);
      this.IncludeCPUReportCheckBox.Name = "IncludeCPUReportCheckBox";
      this.IncludeCPUReportCheckBox.Size = new System.Drawing.Size(121, 17);
      this.IncludeCPUReportCheckBox.TabIndex = 8;
      this.IncludeCPUReportCheckBox.Text = "Include CPU Report";
      this.IncludeCPUReportCheckBox.UseVisualStyleBackColor = true;
      // 
      // IncludeMemoryReportCheckBox
      // 
      this.IncludeMemoryReportCheckBox.AutoSize = true;
      this.IncludeMemoryReportCheckBox.Checked = true;
      this.IncludeMemoryReportCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.IncludeMemoryReportCheckBox.Location = new System.Drawing.Point(734, 111);
      this.IncludeMemoryReportCheckBox.Name = "IncludeMemoryReportCheckBox";
      this.IncludeMemoryReportCheckBox.Size = new System.Drawing.Size(136, 17);
      this.IncludeMemoryReportCheckBox.TabIndex = 9;
      this.IncludeMemoryReportCheckBox.Text = "Include Memory Report";
      this.IncludeMemoryReportCheckBox.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(568, 70);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(109, 16);
      this.label1.TabIndex = 10;
      this.label1.Text = "Time Duration:";
      // 
      // TimmerBox
      // 
      this.TimmerBox.FormattingEnabled = true;
      this.TimmerBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "30",
            "40",
            "50",
            "60",
            "90",
            "120"});
      this.TimmerBox.Location = new System.Drawing.Point(683, 65);
      this.TimmerBox.Name = "TimmerBox";
      this.TimmerBox.Size = new System.Drawing.Size(56, 21);
      this.TimmerBox.TabIndex = 11;
      // 
      // StartTimeLabel
      // 
      this.StartTimeLabel.AutoSize = true;
      this.StartTimeLabel.Location = new System.Drawing.Point(571, 90);
      this.StartTimeLabel.Name = "StartTimeLabel";
      this.StartTimeLabel.Size = new System.Drawing.Size(35, 13);
      this.StartTimeLabel.TabIndex = 12;
      this.StartTimeLabel.Text = "label2";
      // 
      // TotalcheckBox
      // 
      this.TotalcheckBox.AutoSize = true;
      this.TotalcheckBox.Location = new System.Drawing.Point(1238, 45);
      this.TotalcheckBox.Name = "TotalcheckBox";
      this.TotalcheckBox.Size = new System.Drawing.Size(138, 17);
      this.TotalcheckBox.TabIndex = 13;
      this.TotalcheckBox.Text = "Total CPU & Mem Usage";
      this.TotalcheckBox.UseVisualStyleBackColor = true;
      this.TotalcheckBox.CheckedChanged += new System.EventHandler(this.TotalcheckBox_CheckedChanged);
      // 
      // SchedulerButton
      // 
      this.SchedulerButton.Location = new System.Drawing.Point(1125, 69);
      this.SchedulerButton.Name = "SchedulerButton";
      this.SchedulerButton.Size = new System.Drawing.Size(126, 23);
      this.SchedulerButton.TabIndex = 15;
      this.SchedulerButton.Text = "Start Scheduler";
      this.SchedulerButton.UseVisualStyleBackColor = true;
      this.SchedulerButton.Click += new System.EventHandler(this.SchedulerButton_Click);
      // 
      // DateTimeTextBox
      // 
      this.DateTimeTextBox.Location = new System.Drawing.Point(919, 69);
      this.DateTimeTextBox.Name = "DateTimeTextBox";
      this.DateTimeTextBox.Size = new System.Drawing.Size(200, 20);
      this.DateTimeTextBox.TabIndex = 16;
      // 
      // RecourceMonitorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(1473, 640);
      this.Controls.Add(this.DateTimeTextBox);
      this.Controls.Add(this.SchedulerButton);
      this.Controls.Add(this.TotalcheckBox);
      this.Controls.Add(this.StartTimeLabel);
      this.Controls.Add(this.TimmerBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.IncludeMemoryReportCheckBox);
      this.Controls.Add(this.IncludeCPUReportCheckBox);
      this.Controls.Add(this.MemoryChart);
      this.Controls.Add(this.LabelForProcesses);
      this.Controls.Add(this.ProcessThreeDropDown);
      this.Controls.Add(this.ProcessTwoDropDown);
      this.Controls.Add(this.ProcessOneDropDown);
      this.Controls.Add(this.StartButton);
      this.Controls.Add(this.CPUChart);
      //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "RecourceMonitorForm";
      this.Text = "TTS Recource Monitor";
      ((System.ComponentModel.ISupportInitialize)(this.CPUChart)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MemoryChart)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart CPUChart;
    private System.Windows.Forms.Button StartButton;
    private System.Windows.Forms.ComboBox ProcessOneDropDown;
    private System.Windows.Forms.ComboBox ProcessTwoDropDown;
    private System.Windows.Forms.ComboBox ProcessThreeDropDown;
    private System.Windows.Forms.Label LabelForProcesses;
    private System.Windows.Forms.DataVisualization.Charting.Chart MemoryChart;
    private System.Windows.Forms.CheckBox IncludeCPUReportCheckBox;
    private System.Windows.Forms.CheckBox IncludeMemoryReportCheckBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox TimmerBox;
    private System.Windows.Forms.Label StartTimeLabel;
    private System.Windows.Forms.CheckBox TotalcheckBox;
    private System.Windows.Forms.Button SchedulerButton;
    private System.Windows.Forms.TextBox DateTimeTextBox;
  }
}

