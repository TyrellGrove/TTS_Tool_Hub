using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Timers;


namespace CPU_MemoryChart
{
  public partial class RecourceMonitorForm : Form
  {
    //All of the publicly used varibles that are shared across methods.
    #region Public Variables
    public int runStarted = 0;
    public int run = 0;
    public List<double> cpuList1 = new List<double>();
    public List<double> cpuList2 = new List<double>();
    public List<double> cpuList3 = new List<double>();
    public List<DateTime> cpuList1Time = new List<DateTime>();
    public List<DateTime> cpuList2Time = new List<DateTime>();
    public List<DateTime> cpuList3Time = new List<DateTime>();
    public List<double> memoryList1 = new List<double>();
    public List<double> memoryList2 = new List<double>();
    public List<double> memoryList3 = new List<double>();
    public List<DateTime> memoryList1Time = new List<DateTime>();
    public List<DateTime> memoryList2Time = new List<DateTime>();
    public List<DateTime> memoryList3Time = new List<DateTime>();
    public List<Process> myCategoryList1 = new List<Process>();
    public List<Process> myCategoryList2 = new List<Process>();
    public List<Process> myCategoryList3 = new List<Process>();
    public int Process1 = 0;
    public int Process2 = 0;
    public int Process3 = 0;
    public Process currentProcess1 = new Process();
    public Process currentProcess2 = new Process();
    public Process currentProcess3 = new Process();
    public string Name0;
    public string Name1;
    public string Name2;
    public string Name3;
    public DateTime StartTime;
    public DateTime EndTime;
    public System.Timers.Timer myTimer = new System.Timers.Timer();
    public System.Timers.Timer mySchedulerTimer = new System.Timers.Timer();
    #endregion

    //Initialization of the form.
    public RecourceMonitorForm()
    {
      InitializeComponent();
      StartTimeLabel.Text = "";
      TimmerBox.SelectedIndex = 0;
      DateTimeTextBox.Text = DateTime.Now.ToString();
    }

    /// <summary>
    /// Memory Chart Utility Methods
    /// Includes the getMemoryUsageData(), GetMemoryRam(ref List<double> List, ref List<DateTime> Time, ref int Process, ref string myName),
    /// When you click the start monitoring button in the form it goes to the getMemoryUsageData() method which sorts out what processes are being used and starts the GetMemoryRam method on a 
    /// Task for the correctly used processes. Once GetMemoryRam is complete it will invoke a delegate call to the UpdateChart method which adds new points to the chart.
    /// Once UpdateChart method is complete it will invoke a delegate call to the UpdateChartLegend method and updates the title and series names with the datetime and memory usage in Mbs.
    /// </summary>
    #region Memory Chart Utility Methods

    public delegate void getMemoryUsageDataCallback();
    /// <summary> 
    /// getMemoryUsageData() AKA MemoryMain()
    /// Determines what processes are being used and how many we are monitoring, Then initializes the GetMemoryRam() on a new task in a while loop. Then updates the chart and legend once GetMemoryRam()
    /// is complete.
    /// </summary>
    public void getMemoryUsageData()
    {
      while (StartButton.Text == "Stop Monitoring") {
        System.Threading.Thread.Sleep(1000);
        Task MemoryRamTask1 = new Task(() => GetMemoryRam(ref memoryList1, ref memoryList1Time, ref Process1, ref Name1));
        MemoryRamTask1.Start();

        Task MemoryRamTask2 = new Task(() => GetMemoryRam(ref memoryList2, ref memoryList2Time, ref Process2, ref Name2));
        MemoryRamTask2.Start();

        Task MemoryRamTask3 = new Task(() => GetMemoryRam(ref memoryList3, ref memoryList3Time, ref Process3, ref Name3));
        MemoryRamTask3.Start();

        MemoryRamTask1.Wait();
        MemoryRamTask2.Wait();
        MemoryRamTask3.Wait();

        if (MemoryChart.IsHandleCreated) {
          this.MemoryChart.BeginInvoke((MethodInvoker)delegate() { UpdateChart(ref MemoryChart, ref memoryList1, ref memoryList2, ref memoryList3, ref memoryList1Time, ref memoryList2Time, ref memoryList3Time); });
          this.MemoryChart.BeginInvoke((MethodInvoker)delegate() { UpdateChartLegend(DateTime.Now.ToString("h:mm:ss tt"), ref MemoryChart, ref memoryList1, ref memoryList2, ref memoryList3, ref Name1, ref Name2, ref Name3, true); });
        }

      }//End While
    }

    /// <summary> 
    /// GetMemoryRam(ref List<double> List, ref List<DateTime> Time, ref int Process, ref string myName)
    /// Gets the actual ram usage of the process in bytes, Convert that to Mbs by dividing the received value by 1048576, 
    /// Stores that data and the time we got it into the list and time lists for later reporting.
    /// </summary>
    public void GetMemoryRam(ref List<double> List, ref List<DateTime> Time, ref int Process, ref string myName)
    {
      if (IsRunning(Process) & Process != 0) {
        using (PerformanceCounter pcProcess = new PerformanceCounter("Process", "Working Set - Private", myName)) {
          List.Add(Math.Round(((double)pcProcess.NextValue() / 1048576.0), 3)); //1048576 is the number of bytes per mega byte
          Time.Add(DateTime.Now);
        }
      }
      else {
        List.Add(0.00);
        Time.Add(DateTime.Now);
      }
    }
    #endregion

    /// <summary>
    /// CPU Chart Utility Methods
    /// Includes the getCPUUsageDate(), GetCPUPercent(ref List<double> List, ref List<DateTime> Time, ref int Process, ref string myName),
    /// When you click the start monitoring button in the form it goes to the getCPUUsageData() method which sorts out what processes are being used and starts the GetCPUPercent method on a 
    /// Task for the correctly used processes. Once GetCPUPercent is complete it will invoke a delegate call to the UpdateChart method which adds new points to the chart. 
    /// Once the UpdateChart method completes also invokes a delegate for the UpdateChartLegend method and updates the title and series names with the current time and % CPU used.
    /// </summary>
    #region CPU Chart Utility Methods

    /// <summary> 
    /// getCPUUsageData() AKA CPUMain
    /// Determines what processes are being used and how many we are monitoring, Then initializes the GetCPUPercent() on a new task and starts in a while loop.
    /// </summary>
    public void getCPUUsageDate()
    {
      while (StartButton.Text == "Stop Monitoring") {                                                                           //After you have clicked the Start Monitoring button once.                     

        Task CPUPercentTask1 = new Task(() => GetCPUPercent(ref cpuList1, ref cpuList1Time, ref Process1, ref Name1));          //Initialize new task that will run the GetCPUPercent Method and pass it all process1 CPU stuff.
        CPUPercentTask1.Start();                                                                                                   //Start thread.

        Task CPUPercentTask2 = new Task(() => GetCPUPercent(ref cpuList2, ref cpuList2Time, ref Process2, ref Name2));          //Initialize new task that will run the GetCPUPercent Method and pass it all process2 CPU stuff.
        CPUPercentTask2.Start();                                                                                                   //Start thread.

        Task CPUPercentTask3 = new Task(() => GetCPUPercent(ref cpuList3, ref cpuList3Time, ref Process3, ref Name3));          //Initialize new task that will run the GetCPUPercent Method and pass it all process3 CPU stuff.
        CPUPercentTask3.Start();                                                                                                   //Start thread.

        CPUPercentTask1.Wait();                                                                                                 //Wait for all tasks to come back before proceeding.
        CPUPercentTask2.Wait();
        CPUPercentTask3.Wait();

        if (CPUChart.IsHandleCreated) {
          this.CPUChart.BeginInvoke((MethodInvoker)delegate() { UpdateChart(ref CPUChart, ref cpuList1, ref cpuList2, ref cpuList3, ref cpuList1Time, ref cpuList2Time, ref cpuList3Time); });
          this.CPUChart.BeginInvoke((MethodInvoker)delegate() { UpdateChartLegend(DateTime.Now.ToString("h:mm:ss tt"), ref CPUChart, ref cpuList1, ref cpuList2, ref cpuList3, ref Name1, ref Name2, ref Name3, false); });
        }
      }
    }

    /// <summary>
    /// GetCPUPercent(ref List<double> List, ref List<DateTime> Time, ref int Process, ref string myName)
    /// Gets the actual % of CPU used for a process compared to each Logic Processor. IE you have a 4 core hyperthreaded processor it has 8 Logic Processors.
    /// Initializes a Performance Counter for the % Processor Time and grabs a value from it.
    /// Wait for 1 second then grab the next value and divide it the number of Logic Processors. This can be done by the Environment.ProcessorCount property in windows. NOTE: We round this to 3 decimals.
    /// Add this value to the CPU list and add the current DateTime to the CPU time list.
    /// </summary>
    public void GetCPUPercent(ref List<double> List, ref List<DateTime> Time, ref int Process, ref string myName)
    {
      if (IsRunning(Process) & Process != 0) {
        using (PerformanceCounter pcProcess = new PerformanceCounter("Process", "% Processor Time", myName)) {
          pcProcess.NextValue();
          System.Threading.Thread.Sleep(1000);
          List.Add(Math.Round(((double)pcProcess.NextValue() / (double)Environment.ProcessorCount), 3));
          Time.Add(DateTime.Now);
        }
      }
      else {
        List.Add(0.00);
        Time.Add(DateTime.Now);
      }
    }
    #endregion

    /// <summary>
    /// These are the methods related to the set duration of time you want to monitor processes.
    /// </summary>
    #region Count Down Timer Methods
    /// <summary>
    /// Is the main looping method the handles the text of the Time lables.
    /// AKA Time left before we will stop monitoring.
    /// </summary>
    public void getTimeLeft()
    {
      while (StartButton.Text == "Stop Monitoring") {
        System.Threading.Thread.Sleep(1000);
        this.CPUChart.BeginInvoke((MethodInvoker)delegate() { UpdateStartTime(); });
      }
    }

    /// <summary>
    /// Updates the label of the Time remaining before the system will click the StartButton control for you.
    /// </summary>
    public void UpdateStartTime()
    {
      TimeSpan TimeLeft = EndTime - DateTime.Now;

      StartTimeLabel.Text = "Start Time was " + StartTime.ToShortTimeString() + " Time Left is " + TimeLeft.ToString(@"dd\.hh\:mm\:ss");

      if (TimeLeft.Ticks <= 0 & StartButton.Text == "Stop Monitoring") StartButton.PerformClick();
    }
    #endregion

    /// <summary>
    /// These are the methods related to getting the entire systems CPU% and Memory%.
    /// Remember this is the system use not the user. So the Task manager won't match because it doesn't account for what the system is needing just to run. about 3% on both ram and CPU.
    /// </summary>
    #region Total CPU and Memory methods

    /// <summary>
    /// Is the Timer that triggers the Total_Usage method after every elapse of the timer. This is triggered if the TotalCheckedBox is true and on first click of the Start button.
    /// </summary>
    public void Total_Percentage()
    {
      myTimer = new System.Timers.Timer();
      myTimer.AutoReset = true;
      myTimer.Interval = 500;
      myTimer.Elapsed += new System.Timers.ElapsedEventHandler(Total_Usage);
      myTimer.Start();
    }

    /// <summary>
    /// This is the work horse of the Total CPU and Memory usage. It will completely ignore the drop down processes and only work on the total system usage.
    /// We use PerformanceCounter's to get the data from the processes.
    /// Have to add to all of the lists for All Memory, MemoryTime, CPU, CPUTime for processe 1 and 3. We just add zero to them for usage and the now time for time so graph doesn't crash when graphing.
    /// Have to set Name2 for use in the legend.
    /// You have to get CPUcounter value then sleep for a known amount of time before getting the real value and adding it to the cpuList
    /// Memory just needs to be grabbed when you need it since memory use is not based on Processor Time to determine the amount of cpu usage in percent.
    /// If we have CPU and Memory chart handlers. IE if they are up and runing we are going to try and add to them. else we will catch it next time.
    /// </summary>
    public void Total_Usage(object sender, System.Timers.ElapsedEventArgs e)
    {
      PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
      PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

      cpuList1.Add(0.00);
      cpuList1Time.Add(DateTime.Now);
      memoryList1.Add(0.00);
      memoryList1Time.Add(DateTime.Now);
      cpuList3.Add(0.00);
      cpuList3Time.Add(DateTime.Now);
      memoryList3.Add(0.00);
      memoryList3Time.Add(DateTime.Now);

      Name2 = "Total";

      cpuCounter.NextValue();
      System.Threading.Thread.Sleep(1000);

      cpuList2.Add(Math.Round(((double)cpuCounter.NextValue()), 3));
      cpuList2Time.Add(DateTime.Now);

      memoryList2.Add(Math.Round(((double)((1 - (ramCounter.NextValue() / (Int64)((new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory) / 1000000))) * 100)), 3));
      memoryList2Time.Add(DateTime.Now);

      if (CPUChart.IsHandleCreated) {
        this.CPUChart.BeginInvoke((MethodInvoker)delegate() { UpdateChart(ref CPUChart, ref cpuList1, ref cpuList2, ref cpuList3, ref cpuList1Time, ref cpuList2Time, ref cpuList3Time); });
        this.CPUChart.BeginInvoke((MethodInvoker)delegate()
        {
          try {
            CPUChart.Series[1].Name = Name2 + " CPU Usage(" + cpuList2.Last().ToString() + "%)";
          }
          catch { } //If we catch we don't update the legend. Something off happend and we will get it next time. });
        });
      }

      if (MemoryChart.IsHandleCreated) {
        this.MemoryChart.BeginInvoke((MethodInvoker)delegate() { UpdateChart(ref MemoryChart, ref memoryList1, ref memoryList2, ref memoryList3, ref memoryList1Time, ref memoryList2Time, ref memoryList3Time); });
        this.MemoryChart.BeginInvoke((MethodInvoker)delegate()
        {
          try {
            MemoryChart.Series[1].Name = Name2 + " Memory Usage(" + memoryList2.Last().ToString() + "%)";
          }
          catch { } //If we catch we don't update the legend. Something off happend and we will get it next time. });
        });
      }
    }

    /// <summary>
    /// This is the method that when the TotalCheckbox is checked true that it disables the process dropdowns. Then undo that if it is unchecked.
    /// </summary>
    private void TotalcheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (!TotalcheckBox.Checked) {
        ProcessOneDropDown.Enabled = true;
        ProcessTwoDropDown.Enabled = true;
        ProcessThreeDropDown.Enabled = true;
      }

      else {
        ProcessOneDropDown.Enabled = false;
        ProcessTwoDropDown.Enabled = false;
        ProcessThreeDropDown.Enabled = false;
      }
    }
    #endregion

    /// <summary>
    /// General Utilities Methods
    /// Includes the IsRunning(int i), GetProcessInstanceName(int pid), ClearPublicVariables(), FormateForRun(),
    /// UpdateChart(ref System.Windows.Forms.DataVisualization.Charting.Chart myChart, ref List<double> List1, ref List<double> List2, ref List<double> List3, ref List<DateTime> Time1, ref List<DateTime> Time2, ref List<DateTime> Time3)
    /// UpdateChartLegend(string myTime, ref System.Windows.Forms.DataVisualization.Charting.Chart myChart, ref List<double> List1, ref List<double> List2, ref List<double> List3, ref string Name1, ref string Name2, ref string Name3)
    /// These are utility methods that are used in both the Memory and CPU gathering processes.
    /// </summary>
    #region General Utilities Methods

    /// <summary>
    /// IsRunning(int i)
    /// Takes in a Process ID and returns true or false based on if that process id is still running on the system.
    /// </summary>
    public static bool IsRunning(int i)
    {
      try {
        Process.GetProcessById(i);
        return true;
      }
      catch { return false; }
    }

    /// <summary>
    /// GetProcessInstanceName(int pid)
    /// Takes in a Process ID and returns the instance name of that exact process. 
    /// IE chrome might have a instance name of chromeX7&% we can get that exact name with this method from the process id.
    /// The process name is returned as a string.
    /// </summary>
    private static string GetProcessInstanceName(int pid)
    {
      PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");

      string[] instances = cat.GetInstanceNames();
      foreach (string instance in instances) {
        try {
          using (PerformanceCounter cnt = new PerformanceCounter("Process",
               "ID Process", instance, true)) {
            int val = (int)cnt.RawValue;
            if (val == pid) {
              return instance;
            }
          }
        }
        catch { continue; }
      }
      throw new Exception("Could not find performance counter " +
          "instance name for current process. This is truly strange ...");
    }

    /// <summary>
    /// ClearPublicVariables()
    /// This runs when the Start Monitor button is clicked a one time.
    /// In between monitoring sessions we don't want to retain old data.
    /// We want to clear out the public variables back to what they were initialized as to no contaminate the monitor run.
    /// NOTE: Some of these have to be done in a particular order or it will throw a internal error.
    /// IE if you clear the chart before clearing the points. This will throw an error as there are no points assigned to the chart.
    /// </summary>
    public void ClearPublicVariables()
    {
      cpuList1 = new List<double>();
      cpuList2 = new List<double>();
      cpuList3 = new List<double>();
      cpuList1Time = new List<DateTime>();
      cpuList2Time = new List<DateTime>();
      cpuList3Time = new List<DateTime>();
      memoryList1 = new List<double>();
      memoryList2 = new List<double>();
      memoryList3 = new List<double>();
      memoryList1Time = new List<DateTime>();
      memoryList2Time = new List<DateTime>();
      memoryList3Time = new List<DateTime>();
      myCategoryList1 = new List<Process>();
      myCategoryList2 = new List<Process>();
      myCategoryList3 = new List<Process>();
      currentProcess1 = new Process();
      currentProcess2 = new Process();
      currentProcess3 = new Process();
      if (MemoryChart.Series[0].Name != "Process1") MemoryChart.Series[0].Name = "Process1";
      if (MemoryChart.Series[1].Name != "Process2") MemoryChart.Series[1].Name = "Process2";
      if (MemoryChart.Series[2].Name != "Process3") MemoryChart.Series[2].Name = "Process3";
      if (CPUChart.Series[0].Name != "Process1") CPUChart.Series[0].Name = "Process1";
      if (CPUChart.Series[1].Name != "Process2") CPUChart.Series[1].Name = "Process2";
      if (CPUChart.Series[2].Name != "Process3") CPUChart.Series[2].Name = "Process3";
      Name0 = string.Empty;
      Name1 = string.Empty;
      Name2 = string.Empty;
      Name3 = string.Empty;
      StartTime = DateTime.MinValue;
      StartTimeLabel.Text = "";
      SchedulerButton.Text = "Start Scheduler";
      run = 0;
      DateTimeTextBox.Enabled = true;
      if (mySchedulerTimer.Enabled == true) mySchedulerTimer.Enabled = false;
      StartTimeLabel.Text = "";
    }

    ///<summary> 
    ///if (StartButton.Text == "Start Monitoring" & runStarted == 0)
    ///If the text of the Start Monitoring button is Start Monitoring and this is the first click of the Start Monitoring button
    ///Add 1 to the flag
    ///Disable all dropdown controls so the user can't change them during monitoring.
    ///
    /// For each process make sure it is not the value we initialized it at. IE it got a new value from a process that is running on the system.
    /// Make sure that the name of the process is distinct or we will add a # to the end of the process name where the # is the process dropdown that was used.
    /// If the process is not what was initialized we will make the series visable to the user.
    /// Else we make the series not visable to the user.
    /// </summary>
    public void FormateForRun()
    {
      StartButton.Text = "Stop Monitoring";
      runStarted++;
      ProcessOneDropDown.Enabled = false;
      ProcessTwoDropDown.Enabled = false;
      ProcessThreeDropDown.Enabled = false;
      TotalcheckBox.Enabled = false;

      MemoryChart.Series[0].Points.Clear();
      MemoryChart.Series[1].Points.Clear();
      MemoryChart.Series[2].Points.Clear();

      CPUChart.Series[0].Points.Clear();
      CPUChart.Series[1].Points.Clear();
      CPUChart.Series[2].Points.Clear();

      TimmerBox.Enabled = false;

      if (Process1 != 0) {
        currentProcess1 = Process.GetProcessById(Process1);
        MemoryChart.Series[0].Name = Name1;
        MemoryChart.Series[0].IsVisibleInLegend = true;
        MemoryChart.Series[0].Enabled = true;

        CPUChart.Series[0].Name = Name1;
        CPUChart.Series[0].IsVisibleInLegend = true;
        CPUChart.Series[0].Enabled = true;
      }

      else {
        MemoryChart.Series[0].IsVisibleInLegend = false;
        MemoryChart.Series[0].Enabled = false;

        CPUChart.Series[0].IsVisibleInLegend = false;
        CPUChart.Series[0].Enabled = false;
      }

      if (Process2 != 0) {
        currentProcess2 = Process.GetProcessById(Process2);
        MemoryChart.Series[1].Name = Name2;
        MemoryChart.Series[1].IsVisibleInLegend = true;
        MemoryChart.Series[1].Enabled = true;

        CPUChart.Series[1].Name = Name2;
        CPUChart.Series[1].IsVisibleInLegend = true;
        CPUChart.Series[1].Enabled = true;
      }

      else {
        MemoryChart.Series[1].IsVisibleInLegend = false;
        MemoryChart.Series[1].Enabled = false;

        CPUChart.Series[1].IsVisibleInLegend = false;
        CPUChart.Series[1].Enabled = false;
      }

      if (TotalcheckBox.Checked) {
        currentProcess2 = Process.GetProcessById(Process2);
        MemoryChart.Series[1].Name = "Total Memory Used";
        MemoryChart.Series[1].IsVisibleInLegend = true;
        MemoryChart.Series[1].Enabled = true;

        CPUChart.Series[1].Name = "Total CPU% Used";
        CPUChart.Series[1].IsVisibleInLegend = true;
        CPUChart.Series[1].Enabled = true;
      }

      if (Process3 != 0) {
        currentProcess3 = Process.GetProcessById(Process3);
        MemoryChart.Series[2].Name = Name3;
        MemoryChart.Series[2].IsVisibleInLegend = true;
        MemoryChart.Series[2].Enabled = true;

        CPUChart.Series[2].Name = Name3;
        CPUChart.Series[2].IsVisibleInLegend = true;
        CPUChart.Series[2].Enabled = true;
      }

      else {
        MemoryChart.Series[2].IsVisibleInLegend = false;
        MemoryChart.Series[2].Enabled = false;

        CPUChart.Series[2].IsVisibleInLegend = false;
        CPUChart.Series[2].Enabled = false;
      }
    }

    /// <summary> 
    /// UpdateChart(ref System.Windows.Forms.DataVisualization.Charting.Chart myChart, ref List<double> List1, ref List<double> List2, ref List<double> List3, ref List<DateTime> Time1, ref List<DateTime> Time2, ref List<DateTime> Time3)
    /// Adds points to the input chart.
    /// ALSO ensures that the window size can handle adding new points. If the window is too small we add more range to the chart.
    /// </summary>
    public void UpdateChart(ref System.Windows.Forms.DataVisualization.Charting.Chart myChart, ref List<double> List1, ref List<double> List2, ref List<double> List3, ref List<DateTime> Time1, ref List<DateTime> Time2, ref List<DateTime> Time3)
    {
      int window = 0;
      try {
        myChart.Series[0].Points.AddXY(Time1.Last(), List1.Last());
        myChart.Series[1].Points.AddXY(Time2.Last(), List2.Last());
        myChart.Series[2].Points.AddXY(Time3.Last(), List3.Last());
      }
      catch { }
      if ((myChart.Series[0].Points.Count + 10) > window) window = myChart.Series[0].Points.Count + 10;
      if ((myChart.Series[1].Points.Count + 10) > window) window = myChart.Series[1].Points.Count + 10;
      if ((myChart.Series[2].Points.Count + 10) > window) window = myChart.Series[2].Points.Count + 10;
    }

    /// <summary>
    /// UpdateChartLegend(string myTime, ref System.Windows.Forms.DataVisualization.Charting.Chart myChart, ref List<double> List1, ref List<double> List2, ref List<double> List3, ref string Name1, ref string Name2, ref string Name3)
    /// Checks if the processes are running and not what we initialized.
    /// If true, Verify that the current legend name for the process isn't the same as what the other two process names are.
    /// If the legend names have duplicates we update the name by adding a # to the end of the process name where the # is the process number from the input. IE input 1 = 1 etc..
    /// If the legend names are distinct then we don't add a number to the end and just add the captions for the amount of memory used for that process
    /// </summary>
    public void UpdateChartLegend(string myTime, ref System.Windows.Forms.DataVisualization.Charting.Chart myChart, ref List<double> List1, ref List<double> List2, ref List<double> List3, ref string Name1, ref string Name2, ref string Name3, Boolean TRUE)
    {
      try {
        if (IsRunning(Process1) & Process1 != 0) {
          myChart.Series[0].Name = Name1 + "(" + List1.Last().ToString();
          if (!TRUE) myChart.Series[0].Name += "%)";
          else myChart.Series[0].Name += "Mbs)";
        }
      }
      catch { } //If we catch we don't update the legend. Something off happend and we will get it next time.

      try {
        if (IsRunning(Process2) & Process2 != 0) {
          myChart.Series[1].Name = Name2 + "(" + List2.Last().ToString();
          if (!TRUE) myChart.Series[1].Name += "%)";
          else myChart.Series[1].Name += "Mbs)";
        }
      }
      catch { } //If we catch we don't update the legend. Something off happend and we will get it next time.

      try {
        if (IsRunning(Process3) & Process3 != 0) {
          myChart.Series[2].Name = Name3 + "(" + List3.Last().ToString();
          if (!TRUE) myChart.Series[2].Name += "%)";
          else myChart.Series[2].Name += "Mbs)";
        }
      }
      catch { } //If we catch we don't update the legend. Something off happend and we will get it next time.

      myChart.Legends[0].Title = "Processes @ " + myTime; //Set the Title of the memory chart to Processes @ HH:MM:SS tt.
    }
    #endregion

    /// <summary>
    /// On Click
    /// Includes StartButton_Click(object sender, EventArgs e), ProcessOneDropDown_Click(object sender, EventArgs e),
    /// ProcessTwoDropDown_Click(object sender, EventArgs e), and ProcessThreeDropDown_Click(object sender, EventArgs e).
    /// 
    /// StartButton_Click has 3 main parts. On first click, On second click, On Finish of second click.
    /// For more information on StartButton_Click see summary at the method. It is very long.
    /// NOTE: StartButton_Click also contains the sections of code for the Memory and CPU Report forms.
    /// 
    /// ProcessOneDropDown_Click, ProcessTwoDropDown_Click, and ProcessThreeDropDown_Click Clear their perspective lists on click,
    /// Then grabs all of the process running on the machine (So we don't try to run for a process that no longer is running or maybe the process id has changed)
    /// Replaces the processes that are being used by the other drop downs with just text with no associated process id.
    /// </summary>
    #region On Click

    /// <summary>
    /// StartButton_Click(object sender, EventArgs e)
    /// Has 3 main If loops:
    /// 
    /// -1 if (StartButton.Text == "Stop Monitoring" & runStarted == 1) IE second click of the Start Monitoring button
    /// NOTE: -1 contains the report creating code for both Memory and CPU
    /// 
    /// -2 if (StartButton.Text == "Start Monitoring" & runStarted == 0) IE first click of Start Monitoring button
    /// NOTE: -2 contains the code to hide the series from the chart we are not using and starts the threads for the getMemoryUsageData() and getCPUUsageDate()
    /// 
    /// -3 if (StartButton.Text == "Start Monitoring" & runStarted == 2) IE After second click of the Start Monitoring button
    /// NOTE: -3 just clears out the flag that ensures we hit the correct if in StartButton_Click(object sender, EventArgs e)
    /// 
    /// For more details see each if statement below.
    /// </summary>
    private void StartButton_Click(object sender, EventArgs e)
    {

      ///<summary> 
      ///if (StartButton.Text == "Stop Monitoring" & runStarted == 1)
      ///If the text of the Start Monitoring button is Stop Monitoring and this is the second click of the Start Monitoring button
      ///Add 1 to the flag
      ///Enable all dropdown controls so the user can use them and click them.
      ///If the IncludeMemoryReportCheckBox and or IncludeCPUReportCheckBox is checked we will generate a window and place a summary in the frame for each check box that is checked.
      ///This summary contains the average overall, average per series, max per series, min per series. NOTE: everything is rounded to 3 decimals.
      ///When done with the reports or if we are not doing any reports we about the memory and cpu threads and clear all public variables to prep for the next monitoring session.
      /// </summary>
      if (StartButton.Text == "Stop Monitoring" & runStarted == 1) {
        StartButton.Text = "Start Monitoring";
        runStarted++;

        if (!TotalcheckBox.Checked) {
          ProcessOneDropDown.Enabled = true;
          ProcessTwoDropDown.Enabled = true;
          ProcessThreeDropDown.Enabled = true;
        }

        if (TotalcheckBox.Checked & myTimer.Enabled == true) myTimer.Stop();

        TimmerBox.Enabled = true;
        TotalcheckBox.Enabled = true;

        #region Build Report Data For Memory
        double OverallAverage = 0.00;
        int NonZeroProcesses = 0;
        double Process1Average = 0.00;
        double Process2Average = 0.00;
        double Process3Average = 0.00;
        double Process1Min;
        double Process2Min;
        double Process3Min;
        double Process1Max;
        double Process2Max;
        double Process3Max;
        string Summary1 = string.Empty;
        string Summary2 = string.Empty;
        string Summary3 = string.Empty;
        string FrameTitle = "Memory Summary";
        string GraphReportTitle = "The Memory Monitor Results are below:\r\n";
        string Content = string.Empty;

        if (IncludeMemoryReportCheckBox.Checked) {
          if (memoryList1.Average() > 0) {
            NonZeroProcesses++;
            OverallAverage += memoryList1.Average();
            Process1Average = Math.Round(memoryList1.Average(), 3);
            Process1Max = Math.Round(memoryList1.Max(), 3);
            Process1Min = Math.Round(memoryList1.Min(), 3);
            Summary1 = currentProcess1.ProcessName + ": Average = " + Process1Average.ToString() + ", Min = " + Process1Min.ToString() + ", Max  = " + Process1Max.ToString();
          }

          if (memoryList2.Average() > 0) {
            NonZeroProcesses++;
            OverallAverage += Math.Round(memoryList2.Average(), 3);
            Process2Average = Math.Round(memoryList2.Average(), 3);
            Process2Max = Math.Round(memoryList2.Max(), 3);
            Process2Min = Math.Round(memoryList2.Min(), 3);
            Summary2 = currentProcess2.ProcessName + ": Average = " + Process2Average.ToString() + ", Min = " + Process2Min.ToString() + ", Max  = " + Process2Max.ToString();
          }

          if (memoryList3.Average() > 0) {
            NonZeroProcesses++;
            OverallAverage += Math.Round(memoryList3.Average(), 3);
            Process3Average = Math.Round(memoryList3.Average(), 3);
            Process3Max = Math.Round(memoryList3.Max(), 3);
            Process3Min = Math.Round(memoryList3.Min(), 3);
            Summary3 = currentProcess3.ProcessName + ": Average = " + Process3Average.ToString() + ", Min = " + Process3Min.ToString() + ", Max  = " + Process3Max.ToString();
          }

          OverallAverage = Math.Round(((double)OverallAverage / (double)NonZeroProcesses), 3);
          Content = "The overall average for the processes was " + OverallAverage.ToString() + "\r\n" + Summary1 + "\r\n" + Summary2 + "\r\n" + Summary3;

          ReportFrame myMemoryReportFrame = new ReportFrame(FrameTitle, GraphReportTitle, Content, memoryList1, memoryList2, memoryList3, memoryList1Time, memoryList2Time, memoryList3Time);
          myMemoryReportFrame.Show();
        }
        #endregion

        #region Build Report Data For CPU

        OverallAverage = 0.00;
        NonZeroProcesses = 0;
        Process1Average = 0.00;
        Process2Average = 0.00;
        Process3Average = 0.00;
        Process1Min = 0.00;
        Process2Min = 0.00;
        Process3Min = 0.00;
        Process1Max = 0.00;
        Process2Max = 0.00;
        Process3Max = 0.00;
        Summary1 = string.Empty;
        Summary2 = string.Empty;
        Summary3 = string.Empty;
        FrameTitle = "CPU Summary";
        GraphReportTitle = "The CPU Monitor Results are below:\r\n";
        Content = string.Empty;

        if (IncludeCPUReportCheckBox.Checked) {
          if (memoryList1.Average() > 0) {
            NonZeroProcesses++;
            OverallAverage += Math.Round(cpuList1.Average(), 3);
            Process1Average = Math.Round(cpuList1.Average(), 3);
            Process1Max = Math.Round(cpuList1.Max(), 3);
            Process1Min = Math.Round(cpuList1.Min(), 3);
            Summary1 = currentProcess1.ProcessName + ": Average = " + Process1Average.ToString() + "%, Min = " + Process1Min.ToString() + "%, Max  = " + Process1Max.ToString() + "%";
          }

          if (memoryList2.Average() > 0) {
            NonZeroProcesses++;
            OverallAverage += Math.Round(cpuList2.Average(), 3);
            Process2Average = Math.Round(cpuList2.Average(), 3);
            Process2Max = Math.Round(cpuList2.Max(), 3);
            Process2Min = Math.Round(cpuList2.Min(), 3);
            Summary2 = currentProcess2.ProcessName + ": Average = " + Process2Average.ToString() + "%, Min = " + Process2Min.ToString() + "%, Max  = " + Process2Max.ToString() + "%";
          }

          if (memoryList3.Average() > 0) {
            NonZeroProcesses++;
            OverallAverage += Math.Round(cpuList3.Average(), 3);
            Process3Average = Math.Round(cpuList3.Average(), 3);
            Process3Max = Math.Round(cpuList3.Max(), 3);
            Process3Min = Math.Round(cpuList3.Min(), 3);
            Summary3 = currentProcess3.ProcessName + ": Average = " + Process3Average.ToString() + ", Min = " + Process3Min.ToString() + ", Max  = " + Process3Max.ToString();
          }

          OverallAverage = Math.Round(((double)OverallAverage / (double)NonZeroProcesses), 3);
          Content = "The overall average for the processes was " + OverallAverage.ToString() + "\r\n" + Summary1 + "\r\n" + Summary2 + "\r\n" + Summary3;

          ReportFrame myCPUReportFrame = new ReportFrame(FrameTitle, GraphReportTitle, Content, cpuList1, cpuList2, cpuList3, cpuList1Time, cpuList2Time, cpuList3Time);
          myCPUReportFrame.Show();
        }
        #endregion
      }

      //On first click of Start Monitoring
      if (StartButton.Text == "Start Monitoring" & runStarted == 0) {
        ClearPublicVariables();

        StartTime = DateTime.Now;
        StartTimeLabel.Text = "Monitor Started at " + DateTime.Now.ToShortTimeString();

        EndTime = StartTime.AddMinutes(Convert.ToInt32(TimmerBox.Text));

        Name0 = GetProcessInstanceName(0);
        Name1 = GetProcessInstanceName(Process1);
        Name2 = GetProcessInstanceName(Process2);
        Name3 = GetProcessInstanceName(Process3);

        if (Name1 == Name2 | Name1 == Name3) Name1 += "1";
        if (Name2 == Name1 | Name2 == Name3) Name2 += "2";
        if (Name3 == Name1 | Name3 == Name2) Name3 += "3";

        FormateForRun();

        if (Convert.ToInt32(TimmerBox.Text) > 0) {
          Task TimerTask = new Task(() => getTimeLeft());
          TimerTask.Start();
        }

        if (!TotalcheckBox.Checked) {
          Task memoryTask = new Task(() => getMemoryUsageData());
          memoryTask.Start();

          Task cpuTask = new Task(() => getCPUUsageDate());
          cpuTask.Start();
        }

        else {
          Task TotalTask = new Task(() => Total_Percentage());
          TotalTask.Start();
        }
      }

      /// <summary> 
      /// If (StartButton.Text == "Start Monitoring" & runStarted == 2)
      /// If the text of the Start Monitoring button is Start Monitoring and this is after the second button click
      /// Clear the flag that determines what if loop to go down.
      /// </summary>
      if (StartButton.Text == "Start Monitoring" & runStarted == 2) {
        runStarted = 0;
      }
    }

    /// <summary>
    /// Clears ProcessOneDropDown's combobox control of all items,
    /// Gets a new list of running processes from windows
    /// Replaces processes selected by the other dropdown control comboboxes with text that is no associated to a process id.
    /// Finally refreshes the form before exiting.
    /// </summary>
    private void ProcessOneDropDown_Click(object sender, EventArgs e)
    {
      try {
        //Clear the lists
        if (myCategoryList1.Capacity > 0) myCategoryList1.Clear();
        if (this.ProcessOneDropDown.Items.Count > 0) this.ProcessOneDropDown.Items.Clear();

        //Grab the list of currently running processes.
        myCategoryList1 = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList<Process>();

        //Add the list to the drowpdown
        for (int i = 0; i < myCategoryList1.Count; i++) {
          if (myCategoryList1[i].Id != Process2 & myCategoryList1[i].Id != Process3) this.ProcessOneDropDown.Items.Add(myCategoryList1[i].ProcessName);
          else this.ProcessOneDropDown.Items.Add("Used in another List1.");
        }
        this.Refresh();
      }
      catch (Exception ex) { MessageBox.Show(ex.ToString()); }
    }

    /// <summary>
    /// Clears ProcessTwoDropDown's combobox control of all items,
    /// Gets a new list of running processes from windows
    /// Replaces processes selected by the other dropdown control comboboxes with text that is no associated to a process id.
    /// Finally refreshes the form before exiting.
    /// </summary>
    private void ProcessTwoDropDown_Click(object sender, EventArgs e)
    {
      try {
        //Clear the lists
        if (myCategoryList2.Capacity > 0) myCategoryList2.Clear();
        if (this.ProcessTwoDropDown.Items.Count > 0) this.ProcessTwoDropDown.Items.Clear();

        //Grab the list of currently running processes.
        myCategoryList2 = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList<Process>();

        //Add the list to the drowpdown
        for (int i = 0; i < myCategoryList2.Count; i++) {
          if (myCategoryList2[i].Id != Process1 & myCategoryList2[i].Id != Process3) this.ProcessTwoDropDown.Items.Add(myCategoryList2[i].ProcessName);
          else this.ProcessTwoDropDown.Items.Add("Used in another List2.");
        }
        this.Refresh();
      }
      catch (Exception ex) { MessageBox.Show(ex.ToString()); }
    }

    /// <summary>
    /// Clears ProcessThreeDropDown's combobox control of all items,
    /// Gets a new list of running processes from windows
    /// Replaces processes selected by the other dropdown control comboboxes with text that is no associated to a process id.
    /// Finally refreshes the form before exiting.
    /// </summary>
    private void ProcessThreeDropDown_Click(object sender, EventArgs e)
    {
      try {
        //Clear the lists
        if (myCategoryList3.Capacity > 0) myCategoryList3.Clear();
        if (this.ProcessThreeDropDown.Items.Count > 0) this.ProcessThreeDropDown.Items.Clear();

        //Grab the list of currently running processes.
        myCategoryList3 = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList<Process>();

        //Add the list to the drowpdown
        for (int i = 0; i < myCategoryList3.Count; i++) {
          if (myCategoryList3[i].Id != Process1 & myCategoryList3[i].Id != Process2) this.ProcessThreeDropDown.Items.Add(myCategoryList3[i].ProcessName);
          else this.ProcessThreeDropDown.Items.Add("Used in another List3.");
        }
        this.Refresh();
      }
      catch (Exception ex) { MessageBox.Show(ex.ToString()); }
    }
    #endregion

    /// <summary>
    /// On Selected Index Changed
    /// Includeds the ProcessOneDropDown_SelectedIndexChanged(object sender, EventArgs e), ProcessTwoDropDown_SelectedIndexChanged(object sender, EventArgs e),
    /// and ProcessThreeDropDown_SelectedIndexChanged(object sender, EventArgs e).
    /// These methods update the process public variables to be in line with the newly selected process then 
    /// clear the points from the chart for a process if you have finished one monitoring session and change a process to something else that was
    /// already mapped to the chart.
    /// </summary>
    #region On Selected Index Changed
    private void ProcessOneDropDown_SelectedIndexChanged(object sender, EventArgs e)//Stores the id of the process so we know what we have to work on.
    {
      try {
        Process1 = myCategoryList1[ProcessOneDropDown.SelectedIndex].Id;
        MemoryChart.Series[0].Points.Clear();
        CPUChart.Series[0].Points.Clear();
      }
      catch (Exception ex) { MessageBox.Show(ex.ToString()); }
    }

    private void ProcessTwoDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
      try {
        Process2 = myCategoryList2[ProcessTwoDropDown.SelectedIndex].Id;
        MemoryChart.Series[1].Points.Clear();
        CPUChart.Series[1].Points.Clear();
      }
      catch (Exception ex) { MessageBox.Show(ex.ToString()); }
    }

    private void ProcessThreeDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
      try {
        Process3 = myCategoryList3[ProcessThreeDropDown.SelectedIndex].Id;
        MemoryChart.Series[2].Points.Clear();
        CPUChart.Series[2].Points.Clear();
      }
      catch (Exception ex) { MessageBox.Show(ex.ToString()); }
    }
    #endregion

    /// <summary>
    /// These are the Scheduler methods. These consist of the Scheduler Button click, Scheduler Timer and Click the start button methods.
    /// Scheduler button click modifies the controls and enables or disables the correct controls and starts the SchedulerTimer or Stops it at the correct user inputs.
    /// SchedulerTimer is just a standard timer that doesn't auto reset and when the timer elapses the timer clicks that StartButton on the frame.
    /// </summary>
    #region Scheduler
    private void SchedulerButton_Click(object sender, EventArgs e)
    {

      if (SchedulerButton.Text == "Scheduler Monitoring" & run == 1) {
        SchedulerButton.Text = "Start Scheduler";
        run++;

        if (!TotalcheckBox.Checked) {
          ProcessOneDropDown.Enabled = true;
          ProcessTwoDropDown.Enabled = true;
          ProcessThreeDropDown.Enabled = true;
        }

        TotalcheckBox.Enabled = true;
        TimmerBox.Enabled = true;
        DateTimeTextBox.Enabled = true;
      }

      if (SchedulerButton.Text == "Start Scheduler" & run == 0) {

        SchedulerButton.Text = "Scheduler Monitoring";
        run++;
        ProcessOneDropDown.Enabled = false;
        ProcessTwoDropDown.Enabled = false;
        ProcessThreeDropDown.Enabled = false;
        TotalcheckBox.Enabled = false;
        TimmerBox.Enabled = false;
        DateTimeTextBox.Enabled = false;
        StartTimeLabel.Text = "";

        try {
          TimeSpan myTimeToStart = Convert.ToDateTime(DateTimeTextBox.Text) - DateTime.Now;

          if (myTimeToStart.Ticks <= 0) throw new System.ArgumentException(" that is in the future.");

          Task mySchedulerTask = new Task(() => SchedulerTimer(myTimeToStart));
          mySchedulerTask.Start();
        }

        catch {
          MessageBox.Show("You did not enter a valid DateTime input, Please try again.");
          DateTimeTextBox.Text = DateTime.Now.ToString();
        }

      }

      if (SchedulerButton.Text == "Start Scheduler" & run == 2) {
        SchedulerButton.Text = "Start Scheduler";
        DateTimeTextBox.Enabled = true;
        run = 0;
        if (mySchedulerTimer.Enabled == true) mySchedulerTimer.Enabled = false;
      }
    }

    public void SchedulerTimer(TimeSpan myTimeSpan)
    {
      mySchedulerTimer = new System.Timers.Timer();
      mySchedulerTimer.AutoReset = false;
      mySchedulerTimer.Interval = myTimeSpan.TotalMilliseconds;
      mySchedulerTimer.Elapsed += new System.Timers.ElapsedEventHandler(ClickTheStartButton);
      mySchedulerTimer.Start();
    }

    public void ClickTheStartButton(object sender, ElapsedEventArgs A)
    {
      this.Invoke(new Action(() => { StartButton.PerformClick(); }));
    }
    #endregion
  }
}
