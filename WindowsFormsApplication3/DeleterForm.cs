using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Windows.Forms;

namespace APhA_McCain_File_Deleter
{
  public partial class DeleterForm : Form
  {
    public List<string> myDirectorys = new List<string>();

    public DeleterForm()
    {
      InitializeComponent();

      try {
        myDirectorys = Registry_Writer();
        StatusDirectoryTextBox.Text = myDirectorys[0];
        TimingDirectoryTextBox.Text = myDirectorys[1];
      }

      catch (Exception e){
        MessageBox.Text = e.ToString() + "\r\n" + MessageBox.Text;
      }
    }

    public List<string> Registry_Writer()
    {
      List<string> myList = new List<string>();

      //accessing the CurrentUser root element  
      //and adding "OurSettings" subkey to the "SOFTWARE" subkey  
      
      RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\McCainDeleter");
      if (key.ValueCount != 0) {
        myList.Add(key.GetValue("StatusDirectory").ToString());
        myList.Add(key.GetValue("TimingDirectory").ToString());
      }

      if (key.ValueCount == 0) {
        //storing the values  
        key.SetValue("StatusDirectory", "Put your Status Directory Here.");
        key.SetValue("TimingDirectory", "Put your Timing Plan Directory Here.");
        key.Close();

        myList.Add("Put your Status Directory Here.");
        myList.Add("Put your Timing Plan Directory Here.");
      }
      return myList;
    }

    public void OnTimedEvent(object source, ElapsedEventArgs e)
    {
      //Try to delete the raw status data from yesterday
      #region Status
      try {
        int StatusCount = 0;
        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\McCainDeleter");
        string[] files = Directory.GetFiles(key.GetValue("StatusDirectory").ToString());

        foreach (string file in files) {
          FileInfo fi = new FileInfo(file);
          if (fi.LastAccessTime < DateTime.Today.AddDays(-1)) {
            fi.Delete();
            StatusCount++;
          }
        }
        //this.MessageBox.Text = "\r\n" + StatusCount.ToString() + " Statuses were Deleted.\r\n" + this.MessageBox.Text;
      }//end try

      catch (Exception exx) { }//this.MessageBox.Text = "\r\nProblem deleting the status data error message...\r\n" + exx.ToString() + "\r\n" + this.MessageBox.Text; } 
      #endregion

      //Try to delete the raw Timing Plans from yesterday
      #region TimingPlans
      try {
        int TimingCount = 0;
        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\McCainDeleter");
        string[] files = Directory.GetFiles(key.GetValue("TimingDirectory").ToString());

        foreach (string file in files) {
          FileInfo fi = new FileInfo(file);
          if (fi.LastAccessTime < DateTime.Today.AddDays(-1)) {
            fi.Delete();
            TimingCount++;
          }
        }
        //this.MessageBox.Text = "\r\n" + TimingCount.ToString() + " Timing Plans were Deleted.\r\n" + this.MessageBox.Text;

      }//end try

      catch (Exception exxx) { }//this.MessageBox.Text = "\r\nProblem deleting the Timing Plan Data data error message...\r\n" + exxx.ToString() + "\r\n" + this.MessageBox.Text; } //
      #endregion
    }

    private void StartButton_Click(object sender, EventArgs e)
    {
      
      try {
        if (StartButton.Text == "Start") {//If we are starting the McCain File Deleter Perform This.
          //Turn off controls and change button text.
          #region Controls
          StatusDirectoryTextBox.Enabled = false;
          TimingDirectoryTextBox.Enabled = false;
          StartButton.Text = "Stop";
          MessageBox.Clear();
          #endregion

          //Provide warnings!!
          #region Warnings
          int bStatusCount = 0;
          int bTimingCount = 0;
          string[] filesStatus = new string[0];
          string[] filesTiming = new string[0];
          RegistryKey keybefore = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\McCainDeleter");

          try {
            filesStatus = Directory.GetFiles(keybefore.GetValue("StatusDirectory").ToString());
          }

          catch {
            filesStatus = new string[0];
          }

          try {
            filesTiming = Directory.GetFiles(keybefore.GetValue("TimingDirectory").ToString());
          }

          catch {
            filesTiming = new string[0];
          }

          keybefore.Close();

          foreach (string file in filesStatus) {
            FileInfo fi = new FileInfo(file);
            if (fi.LastAccessTime < DateTime.Today.AddDays(-1))
            bStatusCount++;
          }

          foreach (string file in filesTiming) {
            FileInfo fi = new FileInfo(file);
            if (fi.LastAccessTime < DateTime.Today.AddDays(-1))
              bTimingCount++;
          }

          System.Windows.Forms.MessageBox.Show(
            "Your are about to start deleting from the following two directiries:\r\n-" 
            + StatusDirectoryTextBox.Text + "\r\nWhich will delete " + bStatusCount.ToString() + " files.\r\n-"
            + TimingDirectoryTextBox.Text + "\r\nWhich will delete " + bTimingCount.ToString() + " files.\r\nARE YOUR SURE YOU WISH TO CONTINUE?!?!");
          #endregion

          RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\McCainDeleter");
          if (key.ValueCount >= 2) {
            key.SetValue("StatusDirectory", StatusDirectoryTextBox.Text);
            key.SetValue("TimingDirectory", TimingDirectoryTextBox.Text);
            

            myDirectorys[0] = StatusDirectoryTextBox.Text;
            myDirectorys[1] = TimingDirectoryTextBox.Text;
          }

          if (key.ValueCount == 0 | key.ValueCount == 1){
            System.Windows.Forms.MessageBox.Show("One or both of your input directories are blank.\r\nYour must have both directories to continue.");
          }
          key.Close();
          MessageBox.Text = "Starting McCain File Deleter...\r\n" + MessageBox.Text;

          System.Timers.Timer myScheduler = new System.Timers.Timer();
          myScheduler.Elapsed += new ElapsedEventHandler(OnTimedEvent);
          myScheduler.Interval = 1000;
          myScheduler.Enabled = true;

          System.Threading.Thread.Sleep(2000);
          myScheduler.Interval = 21600000; //6 hours in milliseconds
          MessageBox.Text = "Timing Intervol updated to 6 hours.\r\n" + MessageBox.Text;
          while (StartButton.Text != "Stop") ;
        }

        else {//If we are stopping the McCain File Deleter Perform This.
          //Turn on controls and change button text back.
          StatusDirectoryTextBox.Enabled = true;
          TimingDirectoryTextBox.Enabled = true;
          StartButton.Text = "Start";
          MessageBox.Text = "Stopping McCain File Deleter...\r\n" + MessageBox.Text;
        }
      }//end try

      catch (Exception ex) {
        MessageBox.Text = "\r\nThere was a problem with the start button operations that was caught.\r\n" + ex.ToString() + "\r\n" + MessageBox.Text;
        StatusDirectoryTextBox.Enabled = true;
        TimingDirectoryTextBox.Enabled = true;
        StartButton.Text = "Start";
      }
    }
   }//end Registry_Writer()
 }

