using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication3
{
  public partial class FrameToolHub : Form
  {
    public FrameToolHub()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void APhA32_Load(object sender, EventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void APhA32_Click(object sender, EventArgs e)
    {
      String[] Files = {@"D:\Projects\APhA\3.2\1 (Available)\bin\x86\debug\APhA_HubMonitor.exe", @"D:\Projects\APhA\3.2\1 (Available)\bin\x86\debug\APhA_HostMonitor.exe", @"D:\Projects\APhA\3.2\1 (Available)\bin\x86\debug\APhA_StaticTest.exe", @"D:\Projects\APhA\3.2\1 (Available)\bin\x86\debug\APhA_SatelliteMonitor.exe"};
      System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();

      foreach (string s in Files){
      start.FileName = s;
      Process.Start(start);
      }
    }

    private void APhA31_Click(object sender, EventArgs e)
    {
      String[] Files = {@"D:\Projects\APhA\3.1\1 (Available)\bin\x86\debug\APhA_HubMonitor.exe", @"D:\Projects\APhA\3.1\1 (Available)\bin\x86\debug\APhA_HostMonitor.exe", @"D:\Projects\APhA\3.1\1 (Available)\bin\x86\debug\APhA_StaticTest.exe", @"D:\Projects\APhA\3.1\1 (Available)\bin\x86\debug\APhA_SatelliteMonitor.exe"};
      System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();

      foreach (string s in Files) {
        start.FileName = s;
        Process.Start(start);
      }
    }

    private void APhATrunk_Click(object sender, EventArgs e)
    {
      String[] Files = { @"D:\Projects\APhA\Trunk\1 (Available)\bin\x86\debug\APhA_HubMonitor.exe", @"D:\Projects\APhA\Trunk\1 (Available)\bin\x86\debug\APhA_HostMonitor.exe", @"D:\Projects\APhA\Trunk\1 (Available)\bin\x86\debug\APhA_StaticTest.exe", @"D:\Projects\APhA\Trunk\1 (Available)\bin\x86\debug\APhA_SatelliteMonitor.exe" };
      System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();

      foreach (string s in Files) {
        start.FileName = s;
        Process.Start(start);
      }
    }

    private void APhA10_Click(object sender, EventArgs e)
    {
      String[] Files = { @"D:\Projects\APhA\1.0\1 (Available)\bin\x86\debug\APhA_HubMonitor.exe", @"D:\Projects\APhA\1.0\1 (Available)\bin\x86\debug\APhA_HostMonitor.exe", @"D:\Projects\APhA\1.0\1 (Available)\bin\x86\debug\APhA_StaticTest.exe" };
      System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();

      foreach (string s in Files) {
        start.FileName = s;
        Process.Start(start);
      }
    }
  }
}
