using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace TTS_Tool_Hub
{
  public partial class EmulatorTool31Minus : Form
  {
    public int OldIDUsed;
    public Boolean Done;
    public int DaysDiff;
    public DateTime NowTime = DateTime.Now;
    public List<string> TimeColumns = new List<string> { "timestamp", "tsrequest", "tsreceipt", "tsrecord" };
    public static long milliPerDay = 86400000;

    public EmulatorTool31Minus()
    {
      InitializeComponent();
    }

    private void DoneButton_Click(object sender, EventArgs e)
    {
      Done = true;
      DoneButton.Enabled = false;
      RunButton.Enabled = true;
      TableTextBox1.Enabled = true;
      TableTextBox2.Enabled = true;
      SCNRTextBox.Enabled = true;
      SchemaComboBox1.Enabled = true;
      SchemaComboBox2.Enabled = true;
      ResultTextBox.Text = "Stopping...\r\n" + ResultTextBox.Text;
      ResultTextBox.Update();
    } //Stops the loop from running continuesly.

    private async void RunButton_Click(object sender, EventArgs e) //On click Calls doWork Method
    {
      if ((TableTextBox1.Text != string.Empty) & (TableTextBox2.Text != string.Empty)) {
        ResultTextBox.Text = "Started:";
        Done = false;
        OldIDUsed = 0;
        DaysDiff = 0;
        string OnClickQuery = "SELECT * FROM " + SchemaComboBox1.Text + "." + TableTextBox1.Text + " LIMIT 0,1";
        DoneButton.Enabled = true;
        RunButton.Enabled = false;
        TableTextBox1.Enabled = false;
        TableTextBox2.Enabled = false;
        SCNRTextBox.Enabled = false;
        SchemaComboBox1.Enabled = false;
        SchemaComboBox2.Enabled = false;

        #region GetDaysDiff
        try {
          MySqlConnection myConnection = new MySqlConnection((new MySqlConnectionStringBuilder { Server = "localhost", UserID = "apha", Password = "aphauser", Database = SchemaComboBox1.Text, Port = 3306 }).ToString());
          MySqlCommand myCommand = new MySqlCommand(OnClickQuery, myConnection);
          myConnection.Open();
          MySqlDataReader myReader = myCommand.ExecuteReader();

          while (myReader.Read()) {
            for (int i = 1; i < myReader.FieldCount; i++) {
              if (TimeColumns.Contains(myReader.GetName(i)) & (myReader[i] is long | myReader[i] is ulong)) {
                double dbTimeStamp = Convert.ToInt64(myReader[i].ToString());                                               //Gets the Database Column Value
                DateTime dbTimeStampDate = (new DateTime(1970, 1, 1)).AddMilliseconds(dbTimeStamp);                         //Turns Column Value into a DateTime
                DaysDiff = (NowTime - dbTimeStampDate).Days + 1;
                break;
              }
            }
          }
        }//End Try
        catch (Exception ex) { ResultTextBox.Text += ex; }
        #endregion

        while (!Done) {
          myQueryResult Return = new myQueryResult();
          Return.OldIDUsed = OldIDUsed;
          Return.DaysDifference = DaysDiff;
          await dbSync(Return);
        }//End While

        Task.Delay(1500).Wait();
        ResultTextBox.Text = "Done!!\r\n" + ResultTextBox.Text;
        ResultTextBox.Update();
      }

      else { ResultTextBox.Text = "You must have all Schema and Table fields filled in to proceed."; }
    }

    private async Task dbSync(myQueryResult Return)
    {
      long a = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);
      long b = (DaysDiff * milliPerDay);
      long c = a - b;

      //REAL!!
      if (SCNRTextBox.Text == "" | SCNRTextBox.Text == string.Empty) {
        if (TableTextBox1.Text[0] == 'h') {
          Return.query = "SELECT * FROM " + SchemaComboBox1.Text + "." + TableTextBox1.Text + " WHERE (tsrequest >= " + c.ToString() + " AND tsrequest <= " + (c + 2000).ToString() + ") ORDER BY tsrequest ASC limit 0, 1;";
        }

        else {
          Return.query = "SELECT * FROM " + SchemaComboBox1.Text + "." + TableTextBox1.Text + " WHERE (timestamp >= " + c.ToString() + " AND timestamp <= " + (c + 2000).ToString() + ") ORDER BY timestamp ASC limit 0, 1;";
        }
      }

      else {
        if (TableTextBox1.Text[0] == 'h') {
          Return.query = "SELECT * FROM " + SchemaComboBox1.Text + "." + TableTextBox1.Text + " WHERE (tsrequest >= " + c.ToString() + " AND tsrequest <= " + (c + 2000).ToString() + ") ORDER BY tsrequest ASC limit 0, 1;";
        }

        else {
          Return.query = "SELECT * FROM " + SchemaComboBox1.Text + "." + TableTextBox1.Text + " WHERE SCNR = " + SCNRTextBox.Text + " AND (timestamp >= " + c.ToString() + " AND timestamp <= " + (c + 2000).ToString() + ") ORDER BY timestamp ASC limit 0, 1;";
        }
      }

      //TEST!!
      //Return.query = "SELECT * FROM " + SchemaComboBox1.Text + "." + TableTextBox1.Text + " LIMIT 0,1";
      
      Return.builder1 = new MySqlConnectionStringBuilder { Server = "localhost", UserID = "apha", Password = "aphauser", Database = SchemaComboBox1.Text, Port = 3306 };
      
      try {
        //Is the connnection to the SQl Database on your local machine
        #region Connection
        MySqlConnection myConnection = new MySqlConnection(Return.builder1.ToString());
        MySqlCommand myCommand = new MySqlCommand(Return.query, myConnection);
        myConnection.Open();
        MySqlDataReader myReader = myCommand.ExecuteReader();
        #endregion 

        #region HandleNoRowsReturned
        if (!myReader.HasRows) {
          Return.Exception += "\r\nThere was no status between now and 2 seconds in the future of " + c.ToString();
          await Task.Delay(1000);
        }
        #endregion
        //Meat and potatoes of the program
        #region Loop
          while (myReader.Read())//Begin While2
          {
            Return.GetNumColumns = myReader.FieldCount;

            if (Convert.ToInt32(myReader[0].ToString()) != Return.OldIDUsed) {//If we have a new ID lets get the column values
              Return.NewIDUsed = Convert.ToInt32(myReader[0].ToString());
              for (int i = 1; i < Return.GetNumColumns; i++) {
                if (Return.TimeColumns.Contains(myReader.GetName(i)) & (myReader[i] is long | myReader[i] is ulong) & !(i == (Return.GetNumColumns - 1))) {        //Checks to see if the column is one that contains a Time Stamp in Unix Time Milliseconds and is not the last column
                  double dbTimeStamp = Convert.ToInt64(myReader[i].ToString());                                                                                    //Gets the Database Column Value
                  DateTime dbTimeStampDate = (new DateTime(1970, 1, 1)).AddMilliseconds(dbTimeStamp);                                                              //Turns Column Value into a DateTime
                  dbTimeStamp = ((dbTimeStampDate.AddDays(Return.DaysDifference)).Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;                           //Brings the DB TimeStamp to the current day
                  Return.QueryValues += "'" + (dbTimeStamp).ToString() + "', ";                                                                                    //Add values to the return
                  Return.ColumnNames += myReader.GetName(i).ToString() + ", ";
                }

                if (Return.TimeColumns.Contains(myReader.GetName(i)) & (myReader[i] is long | myReader[i] is ulong) & (i == (Return.GetNumColumns - 1))) {        //Checks to see if the column is one that contains a Time Stamp in Unix Time Milliseconds and is the last column
                  double dbTimeStamp = Convert.ToInt64(myReader[i].ToString());                                                                                   //Gets the Database Column Value
                  DateTime dbTimeStampDate = (new DateTime(1970, 1, 1)).AddMilliseconds(dbTimeStamp);                                                             //Turns Column Value into a DateTime
                  dbTimeStamp = ((dbTimeStampDate.AddDays(Return.DaysDifference)).Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;                          //Brings the DB TimeStamp to the current day
                  Return.QueryValues += "'" + (dbTimeStamp).ToString() + "'";                                                                                   //Add values to the return
                  Return.ColumnNames += myReader.GetName(i).ToString() + ", ";
                }

                if (myReader.IsDBNull(i) & !(i == (Return.GetNumColumns - 1))) {//If the column value is empty and not the last column
                  Return.QueryValues += "NULL, ";
                  Return.ColumnNames += myReader.GetName(i).ToString() + ", ";
                }

                if (myReader.IsDBNull(i) & (i == (Return.GetNumColumns - 1))) {//If the column value is empty and is the last column
                  Return.QueryValues += "NULL";
                  Return.ColumnNames += myReader.GetName(i).ToString() + "";
                }

                if (!myReader.IsDBNull(i) & (i == (Return.GetNumColumns - 1))) {//If the column value is not null and is the last column
                  Return.QueryValues += "'" + myReader[i].ToString() + "'";
                  Return.ColumnNames += myReader.GetName(i).ToString() + "";
                }

                if (!Return.TimeColumns.Contains(myReader.GetName(i).ToString()) & !myReader.IsDBNull(i) & !(i == (Return.GetNumColumns - 1))) {//IF this is not a time column and not null and not the last column
                  Return.QueryValues += "'" + myReader[i].ToString() + "', ";
                  Return.ColumnNames += myReader.GetName(i).ToString() + ", ";
                }

                if (Return.TimeColumns.Contains(myReader.GetName(i).ToString()) & !myReader.IsDBNull(i) & !(i == (Return.GetNumColumns - 1)) & myReader[i] is DateTime) {//If this is a time column and not null and not the last column and is a date time value
                  DateTime tempDate = Convert.ToDateTime(myReader[i].ToString());
                  tempDate = tempDate.AddDays(Return.DaysDifference);
                  string [] temp =  (tempDate.ToString()).Split(' ', '/');
                  Return.QueryValues += "'" + temp[2] + "-" + temp[0] + "-" + temp[1] + " " + temp[3] + "', ";
                  Return.ColumnNames += myReader.GetName(i).ToString() + ", ";
                }

                if (Return.TimeColumns.Contains(myReader.GetName(i).ToString()) & !myReader.IsDBNull(i) & (i == (Return.GetNumColumns - 1)) & myReader[i] is DateTime) {//If this is a time column and not null and is the last column and is a date time value
                  DateTime tempDate = Convert.ToDateTime(myReader[i].ToString());
                  tempDate = tempDate.AddDays(Return.DaysDifference);
                  string[] temp = (tempDate.ToString()).Split(' ', '/');
                  Return.QueryValues += "'" + temp[2] + "-" + temp[0] + "-" + temp[1] + " " + temp[3] + "'";
                  Return.ColumnNames += myReader.GetName(i).ToString() + "";
                }
              }//End For
              await Task.Delay(1000);
            }//End If

            else {
              Return.Exception += "row id:" + OldIDUsed.ToString() + " was returned.\r\n";
              Return.NewIDUsed = Return.OldIDUsed;
              await Task.Delay(1000);
            }
          }//End While2

        //Close the Conneciton
        myConnection.Close();
      }//End Try

      catch (Exception ex) {
        Return.Exception += ex.ToString();
      }
        #endregion 

      #region PostToWindow
      if (Return.Exception != string.Empty) {
        ResultTextBox.Text = Return.Exception + "\r\n" + ResultTextBox.Text;
        ResultTextBox.Update();
      }

      else {
        ResultTextBox.Text = "Get Sucess\r\nColumnNames: " + Return.ColumnNames + "\r\nQueryValues: " + Return.QueryValues + "\r\n" + ResultTextBox.Text;
        ResultTextBox.Update();
      }
      OldIDUsed = Return.NewIDUsed;
      #endregion

      #region PostToSQLDatabase
      if (Return.Exception == string.Empty)
      {
        Return.query = "INSERT INTO " + SchemaComboBox2.Text + "." + TableTextBox2.Text + " (" + Return.ColumnNames + ") VALUES (" + Return.QueryValues + ");";
        Return.builder2 = new MySqlConnectionStringBuilder { Server = "localhost", UserID = "apha", Password = "aphauser", Database = SchemaComboBox2.Text, Port = 3306 };

        try {
          MySqlConnection mySecondConnection = new MySqlConnection(Return.builder2.ToString());
          MySqlCommand mySecondCommand = new MySqlCommand(Return.query, mySecondConnection);
          mySecondConnection.Open();
          int worked = mySecondCommand.ExecuteNonQuery();

          if (worked == 1) {
            ResultTextBox.Text = "Post Success\r\n" + ResultTextBox.Text;
          }

          else {
            ResultTextBox.Text = "Post Failed\r\n" + ResultTextBox.Text;
          }
          mySecondConnection.Close();
        }
        catch (Exception exx){
          ResultTextBox.Text = exx + "\r\n" + ResultTextBox.Text;
          
        }
      }
      #endregion
      await Task.Delay(10);
    }

    public class myQueryResult
    {
      public string QueryValues = string.Empty;
      public string ColumnNames = string.Empty;
      public DateTime NowTime = DateTime.Now;
      public int NewIDUsed = 0;
      public int OldIDUsed = 0;
      public int GetNumColumns;
      public int PostNumColumns;
      public int DaysDifference;
      public long queryTimeStamp;
      public string Exception = string.Empty;
      public string Schema1;
      public string Table1;
      public string Schema2;
      public string Table2;
      public string SCNR = string.Empty;
      public List<string> TimeColumns = new List<string> { "timestamp", "tsrequest", "tsreceipt", "tsrecord" };
      public MySqlConnectionStringBuilder builder1;
      public MySqlConnectionStringBuilder builder2;
      public string query;
    }

  }//End Form
}//End Namespace
