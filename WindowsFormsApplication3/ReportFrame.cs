using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_MemoryChart
{
  public partial class ReportFrame : Form
  {
    public List<double> RmemoryList1 = new List<double>();
    public List<double> RmemoryList2 = new List<double>();
    public List<double> RmemoryList3 = new List<double>();
    public List<DateTime> RmemoryList1Time = new List<DateTime>();
    public List<DateTime> RmemoryList2Time = new List<DateTime>();
    public List<DateTime> RmemoryList3Time = new List<DateTime>();
    public string temp = string.Empty;
    public string units = string.Empty;
    public string fileName = string.Empty;

    public ReportFrame(string FrameTitle, string GraphReportTitle, string Content, List<double> memoryList1, List<double> memoryList2, List<double> memoryList3, List<DateTime> memoryList1Time, List<DateTime> memoryList2Time, List<DateTime> memoryList3Time )
    {
      InitializeComponent();
      this.Text = FrameTitle;
      this.textBox1.Text = GraphReportTitle + "\r\n" + Content;

      RmemoryList1 = memoryList1;
      RmemoryList2 = memoryList2;
      RmemoryList3 = memoryList3;
      RmemoryList1Time = memoryList1Time;
      RmemoryList2Time = memoryList2Time;
      RmemoryList3Time = memoryList3Time;

      if (this.Text == "Memory Summary") { units = "Mbs"; fileName = "MemoryMonitorOutput"; }
      else { units = "%"; fileName = "CPUMonitorOutput"; }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ExportButton_Click(object sender, EventArgs e)
    {
      List<string> myOutput = new List<string>();
      string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName + DateTime.Now.ToString("hhmmss") + ".csv";

      int Count1 = RmemoryList1.Count;
      int Count2 = RmemoryList2.Count;
      int Count3 = RmemoryList3.Count;

      int Biggest = Count1;
      if (Biggest < Count2) Biggest = Count2;
      if (Biggest < Count3) Biggest = Count3;

      myOutput.Add("Process1 TimeStamp, Process1 " + units + " , Process2 TimeStamp, Process2 " + units + " , Process3 TimeStamp, Process3 " + units);

      for (int i = 0; i < Biggest; i++) {
        if (i >= Count1) temp += DateTime.Now.ToString("hh:mm:ss") + ", 0.00, ";
        else temp += RmemoryList1Time[i].ToString() + ", " + RmemoryList1[i].ToString() + ", ";

        if (i >= Count2) temp += DateTime.Now.ToString("hh:mm:ss") + ", 0.00, ";
        else temp += RmemoryList2Time[i].ToString() + ", " + RmemoryList2[i].ToString() + ", ";

        if (i >= Count3) temp += DateTime.Now.ToString("hh:mm:ss") + ", 0.00";
        else temp += RmemoryList3Time[i].ToString() + ", " + RmemoryList3[i].ToString();

        myOutput.Add(temp);
        temp = string.Empty;
      }

      System.IO.File.WriteAllLines(@path, myOutput.ToArray());

    }
  }
}
