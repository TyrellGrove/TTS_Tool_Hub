using Microsoft.Win32;
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
  public partial class ButtonConfiguration : Form
  {
    public RegistryKey key;
    public Button Button;
    
    public ButtonConfiguration(Button myButton)
    {
      InitializeComponent();
      key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\TTSToolHub\" + myButton.Name.ToString());
      Button = myButton;
      try {
        ButtonTextBox.Text = key.GetValue("ButtonName").ToString();
      }
      catch { ButtonTextBox.Text = string.Empty; }

      try {
        DirectoryTextBox.Text = key.GetValue("Directory").ToString();
      }
      catch { DirectoryTextBox.Text = string.Empty; }
    }

    private void Edit31_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog myOpenDirectory = new FolderBrowserDialog();
      myOpenDirectory.Description = "TTS Directory Selector";
      if (myOpenDirectory.ShowDialog() == DialogResult.OK){
        DirectoryTextBox.Text = myOpenDirectory.SelectedPath;
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {

      this.Close();
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      if (ButtonTextBox.Text == string.Empty){
        MessageBox.Show("You must input a button lable to continue.");
      }

      if (DirectoryTextBox.Text == string.Empty){
        MessageBox.Show("You must input a directory to continue.");
      }

      if (!Directory.Exists(DirectoryTextBox.Text)){
        MessageBox.Show("Your input directory doesn't exist.");
      }

      if (Directory.Exists(DirectoryTextBox.Text) & ButtonTextBox.Text != string.Empty) {
        key.SetValue("ButtonName", ButtonTextBox.Text);
        key.SetValue("Directory", DirectoryTextBox.Text);
        Button.Text = key.GetValue("ButtonName").ToString();
        key.Close();
        this.Close();
      }
    }
  }
}
