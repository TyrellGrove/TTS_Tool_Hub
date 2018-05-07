using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TTS_Tool_Hub
{
  public partial class GraphResourcesFrame : Form
  {
    public string[] myFile;
    public List<double> myX1;
    public List<double> myX2;
    public List<double> myX3;
    public List<DateTime> myY1;
    public List<DateTime> myY2;
    public List<DateTime> myY3;

    public GraphResourcesFrame()
    {
      InitializeComponent();
    }

    private void CPULoadButton_Click(object sender, EventArgs e)
    {
      if (Directory.Exists(MemoryTextBox.Text) || File.Exists(MemoryTextBox.Text)) myFile = File.ReadAllLines(FilePath.Text);

      if (myFile.Length > 0) {
        List<string> myList = myFile.ToList<string>();
        myList.RemoveAt(0);
        foreach (string line in myList) { 
          string[] hold = line.Split(',');
          myX1.Add(Convert.ToDouble(hold[0]));
          myX2.Add(Convert.ToDouble(hold[2]));
          myX3.Add(Convert.ToDouble(hold[4]));
          myY1.Add(Convert.ToDateTime(hold[1]));
          myY2.Add(Convert.ToDateTime(hold[3]));
          myY3.Add(Convert.ToDateTime(hold[5]));
        }

        mapper(myX1, myY1, CPUChart.Series[0]);
        mapper(myX2, myY2, CPUChart.Series[1]);
        mapper(myX3, myY3, CPUChart.Series[2]);

        ClearPublicVariables();
      }
    }

    private void MemoryLoadButton_Click(object sender, EventArgs e)
    {
      if (Directory.Exists(MemoryTextBox.Text) || File.Exists(MemoryTextBox.Text)) myFile = File.ReadAllLines(MemoryTextBox.Text);

      if (myFile.Length > 0) {
        List<string> myList = myFile.ToList<string>();
        myList.RemoveAt(0);
        foreach (string line in myList) {
          string[] hold = line.Split(',');
          myX1.Add(Convert.ToDouble(hold[0]));
          myX2.Add(Convert.ToDouble(hold[2]));
          myX3.Add(Convert.ToDouble(hold[4]));
          myY1.Add(Convert.ToDateTime(hold[1]));
          myY2.Add(Convert.ToDateTime(hold[3]));
          myY3.Add(Convert.ToDateTime(hold[5]));
        }

        mapper(myX1, myY1, MemoryChart.Series[0]);
        mapper(myX2, myY2, MemoryChart.Series[1]);
        mapper(myX3, myY3, MemoryChart.Series[2]);

        ClearPublicVariables();
      }
    }

    private void mapper(List<double> myDouble, List<DateTime> myTime, System.Windows.Forms.DataVisualization.Charting.Series Series)
    {
      int Size = myDouble.Count;
      if (Size < myTime.Count) Size = myTime.Count;

      for (int i = 0; i < Size; i++) {
        if (myDouble.Count < i) myDouble.Add(0.00);

        if (Size < myTime.Count) myTime.Add(DateTime.Now);

        if (myDouble.Count == myTime.Count) Series.Points.AddXY(myTime[i], myDouble[i]);
      }
    }

    public void ClearPublicVariables()
    {
      for (int i = 0; i < myFile.Length; i++) myFile[i] = string.Empty;
      myX1.Clear();
      myX2.Clear();
      myX3.Clear();
      myY1.Clear();
      myY2.Clear();
      myY3.Clear();
    }

  }
}
