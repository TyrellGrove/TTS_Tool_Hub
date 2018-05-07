using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Windows.Forms;


namespace TTS_Tool_Hub
{
  public partial class WebRequestResultsForm : Form
  {
    public string TestPasses;

    public static int CountStringInstances(string src, string lookingFor) {
      // Loop through all instances of the string 'src'.
      int count = 0;
      int i = 0;
      while ((i = src.IndexOf(lookingFor, i)) != -1) {
        i += lookingFor.Length;
        count++;
      }
      return count;
    }

    public string getRequest(string src) 
    {
      try {
        using (WebClient wb = new WebClient()) {
          string response = wb.DownloadString(src);
          return response;
        }
      }//End Try
      catch { return "The Get Request returned an error"; }
    }

    public string postRequest(string src, NameValueCollection Data)
    {
      try {
        using (WebClient wb = new WebClient()) {
          string response = System.Text.Encoding.UTF8.GetString(wb.UploadValues(src, "POST", Data));
          return response;
        }
      }//End Try
      catch { return "The Post Request returned an error"; }
    }
    
    public WebRequestResultsForm(string returnType, string src, NameValueCollection postData, string TestPassesIfContains)
    {
      InitializeComponent();
      string Result = "";
     
      if (postData.Count == 0) {//If Get request perform Get Request
        Result = getRequest(src);
        
      }
      
      else if (postData.Count != 0){//If Post request perform Post Request
        Result = postRequest(src, postData);
      }

      if (TestPassesIfContains != "") {//If the string we are looking for in the response isn't blank check web response for the string.
        if ((Result.IndexOf(TestPassesIfContains) > -1)) {
          int CountTestPassesIfContains = CountStringInstances(Result, TestPassesIfContains);
          TestPasses = "\r\n\tTest Result is: PASSED. The return contains the string '" + TestPassesIfContains + "' and was found " + CountTestPassesIfContains.ToString() + " times.\r\n";
        }
        else {
          TestPasses = "\r\n\tTest Result is: FAILED. The return doesn't contain the string '" + TestPassesIfContains + "'\r\n";
        }
      }

      if (returnType[0].ToString() == "y") {//is JSON

        ResultBox.Text = TestPasses + "\r\n\tURL:\r\n\r\n" + src + "\r\n\r\n\tOriginal Resonse:\r\n\r\n" + Result + "\r\n\r\n\tReadable Response Below:\r\n\r\n" + Result.Replace("\",\"", "\r\n").Replace("{", "").Replace("}", "").Replace("\"", "").Replace("],", "]\r\n\r\n");
      }

      else {//is XML
        ResultBox.Text = TestPasses + "\r\n\tURL:\r\n\r\n" + src + "\r\n\r\n\tOriginal Resonse:\r\n\r\n" + Result + "\r\n\r\n\tReadable Response Below:\r\n\r\n" + Result.Replace("></", "\n NO DATA \n").Replace("><", "\r\n").Replace("</", "\r\n").Replace(">", "\r\n").Replace("<", "");
      }

      CloseButton.Location = new Point(((this.Size.Width - CloseButton.Size.Width)/2), CloseButton.Location.Y); 
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
